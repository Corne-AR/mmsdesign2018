using AMS.Data;
using AMS.Data.Keys;
using AMS.Data.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Data.People
{
    [Serializable]
    public class Client : DataClass
    {
        public string Account { get; set; }// PK
        public string Name { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Fax { get; set; }
        public string PhysicalAddress { get; set; }
        public string PostalAddress { get; set; }
        public string Country { get; set; }
        public bool IsInternational { get; set; }
        public bool Active { get; set; }
        public string VendorNr { get; set; }
        public bool VendorRenewal { get; set; }
        public string VatNr { get; set; }
        public DateTime Expirydate { get; set; }
        public string Keywords { get; set; }
        public string Catagory { get; set; }
        public string CurrencyUsed { get; set; }
        public bool LanguageAfr { get; set; }

        public bool IsVatClient { get => CurrencyUsed == "ZAR" && !IsInternational; }

        [XmlIgnore]
        public decimal Credit
        {
            get
            {
                //decimal credit = 0m;
                //var transactions = DMS.TransactionManager.GetDataList(i =>
                //    i.Account == this.Account &&
                //    i.Type == Transactions.TransactionType.Invoice &&
                //    i.TotalDue != 0);

                //foreach (var trans in transactions)
                //{
                //    credit += trans.TotalDue;
                //}

                //var receipts = (from i in Data.DMS.AccountsManager.ReceiptList
                //                where i.Account == Account
                //                where i.AmountRemaining != 0
                //                select i).ToList();

                //credit -= receipts.Sum(i => i.AmountRemaining);

                //return credit;

                return GetCredit(0);
            }
        }

        public decimal GetCredit(int AddDays)
        {
            decimal credit = 0m;
            var transactions = DMS.TransactionManager.GetDataList(i =>
                i.Account == this.Account &&
                i.Type == Transactions.TransactionType.Invoice &&
                i.TotalDue != 0 &&
                i.TransactionDate < DateTime.Now.AddDays(AddDays));

            foreach (var trans in transactions)
            {
                credit += trans.TotalDue;
            }

            var receipts = (from i in Data.DMS.AccountsManager.ReceiptList
                            where i.Account == Account
                            where i.AmountRemaining != 0
                            where i.ReceiptDate < DateTime.Now.AddDays(AddDays)
                            select i).ToList();

            credit -= receipts.Sum(i => i.AmountRemaining);

            return credit;
        }

        private decimal bulkDiscount;
        /// <summary>
        /// Returns the bulk discount calculated at Maintenance Value
        /// </summary>
        public decimal BulkDiscount { get { return bulkDiscount; } }

        public HashSet<string> PeopleIDList { get; set; }

        [XmlIgnore]
        public List<Person> GetPeople { get { return Data.DMS.PeopleManager.GetDataList(i => PeopleIDList.Contains(i.ID)); } }

        public string MainPersonID { get; set; }
        [XmlIgnore]
        public Person GetMainContact
        {
            get
            {
                var person = DMS.PeopleManager.GetData(i => i.ID == MainPersonID);
                if (person == null && PeopleIDList != null && PeopleIDList.Count > 0) person = DMS.PeopleManager.GetData(i => i.ID == PeopleIDList.ToList()[0]);
                if (person == null) person = new Person();
                return person;
            }
        }

        [XmlIgnore]
        public List<Transactions.Transaction> GetInvoices { get { return DMS.TransactionManager.GetDataList(i => i.Account == Account && i.Type == Transactions.TransactionType.Invoice); } }

        [XmlIgnore]
        public List<Transactions.Transaction> GetQuotes { get { return DMS.TransactionManager.GetDataList(i => i.Account == Account && i.Type == Transactions.TransactionType.Quote); } }

        [XmlIgnore]
        public List<Transactions.Transaction> GetTransactions { get { return DMS.TransactionManager.GetDataList(i => i.Account == Account); } }

        [XmlIgnore]
        public decimal GetInvoiceTotals
        {
            get { return GetInvoices.Sum(i => i.Total); }
        }

        [XmlIgnore]
        public HashSet<Accounts.Receipt> GetReceipts { get { return new HashSet<Accounts.Receipt>(DMS.AccountsManager.ReceiptList.Where(i => i.Account == Account).ToList()); } }

        public string AccountantID { get; set; }

        [XmlIgnore]
        public Person GetAccountant
        {
            get
            {
                var person = DMS.PeopleManager.GetData(i => i.ID == AccountantID);
                if (person == null) person = new Person();
                return person;
            }
        }

        public string PurchaseOrderContactID { get; set; }

        [XmlIgnore]
        public Person GetPurchaseOrderContact
        {
            get
            {
                var person = DMS.PeopleManager.GetData(i => i.ID == PurchaseOrderContactID);
                if (person == null) person = new Person();
                return person;
            }
        }

        [XmlIgnore]
        public List<Products.Product> GetProducts
        {
            get { return DMS.ProductManager?.GetDataList(i => i.Account == Account); }
        }

        public string TransactionNotes { get; set; }

        [XmlIgnore]
        public string GetSummary
        {
            get
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendLine(("Client Name:   " + Name).Trim());
                sb.AppendLine(("Email:   " + Email).Trim());
                sb.AppendLine(("Telephone:   " + Telephone).Trim());
                sb.AppendLine(("Fax:   " + Telephone).Trim());
                sb.AppendLine();
                sb.AppendLine(("Contact:   " + GetMainContact.DisplayName).Trim());
                sb.AppendLine(("Contact Email:   " + GetMainContact.Email).Trim());
                sb.AppendLine(("Contact Telephone:   " + GetMainContact.ContactNumber).Trim());
                sb.AppendLine();
                sb.AppendLine(("Postal:   " + PostalAddress).Trim());
                sb.AppendLine();
                sb.AppendLine(("Physical: " + PhysicalAddress).Trim());
                sb.AppendLine();
                sb.AppendLine(("Vat:   " + VatNr).Trim());
                sb.AppendLine(("Afrikaans:   " + LanguageAfr).Trim());

                return ("" + sb.ToString()).Trim();
            }
        }

        [XmlIgnore]
        public string GetShortSummary
        {
            get
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendLine(("Klient Naam:   " + Name).Trim());
                sb.AppendLine(("Kontak Persoon:   " + GetMainContact.DisplayName).Trim());
                sb.AppendLine(("Email:   " + GetMainContact.Email).Trim());
                sb.AppendLine(("Telefoon:   " + GetMainContact.ContactNumber).Trim());
                
                return ("" + sb.ToString()).Trim();
            }
        }
        [XmlIgnore]
        public string GetContact
        {
            get
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendLine(("Contact:   " + GetMainContact.DisplayName).Trim());
                sb.AppendLine(("Contact Email:   " + GetMainContact.Email).Trim());
                sb.AppendLine(("Contact Telephone:   " + GetMainContact.ContactNumber).Trim());
                sb.AppendLine();

                return ("" + sb.ToString()).Trim();
            }
        }

        public string MaintenanceSummary()
        {
            if (GetProducts == null || GetProducts.Count == 0) return "";

            var maintCount = GetProducts.Where(i => i.HasMaintenance).Count();
            var count = GetProducts.Count;

            if (maintCount == count) return "Fully Covered";

            return $"{maintCount} of {count}";
        }

        public Client()
        {
            PeopleIDList = new HashSet<string>();
        }

        public bool HasSupport
        {
            get
            {
                return (new DateTime(Expirydate.Year, Expirydate.Month, 1) >= new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(-2));
            }
        }

        public bool HasPerson(string Search)
        {
            bool hasPerson = false;

            foreach (var p in PeopleIDList)
            {
                var queryPeople = DMS.PeopleManager.GetData(i => i.ID == p && i.DisplayName.ToLower().Contains(Search));
                if (queryPeople != null)
                {
                    hasPerson = true;
                    break;
                }
            }

            return hasPerson;
        }

        public bool Save(string Message, bool Overwrite, bool UseLog)
        {
            ID = Account;
            SetFile(Account, AMS.Settings.Program.Directories.Clients + Account, DataType.Client);

            if (UseLog) AddDataLog(Account, Message, DataType.Client);
            bool saved = DMS.ClientManager.Save(this, Message, Overwrite, true);

            UserPKManager.UpdatePk(KeyType.Account, Account);

            return saved;
        }

        public void ViewDatalog()
        {
            using (AMS.Forms.Log.DatalogViewer f = new AMS.Forms.Log.DatalogViewer(this))
            {
                f.ShowDialog();
                if (f.RequireSave)
                {
                    this.DatalogList = f.DatalogList;
                    this.Save("", true, false);
                }
            }
        }

        // Methods

        /// <summary>
        /// Sum of Products Ex-Vat with Date within 2 Months from Client's Expiry Date
        /// </summary>
        /// <returns>productList.Sum(i => i.PriceExVat)</returns>
        public decimal GetProductValue()
        {
            var productList = DMS.ProductManager.GetDataList(i => i.Account == Account &&
               i.ExpiryDate.AddMonths(2) >= Expirydate && (i.CatalogName == "Model Maker" ||
                 i.CatalogName == "Pipe Maker" ||
                 i.CatalogName == "Road Maker" ||
                 i.CatalogName == "Survey Maker")).ToList();

            if (productList != null && productList.Count > 0) return productList.Sum(i => i.PriceExVat);
            else return 0m;
        }

        public List<Person> GetPeopleList()
        {
            var people = new List<Person>();
            foreach (var i in PeopleIDList)
            {
                var person = DMS.PeopleManager.GetData(p => p.ID == i);
                if (person != null) people.Add(person);
            }

            return people;
        }

        /// <summary>
        /// 8% of Products' Ex-Vat (or Min Maint) with BulkDiscount. 
        /// </summary>
        public decimal GetMMSMaintenanceValue(int NumberofYears)
        {
            if (!HasSupport) return 0m;

            var productList = DMS.ProductManager.GetDataList(
                i => i.Account == Account &&
                i.ExpiryDate.AddMonths(2) >= Expirydate &&
                i.Stolen == false &&
                (i.CatalogName == "Model Maker" ||
                 i.CatalogName == "Pipe Maker" ||
                 i.CatalogName == "Road Maker" ||
                 i.CatalogName == "Point Clouds" ||
                 i.CatalogName == "Irrigation" ||
                 i.CatalogName == "Survey Maker")).ToList();

            return GetMMSMaintenanceValue(NumberofYears, productList);
        }

        /// <summary>
        /// 9% of Products' Ex-Vat (or Min Maint) with BulkDiscount.
        /// </summary>
        private decimal GetMMSMaintenanceValue(int NumberofYears, List<Products.Product> ProductList)
        {
            if (!HasSupport) return 0m;

            decimal value = 0m;

            foreach (var i in ProductList)
                value += i.PriceExVat;

            if (value * DMS.MaintenanceFactor < DMS.MinMaintenanceValue / DMS.VatRateValue) value = DMS.MinMaintenanceValue / DMS.VatRateValue; // setting minimum maint value ex vat
            else value *= DMS.MaintenanceFactor;

            bulkDiscount = value;

            if (value > 31250m) value = value * 0.7m;
            else if (value > 25000m) value = value * 0.75m;
            else if (value > 18750m) value = value * 0.8m;
            else if (value > 12500m) value = value * 0.85m;
            else if (value > 6250m) value = value * 0.9m;

            bulkDiscount = bulkDiscount - value;

            if (NumberofYears == 0) value = 0;
            if (NumberofYears == 2) value = value + value * 0.9m;

            value = Math.Floor(value * 100) / 100;

            return value;
        }

        public Data.People.MaintenanceType GetMaintenanceType()
        {
            MaintenanceType maintType = new MaintenanceType();
            if (string.IsNullOrEmpty(Account)) return MaintenanceType.New;

            // New Maintenance
            if (Expirydate < new DateTime(2000, 1, 1)) maintType = MaintenanceType.New;
            else maintType = MaintenanceType.Current;

            // Current and Expiring
            if (maintType != MaintenanceType.New && HasSupport)
            {
                int quoteMonths = Expirydate.Month - DateTime.Now.Month + (Expirydate.Year - DateTime.Now.Year) * 12;

                if (quoteMonths == 1 || quoteMonths == 0 || quoteMonths == -1 || quoteMonths == -2)
                    maintType = MaintenanceType.Expiring;
                else
                    maintType = MaintenanceType.Current;
            }
            // Expired Maintenance
            if (maintType != MaintenanceType.New && !HasSupport) maintType = MaintenanceType.Expired;

            return maintType;
        }

        public void OLDSendMaintenanceRenewal()
        {
            var mail = new AMS.Data.Communications.Mail();

            if (!string.IsNullOrEmpty(GetMainContact.DisplayName)) mail.Contact = GetMainContact.FirstName;
            else mail.Contact = Name;
            if (!string.IsNullOrEmpty(GetMainContact.Email)) mail.MailTo = GetMainContact.Email;
            else mail.MailTo = Email;

            mail.Body = "Dear " + mail.Contact + "\r\n\r\n" + "Please note your maintenance agreement with Model Maker Solution renewal is set for " + string.Format("{0:1 MMMM yyy}.\r\nThe outstanding value is {1:0.00}", Expirydate, GetMMSMaintenanceValue(1)) + "\r\n" +
                "Visit " + AMS.Suite.SuiteManager.Profile.Website + " for more information.\r\n\r\n" +
                AMS.Users.UserManager.CurrentUser.FirstName + " " + AMS.Users.UserManager.CurrentUser.LastName + "\r\n" +
                AMS.Suite.SuiteManager.Profile.CompanyName + "\r\n" + AMS.Suite.SuiteManager.Profile.CompanyContactNr;
            mail.Subject = "Model Maker Maintenance";

            AMS.Communications.MailManager.SendMail(mail);
        }
    }
}