using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Search
{
    public class SearchData
    {
        private Search.SearchType searchType;
        public SearchType SearchType
        {
            get { return searchType; }
            set { searchType = value; }
        }

        private SearchRange searchRange;

        public string Results { get; set; }
        public string Account { get { if (client == null)return null; return client.Account; } }
        public string ClientName { get { if (client == null)return null; return client.Name; } }
        public string Contact
        {
            get
            {
                StringBuilder contact = new StringBuilder();
                if (client == null) return null;

                if (!string.IsNullOrEmpty(client.GetMainContact.DisplayName)) contact.Append(client.GetMainContact.DisplayName);
                if (!string.IsNullOrEmpty(client.GetMainContact.ContactNumber)) contact.Append(" - " + client.GetMainContact.ContactNumber);
                else if (!string.IsNullOrEmpty(client.Telephone)) contact.Append(" - " + client.Telephone);

                return contact.ToString();
            }
        }

        // Searchable Variables

        private Data.People.Client client;
        public Data.People.Client Client { get { return client; } }

        private Products.Product product;
        public Data.Products.Product Product;
        public string ProductID { get { if (product == null) return ""; return product.ID; } }

        private Data.Quotes.Quote quote;
        public Data.Quotes.Quote Quote { get { return quote; } }
        public string QuoteID { get { if (quote == null) return ""; return quote.ID; } }

        private Data.Transactions.Transaction transaction;
        public Data.Transactions.Transaction Transaction { get { return transaction; } }
        public string TransactionID { get { if (transaction == null) return ""; return transaction.ID; } }

        private Data.Accounts.Receipt receipt;
        private Transactions.Transaction i;
        public Data.Accounts.Receipt Receipt { get { return receipt; } }
        public string ReceiptID { get { if (receipt == null) return ""; return receipt.ID; } }

        public decimal Amount { get; set; }

        // Constructors

        public SearchData(Search.SearchType SearchType)
        {
            Clear();
            this.searchType = SearchType;
        }

        public SearchData(Data.People.Client Client, Search.SearchType SearchType)
        {
            Clear();
            SetClient(Client, SearchType);
        }

        public SearchData(Data.Transactions.Transaction Transaction)
        {
            Clear();

            this.client = Transaction.Client;
            this.transaction = Transaction;
            this.searchType = Search.SearchType.Transaction;
            this.Amount = Transaction.Total;

            Results = transaction.Type + " " + transaction.ID + "  " +  "   -   " + "Due " + transaction.TotalDue;
        }

        public SearchData(Data.Accounts.Receipt Receipt)
        {
            Clear();

            this.client = Receipt.Client;
            this.receipt = Receipt;
            this.searchType = Search.SearchType.Receipt;
            this.Amount = Receipt.Amount;

            Results = "Receipt " + receipt.ID + " \"" + receipt.Description;
        }

        public SearchData(Data.Products.Product Product)
        {
            Clear();

            this.client = Product.Client;
            this.product = Product;
            this.searchType = Search.SearchType.Product;

            Results = "Product " + product.ID + " " + product.PriceExVat + "  " + product.ContentSummary;
        }

        public SearchData(Quotes.Quote Quote)
        {
            Clear();

            this.client = Quote.Client;
            this.quote = Quote;
            this.searchType = Search.SearchType.Quote;
            this.Amount = Quote.Transaction.Total;

            Results = quote.ProgressType + " " + quote.ID + " - " + string.Format("{0:dd MMM yyyy}  -  {1} {2}", quote.QuoteDate, quote.Contact, quote.Email);
        }

        public SearchData(Transactions.Transaction i, Search.SearchType searchType)
        {
            // TODO: Complete member initialization
            this.i = i;
            this.searchType = searchType;
        }

        // Methods

        /// <summary>
        /// Will Require a Clear before searching, where as the constructor will auto clear the results before searching
        /// </summary>
        public void SetClient(Data.People.Client Client, Search.SearchType SearchType)
        {
            this.client = Client;
            this.searchType = SearchType;

            if (searchType == Search.SearchType.Maintenance)
            {
                GetMaintenanceResults(client);
                Amount = client.GetMMSMaintenanceValue(1);
            }
            if (searchType == Search.SearchType.Statement)
                GetCreditResults(client);
        }

        public void SetRange(SearchRange SearchRange)
        {
            this.searchRange = SearchRange;
        }

        public bool WithinRange(DateTime date)
        {
            bool within = (searchRange == SearchRange.All);

            if (!within)
                within = searchRange == SearchRange.Month && date > DateTime.Now.AddMonths(-1);
           //CA start
                if (!within)
                within = searchRange == SearchRange.Month && date > DateTime.Now.AddMonths(-2);
            //CA end
            if (!within)
                within = searchRange == SearchRange.Today && new DateTime(date.Year, date.Month, date.Day) == new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            if (!within)
                within = searchRange == SearchRange.Week && date > DateTime.Now.AddDays(-7);
            if (!within)
                within = searchRange == SearchRange.Year && date > DateTime.Now.AddYears(-1);

            return within;
        }

        public void Clear()
        {
            client = new People.Client();
            searchType = Search.SearchType.Null;
            Results = null;
        }

        private void GetMaintenanceResults(Data.People.Client Client)
        {
            StringBuilder sb = new StringBuilder();
            string currency = Client.CurrencyUsed;
            if ((currency == null || currency == "0") && AMS.Suite.SuiteManager.Profile.ForexList != null) currency = AMS.Suite.SuiteManager.Profile.ForexList[0];

            sb.AppendFormat("Expiring: 1 {0: MMMM yyyy}", Client.Expirydate);
            sb.AppendFormat(" - Value: {0} {1:C} - {2:C}", currency, Client.GetMMSMaintenanceValue(1), Client.GetMMSMaintenanceValue(2));

            Results = sb.ToString();
        }

        private void GetCreditResults(Data.People.Client Client)
        {
            StringBuilder sb = new StringBuilder();
            string currency = Client.CurrencyUsed;
            if ((currency == null || currency == "0") && AMS.Suite.SuiteManager.Profile.ForexList != null) currency = AMS.Suite.SuiteManager.Profile.ForexList[0];


            if (client.Credit > 0)
                sb.AppendFormat("Debit: {0:C}", client.Credit);
            else
                sb.AppendFormat("Credit: {0:C}", client.Credit);

            // sb.AppendFormat(" - {0:d}",client.Metadata.EmailDate);
            var log = client.DatalogList.Where(i => i.Message == "Statement Emailed.").LastOrDefault();
            if (log != null) sb.AppendFormat(" - {0:dd MMM yyyy}", log.Created);

            Results = sb.ToString();
        }

        #region HashSet Identifier

        public override bool Equals(object obj)
        {
            var other = obj as SearchData;
            if (other == null)
            {
                return false;
            }
            if (Results == null) return false;
            return Results == other.Results;
        }

        public override int GetHashCode()
        {
            string account = "";
            if (client != null) account = client.Account;
            return (account + Results).GetHashCode();
        }

        #endregion
    }
}
