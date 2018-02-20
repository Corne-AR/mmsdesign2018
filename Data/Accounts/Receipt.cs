using AMS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Accounts
{
    [Serializable]
    public class Receipt : DataClass
    {
        public string Account { get; set; }
        public Data.People.Client Client { get { return DMS.ClientManager.GetData(i => i.Account == Account); } }
        public string ClientInfo { get { if (Client == null) return "NO ACCOUNT"; return Client.Name; } }
        public string Description { get; set; }
        public DateTime ReceiptDate { get; set; }
        public DateTime DateFinalized { get; set; }
        public string GetReceiptDate { get { return string.Format("{0:dd MMM yy}", ReceiptDate); } }
        public bool BeingProcessed { get; set; }        // Manager will tag this to know it is busy being processed, on save it will be false again
        public string BeingProcessedReference { get; set; }
        public decimal Amount { get; set; }
        public decimal AmountRemaining
        {
            get
            {
                decimal value = Amount;

                if (ReceiptAllocationList != null)
                {

                    foreach (var i in ReceiptAllocationList)
                    {
                        try
                        {

                            //if (i.CurrencyAdjustment == 0 &&
                            //    AMS.Suite.SuiteManager.Profile.ForexList != null && AMS.Suite.SuiteManager.Profile.ForexList.Count > 0 &&
                            //    i.Transaction != null &&
                            //    i.Transaction.Currency != AMS.Suite.SuiteManager.Profile.ForexList[0]
                            //    && !string.IsNullOrEmpty(i.Transaction.Forex) && i.Transaction.Forex != "0")
                            //{
                            //    value -= i.Amount * Convert.ToDecimal(i.Transaction.Forex);
                            //}
                            //else
                            //{
                            value -= i.Amount;
                            //}
                        }
                        catch (Exception ex) { AMS.MessageBox_v2.Show("There was a problem in either of the following\r\n\r\nReceipt:" + i.ReceiptID + "\r\nTransaction" + i.TransactionID + "\r\n\r\n" + ex.Message, AMS.MessageType.Error); }
                    }
                }
                return value;
            }
        }

        public decimal Profit { get; set; }
        public decimal Tithe { get; set; }
        public ProcessType ProcessType { get; set; }

        public HashSet<ReceiptAllocation> ReceiptAllocationList { get; set; }
        public string GetInvoiceIDList
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                foreach (var i in ReceiptAllocationList)
                    sb.AppendLine($"{i.TransactionID} - {i.Amount:#.00}");
                return sb.ToString().Trim();
            }
        }

        public List<Transactions.Transaction> GetInvoices()
        {
            var list = new List<Transactions.Transaction>();
            foreach (var allocation in ReceiptAllocationList.Where(i => i.Transaction.Type == Transactions.TransactionType.Invoice || i.Transaction.Type == Transactions.TransactionType.CreditNote))
                list.Add(allocation.Transaction);

            return list;
        }

        // Constructors

        public Receipt()
        {
            ReceiptAllocationList = new HashSet<ReceiptAllocation>();
            ReceiptDate = DateTime.Now;
        }

        internal void Unlink(string TransactionId)
        {
            var transaction = DMS.TransactionManager.GetData(i => i.ID == TransactionId);
            if (transaction != null)
            {
                var query = (from i in transaction.ReceiptAllocationList
                             where i.ReceiptID == this.ID
                             select i).FirstOrDefault();

                if (query != null)
                {
                    transaction.ReceiptAllocationList.Remove(query);
                    transaction.CalculateTotals();
                }
            };
        }

        public void Unlink(bool Auto)
        {
            if (Auto || AMS.MessageBox_v2.Show("Are you sure you want to unlink this receipt to related transactions?\r\nWARNING, this cannot be undone.", AMS.MessageType.Question) == AMS.MessageOut.YesOk)
            try
            {
                foreach (var link in ReceiptAllocationList)
                {
                    var transaction = DMS.TransactionManager.GetData(i => i.ID == link.TransactionID);
                    transaction.ReceiptAllocationList.Remove(link);
                    transaction.Save("Removed Statement Link '" + link.ReceiptID + "'", true, true);
                }

                ReceiptAllocationList.Clear();
                DMS.AccountsManager.SaveReceipts();
            }
               catch
                {
                    AMS.MessageBox_v2.Show("Some linked references are missing, check that all linked files exist");
                    return;
                }
        }

        public void CreateInvoice(string ItemDescription, decimal Value)
        {
            if (Account == null || Client == null)
            {
                AMS.MessageBox_v2.Show("Receipt does not have any account associated to.");
                return;
            }

            if (ReceiptAllocationList.Count > 0)
            {
                AMS.MessageBox_v2.Show("Receipt has already been linked to another transaction(s).");
                return;
            }

            Data.Transactions.Transaction trans = new Transactions.Transaction()
            {
                Account = Account,
                Contact = Client.GetMainContact.DisplayName,
                ContactNr = Client.GetMainContact.ContactNumber,
                Currency = AMS.Suite.SuiteManager.Profile.ForexList[0],
                TransactionDate = DateTime.Now,
                DueDate = DateTime.Now,
                Email = Client.GetMainContact.Email,
                UseVat = !Client.IsInternational && AMS.Suite.SuiteManager.Profile.VatRegisterd
            };
            if (trans.UseVat)
            {
                trans.ItemList.Add(new Products.Product()
                {
                    Description = ItemDescription,
                    PriceExVat = Value / 1.14m
                });
            }
            else
            {
                trans.ItemList.Add(new Products.Product()
                {
                    Description = ItemDescription,
                    PriceExVat = Value
                });
            }

            trans.Save("Receipt " + this.ID + " created Invoice.", false, true);

            var translist = new List<Data.Transactions.Transaction>
            {
                trans
            };
            DMS.AccountsManager.LinkTransactions(translist, this);
            DMS.AccountsManager.SaveReceipts();
            DMS.AccountsManager.SaveTransactions();
        }

        public void CreateMaintInvoice()
        {
            if (string.IsNullOrEmpty(this.Account))
            {
                AMS.MessageBox_v2.Show("Please assign an Account to Receipt " + this.ID);
                return;
            }

            string date = "";
            int yearCount = 1;

            // Possible Jimmy issues
            if ((decimal)this.Amount / 1.14m > this.Client.GetMMSMaintenanceValue(1) * 1.5m) // 1.5 = rounding 
            {
                date = string.Format("{0:dd MMM yyyy}", this.Client.Expirydate.AddYears(2));
                yearCount = 2;
            }
            else
            {
                date = string.Format("{0:dd MMM yyyy}", this.Client.Expirydate.AddYears(1));
                yearCount = 1;
            }
            //////

            var ratio = Math.Abs((decimal)this.Amount / 1.14m - this.Client.GetMMSMaintenanceValue(yearCount));

            if (ratio >= 0.05m &&
                !(AMS.MessageBox_v2.Show($"WARNING\r\nThe receipt amount of {this.Amount / 1.14m:n2} (VAT?) does not match {this.Client.GetMMSMaintenanceValue(yearCount)} ({yearCount} years)\r\n\r\nWould you like to continue?", AMS.MessageType.Question) == AMS.MessageOut.YesOk))
                return;

            var trans = Data.Transactions.Utilities.CreateMaintenanceInvoice(this.Account, yearCount);

            var translist = new List<Data.Transactions.Transaction>
            {
                trans
            };
            DMS.AccountsManager.LinkTransactions(translist, this);
            DMS.AccountsManager.SaveReceipts();
            DMS.AccountsManager.SaveTransactions();
        }

        public override string ToString()
        {
            return $"{ID} - Account: {Account} - {Description}";
        }
    }
}