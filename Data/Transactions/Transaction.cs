using AMS.Data.Keys;
using AMS.Data.People;
using Data.People;
using Data.Quotes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Data.Transactions
{
    [Serializable]
    public partial class Transaction : AMS.Data.DataClass
    {
        public string Account { get; set; }

        public TransactionType Type { get; set; }                // Invoice, Proforma etc

        public string Contact { get; set; }
        public string ContactNr { get; set; }
        public string Email { get; set; }
        public string ClientRef { get; set; }  // Client's ref nr ex: PONr
        public string SupplierRef { get; set; }  // When this is a purchase order, allow a supplierRef
        public bool SendtoSupplier { get; set; }
        public bool UseSupplierInfo { get; set; }

        public string Currency { get; set; }        // ZAR, USD, GBP, EURO
        public string Forex { get; set; }            // Exchange rate at time of invoice
        public string PaymentTerms
        {
            get
            {
                string terms = "";

                int days = (new DateTime(DueDate.Year, DueDate.Month, DueDate.Day, 1, 1, 1) - new DateTime(TransactionDate.Year, TransactionDate.Month, TransactionDate.Day, 1, 1, 1)).Days;

                if (days < 1) terms = "COD";
                else terms = days + "Day";

                return terms;
            }
        }
        public bool UseVat { get; set; }
        public bool IsVoid { get; set; }
        public bool IsAudit { get; set; }

        public string MMSOrderPaymentTerms { get; set; }

        public bool IsFinalized { get; set; }
        public string ClientID { get; set; }      // The transaction may belong to a supplier, but the orginal order was made out to another client.
        public string UCRNr
        {
            get
            {
                return string.Format("{0}{1}{2}{3}", TransactionDate.Year.ToString()[3], "ZA", AMS.Suite.SuiteManager.Profile.CustomsNumber, ID);
            }
        }
        public string ClientNotes { get; set; }  // This is notes both at Client Data as well as on each transaction.
        public bool PrintClientNotes { get; set; }

        public DateTime TransactionDate { get; set; }
        public string GetTransactionDate { get { return string.Format("{0:dd MMM yy}", TransactionDate); } }
        public DateTime DueDate { get; set; }
        public DateTime ReceiptDate { get; set; }
        public string SupplierId { get; set; }
        public List<Data.Products.Product> ItemList { get; set; }
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
        public HashSet<Data.Accounts.ReceiptAllocation> ReceiptAllocationList { get; set; }
        public string GetReceiptIDList
        {
            get
            {
                if (ReceiptAllocationList == null) ReceiptAllocationList = new HashSet<Accounts.ReceiptAllocation>();
                StringBuilder sb = new StringBuilder();

                foreach (var i in ReceiptAllocationList)
                {
                    sb.AppendLine($"{i.ReceiptID} - {i.Amount:#.00}");
                }

                return sb.ToString().Trim();
            }
        }
        public bool BeingProcessed { get; set; }        // Manager will tag this to know it is busy being processed, on save it will be false again

        public List<Transaction> PurchaseOrderList()
        {
            HashSet<Transaction> poList = new HashSet<Transaction>();
            foreach (var id in LinkedIDList)
            {
                var linked = DMS.TransactionManager.GetData(i => i.ID == id && i.Type == TransactionType.PurchaseOrder);
                if (linked != null)
                    poList.Add(linked);
            }
            return poList.ToList();
        }

        public List<Transaction> InvoiceList()
        {
            HashSet<Transaction> poList = new HashSet<Transaction>();
            foreach (var id in LinkedIDList)
            {
                var linked = DMS.TransactionManager.GetData(i => i.ID == id && i.Type == TransactionType.Invoice);
                if (linked != null)
                    poList.Add(linked);
            }
            return poList.ToList();
        }

        public List<Data.Accounts.Receipt> ReceiptList()
        {
            HashSet<Data.Accounts.Receipt> reList = new HashSet<Accounts.Receipt>();

            foreach (var allocation in ReceiptAllocationList.Where(x => x != null))
            {
                reList.Add(allocation.Receipt);
            }
            return reList.ToList();
        }

        // Constructors

        public Transaction()
        {
            ItemList = new List<Data.Products.Product>();
            Type = new TransactionType();
            LinkedIDList = new HashSet<string>();
        }

        //private bool hasBulkdiscount;
        // For MMS, check if client is new, and setup file version
        public bool NewMMPackage { get; set; }
        public string SetupFileVersion { get; set; }

        public Data.People.Client Client { get { return Data.DMS.ClientManager.GetData(i => i.Account == Account); } }
        public Data.People.Client OrderClient { get { return Data.DMS.ClientManager.GetData(i => i.Account == ClientID); } }
        public string GetClientInfo
        {
            get
            {
                string info = "";

                if (Account != null && Client != null) info = Client.Name;
                else info = "N/A";

                if (Type == TransactionType.PurchaseOrder)
                    info = OrderClient.Name;

                return info;
            }
        }

        public string GetSummary
        {
            get
            {
                StringBuilder sb = new StringBuilder();

                try
                {
                    if (!string.IsNullOrEmpty(ClientID)) sb.AppendLine($"Referenced Client: {OrderClient.Name}");
                    if (Client.IsInternational) sb.AppendLine("UCR Nr: " + UCRNr);

                    if (ReceiptAllocationList != null && ReceiptAllocationList.Count > 0)
                    {
                        sb.AppendLine("Receipts");
                        foreach (var i in ReceiptAllocationList)
                        {
                            sb.AppendLine($"{i.ReceiptID} - {i.Amount:#.00} - {i.Receipt.Description} - {i.Receipt.GetReceiptDate}");
                            //sb.AppendLine(i.Receipt.ID + " - " + i.Amount + " - " + i.Receipt.Description + " - " + i.Receipt.GetReceiptDate);
                            if (i.CurrencyAdjustment != 0) sb.AppendLine($"Currency Adjustment {i.CurrencyAdjustment:#.00}");
                        }
                    }

                    if (InvoiceList().Count > 0)
                    {
                        sb.AppendLine();
                        sb.AppendLine("Invoices");
                        foreach (var i in InvoiceList())
                            if (!string.IsNullOrEmpty(i.ClientRef))
                                sb.AppendLine(i.ID + " - " + i.Total + " - " + i.Client.Name + " - " + i.GetTransactionDate + " - " + i.ClientRef);
                            else
                                sb.AppendLine(i.ID + " - " + i.Total + " - " + i.Client.Name + " - " + i.GetTransactionDate);
                    }


                    if (PurchaseOrderList().Count > 0)
                    {
                        sb.AppendLine();
                        sb.AppendLine("Purchase Orders");
                        foreach (var i in PurchaseOrderList())
                            sb.AppendLine(i.ID + " - " + i.Total + " - " + i.Client.Name + " - " + i.GetTransactionDate);
                    }
                }
                catch { }

                return sb.ToString();
            }
        }

        //private decimal totalFix;       // Used to add/remove to the total due, typically for forex exchange fixing to 0 out the receipts
        private decimal subtotal;
        public decimal SubTotal
        {
            get
            {

                if (subtotal == 0m) CalculateTotals();
                return Math.Round(subtotal, 2);
            }
        }
        private decimal totalVat;
        public decimal TotalVat
        {
            get
            {
                if (totalVat == 0m) CalculateTotals();
                return Math.Round(totalVat, 2);
            }
        }
        private decimal total;
        public decimal Total
        {
            get
            {
                if (total == 0m) CalculateTotals();
                return Math.Round(total, 2);
            }
        }
        private decimal totalDue;
        public decimal TotalDue
        {
            get
            {
                if (totalDue < 0.05m) CalculateTotals();
                return Math.Round(totalDue, 2);
            }
        }

        public bool IsPaid()
        {
            return (TotalDue <= 0.05m && TotalDue >= -0.05m);
        }

        public bool HasUnpaidInvoices()
        {
            bool hasunpaid = false;
            foreach (var i in LinkedIDList)
            {
                var trans = DMS.TransactionManager.GetData(qi => qi.ID == i && qi.Type == TransactionType.Invoice);
                if (!hasunpaid && trans != null) hasunpaid = !trans.IsPaid();
            }

            return hasunpaid;
        }

        public void CalculateTotals()
        {
            subtotal = 0m;
            totalDue = 0m;
            totalVat = 0m;
            total = 0m;

            if (ReceiptAllocationList == null) ReceiptAllocationList = new HashSet<Accounts.ReceiptAllocation>();
            decimal totalReceipts = (from i in ReceiptAllocationList
                                     select i).ToList().Sum(i => i.Amount);

            foreach (var i in ItemList)
            {
                decimal value = Math.Round(i.ItemTotal, 2);

                subtotal += value;

                if (UseVat) total += value * 1.14m;
                else total += value;
            }

            if (UseVat) totalVat = total - subtotal;
            totalDue = total - totalReceipts;
            if (ReceiptAllocationList.Select(i => i.CurrencyAdjustment).Sum() != 0) totalDue = 0;

            if (IsVoid)
            {
                totalDue = 0m;
                total = 0m;
            }
        }

        // Save

        public bool Save(string Message, bool OverWrite, bool UseLog)
        {
            //if (IsAudit)
            //{
            //    AMS.MessageBox_v2.Show("Transaction has already been audited, and cannot be changed again.");
            //    return false;
            //}

            if (Type == TransactionType.Proforma && ID == null) ID = UserPKManager.NewUserPK(KeyType.Proforma);
            if (Type == TransactionType.Invoice && ID == null) ID = UserPKManager.NewUserPK(KeyType.Invoice);
            if (Type == TransactionType.PurchaseOrder && ID == null) ID = UserPKManager.NewUserPK(KeyType.PurchaseOrder);

            LinkedIDList.Add(ID);
            if (UseLog) AddDataLog(ID, Message, AMS.Data.DataType.Transaction);

            SetFile(ID + " - " + Client.Name, AMS.Settings.Program.Directories.Clients + "\\" + Account + "\\Transactions", AMS.Data.DataType.Transaction);
            BeingProcessed = false;

            //if(this.Type== TransactionType.PurchaseOrder && this.ClientID!= this.ClientRef)
            //{
            //    var refclient = DMS.ClientManager.GetData(i => i.ID == this.ClientRef);

            //    if(refclient != null)
            //    {
            //        this.ClientID = refclient.ID;
            //    }

            //}

            bool saved = Data.DMS.TransactionManager.Save(this, Message, OverWrite, true);

            UserPKManager.UpdatePk(KeyType.Proforma, ID);
            UserPKManager.UpdatePk(KeyType.Invoice, ID);
            UserPKManager.UpdatePk(KeyType.PurchaseOrder, ID);

            if (saved)
            {
                if (this.Type == TransactionType.PurchaseOrder)
                {
                    if (Client.TransactionNotes != this.ClientNotes)
                    {
                        var client = DMS.ClientManager.GetData(i => i.ID == ClientID);
                        client.TransactionNotes = this.ClientNotes;
                        client.Save("Update Transaction Notes", true, false);
                    }
                }
                else
                {
                    if (Client.TransactionNotes != this.ClientNotes)
                    {
                        Client.TransactionNotes = this.ClientNotes;
                        Client.Save("Update Transaction Notes", true, false);
                    }
                }
            }

            return saved;
        }

        // Methods

        public void SetVoid()
        {
            if (IsVoid == true && AMS.MessageBox_v2.Show("Please add reason for this un-void.", AMS.MessageType.QuestionInput) == AMS.MessageOut.YesOk)
            {
                IsVoid = false;
                string note = AMS.MessageBox_v2.MessageValue;
                Save(ID + " Un-Void: " + note, false, true);
                return;
            }

            if (IsVoid != true && AMS.MessageBox_v2.Show("Please add reason for this void.", AMS.MessageType.QuestionInput) == AMS.MessageOut.YesOk)
            {
                string note = AMS.MessageBox_v2.MessageValue;
                IsVoid = true;
                Save(ID + " Void: " + note, false, true);
                return;
            }
        }

        public void CancelTransaction()
        {
            #region Messge Box and Type

            if (Type == TransactionType.Invoice || Type == TransactionType.PurchaseOrder)
            {
                var type = Type == TransactionType.Invoice ? TransactionType.CreditNote : TransactionType.CancellationOrder;
                string message = $"Are you sure you want to proceed making {Type} {ID} into a {type}";

                if (Type == TransactionType.Invoice && AMS.MessageBox_v2.Show(message, AMS.MessageType.QuestionInput) != AMS.MessageOut.YesOk)
                    return;

                #endregion

                if (Type == TransactionType.Invoice && PurchaseOrderList().Count > 0)
                    AMS.MessageBox_v2.Show("There are Purchase Orders associated and 'may' require Cancellation orders", AMS.MessageType.Warning);

                NewCancelTransaction(AMS.MessageBox_v2.MessageValue);

            }
            else
            {
                AMS.MessageBox_v2.Show($"Transaction should be an invoice or a purchase order. Type = {Type}");
            }
        }

        private void NewCancelTransaction(string Log)
        {
            var newType = Type == TransactionType.Invoice ? TransactionType.CreditNote : TransactionType.CancellationOrder;
            var keyType = Type == TransactionType.Invoice ? KeyType.Invoice : KeyType.PurchaseOrder;

            var newTrans = (Transaction)this.Clone();
            newTrans.ReceiptAllocationList.Clear();
            foreach (var i in newTrans.ItemList) i.PriceExVat = i.PriceExVat * -1;
            newTrans.ID = UserPKManager.NewUserPK(keyType);
            newTrans.Type = newType;
            newTrans.DueDate = DateTime.Today; //Corne was hier
            newTrans.TransactionDate = DateTime.Today; //Corne was hier
            newTrans.CalculateTotals();
            newTrans.Save(newTrans.ID + " Credited for " + ID + ": " + Log, false, true);

            // Invoice Receipt and Allocation

            var newReceipt = new Accounts.Receipt()
            {
                Account = Account,
                Description = $"{Type} {ID} was converted to {newType}",
                Amount = TotalDue,
                ReceiptDate = DateTime.Now,
                ID = $"Temp {ID}"
            };

            var oldReceipt = new Accounts.Receipt()
            {
                Account = newTrans.Account,
                Description = $"{newTrans.Type} {newTrans.ID} was converted from {ID}",
                Amount = newTrans.TotalDue,
                ReceiptDate = DateTime.Now,
                ID = $"Temp {newTrans.ID}"
            };

            this.LinkedIDList.Add(newTrans.ID);

            DMS.AccountsManager.AddReceipt(newReceipt);
            DMS.AccountsManager.AddReceipt(oldReceipt);

            DMS.AccountsManager.SaveReceipts();

            var inReceiptSaved = DMS.AccountsManager.ReceiptList.Where(i => i.Description == newReceipt.Description && i.ReceiptDate == newReceipt.ReceiptDate).FirstOrDefault();
            var crReceiptSaved = DMS.AccountsManager.ReceiptList.Where(i => i.Description == oldReceipt.Description && i.ReceiptDate == oldReceipt.ReceiptDate).FirstOrDefault();

            DMS.AccountsManager.LinkTransactions(this, inReceiptSaved);
            DMS.AccountsManager.LinkTransactions(newTrans, crReceiptSaved);

            //if (AMS.MessageBox_v2.Show("New Receipts for this Credit Note and Invoice has been created. Would you like to save now?\r\nIf you select No, you will have to manually save the changes", AMS.MessageType.Question) == AMS.MessageOut.YesOk)
            //{
            DMS.AccountsManager.SaveReceipts();
            DMS.AccountsManager.SaveTransactions();

            this.CalculateTotals();
            //}
        }

        public string GetTransactionType()
        {
            string type = "";

            if (Type == TransactionType.CreditNote) type = "Credit Note";
            if (Type == TransactionType.Invoice) type = "Tax Invoice";
            if (Type == TransactionType.Proforma) type = "Pro-Forma Invoice";
            if (Type == TransactionType.PurchaseOrder) type = "Purchase Order";
            if (Type == TransactionType.Quote) type = "Quote";

            return type;
        }

        public bool GenerateTransactions(Transaction Source)
        {
            bool generated = false;

            bool newInoivce = (Source.Type == TransactionType.Proforma);
            bool newPurchaseOrders = (Source.Type == TransactionType.Proforma) || (Source.Type == TransactionType.Invoice);

            string header = "";
            if (newInoivce) header = "Generate Invoice now?\r\n";
            if (newPurchaseOrders) header = "Generate Purchase Order(s) now?\r\n";
            if (newInoivce && newPurchaseOrders) header = "Generate Invoice and Purchase Order(s) now?\r\n";

            #region Check if valid

            if (Source.Type == TransactionType.Invoice ||
                Source.Type == TransactionType.Proforma ||
                Source.Type == TransactionType.Quote)
            {
            }
            else
            {
                AMS.MessageBox_v2.Show("Transactions can only generated from a Proforma, Quote or Invoice");
                return false;
            }

            string type = "";
            if (newInoivce) TransactionType.Invoice.ToString();
            if (newPurchaseOrders) type = TransactionType.PurchaseOrder.ToString();


            if (!Source.IsAudit && AMS.MessageBox_v2.Show(header + "WARNING: This will finalize the order.", AMS.MessageType.Question) == AMS.MessageOut.YesOk)
            {
                #region Check for products without suppliers

                var noSuppliers = (from i in Source.ItemList
                                   where i.SupplierID == null || i.SupplierID.Trim() == ""
                                   select i).ToList();

                StringBuilder noSupplierProductList = new StringBuilder();

                foreach (var i in noSuppliers)
                {
                    noSupplierProductList.AppendLine(i.Description + " - " + i.ItemTotal);
                }

                if (noSuppliers.Count > 0)
                    if (!(AMS.MessageBox_v2.Show("Missing Suppliers\r\n\r\nThe following items does not have any Supplier associated to.\r\n\r\n" + noSupplierProductList.ToString() + "\r\n\r\nDo you wish to continue?", AMS.MessageType.Question) == AMS.MessageOut.YesOk)) return false;

                #endregion
            }
            else
            {
                return false;
            }

            #endregion

            header = "Generating Transactions\r\n\r\n";
            AMS.MessageBox_v2.ShowProcess(header + "Querying related transactions");

            // Get list of associated transactions
            var transactionList = (from i in Data.DMS.TransactionManager.GetDataList()
                                   where
                                   (i.ID == Source.ID) ||
                                   (i.LinkedIDList.Contains(Source.ID))
                                   select i).ToList();

            var quoteList = (from i in Data.DMS.QuoteManager.GetDataList()
                             where
                             (i.ID == Source.ID) ||
                             (i.LinkedIDList.Contains(Source.ID))
                             select i).ToList();

            HashSet<string> newIdList = new HashSet<string>();

            foreach (var transaction in transactionList)
                foreach (var i in transaction.LinkedIDList)
                    newIdList.Add(i);

            foreach (var quote in quoteList)
                foreach (var i in quote.LinkedIDList)
                    newIdList.Add(i);

            //HashSet<string> newSupplierIdList = new HashSet<string>();

            // Generate new transactions
            if (newInoivce)
            {
                AMS.MessageBox_v2.ShowProcess("Generating a new invoice");
                newIdList.Add(GenerateInvoice(Source).ID);
                generated = true;
            }

            // Generate new Purchase Order
            if (newPurchaseOrders)
            {
                AMS.MessageBox_v2.ShowProcess("Generating a new purchase orders");
                var list = GeneratePurchaseOrders(Source);
                foreach (var i in list) newIdList.Add(i.ID);
                //foreach (var i in list) newSupplierIdList.Add(i.SupplierId);
                generated = true;
            }

            foreach (var id in newIdList)
            {
                var trans = DMS.TransactionManager.GetData(i => i.ID == id);

                if (trans != null)
                {
                    trans.LinkedIDList = newIdList;
                    trans.Save("", true, false);
                }

                var quote = DMS.QuoteManager.GetData(i => i.ID == id);

                if (quote != null)
                {
                    quote.LinkedIDList = newIdList;
                    quote.Save("", true, false, quote.ProgressType);
                }
            }

            AMS.MessageBox_v2.EndProcess();

            return generated;
        }

        private Transaction GenerateInvoice(Transaction Source)
        {
            var transaction = (Transaction)Source.Clone();

            transaction.Type = TransactionType.Invoice;
            transaction.ID = UserPKManager.NewUserPK(KeyType.Invoice);
            transaction.LinkedIDList.Add(Source.ID);
            transaction.Metadata.Created = new DateTime();
            transaction.Metadata.EmailDate = new DateTime();
            transaction.Save("Generated " + transaction.GetTransactionType() + " " + transaction.ID, false, true);

            return transaction;
        }

        public Transaction DuplicateTransaction(Transaction Source)
        {
            var transaction = (Transaction)Source.Clone();

            switch (transaction.Type)
            {
                case TransactionType.CreditNote: transaction.ID = UserPKManager.NewUserPK(KeyType.Invoice); break;
                case TransactionType.Invoice: transaction.ID = UserPKManager.NewUserPK(KeyType.Invoice); break;
                case TransactionType.Proforma: transaction.ID = UserPKManager.NewUserPK(KeyType.Proforma); break;
                case TransactionType.PurchaseOrder: transaction.ID = UserPKManager.NewUserPK(KeyType.PurchaseOrder); break;
            }

            transaction.LinkedIDList.Clear();
            transaction.ClientRef = "";
            transaction.DatalogList.Clear();
            transaction.DueDate = DateTime.Now;
            transaction.TransactionDate = DateTime.Now;
            transaction.IncludeAccountant = false;
            transaction.IsAudit = false;
            transaction.IsFinalized = false;
            transaction.IsVoid = false;
            transaction.Metadata = new AMS.Data.Metadata();
            transaction.Notes = "";
            transaction.ReceiptAllocationList.Clear();
            transaction.ReceiptDate = new DateTime();
            transaction.SendtoSupplier = false;

            transaction.Save("Generated " + transaction.GetTransactionType() + " " + transaction.ID, false, true);

            return transaction;
        }

        private List<Transaction> GeneratePurchaseOrders(Transaction Source)
        {
            AMS.MessageBox_v2.ShowProcess("Generating a new purchase orders");

            // List of Suppliers
            var poList = new List<Transaction>();

            #region Supplier List

            HashSet<Data.People.Client> supplierList = new HashSet<Data.People.Client>();
            foreach (var item in Source.ItemList)
            {
                var supplier = Data.DMS.ClientManager.GetData(i => i.ID == item.SupplierID);
                if (supplier != null) supplierList.Add(supplier);
            }

            #endregion

            // Generate per supplier from list
            int nr = 0;
            foreach (var supplier in supplierList)
            {
                nr++;
                AMS.MessageBox_v2.ShowProcess("Generating purchase order " + nr + "/" + supplierList.Count);

                // Get the product list associated to the supplier
                var productList = (from i in Source.ItemList
                                   where i.SupplierID == supplier.ID
                                   select i).ToList();

                var newPrurchaseOrder = (Transaction)Source.Clone();
                newPrurchaseOrder.ID = UserPKManager.NewUserPK(KeyType.PurchaseOrder);
                //newPrurchaseOrder.ClientRef = Source.Account;
                newPrurchaseOrder.ClientID = Source.Account;
                newPrurchaseOrder.Account = supplier.Account;
                newPrurchaseOrder.Type = TransactionType.PurchaseOrder;
                newPrurchaseOrder.ItemList = productList;
                newPrurchaseOrder.SupplierId = supplier.Account;
                newPrurchaseOrder.LinkedIDList.Add(Source.ID);
                newPrurchaseOrder.Metadata.Created = new DateTime();
                newPrurchaseOrder.Metadata.EmailDate = new DateTime();
                newPrurchaseOrder.ReceiptAllocationList = new HashSet<Accounts.ReceiptAllocation>();
                newPrurchaseOrder.Save("Generate Purchase Order " + newPrurchaseOrder.ID, false, true);
                newPrurchaseOrder.Contact = "";
                newPrurchaseOrder.Email = "";

                poList.Add(newPrurchaseOrder);
                System.Windows.Forms.Application.DoEvents();
                System.Threading.Thread.Sleep(100);
            }

            AMS.MessageBox_v2.EndProcess();
            return poList;
        }

        public bool IsMailed
        {
            get { return (Metadata.EmailDate != null && Metadata.EmailDate > new DateTime(1900, 1, 1)); }
        }

        public string POGenerated
        {
            get
            {
                // Only applicable to invoices
                if (!(Type == TransactionType.Invoice || Type == TransactionType.CreditNote)) return "";

                // Get All items without Supplier ID
                var noSupplierList = ItemList.Where(i => string.IsNullOrEmpty(i.SupplierID));
                if (noSupplierList != null && noSupplierList.Count() > 0)
                    return "Supplier ID Missing";

                // Make sure all items is applicable
                int naCount = 0;
                var naItemList = ItemList.Where(i => i.SupplierID == "Not Applicable");
                if (naItemList != null) naCount = naItemList.Count();
                if (naItemList != null && naItemList.Count() == ItemList.Count)
                    return "";

                // List of suppliers
                HashSet<string> supplierList = new HashSet<string>();
                foreach (var item in ItemList)
                    if (item.SupplierID != null && item.SupplierID != "Not Applicable") supplierList.Add(item.SupplierID);

                string returnValue = "";
                if (PurchaseOrderList().Count != supplierList.Count) returnValue = supplierList.Count - PurchaseOrderList().Count + " missing Purchase Orders";

                return returnValue;
            }
        }

        public bool IncludeAccountant { get; set; }

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

        public bool HasItem(string Description)
        {
            if (Description == null) return false;

            Description = Description.ToLower();

            var query = (from i in ItemList
                         where i.Name != null && i.Name.ToLower().Contains(Description) ||
                         i.Description != null && i.Description.ToLower().Contains(Description)
                         select i).FirstOrDefault();

            if (query != null) return true;

            return false;
        }

        public override string ToString()
        {
            return $"{ID} | {Account} | {Client?.Name} | {Type} | Paid: {IsPaid()}";
        }


        public void SetClient(Client Client)
        {
            Account = Client.Account;
            UseVat = !Client.IsInternational && AMS.Suite.SuiteManager.Profile.VatRegisterd;
            Currency = Client.CurrencyUsed;
        }

        public void Unlink()
        {
            if (AMS.MessageBox_v2.Show("Are you sure you want to unlink this transactions' receipt allocations?\r\nWARNING, this cannot be undone.", AMS.MessageType.Question) == AMS.MessageOut.YesOk)
            {
                foreach (var link in ReceiptAllocationList)
                {
                    var transaction = DMS.TransactionManager.GetData(i => i.ID == link.TransactionID);
                    transaction.ReceiptAllocationList.Remove(link);
                    transaction.Save("Removed Statement Link '" + link.ReceiptID + "'", true, true);

                    var receipt = link.Receipt;
                    receipt.ReceiptAllocationList.Remove(link);
                }

                ReceiptAllocationList.Clear();
                DMS.AccountsManager.SaveReceipts();
            }
        }
    }
}