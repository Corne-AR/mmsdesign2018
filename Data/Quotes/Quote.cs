using AMS.Data.Keys;
using AMS.Data.People;
using Data.Catalogs;
using Data.People;
using Data.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Quotes
{
    [Serializable]
    public partial class Quote : AMS.Data.DataClass
    {
        public string Account { get; set; }
        public string Currency { get; set; }
        public string PaymentTerms { get; set; }

        public DateTime QuoteDate { get; set; }
        public DateTime ExpiryDate { get; set; }

        public string Contact { get; set; }
        public string Email { get; set; }

        public bool UseMaintence { get; set; }
        public int ExtendMonths { get; set; }
        public DateTime ExtendDate { get; set; }
        public Data.People.MaintenanceType MaintenanceType { get { return Client.GetMaintenanceType(); } }

        public decimal AbsaFx { get; set; }
        public decimal ExportFx { get; set; }

        public bool IsMailed
        {
            get { return (Metadata.EmailDate != null && Metadata.EmailDate > new DateTime(1900, 1, 1)); }
        }

        // TODO: Remove after data was updated, since it was replaced with ProgressType
        public bool Finalized { get; set; }

        /// <summary>
        /// USE AS READONLY
        /// </summary>
        public ProgressType ProgressType { get; set; }
        public bool Itemized { get; set; }
        public decimal Discount { get; set; }
        public decimal AddtoCost { get; set; }
        public bool International { get; set; }
        public bool UseClient { get; set; }

        public HashSet<string> LinkedIDList { get; set; }
        public string GetLinkedIDList
        {
            get
            {
                string list = "";

                var sortedList = (from i in LinkedIDList
                                  orderby i ascending
                                  select i).ToList();

                foreach (var i in sortedList)
                    list += i + " - ";

                if (list != "") list = list.Substring(0, list.Length - 3);

                return list;
            }
        }

        public Data.People.Client QuoteClient;
        public Data.People.Client Client
        {
            get
            {
                if (QuoteClient == null) QuoteClient = DMS.ClientManager.GetData(i => i.Account == Account);
                return QuoteClient;
            }
        }

        public int SpacerTotals { get; set; }
        public int SpacerTerms { get; set; }

        public Quote()
        {
            LinkedIDList = new HashSet<string>();
            QuoteClient = (Data.People.Client)DMS.ClientManager.CurrentData.Clone();
            International = QuoteClient.IsInternational;
            UseMaintence = false;
            UseClient = true;

            if (ProgressType == Quotes.ProgressType.New &&
                QuoteDate < new DateTime(2000, 1, 1)) QuoteDate = DateTime.Now;

            PaymentTerms = "COD";

            var currency = (from i in AMS.Suite.SuiteManager.Profile.ForexList
                            where i == QuoteClient.CurrencyUsed
                            select i).FirstOrDefault();

            if (currency == null) QuoteClient.CurrencyUsed = AMS.Suite.SuiteManager.Profile.ForexList[0];
            Currency = QuoteClient.CurrencyUsed;
        }

        // Transaction
        [field: NonSerialized]
        private Transaction transaction;
        public Transaction Transaction
        {
            get
            {
                try
                {
                    Calculate();
                    transaction.ID = this.ID;
                    transaction.DatalogList = this.DatalogList;
                }
                catch (Exception ex)
                {
                    AMS.MessageBox_v2.Show("There was a problem converting the quote to a transaction.\r\n\r\n" + ex.Message, AMS.MessageType.Error);
                }

                return transaction;
            }
        }

        // Catalog

        private decimal totalValue = 0;
        private decimal totalCODValue = 0;
        private decimal totalMaintenanceValue = 0;
        private decimal totalCODMaintenanceValue = 0;

        public decimal CustomCOD { get; set; }
        public decimal Total { get { if (GeoLocation() == Data.People.GeoLocation.International) return SubTotal; return Math.Round((totalValue + totalMaintenanceValue) * VATFactor(), 2); } }
        public decimal CODTotal
        {
            get
            {
                if (CustomCOD > 0) return CustomCOD;
                if (GeoLocation() != Data.People.GeoLocation.Local) return SubTotal;
                return Math.Round((totalCODValue + totalCODMaintenanceValue) * VATFactor(), 2);
            }
        }

        //public decimal SubTotal { get { return Math.Round(Transaction.SubTotal, 2); } }
        public decimal SubTotal { get { return Transaction.SubTotal; } }
        public decimal VATTotal
        {
            get
            {
                if (GeoLocation() == Data.People.GeoLocation.International) return 0;
                if (PaymentTerms == "COD") return Math.Round(CODTotal - SubTotal, 2);
                return Math.Round(Total - SubTotal, 2);
            }
        }

        // Comes from the quote with no altered data
        private List<Catalog> quoteCatalogList = new List<Catalog>();
        public List<Catalog> QuoteCatalogList { get { return quoteCatalogList; } }

        // Based on the calculations
        private List<Catalog> caluclatedCatalogList = new List<Catalog>();
        public List<Catalog> CaluclatedCatalogList { get { return caluclatedCatalogList; } }


        public bool HasSLOption()
        {
            if (CaluclatedCatalogList == null) return false;
            return CaluclatedCatalogList.Where(i => i.HasSLKeyOption).FirstOrDefault() != null;
        }

        public void AddToCatalog(Catalog cata)
        {
            quoteCatalogList.Add(cata);
        }

        public void SetQuoteList(List<Catalogs.Catalog> newList)
        {
            quoteCatalogList = newList;
        }

        /// <summary>
        /// Calculates Each Catalog's Value and Maintenance in the List
        /// </summary>
        public void Calculate()
        {
            if (transaction != null && ProgressType != Quotes.ProgressType.New) return;

            // 1. Reset numbers
            // 2. Calculate catalogs
            // 3. Create virtual transaction

            totalValue = 0;
            totalMaintenanceValue = 0;
            totalCODValue = 0;
            totalCODMaintenanceValue = 0;
            transaction = null;

            try
            {
                #region Set Forex 1st

                // Get default currency if needed, else use saved currency
                if (string.IsNullOrEmpty(Currency) && AMS.Suite.SuiteManager.Profile.ForexList.Count > 0)
                    Currency = AMS.Suite.SuiteManager.Profile.ForexList[0].ToString();

                // Make sure all items have same currency as the catalog
                foreach (var c in QuoteCatalogList)
                {
                    var defaultForex = (from i in c.ForexList
                                        where i.Name == Currency
                                        select i).FirstOrDefault();

                    c.SelectedForex = defaultForex;

                    foreach (var i in c.ItemList)
                    {
                        i.Forex = defaultForex;
                    }
                }

                #endregion

                Data.Calculations.QuoteCalculator quoteCalculator = new Data.Calculations.QuoteCalculator(this);

                this.caluclatedCatalogList = quoteCalculator.CatalogList;

                this.totalValue = quoteCalculator.TotalValue;
                this.totalCODValue = quoteCalculator.TotalCODValue;

                if (UseMaintence && ExtendMonths == 0) totalMaintenanceValue = quoteCalculator.TotalMaintenanceValue;
                if (UseMaintence && ExtendMonths == 0) totalCODMaintenanceValue = quoteCalculator.TotalCODMaintenanceValue;

                if (UseMaintence && ExtendMonths > 0) totalMaintenanceValue = quoteCalculator.TotalMaintenanceValue / 12 * ExtendMonths;
                if (UseMaintence && ExtendMonths > 0) totalCODMaintenanceValue = quoteCalculator.TotalCODMaintenanceValue / 12 * ExtendMonths;
            }
            catch (Exception ex) { AMS.MessageBox_v2.Show("Was unable to calculate the catalog list's values\r\n\r\n" + ex.Message + "\r\n" + ex.InnerException, AMS.MessageType.Error); }

            // Set transaction

            try
            {
                transaction = GetTransaction(this);
            }
            catch { }
        }

        public void ResetCalcuation()
        {
            caluclatedCatalogList = new List<Catalog>();
            Calculate();
        }

        public decimal VATFactor()
        {
            if (!AMS.Suite.SuiteManager.Profile.VatRegisterd) return 1m;

            decimal addVat = 1m;

            var geolocation = GeoLocation();

            if ((geolocation == Data.People.GeoLocation.Local || geolocation == Data.People.GeoLocation.International) &&
                geolocation != Data.People.GeoLocation.Neighbour)
            {
                addVat = 1.14m;
            }

            return addVat;
        }

        public bool Save(string Message, bool OverWrite, bool UseLog, Quotes.ProgressType ProgressType)
        {
            if (ID == null || ID.Count() < 3)
                ID = UserPKManager.NewUserPK(KeyType.Quote);

            if (QuoteClient == null || QuoteClient.Name == null || Metadata.Modified != DateTime.Now) QuoteClient = DMS.ClientManager.GetData(i => i.Account == Account);

            SetFile(ID + " - " + QuoteClient.Name, AMS.Settings.Program.Directories.Clients + Account + "\\Quotes", AMS.Data.DataType.Quote);

            LinkedIDList.Add(ID);
            if (UseLog) AddDataLog(ID, Message, AMS.Data.DataType.Quote);

            if (this.ProgressType == Quotes.ProgressType.New && ProgressType == Quotes.ProgressType.New) QuoteDate = DateTime.Now;
            this.ProgressType = ProgressType;

            UpdateCatalog();
            Calculate();

            bool saved = DMS.QuoteManager.Save(this, Message, OverWrite, true);

            UserPKManager.UpdatePk(KeyType.Quote, ID);

            return saved;
        }

        private void UpdateCatalog()
        {
            foreach (var cat in quoteCatalogList)
                cat.SaveQuotedCatalog();
        }

        public Data.People.GeoLocation GeoLocation()
        {
            var geoLocation = Data.People.GeoLocation.Unknown;

            string currency = AMS.Suite.SuiteManager.Profile.ForexList[0].ToString();

            if (!Client.IsInternational && Currency == currency) geoLocation = Data.People.GeoLocation.Local;
            if (Client.IsInternational && Currency != currency) geoLocation = Data.People.GeoLocation.International;
            if (Client.IsInternational && Currency == currency) geoLocation = Data.People.GeoLocation.Neighbour;

            return geoLocation;
        }

        public string DuplicateQuote()
        {
            if (AMS.MessageBox_v2.Show("Would you like to create a new quote from this one?", AMS.MessageType.Question) == AMS.MessageOut.YesOk)
            {
                var newQuote = (Quote)this.Clone();
                newQuote.ID = null;
                newQuote.transaction = new Transactions.Transaction();
                newQuote.LinkedIDList = new HashSet<string>();
                newQuote.Metadata = new AMS.Data.Metadata();

                newQuote.Save("Quote copied from " + this.ID, false, true, Quotes.ProgressType.New);

                return newQuote.ID;
            }
            else return null;
        }
    }
}