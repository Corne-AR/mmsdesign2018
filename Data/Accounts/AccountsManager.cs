using AMS.Data;
using Data.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Accounts
{
    public class AccountsManager
    {
        private AMS.Data.IO.aFile ReceiptsFileName = new AMS.Data.IO.aFile("Receipts", AMS.Settings.Program.Directories.Data, AMS.Data.DataType.Data);

        private Receipt Receipt;
        private HashSet<Receipt> receiptList;
        public HashSet<Receipt> ReceiptList
        {
            get
            {
                if (receiptList == null) GetReceiptData();
                return receiptList;
            }
        }

        private HashSet<Receipt> originalReceiptList;
        public HashSet<Receipt> OriginalReceiptList { get { return originalReceiptList; } }

        private List<Transaction> TransactionList;

        public event EventHandler ReceiptProcessed_Event;
        public event EventHandler Saved_Event;
        public event EventHandler Load_Event;
        public event EventHandler ReceiptAdded;

        //  Methods

        public HashSet<Receipt> GetReceiptData()
        {
            if (receiptList == null) receiptList = new HashSet<Receipt>();

            originalReceiptList = new HashSet<Receipt>();

            List<Receipt> sList = (List<Receipt>)AMS.IO.XML_v1.Reader<List<Receipt>>(ReceiptsFileName.FullName);
            if (sList == null) sList = new List<Receipt>();

            sList = sList.OrderBy(i => i.ReceiptDate).ToList();

            foreach (var i in sList)
            {
                receiptList.Add(i);
                originalReceiptList.Add((Receipt)i.Clone());
            }

            if (Load_Event != null) Load_Event(this, EventArgs.Empty);

            return receiptList;
        }

        public void ResetReceipts()
        {
            receiptList = new HashSet<Receipt>();
        }

        /// <summary>
        /// Creates a new AccountsManager 
        /// </summary>
        /// <param name="receiptList"></param>
        public void Save(string Account, List<Receipt> receiptList)
        {
            AMS.Data.GobalManager.SuspendEvents();
            AccountsManager ac = new AccountsManager();
            ac.GetReceiptData();

            foreach (var i in receiptList)
                ac.SetRecipt(i);

            ac.SaveReceipts();
            ac.SaveTransactions();

            //foreach (var r in ac.ReceiptList.Where(i => i.Account == Account))
            //{
            //    foreach (var allocation in r.ReceiptAllocationList)
            //    {
            //        var transaction = allocation.Transaction;

            //        if (transaction.ReceiptAllocationList != null)
            //        {
            //            var hasAllocation = transaction.ReceiptAllocationList.Where(i => i.ReceiptID == r.ID).FirstOrDefault();
            //            if (hasAllocation != null) transaction.ReceiptAllocationList.Remove(hasAllocation);
            //        }

            //        transaction.ReceiptAllocationList.Add(allocation);
            //        transaction.Save("Receipt " + r.ID + " allocated", true, true);
            //    }
            //}
            AMS.Data.GobalManager.ResumeEvents();
            if (Saved_Event != null) Saved_Event(this, EventArgs.Empty);
        }

        public bool SaveReceipts()
        {
            AMS.Data.GobalManager.SuspendEvents();

            foreach (var i in receiptList.Where(x => x.ID == null || x.ID.Contains("Temp") || x.BeingProcessed))
            {
                if (i.ID == null || i.ID.Contains("Temp"))
                {
                    i.ID = AMS.Data.Keys.UserPKManager.NewUserPK(AMS.Data.Keys.KeyType.Receipt);
                    AMS.Data.Keys.UserPKManager.UpdatePk(AMS.Data.Keys.KeyType.Receipt, i.ID);
                }

                i.BeingProcessed = false;
            }

            bool saved = AMS.IO.XML_v1.Writter<List<Receipt>>(receiptList.ToList(), ReceiptsFileName, "Saving Receipt List", true);
            AMS.Data.GobalManager.ResumeEvents();

            if (saved && Saved_Event != null) Saved_Event(this, EventArgs.Empty);
            return saved;
        }

        public void SaveTransactions()
        {
            AMS.Data.GobalManager.SuspendEvents();

            var transList = new HashSet<string>();

            // Compare to hard drive data
            DataManager<Transaction> existingTransactionManager = new DataManager<Transaction>(DataType.Transaction);

            foreach (var r in receiptList)
            {
                foreach (var allocation in r.ReceiptAllocationList)
                {
                    try
                    {
                        var transaction = DMS.TransactionManager.GetData(i => i.ID == allocation.TransactionID);
                        var existingTrans = existingTransactionManager.GetData(i => i.ID == allocation.TransactionID);

                        bool updateTransation = true;

                        if (existingTrans.ReceiptAllocationList != null)
                        {
                            var queryAllocation = (from i in existingTrans.ReceiptAllocationList
                                                   where i.ReceiptID == r.ID && i.Amount == allocation.Amount
                                                   select i).FirstOrDefault();

                            if (queryAllocation != null) updateTransation = false;
                        }

                        if (updateTransation)
                        {
                            if (transaction.ReceiptAllocationList != null)
                            {
                                var hasAllocation = transaction.ReceiptAllocationList.Where(i => i.ReceiptID == r.ID).FirstOrDefault();
                                if (hasAllocation != null) transaction.ReceiptAllocationList.Remove(hasAllocation);
                            }

                            transaction.ReceiptAllocationList.Add(allocation);

                            transaction.Save("Receipt " + r.ID + " allocated", true, true);
                        }
                    }
                    catch (Exception ex)
                    {
                        AMS.MessageBox_v2.Show("There is a problem with the receipt/transaction allocation\r\n" +
                            "Receipt: " + allocation.ReceiptID + "\r\n" +
                            "Transaction: " + allocation.TransactionID + "\r\n\r\n" + ex.Message);
                    }
                }
            }

            AMS.Data.GobalManager.ResumeEvents();

            if (Saved_Event != null) Saved_Event(this, EventArgs.Empty);
        }

        private bool LinkTransactions()
        {
            #region Validate

            if (TransactionList == null || TransactionList.Count == 0)
            {
                AMS.MessageBox_v2.Show("No transactions were selected", 1500);
                return false;
            }

            if (Receipt.DateFinalized > new DateTime(1900, 1, 1) && !(Receipt.ReceiptAllocationList == null || Receipt.ReceiptAllocationList.Count == 0))
            {
                if (AMS.MessageBox_v2.Show("This receipt '" + Receipt.ID + "' has already been allocated, would you like to re-allocate?", AMS.MessageType.Question) == AMS.MessageOut.YesOk)
                {
                    foreach (var trans in Receipt.ReceiptAllocationList)
                    {
                        Receipt.Unlink(trans.TransactionID);
                    }

                    Receipt.ReceiptAllocationList = new HashSet<ReceiptAllocation>();
                    Receipt.DateFinalized = new DateTime();
                }
                else return false;
            }

            #endregion

            try
            {
                // Processing per single Receipt, but can have multiple transactions
                decimal receiptAmountRemaining = Receipt.Amount;

                var newAllocationList = new HashSet<ReceiptAllocation>();

                TransactionList = TransactionList.OrderBy(d => d.TransactionDate).ToList();
                decimal transTotal = TransactionList.Select(i => i.Total).Sum();

                foreach (var transacion in TransactionList)
                {
                    Receipt.Account = transacion.Account;
                    transacion.BeingProcessed = true;

                    bool isUSD = transacion.Currency == "USD";
                    //decimal usdFactor = (decimal)transacion.Total / transTotal;
                    decimal usdFactor = (decimal)Receipt.Amount / transTotal;

                    if (receiptAmountRemaining > 0 || receiptAmountRemaining < -1)
                    {
                        decimal allocatedAmount = 0m;

                        // Get the remaining amount from either one of the transactions, or the receipt
                        // if the Receipt.Amount is less that 0, then it is a credit note
                        if (receiptAmountRemaining - transacion.TotalDue > 0 || Receipt.Amount < 0) allocatedAmount = isUSD ? Receipt.Amount * usdFactor : transacion.TotalDue;
                        else allocatedAmount = receiptAmountRemaining;

                        #region Allocate transactions and receipt

                        var allocation = new ReceiptAllocation();
                        allocation.TransactionID = transacion.ID;
                        allocation.ReceiptID = Receipt.ID;
                        allocation.Amount = allocatedAmount;

                        if (isUSD)
                        {
                            decimal forex = 0;
                            try { forex = Convert.ToDecimal(transacion.Forex); }
                            catch { throw new Exception("Could not convert the forex value."); }

                            allocation.CurrencyAdjustment = allocatedAmount - transacion.TotalDue * forex;
                        }

                        newAllocationList.Add(allocation);
                        transacion.ReceiptAllocationList.Add(allocation);

                        #endregion

                        transacion.CalculateTotals();  // Refresh control
                        receiptAmountRemaining -= allocatedAmount;
                    }
                }

                Receipt.ReceiptAllocationList = newAllocationList;
                Receipt.DateFinalized = DateTime.Now;

                // Finally Fire Event to say the Receipt has been processed
                if (ReceiptProcessed_Event != null) ReceiptProcessed_Event(this, EventArgs.Empty);

                return true;
            }
            catch (Exception ex) { AMS.MessageBox_v2.Show("Could not proceed with Receipt " + Receipt.ID + "\r\n\r\n" + ex.Message + "\r\n" + ex.InnerException, AMS.MessageType.Error); return false; }
        }

        public void SetRecipt(Receipt Receipt)
        {
            if (Receipt == null) Receipt = new Receipt();

            var queryReceipt = (from i in receiptList.ToList()
                                where i.ID == Receipt.ID
                                select i).FirstOrDefault();

            if (queryReceipt != null)
            {
                queryReceipt.Account = Receipt.Account;
                queryReceipt.Amount = Receipt.Amount;
                queryReceipt.BeingProcessed = Receipt.BeingProcessed;
                queryReceipt.BeingProcessedReference = Receipt.BeingProcessedReference;
                queryReceipt.DateFinalized = Receipt.DateFinalized;
                queryReceipt.Description = Receipt.Description;
                queryReceipt.ID = Receipt.ID;
                queryReceipt.Notes = Receipt.Notes;
                queryReceipt.ProcessType = Receipt.ProcessType;
                queryReceipt.Profit = Receipt.Profit;
                foreach (var i in Receipt.ReceiptAllocationList)
                    queryReceipt.ReceiptAllocationList.Add(i);
                queryReceipt.ReceiptDate = Receipt.ReceiptDate;
                queryReceipt.Tithe = Receipt.Tithe;
            }
            else
                receiptList.Add(Receipt);

            this.Receipt = Receipt;
        }

        public void SetTransactions(List<Transaction> TransactionList)
        {
            if (TransactionList == null) TransactionList = new List<Transaction>();
            this.TransactionList = TransactionList;
        }

        public void LinkTransactions(Transaction Transaction, Receipt Receipt)
            => LinkTransactions(new List<Transaction> { Transaction }, Receipt);

        public void LinkTransactions(List<Transaction> TransactionList, Receipt Receipt)
        {
            SetTransactions(TransactionList);
            SetRecipt(Receipt);
            LinkTransactions();
        }

        public void RevertData()
        {
            TransactionList = null;
            Receipt = null;
            receiptList = null;

            GetReceiptData();
            DMS.TransactionManager.LoadData();

            if (ReceiptProcessed_Event != null) ReceiptProcessed_Event(this, EventArgs.Empty);
        }

        public void AddReceipt()
        {
            if (receiptList == null) receiptList = new HashSet<Accounts.Receipt>();
            receiptList.Add(new Receipt()
            {
                ID = $"Temp {receiptList.Count}"
            });
            SaveReceipts();
        }

        public void AddReceipt(Accounts.Receipt newReceipt)
        {
            receiptList.Add(newReceipt);
            ReceiptAdded?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Processes all receipts without accounts allocated
        /// </summary>
        public void ProcessReceipts()
        {
            string header = "Processing Receipts without Accounts.";
            string message = "";
            string update = "";
            HashSet<string> ignoredWords = new HashSet<string>();

            HashSet<string> ignoreList = new HashSet<string>(DMS.ProcessPreferencesManager.WordList);

            AMS.MessageBox_v2.ShowProcess("");

            // Iterate each payment
            int nr = 0;
            var queryReceiptList = receiptList.Where(i => string.IsNullOrEmpty(i.Account));
            foreach (var receipt in queryReceiptList)
            {
                nr++;
                // Using bool to know which client to refer to
                // 1. Transaction
                // 2. Account
                // 3. ClientName
                // 4. Keyword
                // 5. Product
                // 6. Client's Note

                string account = "";
                string reference = "";
                string multiRefrence = "";

                message = receipt.ID + " - " + receipt.Description + " - " + receipt.Amount;
                AMS.MessageBox_v2.ShowProcess(header + "\r\n\r\n" + message + "\r\n" + update, nr, queryReceiptList.Count());

                #region Possible Transactions based on price and date

                if (receipt.Amount != 0 && receipt.ReceiptDate > new DateTime(1900, 1, 1))
                {
                    var queryTransList = DMS.TransactionManager.GetDataList(i =>
                        i.Type != TransactionType.Proforma &&
                        (i.TotalDue == receipt.Amount || i.TotalDue == receipt.Amount + 0.01m || i.TotalDue == receipt.Amount - 0.01m) &&
                        i.TransactionDate > receipt.ReceiptDate.AddMonths(-2) &&
                        i.TransactionDate < receipt.ReceiptDate.AddMonths(2));

                    if (queryTransList != null && queryTransList.Count == 1)
                    {
                        account = queryTransList[0].Account;
                        queryTransList[0].BeingProcessed = true;
                        var list = new List<Transaction>();
                        list.Add(queryTransList[0]);
                        LinkTransactions(list, receipt);

                        reference = "Single Transaction " + queryTransList[0].ID;
                    }

                    if (queryTransList != null && queryTransList.Count > 1)
                    {
                        foreach (var i in queryTransList)
                            multiRefrence += "Multi - " + i.Client.Name + " [" + i.ID + "]\r\n";
                    }

                    if (!string.IsNullOrEmpty(account))
                    {
                        receipt.Account = account;
                        receipt.BeingProcessedReference = reference;
                    }
                }


                #endregion

                #region Interperate Description for Transaction data

                if (receipt.Description != null)
                {
                    var wordList = new HashSet<string>();
                    wordList.Add(receipt.Description.Trim());

                    foreach (var word in receipt.Description.Split(' '))
                        wordList.Add(word.Trim());

                    foreach (var word in wordList)
                    {
                        #region Interprate Words

                        var queryIgnoreList = (from i in ignoreList
                                               where i.Trim().ToUpper() == word.Trim().ToUpper()
                                               select i).FirstOrDefault();

                        if (queryIgnoreList != null) ignoredWords.Add(word);

                        if (!string.IsNullOrEmpty(word) && word.Count() > 2 && queryIgnoreList == null)
                        {
                            try
                            {
                                receipt.BeingProcessed = true;

                                // Transaction
                                if (string.IsNullOrEmpty(account))
                                {
                                    var queryTransaction = DMS.TransactionManager.GetData(i => i.ID.ToLower() == word.Trim().ToLower() && i.Type != TransactionType.Proforma);
                                    if (queryTransaction != null)
                                    {
                                        account = queryTransaction.Account;
                                        queryTransaction.BeingProcessed = true;
                                        var list = new List<Transaction>();
                                        list.Add(queryTransaction);
                                        LinkTransactions(list, receipt);

                                        reference = "Transaction " + queryTransaction.ID + " [" + word + "]";
                                    }
                                }
                            }
                            catch { }
                        }

                        #endregion
                    }
                }

                #endregion

                #region Intrpate Description

                if (receipt.Description != null)
                {
                    var wordList = new HashSet<string>();
                    wordList.Add(receipt.Description.Trim());

                    foreach (var word in receipt.Description.Split(' '))
                        wordList.Add(word.Trim());

                    foreach (var word in wordList)
                    {
                        #region Interprate Words

                        var queryIgnoreList = (from i in ignoreList
                                               where i.Trim().ToUpper() == word.Trim().ToUpper()
                                               select i).FirstOrDefault();

                        if (!string.IsNullOrEmpty(word) && word.Count() > 2 && queryIgnoreList == null)
                        {
                            try
                            {
                                receipt.BeingProcessed = true;
                                // Using bool to know which client to refer to
                                // 1. Transaction
                                // 2. Account
                                // 3. ClientName
                                // 4. Keyword
                                // 5. Product
                                // 6. Client's Note

                                // Check filters
                                // Account
                                if (string.IsNullOrEmpty(account))
                                {
                                    var queryClientAccount = (from i in DMS.ClientManager.GetDataList()
                                                              where i.Account.Trim().ToUpper() == word.Trim().ToUpper()
                                                              select i).FirstOrDefault();
                                    if (queryClientAccount != null)
                                    {
                                        account = queryClientAccount.Account;
                                        reference = "Client Account [" + word + "]";
                                    }
                                }

                                // ClientName
                                if (string.IsNullOrEmpty(account))
                                {
                                    var queryClientName = (from i in DMS.ClientManager.GetDataList()
                                                           where i.Name.Trim().ToUpper().Contains(word.Trim().ToUpper())
                                                           select i).FirstOrDefault();

                                    if (queryClientName != null)
                                    {
                                        account = queryClientName.Account;
                                        reference = "Client Name [" + word + "]";
                                    }
                                }

                                // Keyword
                                if (string.IsNullOrEmpty(account))
                                {
                                    var queryKeyword = (from i in DMS.KeywordList
                                                        where i.Keywords != null && i.Keywords.ToUpper().Contains(word.ToUpper().Trim())
                                                        select i).FirstOrDefault();

                                    if (queryKeyword != null)
                                    {
                                        account = queryKeyword.Account;
                                        reference = "Client Keyword [" + word + "]";
                                    }
                                }

                                // Product
                                if (string.IsNullOrEmpty(account))
                                {
                                    var queryProduct = DMS.ProductManager.GetData(i => i.Name.ToLower() == word.Trim().ToLower());
                                    if (queryProduct != null)
                                    {
                                        account = queryProduct.Account;
                                        reference = "Product [" + word + "]";
                                    }
                                }

                                // Client Notes
                                if (string.IsNullOrEmpty(account))
                                {
                                    //var queryNotes = DMS.ClientManager.GetData(i => i.Notes != null && i.Notes.ToLower().Contains(word.Trim().ToLower()));
                                    //if (queryNotes != null) 
                                    //    account = queryNotes.Account;
                                }
                            }
                            catch { }
                        }

                        #endregion
                    }
                }

                #endregion

                update = "Not found";
                if (!string.IsNullOrEmpty(account)) update = "'" + receipt.Description.Trim() + "' found in " + account;

                if (!string.IsNullOrEmpty(account))
                {
                    receipt.Account = account;
                    receipt.BeingProcessedReference = reference;
                }

                if (!string.IsNullOrEmpty(multiRefrence)) receipt.BeingProcessedReference = receipt.BeingProcessedReference + "\r\n\r\n" + multiRefrence;

                AMS.MessageBox_v2.ShowProcess(header + "\r\n\r\n" + message + "\r\n" + update, nr, queryReceiptList.Count());
            }


            string ss = "";
            ignoredWords.ToList().ForEach(i => ss += i + "\r\n");

            //if (!string.IsNullOrEmpty(ss))
            //    AMS.MessageBox_v2.Show($"These words were ignored:\r\n\r\n{ss}");

            AMS.MessageBox_v2.EndProcess();
        }
    }
}