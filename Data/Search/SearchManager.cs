using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Search
{
    public class SearchManager
    {
        /// <summary>
        /// When searching for a collection of related data
        /// </summary>
        public event EventHandler SearchSummary;
        public event SearchAll All_Search;
        public event SearchProduct Product_Search;
        public event SearchClient Client_Search;
        public event SearchTransaction Transaction_Search;
        public event SearchReceipt Receipt_Search;

        public event EventHandler Clear_Search;

        private string searchString;
        private SearchType searchType;

        /// <summary>
        /// Search timer, helps with key strokes
        /// </summary>
        private System.Windows.Forms.Timer timer;

        HashSet<Data.Search.SearchData> searchDataList;

        private People.Client client;
        private List<People.Client> clientList;

        private Products.Product product;
        private List<Products.Product> productList;
        private Transactions.Transaction transaction;
        private IList<Transactions.Transaction> transactionList;
        private Accounts.Receipt recipt;
        private List<Accounts.Receipt> receiptList;
        private HashSet<People.Client> clientHashList;
        private HashSet<Products.Product> productHashList;
        private HashSet<Transactions.Transaction> transactionHashList;
        private HashSet<Accounts.Receipt> reciptHashList;
        private string summary;
        public string Summary
        {
            get
            {
                if (searchDataList != null && searchDataList.Count > 0) summary = searchDataList.Count + " Results  -  " + summary;
                return summary;
            }
        }

        // Constructors

        public SearchManager()
        {
            searchString = "";
            searchType = SearchType.Null;

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 500;
            timer.Tick += DoSearch_Event;

            SetSummary();
        }

        // Methods

        public void ClearSearch()
        {
            if (Clear_Search != null) Clear_Search(this, EventArgs.Empty);
            searchString = "";
            SetSummary();
        }

        public void DoSearch(string SearchString, SearchType SearchType)
        {
            timer.Stop();
            searchDataList = new HashSet<SearchData>();
            this.searchString = SearchString;
            this.searchString = ("" + searchString).ToLower();
            this.searchType = SearchType;

            if (string.IsNullOrEmpty(searchString))
                ClearSearch();
            else
                timer.Start();
        }

        private void DoClientSearch()
        {
            client = (from i in DMS.ClientManager.GetDataList()
                      where
                      (i.Account != null && i.Account.ToLower().Trim() == searchString.ToLower().Trim()) ||
                      (i.Catagory != null && i.Catagory.ToLower().Trim() == searchString.ToLower().Trim()) ||
                      (i.Country != null && i.Country.ToLower().Trim() == searchString.ToLower().Trim()) ||
                      (i.CurrencyUsed != null && i.CurrencyUsed.ToLower().Trim() == searchString.ToLower().Trim()) ||
                      //(i.DatalogIDList != null && i.DatalogIDList.Where(qi => qi.ToLower().Contains(searchString)).Count() > 0) ||
                      (i.Email != null && i.Email.ToLower().Trim() == searchString.ToLower().Trim()) ||
                      //(i.Expirydate != null && string.Format("{0:dd MMMM yyyy}", i.Expirydate).ToLower().Contains(searchString)) ||
                      (i.Fax != null && i.Fax.ToLower().Trim() == searchString.ToLower().Trim()) ||
                      (i.Name != null && i.Name.ToLower().Trim() == searchString.ToLower().Trim()) ||
                     (i.Notes != null && i.Notes.ToLower().Contains(searchString)) ||
                      //(i.PeopleIDList != null && i.HasPerson(searchString)) ||
                      (i.PhysicalAddress != null && i.PhysicalAddress.ToLower().Trim() == searchString.ToLower().Trim()) ||
                      (i.PostalAddress != null && i.PostalAddress.ToLower().Trim() == searchString.ToLower().Trim()) ||
                      (i.Telephone != null && i.Telephone.ToLower().Trim() == searchString.ToLower().Trim()) ||
                      (i.VatNr != null && i.VatNr.ToLower().Trim() == searchString.ToLower().Trim()) ||
                      (i.VendorNr != null && i.VendorNr.ToLower().Trim() == searchString.ToLower().Trim())
                      select i).FirstOrDefault();

            clientList = (from i in DMS.ClientManager.GetDataList()
                          where
                          (i.Account != null && i.Account.ToLower().Contains(searchString)) ||
                          (i.Catagory != null && i.Catagory.ToLower().Contains(searchString)) ||
                          (i.Country != null && i.Country.ToLower().Contains(searchString)) ||
                          (i.CurrencyUsed != null && i.CurrencyUsed.ToLower().Contains(searchString)) ||
                          // (i.DatalogIDList != null && i.DatalogIDList.Where(qi => qi.ToLower().Contains(searchString)).Count() > 0) ||
                          (i.Email != null && i.Email.ToLower().Contains(searchString)) ||
                          (i.Expirydate != null && string.Format("{0:dd MMMM yyyy}", i.Expirydate).ToLower().Contains(searchString)) ||
                          (i.Fax != null && i.Fax.ToLower().Contains(searchString)) ||
                          (i.Name != null && i.Name.ToLower().Contains(searchString)) ||
                          (i.Notes != null && i.Notes.ToLower().Contains(searchString)) ||
                          (i.PeopleIDList != null && i.HasPerson(searchString)) ||
                          (i.PhysicalAddress != null && i.PhysicalAddress.ToLower().Contains(searchString)) ||
                          (i.PostalAddress != null && i.PostalAddress.ToLower().Contains(searchString)) ||
                          (i.Telephone != null && i.Telephone.ToLower().Contains(searchString)) ||
                          (i.VatNr != null && i.VatNr.ToLower().Contains(searchString)) ||
                          (i.VendorNr != null && i.VendorNr.ToLower().Contains(searchString)) ||
                          (i.GetMMSMaintenanceValue(1).ToString().Contains(searchString.Trim())) ||
                          (i.GetMMSMaintenanceValue(2).ToString().Contains(searchString.Trim()))
                          select i).ToList();

            // Set Search Results
            if (searchType == SearchType.All || searchType == SearchType.Client)
                foreach (var i in clientList) searchDataList.Add(new SearchData(i, SearchType.Client));
        }

        private void DoProductSearch()
        {
            product = DMS.ProductManager.GetData(i => ("" + i.Name).ToUpper().Trim() == ("" + searchString).Trim().ToUpper());
            productList = DMS.ProductManager.GetDataList(i => i.Name.ToUpper().Contains(searchString.ToUpper()));

            // Set Search Results
            if (searchType == SearchType.All || searchType == SearchType.Product)
                foreach (var i in productList) searchDataList.Add(new SearchData(i));
        }

        private void DoReceiptSearch()
        {
            recipt = DMS.AccountsManager.ReceiptList.Where(i => i.ID.ToUpper().Trim() == ("" + searchString).Trim().ToUpper()).FirstOrDefault();
            if (recipt == null) recipt = DMS.AccountsManager.ReceiptList.Where(i => ("" + i.Description).ToUpper().Trim() == ("" + searchString).Trim().ToUpper()).FirstOrDefault();
            receiptList = new List<Accounts.Receipt>();
            if (recipt != null) receiptList.Add(recipt);
            receiptList.AddRange(DMS.AccountsManager.ReceiptList.Where(i => ("" + i.Description).ToUpper().Contains(searchString.ToUpper())).ToList());

            // Set Search Results
            if (searchType == SearchType.All || searchType == SearchType.Receipt)
                foreach (var i in receiptList) searchDataList.Add(new SearchData(i));
        }

        private void DoTransactionSearch()
        {
            transaction = DMS.TransactionManager.GetData(i => i.ID.ToLower().Trim().Contains(("" + searchString).Trim().ToLower()) || i.HasItem(searchString));

            if (transaction == null)
            {
                var quote = DMS.QuoteManager.GetData(i => i.ID.ToLower().Trim().Contains(("" + searchString).Trim().ToLower()));
                if (quote != null) transaction = quote.Transaction;
            }

            transactionList = (from i in DMS.TransactionManager.GetDataList()
                               where i.ID != null && i.ID.ToLower().Contains(searchString) ||
                               i.Notes != null && i.Notes.ToLower().Contains(searchString) ||
                               i.ClientRef != null && i.ClientRef.ToLower().Contains(searchString) ||
                               i.Total != 0 && i.Total.ToString().ToLower().Contains(searchString) ||
                               // i.ReceiptAllocationList != null && i.ReceiptAllocationList.Where(r => r.ReceiptID.ToLower().Contains(searchString)).Count() > 0 ||
                               i.HasItem(searchString)
                               select i).ToList();

            if (transaction != null) transactionList.Add(transaction);


            // Set Search Results
            if (searchType == SearchType.All || searchType == SearchType.Transaction || searchType == SearchType.Quote)
                foreach (var i in transactionList) searchDataList.Add(new SearchData(i));
        }

        public void DoInactiveClientSearch()
        {
            searchDataList = new HashSet<Data.Search.SearchData>();
            clientList = new List<People.Client>();
            clientHashList = new HashSet<People.Client>();

            searchString = "InActive Clients";

            var clientInActiveList = (from i in DMS.ClientManager.GetDataList()
                                      where !i.Active
                                      select i).ToList();

            // Populate the search list
            if (clientInActiveList != null)
            {
                foreach (var i in clientInActiveList)
                {
                    var search = new Data.Search.SearchData(i, SearchType.Client);
                    searchDataList.Add(search);
                    clientList.Add(i);
                }
            }

            foreach (var i in clientList)
                clientHashList.Add(i);

            SetSummary();

            if (All_Search != null) All_Search(this, new AllSearchArgs()
            {
                ClientList = clientHashList,
                SearchType = SearchType.Client,
                SearchDataList = searchDataList
            });
        }

        public void DoMaintenanceSearch()
        {
            var f = new AMS.Utilities.Forms.DatePicker("Set Start Date for Maintenance", DateTime.Now.AddDays(-30));
            f.ShowDialog();
            var startDate = f.DateTimeValue;

            f = new AMS.Utilities.Forms.DatePicker("End Range for Maintenance", DateTime.Now);
            f.DateTimeValue = DateTime.Now;
            f.ShowDialog();
            var endDate = f.DateTimeValue;

            DoMaintenanceSearch(startDate, endDate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Month">Month 0 = this Month, Month 1 = next</param>
        public void DoMaintenanceSearch(int Month)
        {
            DoMaintenanceSearch(DateTime.Now.AddMonths(Month - 1), DateTime.Now.AddMonths(Month));
        }

        public void DoMaintenanceSearch(DateTime StartDate, DateTime EndDate)
        {
            searchDataList = new HashSet<Data.Search.SearchData>();
            clientList = new List<People.Client>();

            var clientMaintenanceList = (from i in DMS.ClientManager.GetDataList()
                                         where i.Expirydate >= StartDate
                                         where i.Expirydate <= EndDate
                                         orderby i.Expirydate
                                         select i).ToList();

            // Populate the search list
            //if (clientMaintenanceList != null)
            // {
            foreach (var i in clientMaintenanceList)
            {
                var search = new Data.Search.SearchData(i, SearchType.Maintenance);
                searchDataList.Add(search);
                clientList.Add(i);
            }
            //}

            var clientHashList = new HashSet<People.Client>(clientList);

            if (All_Search != null) All_Search(this, new AllSearchArgs()
            {
                ClientList = clientHashList,
                SearchType = SearchType.Maintenance,
                SearchDataList = searchDataList
            });
        }

        public void DoStatementSearch() //Corne
        {
            searchDataList = new HashSet<Data.Search.SearchData>();
            clientList = new List<People.Client>();

            var clients = DMS.ClientManager.GetDataList()
                .Where(i => i.Credit < -5 || i.Credit > 5)
                .OrderBy(i => i.Credit)
                .ToList();

            //Populate the search list
            if (clients != null)
            {
                foreach (var i in clients)
                {
                    var search = new Data.Search.SearchData(i, SearchType.Statement);
                    searchDataList.Add(search);
                    clientList.Add(i);
                }
            }

            var clientHashList = new HashSet<People.Client>(clientList);

            if (All_Search != null) All_Search(
                this,
                new AllSearchArgs()
                {
                    ClientList = clientHashList,
                    SearchType = SearchType.Statement,
                    SearchDataList = searchDataList
                });
        }

        public void DoVendorSeach()
        {
            searchDataList = new HashSet<Data.Search.SearchData>();
            clientList = new List<People.Client>();
            clientHashList = new HashSet<People.Client>();

            searchString = "Vendor required Clients";

            var clients = (from i in DMS.ClientManager.GetDataList()
                           where i.VendorRenewal || !string.IsNullOrEmpty(i.VendorNr)
                           select i).ToList();

            // Populate the search list
            if (clients != null)
            {
                foreach (var i in clients)
                {
                    var search = new Data.Search.SearchData(i, SearchType.Client);
                    searchDataList.Add(search);
                    clientList.Add(i);
                }
            }

            foreach (var i in clientList)
                clientHashList.Add(i);

            SetSummary();

            if (All_Search != null) All_Search(this, new AllSearchArgs()
            {
                ClientList = clientHashList,
                SearchType = SearchType.Client,
                SearchDataList = searchDataList
            });
        }

        public void DoQuoteChase()
        {
            var f = new AMS.Utilities.Forms.DatePicker("Set Start Date for Quotes", DateTime.Now.AddDays(-30));
            f.ShowDialog();
            var startDate = f.DateTimeValue;

            f = new AMS.Utilities.Forms.DatePicker("End Range for Quotes", DateTime.Now);
            f.DateTimeValue = DateTime.Now;
            f.ShowDialog();
            var endDate = f.DateTimeValue;

            DoQuoteChase(startDate, endDate);
        }

        public void DoQuoteChase(DateTime StartDate, DateTime EndDate)
        {
            searchDataList = new HashSet<Data.Search.SearchData>();
            clientList = new List<People.Client>();
            clientHashList = new HashSet<People.Client>();

            var quoteList = (from i in DMS.QuoteManager.GetDataList()
                             where
                             i.QuoteDate > StartDate &&
                             i.QuoteDate < EndDate
                             && i.ProgressType != Quotes.ProgressType.Finalized
                             && i.LinkedIDList.Count == 1
                             select i).ToList();


            // Populate the search list
            if (quoteList != null)
            {
                quoteList = quoteList.OrderBy(i => i.ID).OrderBy(i => i.Client.Name).ToList();
                foreach (var i in quoteList)
                {
                    var search = new Data.Search.SearchData(i);
                    searchDataList.Add(search);
                    clientList.Add(i.Client);
                }
            }

            foreach (var i in clientList)
                clientHashList.Add(i);

            SetSummary();

            if (All_Search != null) All_Search(this, new AllSearchArgs()
            {
                ClientList = clientHashList,
                SearchType = SearchType.Quote,
                SearchDataList = searchDataList
            });
        }

        public void DoQuotesNoQuoteDate()
        {
            searchDataList = new HashSet<Data.Search.SearchData>();
            clientList = new List<People.Client>();
            clientHashList = new HashSet<People.Client>();

            var quoteList = (from i in DMS.QuoteManager.GetDataList()
                             where
                             i.QuoteDate < new DateTime(2000, 1, 1)
                             && i.ProgressType != Quotes.ProgressType.Finalized
                             select i).ToList();


            // Populate the search list
            if (quoteList != null)
            {
                quoteList = quoteList.OrderBy(i => i.ID).OrderBy(i => i.Client.Name).ToList();
                foreach (var i in quoteList)
                {
                    var search = new Data.Search.SearchData(i);
                    searchDataList.Add(search);
                    clientList.Add(i.Client);
                }
            }

            foreach (var i in clientList)
                clientHashList.Add(i);

            SetSummary();

            if (All_Search != null) All_Search(this, new AllSearchArgs()
            {
                ClientList = clientHashList,
                SearchType = SearchType.Quote,
                SearchDataList = searchDataList
            });
        }

        private void CheckClientOrder(List<Data.People.Client> clientList)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var i in clientList)
            {
                sb.AppendLine(i.Account + " " + i.Name);
            }
            AMS.MessageBox_v2.Show(sb.ToString());
        }

        public void DoTransactionLinkSearch(Transactions.Transaction transaction)
        {
            var searchDataList = new HashSet<Data.Search.SearchData>();
            var clientList = new HashSet<People.Client>();

            HashSet<Transactions.Transaction> transactionList = new HashSet<Transactions.Transaction>();
            HashSet<Transactions.Transaction> wtf_TransactionList = new HashSet<Transactions.Transaction>();

            foreach (var i in transaction.LinkedIDList)
            {
                var trans = DMS.TransactionManager.GetData(qi => qi.ID == i);
                if (trans != null) transactionList.Add((Data.Transactions.Transaction)trans.Clone());
            }

            // Get a list of un-intended transactions, this should ideally by 0
            foreach (var trans in transactionList)
            {
                foreach (var id in transaction.LinkedIDList)
                {
                    var queryTrans = DMS.TransactionManager.GetData(qi => qi.ID == id);
                    var queryList = transactionList.Where(qi => qi.ID == id).FirstOrDefault();

                    if (queryTrans != null && queryTrans.ID != queryList.ID)
                        wtf_TransactionList.Add((Data.Transactions.Transaction)queryTrans.Clone());
                }
            }

            // Add those WTF to the list
            if (wtf_TransactionList.Count > 0)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var i in wtf_TransactionList)
                {
                    transactionList.Add(i);
                    sb.AppendLine(i.ID);
                }

                AMS.MessageBox_v2.Show("The following transactions have questionable links, please review them\r\n\r\n" + sb.ToString());
            }

            // Finally send them to the search panel

            foreach (var trans in transactionList)
            {
                searchDataList.Add(new SearchData(trans));

                // Create Receipt List
                foreach (var receipt in trans.ReceiptList())
                    searchDataList.Add(new SearchData(receipt));
            }

            if (All_Search != null) All_Search(this, new AllSearchArgs()
            {
                ClientList = clientList,
                SearchType = SearchType.Transaction,
                SearchDataList = searchDataList
            });
        }

        public void DoTransactionLinkSearch(Accounts.Receipt receipt)
        {
            var searchDataList = new HashSet<Data.Search.SearchData>();
            var clientList = new HashSet<People.Client>();

            HashSet<Transactions.Transaction> transactionList = new HashSet<Transactions.Transaction>();
            HashSet<Transactions.Transaction> wtf_TransactionList = new HashSet<Transactions.Transaction>();

            foreach (var queryReceipt in receipt.ReceiptAllocationList)
            {
                var transaction = queryReceipt.Transaction;
                {
                    foreach (var i in transaction.LinkedIDList)
                    {
                        var trans = DMS.TransactionManager.GetData(qi => qi.ID == i);
                        if (trans != null) transactionList.Add((Data.Transactions.Transaction)trans.Clone());
                    }

                    // Get a list of un-intended transactions, this should ideally by 0
                    foreach (var trans in transactionList)
                    {
                        foreach (var id in transaction.LinkedIDList)
                        {
                            var queryTrans = DMS.TransactionManager.GetData(qi => qi.ID == id);
                            var queryList = transactionList.Where(qi => qi.ID == id).FirstOrDefault();

                            if (queryTrans != null && queryTrans.ID != queryList.ID)
                                wtf_TransactionList.Add((Data.Transactions.Transaction)queryTrans.Clone());
                        }
                    }

                    // Add those WTF to the list
                    if (wtf_TransactionList.Count > 0)
                    {
                        StringBuilder sb = new StringBuilder();

                        foreach (var i in wtf_TransactionList)
                        {
                            transactionList.Add(i);
                            sb.AppendLine(i.ID);
                        }

                        AMS.MessageBox_v2.Show("The following transactions have questionable links, please review them\r\n\r\n" + sb.ToString());
                    }

                    // Finally send them to the search panel

                    foreach (var trans in transactionList)
                    {
                        searchDataList.Add(new SearchData(trans));

                        // Create Receipt List
                        foreach (var r in trans.ReceiptList())
                            searchDataList.Add(new SearchData(r));
                    }
                }
            }

            if (All_Search != null) All_Search(this, new AllSearchArgs()
            {
                ClientList = clientList,
                SearchType = SearchType.Transaction,
                SearchDataList = searchDataList
            });
        }

        private void SetSummary()
        {
            summary = "";

            if (!string.IsNullOrEmpty(searchString)) summary = "Searching: " + searchString;

            if (client != null) summary += "  -  " + client.Name;
            if (clientHashList != null && clientHashList.Count > 0) summary += "  -  " + clientHashList.Count + "/" + DMS.ClientManager.GetDataList().Count + " Possible Clients";

            if (product != null) summary += "  -  Product " + product.Name;
            if (productHashList != null && productHashList.Count > 0) summary += "  -  " + productHashList.Count + "/" + DMS.ProductManager.GetDataList().Count + " Possible Products";

            if (transaction != null) summary += "  -  Transaction " + transaction.ID;
            if (transactionHashList != null && productHashList.Count > 0) summary += "  -  " + transactionHashList.Count + "/" + DMS.TransactionManager.GetDataList().Count + " Possible Transactions";

            if (SearchSummary != null) SearchSummary(this, EventArgs.Empty);
        }

        // Events

        private void DoSearch_Event(object sender, EventArgs e)
        {
            timer.Stop();

            AMS.MessageBox_v2.ShowProcess("Searching: " + searchString);

            searchDataList = new HashSet<Data.Search.SearchData>();

            DoClientSearch();
            DoProductSearch();
            DoTransactionSearch();
            DoReceiptSearch();

            clientHashList = new HashSet<People.Client>();
            productHashList = new HashSet<Products.Product>();
            transactionHashList = new HashSet<Transactions.Transaction>();
            reciptHashList = new HashSet<Accounts.Receipt>();

            #region Create HashList

            if (clientList != null)
                foreach (var i in clientList)
                    clientHashList.Add(i);

            if (productHashList != null)
                foreach (var i in productList)
                {
                    clientHashList.Add(i.Client);
                    productHashList.Add(i);
                }

            if (transactionList != null)
                foreach (var i in transactionList)
                {
                    clientHashList.Add(i.Client);
                    transactionHashList.Add(i);
                }

            if (receiptList != null)
                foreach (var i in receiptList)
                {
                    clientHashList.Add(i.Client);
                    reciptHashList.Add(i);
                }

            #endregion

            #region Build Search List from HashLists

            //foreach (var i in clientHashList)
            //{
            //    searchDataList.Add(new SearchData(i, SearchType.Client));
            //}

            //foreach (var i in productHashList)
            //{
            //    searchDataList.Add(new SearchData(i));
            //}

            //foreach (var i in transactionHashList)
            //{
            //    searchDataList.Add(new SearchData(i));
            //}

            //foreach (var i in reciptHashList)
            //{
            //    searchDataList.Add(new SearchData(i));
            //}

            #endregion

            #region Fire required Events

            // if (searchType == SearchType.All)
            {
                if (All_Search != null) All_Search(this, new AllSearchArgs()
                {
                    SearchString = searchString,
                    SearchType = searchType,
                    ClientList = clientHashList,
                    SearchDataList = searchDataList
                });
            }

            if (searchType == SearchType.Client)
            {
                if (Client_Search != null) Client_Search(this, new ClientSearchArgs()
                {
                    Client = client,
                    ClientList = clientHashList,
                    SearchString = searchString
                });
            }

            if (searchType == SearchType.Product)
            {
                if (Client_Search != null) Client_Search(this, new ClientSearchArgs()
                {
                    Client = client,
                    ClientList = clientHashList,
                    SearchString = searchString
                });

                if (Product_Search != null) Product_Search(this, new ProductSearchArgs()
                {
                    Product = product,
                    ProductList = productHashList,
                    SearchString = searchString,
                });
            }

            if (searchType == SearchType.Transaction || searchType == SearchType.All)
            {
                if (Client_Search != null) Client_Search(this, new ClientSearchArgs()
                {
                    Client = client,
                    ClientList = clientHashList,
                    SearchString = searchString
                });

                if (Transaction_Search != null) Transaction_Search(this, new TransactionSearchArgs()
                {
                    Transaction = transaction,
                    TransactionList = transactionHashList,
                    SearchString = searchString,
                });
            }

            if (searchType == SearchType.Receipt || searchType == SearchType.All)
            {
                if (Client_Search != null) Client_Search(this, new ClientSearchArgs()
                {
                    Client = client,
                    ClientList = clientHashList,
                    SearchString = searchString
                });

                if (Receipt_Search != null) Receipt_Search(this, new ReciptSearchArgs()
                {
                    Receipt = recipt,
                    ReceiptList = reciptHashList,
                    SearchString = searchString,
                });
            }

            #endregion

            SetSummary();

            AMS.MessageBox_v2.EndProcess();
        }

    }
}