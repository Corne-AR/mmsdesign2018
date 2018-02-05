using AMS.Data.People;
using Data.People;
using Data.Products;
using Data.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class OldSearch
    {
        // Use Event handler to execute events in each control window
        // 2 Types for results. 
        //      A list of items ex: list of clients in Hermanus
        //      Most obvious/single result of search string 
        string oldAccount = "";
        int minCharacters = 3;
        string search;
        string account = "";
        public bool Filtered = true;

        public event EventHandler DoSearch_Event;
        public event EventHandler ClearSearch_Event;

        // Search Method

        public void NewSearch(string SearchString)
        {
            if (SearchString.Count() < minCharacters) return;
            
            account = "";

            if (DMS.ClientManager.CurrentData != null && oldAccount == "") oldAccount = DMS.ClientManager.CurrentData.Account;
            search = SearchString;

            // Do Search
            SearchClients();

            //if (ClientList.Count > 0) DMS.ClientManager.SetCurrent(Client);
            //else { DMS.ClientManager.SetCurrent(new Data.People.Client()); }
            //if (Client != null && Client.Account != null) account = Client.Account;

            if (account != "")
            {
                SeachTransactions();
                SearchProducts();
                SearchLog();
            }

            System.Windows.Forms.Application.DoEvents();
            DoSearch_Event?.Invoke(this, EventArgs.Empty);
            System.Windows.Forms.Application.DoEvents();
        }

        public void ClearSearch()
        {
            search = "";
            ClearSearch_Event?.Invoke(this, EventArgs.Empty);
            if (oldAccount != null && oldAccount != "") DMS.ClientManager.SetCurrent(i => i.Account == oldAccount);
        }

        private void SearchClients()
        {
            //clientList = (from i in DMS.ClientManager.GetDataList()
            //              where
            //              (i.Account != null && i.Account.ToLower().Contains(search)) ||
            //              (i.Catagory != null && i.Catagory.ToLower().Contains(search)) ||
            //              (i.Country != null && i.Country.ToLower().Contains(search)) ||
            //              (i.CurrencyUsed != null && i.CurrencyUsed.ToLower().Contains(search)) ||
            //                  // (i.DatalogIDList != null && i.DatalogIDList.Where(qi => qi.ToLower().Contains(search)).Count() > 0) ||
            //              (i.Email != null && i.Email.ToLower().Contains(search)) ||
            //              (i.Expirydate != null && string.Format("{0:dd MMMM yyyy}", i.Expirydate).ToLower().Contains(search)) ||
            //              (i.Fax != null && i.Fax.ToLower().Contains(search)) ||
            //              (i.Name != null && i.Name.ToLower().Contains(search)) ||
            //              (i.Notes != null && i.Notes.ToLower().Contains(search)) ||
            //              (i.PeopleIDList != null && i.HasPerson(search)) ||
            //              (i.PhysicalAddress != null && i.PhysicalAddress.ToLower().Contains(search)) ||
            //              (i.PostalAddress != null && i.PostalAddress.ToLower().Contains(search)) ||
            //              (i.Telephone != null && i.Telephone.ToLower().Contains(search)) ||
            //              (i.VatNr != null && i.VatNr.ToLower().Contains(search)) ||
            //              (i.VendorNr != null && i.VendorNr.ToLower().Contains(search)) ||
            //              (i.Keywords != null && i.Keywords.Contains(search)) ||
            //              (HasSearch(i.Account))
            //              select i).ToList();
        }

        private void SeachTransactions()
        {
            //var transaction = DMS.TransactionManager.GetData(i => i.Account == account && i.ID.ToLower().Contains(search));
            //var quote = DMS.QuoteManager.GetData(i => i.Account == account && i.ID.ToLower().Contains(search));

            //foreach (var i in DMS.QuoteManager.GetDataList(i => i.Account == account && i.ID.ToLower().Contains(search.ToLower())))
            //    transactionList.Add(i.Transaction);
        }

        private void SearchLog()
        {
            string invoice = "";
            string proforma = "";
            string quote = "";
            string purchaseOrder = "";

            dataLogs = new List<AMS.Data.Datalog>();
            var dmLogList = (from i in DMS.ClientManager.GetDataList(i => i.Account == account)
                             select i).FirstOrDefault().DatalogList;
            foreach (var i in dmLogList)
                dataLogs.Add(i);

            dataLogs = (from i in dataLogs
                        where
                        (i.Message.ToLower().Contains(search.ToLower())) ||
                        (invoice != "" && i.Message.ToLower().Contains(invoice.ToLower())) ||
                        (quote != "" && i.Message.ToLower().Contains(quote.ToLower())) ||
                        (proforma != "" && i.Message.ToLower().Contains(proforma.ToLower())) ||
                        (purchaseOrder != "" && i.Message.ToLower().Contains(purchaseOrder.ToLower()))
                        select i).ToList();

        }

        private void SearchProducts()
        {
        }

        // Search Results

        private List<Client> clientList = new List<Client>();
        public List<Client> ClientList
        {
            get
            {
                return clientList;
            }
        }
        public Client Client
        {
            get
            {
                if (ClientList.Count > 0) return ClientList[0];
                else return null;
            }
        }

        public bool HasTransaction(List<Product> productList)
        {
            var item = productList.Where(i =>
                (i.Name != null && i.Name.ToLower().Contains(search))
                ).FirstOrDefault();

            return (item != null);
        }

        private bool HasSearch(string Account)
        {
            bool hasItem = false;

            var queryProducts = DMS.ProductManager.GetData(i => i.Account == Account && (
                (i.Name != null && i.Name.ToLower().Contains(search)) //||
                //(i.ProductName != null && i.ProductName.ToLower().Contains(search))
                ));

            var queryTransactions = DMS.TransactionManager.GetData(i => i.Account == Account && (
                (i.ID != null && i.ID.ToLower().Contains(search)) ||
                (i.LinkedIDList != null && i.LinkedIDList.Where(qi => qi.ToLower().Contains(search)).Count() > 0)
                ));

            hasItem = (queryProducts != null || queryTransactions != null);

            return hasItem;
        }

        private List<AMS.Data.Datalog> dataLogs;
        public List<AMS.Data.Datalog> DataLogs
        {
            get
            {
                return dataLogs;
            }
        }

        public bool HasProduct(Product product)
        {
            var queryQuote = DMS.TransactionManager.GetData(i => i.ID.ToLower().Contains(search));
            if (queryQuote == null || queryQuote.LinkedIDList.Where(qi => qi.ToLower().Contains(search)).Count() == 0) return false;

            return (product.Name.ToLower().Contains(search));
        }
        public bool HasProduct(List<Product> productList)
        {
            bool hasProduct = false;

            foreach (var i in productList)
            {
                if (HasProduct(i)) return true;
            }

            return hasProduct;
        }

        private List<Transaction> transactionList = new List<Transaction>();
        public List<Transaction> TransactionList
        {
            get
            {
                return transactionList;
            }
        }
    }
}