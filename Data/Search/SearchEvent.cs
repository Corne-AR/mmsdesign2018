using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Search
{
    public delegate void SearchAll(object sender, AllSearchArgs e);
    public delegate void SearchProduct(object sender, ProductSearchArgs e);
    public delegate void SearchClient(object sender, ClientSearchArgs e);
    public delegate void SearchReceipt(object sender, ReciptSearchArgs e);
    public delegate void SearchTransaction(object sender, TransactionSearchArgs e);

    public class AllSearchArgs : EventArgs
    {
        public string SearchString { get; set; }
        public SearchType SearchType { get; set; }

        public HashSet<Data.Transactions.Transaction> TransactionList { get; set; }
        public HashSet<Data.Accounts.Receipt> ReceiptList { get; set; }
        public HashSet<Data.People.Client> ClientList { get; set; }
       
        public HashSet<Data.Search.SearchData> SearchDataList { get; set; }
    }

    public class ProductSearchArgs : EventArgs
    {
        public string SearchString { get; set; }
        public Products.Product Product { get; set; }
        public HashSet<Data.Products.Product> ProductList { get; set; }
        public SearchType SearchType { get { return Search.SearchType.Product; } }
    }

    public class ReciptSearchArgs : EventArgs
    {
        public string SearchString { get; set; }
        public Accounts.Receipt Receipt { get; set; }
        public HashSet<Accounts.Receipt> ReceiptList { get; set; }
        public SearchType SearchType { get { return Search.SearchType.Receipt; } }
    }

    public class TransactionSearchArgs : EventArgs
    {
        public string SearchString { get; set; }
        public Transactions.Transaction Transaction { get; set; }
        public HashSet<Transactions.Transaction> TransactionList { get; set; }
        public SearchType SearchType { get { return Search.SearchType.Transaction; } }
    }

    public class ClientSearchArgs : EventArgs
    {
        public string SearchString { get; set; }
        public Data.People.Client Client { get; set; }
        public HashSet<Data.People.Client> ClientList { get; set; }
        public SearchType SearchType { get { return Search.SearchType.Client; } }
    }
}