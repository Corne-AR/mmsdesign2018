using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Transactions
{
    public static class Utilities
    {
        //public static void OLDLinkTransactions(HashSet<string> LinkedIDList, string ID)
        //{
        //    if (ID == null || LinkedIDList == null) return;

        //    AMS.MessageBox.ShowProcess("Please wait\r\nUpdating Transaction Links");

        //    HashSet<string> idList = new HashSet<string>();

        //    // Get lists of associated transactions
        //    HashSet<Quote> quoteList = new HashSet<Quote>();
        //    HashSet<Transaction> transList = new HashSet<Transaction>();

        //    foreach (var id in LinkedIDList)
        //    {
        //        foreach (var q in DMS.QuoteManager.GetDataList(i => i.ID == id ||
        //            i.LinkedIDList.Where(qi => qi.ToLower().Contains(ID.ToLower())).Count() > 0))
        //            if (q != null) quoteList.Add(q);

        //        foreach (var t in DMS.TransactionManager.GetDataList(i => i.ID == id ||
        //            i.LinkedIDList.Where(qi => qi.ToLower().Contains(ID.ToLower())).Count() > 0))
        //            if (t != null) transList.Add(t);
        //    }

        //    // Add the associated transactions to the idList
        //    foreach (var i in quoteList)
        //        if (i != null) idList.Add(i.ID);

        //    foreach (var i in transList)
        //        if (i != null) idList.Add(i.ID);


        //    // Add back the id's to the associated transactions
        //    foreach (var i in quoteList)
        //    {
        //        if (i != null)
        //        {
        //            var oldList = new HashSet<string>();
        //            foreach (var id in i.LinkedIDList)
        //                oldList.Add(id);

        //            i.LinkedIDList = new HashSet<string>();
        //            foreach (var id in idList)
        //            {
        //                if (id != i.ID) i.LinkedIDList.Add(id);
        //            }

        //            if (oldList != i.LinkedIDList)
        //            {
        //                AMS.MessageBox.UpdateProcess("Quote " + i.ID + " - " + i.GetLinkedIDList);
        //                System.Threading.Thread.Sleep(10);
        //                i.Save("Updating Links - " + i.GetLinkedIDList, true, true);
        //            }
        //        }
        //    }

        //    foreach (var i in transList)
        //    {
        //        if (i != null)
        //        {
        //            var oldList = new HashSet<string>();
        //            foreach (var id in i.LinkedIDList)
        //                oldList.Add(id);

        //            i.LinkedIDList = new HashSet<string>();
        //            foreach (var id in idList)
        //            {
        //                if (id != i.ID) i.LinkedIDList.Add(id);
        //            }

        //            if (oldList != i.LinkedIDList)
        //            {
        //                AMS.MessageBox.UpdateProcess("Transaction " + i.ID + " - " + i.GetLinkedIDList);
        //                System.Threading.Thread.Sleep(10);
        //                i.Save("Updating Links - " + i.GetLinkedIDList, true, false);
        //            }
        //        }
        //    }

        //    AMS.MessageBox.EndProcess();
        //}

        public static HashSet<Data.People.Client> SupplierList(Data.Quotes.Quote Quote)
        {
            var list = new HashSet<Data.People.Client>();

            foreach (var catalog in Quote.QuoteCatalogList)
            {
                bool add = false;

                foreach (var item in catalog.ItemList)
                {
                    if (item.Selected && item.Maintenance)
                    {
                        if (list.Where(qi => qi.ID == item.SupplierID).Count() == 0 && !string.IsNullOrEmpty(item.SupplierID))
                        {
                            list.Add(DMS.ClientManager.GetData(qi => qi.ID == item.SupplierID));
                        }

                        add = string.IsNullOrEmpty(item.SupplierID);
                    }
                }

                if (add) list.Add(DMS.ClientManager.GetData(qi => qi.ID == catalog.DefaultSupplierID));
            }

            return list;
        }

        /// <summary>
        /// Create a new transaction and save all
        /// </summary>
        /// <param name="Account"></param>
        /// <param name="YearCount"></param>
        /// <returns></returns>
        public static Transaction CreateMaintenanceInvoice(string Account, int YearCount)
        {
            var client = DMS.ClientManager.GetData(i => i.Account == Account);
            var itemList = DMS.ProductManager.GetDataList(i => i.Account == Account && i.ExpiryDate == client.Expirydate);

            return CreateMaintenanceInvoice(Account, YearCount, itemList);
        }

        /// <summary>
        /// Create a new transaction and save all
        /// </summary>
        /// <param name="Account"></param>
        /// <param name="YearCount"></param>
        /// <param name="Products"></param>
        /// <returns></returns>
        public static Transaction CreateMaintenanceInvoice(string Account, int YearCount, List<Products.Product> Products)
        {
            var client = DMS.ClientManager.GetData(i => i.Account == Account);

            var itemList = new List<Products.Product>();
            string msg = string.Format("Client Maintenance changed from {0:MMM yyyy} to {1:MMM yyyy}", client.Expirydate, client.Expirydate.AddYears(YearCount));

            foreach (var i in Products)
            {
                i.ExpiryDate = client.Expirydate.AddYears(YearCount);
                i.Save(msg, true, true);
            }
            var newItem = new Products.Product
            {
                Description = string.Format("MMS Software Subscription until {0:MMMM yyyy}", client.Expirydate.AddYears(YearCount)),
                Name = Products.Select(x => x.Name).Distinct().BuildString(", "),
                PriceExVat = client.GetMMSMaintenanceValue(YearCount),
                SupplierID = "AS001"
            };
            itemList.Add(newItem);

            Transaction trans = new Transaction
            {
                Account = client.Account,
                Contact = client.GetMainContact.DisplayName,
                ContactNr = client.GetMainContact.ContactNumber,
                Currency = AMS.Suite.SuiteManager.Profile.ForexList[0],
                TransactionDate = DateTime.Now,
                DueDate = DateTime.Now,
                Email = client.GetMainContact.Email,
                UseVat = !client.IsInternational && AMS.Suite.SuiteManager.Profile.VatRegisterd
            };
            trans.Account = client.Account;
            trans.DueDate = DateTime.Now;
            trans.TransactionDate = DateTime.Now;
            trans.ItemList = itemList;
            trans.Save("Generated Software Subscription Invoice", false, true);

            client.Expirydate = client.Expirydate.AddYears(YearCount);
            client.Save(msg, true, true);

            var translist = new List<Data.Transactions.Transaction>();

            return trans;
        }

        public static void SendToSupplier(List<Transaction> PurchaseOrderList)
        {
            try
            {
                if (PurchaseOrderList == null || PurchaseOrderList.Count == 0) return;

                var supplier = DMS.ClientManager.GetData(i => i.Account == PurchaseOrderList[0].SupplierId);

                if (supplier == null) throw new Exception("Purchase Order " + PurchaseOrderList[0].ID + ": Supplier " + PurchaseOrderList[0].SupplierId + " cannot be found in the database.");

                StringBuilder receiptListInfo = new StringBuilder();
                decimal value = 0m;

                foreach (var po in PurchaseOrderList)
                {
                    var receipts = po.ReceiptList();

                    if (receipts == null || receipts.Count == 0) throw new Exception("Purchase Order " + po.ID + ": Receipt(s) pending.");

                    if (receipts != null && receipts.Count == 1)
                    {
                        try
                        {
                            var receipt = receipts[0];

                            receiptListInfo.AppendLine(receipt.Description + " - " + po.GetClientInfo + " - R" + receipt.Amount);
                            value += receipt.Amount;
                        }
                        catch (Exception ex) { throw new Exception($"There was something wrong with receipt info. Purchase Order " + po.ID + " may have a Null receipt link", ex); }
                    }

                    if (receipts != null && receipts.Count > 1)
                    {
                        string rinfo = "";
                        decimal rAmount = 0m;
                        foreach (var r in receipts)
                        {
                            rAmount += r.Amount;
                            rinfo += r.Description + " ";
                        }
                        receiptListInfo.AppendLine(rinfo?.Trim() + " - " + po.GetClientInfo + " - R" + rAmount);
                        value += rAmount;
                    }
                }

                StringBuilder sb = new StringBuilder();

                sb.AppendLine("List of invoices for " + supplier.Name);
                sb.AppendLine("Date: " + string.Format("{0:dd MMM yyyy}", DateTime.Now));
                sb.AppendLine();
                sb.AppendLine(receiptListInfo.ToString());
                sb.AppendLine("Total: " + value);

                if (AMS.MessageBox_v2.Show(sb.ToString(), AMS.MessageType.Question) == AMS.MessageOut.YesOk)
                {
                    var mail = Data.DMS.MailManager.NewMail(supplier.Account, supplier.GetAccountant.DisplayName, supplier.GetAccountant.Email, "Betaling Gedoen", sb.ToString(), null, Communications.TemplateTypes.SupplierPayments);
                    DMS.MailManager.SendGeneralMail(mail);

                    foreach (var po in PurchaseOrderList)
                    {
                        po.SendtoSupplier = true;
                        po.Save(po.ID + " payment completed for " + supplier.GetAccountant.DisplayName + " " + supplier.GetAccountant.Email, true, true);
                    }

                    supplier.AddDataLog("Accounts", sb.ToString(), AMS.Data.DataType.Transaction);
                    supplier.Save("Updating Accounts", true, false);
                }
            }
            catch (Exception ex) { AMS.MessageBox_v2.Show(ex.Message, AMS.MessageType.Error); }
        }

        public static void Profit(DateTime StartDate, DateTime EndDate)
        {
            var receipts = DMS.AccountsManager.ReceiptList.Where(i => i.ReceiptDate > StartDate && i.ReceiptDate < EndDate).ToList();
            receipts = receipts.OrderBy(i => i.ReceiptDate).ToList();
            decimal total = 0;
            string info = "";
            // USD/VAT??

            foreach (var receipt in receipts)
            {
                info += "RECEIPT    " + receipt.Description + " " + string.Format("{0:dd MMM yyyy}", receipt.ReceiptDate) + "\r\n";
                foreach (var trans in receipt.ReceiptAllocationList)
                {
                    if (trans.Transaction.Type == TransactionType.Invoice || trans.Transaction.Type == TransactionType.CreditNote)
                    {
                        decimal value = 0m;

                        value = trans.Amount;

                        info += trans.TransactionID + " : " + trans.Amount + "\r\n";

                        foreach (var po in trans.Transaction.PurchaseOrderList())
                        {
                            value -= po.Total;
                            info += po.ID + " : " + po.Total + "\r\n";
                        }

                        total += value;
                    }
                }
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("Profit between {0:dd MMM yyyy} and {1:dd MMM yyyy}", StartDate, EndDate));
            sb.AppendLine();
            sb.AppendLine(string.Format("Profit {0:C}", total));
            sb.AppendLine(string.Format("Tithe {0:C}", (decimal)total / 10m));
            sb.AppendLine();
            sb.AppendLine(info);


            AMS.MessageBox_v2.Show(sb.ToString());
        }
    }
}
