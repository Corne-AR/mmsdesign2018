using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Search
{
    /// <summary>
    /// Responsible for finding associated data links between different data types
    /// ex: Client Id with associated transactions and receipts inside the accounts manager
    /// </summary>
    public class SearchLinkManager
    {
        public event EventHandler Client_SearchLink;
        public event EventHandler Transaction_SearchLink;
        //public event EventHandler Person_SeachLink;
        public event EventHandler Receipt_SeachLink;

        public HashSet<Data.Transactions.Transaction> TransactionList;
        public HashSet<Data.Accounts.Receipt> ReceiptList;
        public HashSet<Data.People.Client> ClientList;

        // Methods

        public void SetReceipt(Data.Accounts.Receipt Receipt)
        {
            // Client
            ClientList = new HashSet<Data.People.Client>();

            var clientList = DMS.ClientManager.GetDataList(i => i.Account == Receipt.Account);
            foreach (var i in clientList)
                ClientList.Add(i);

            if (Client_SearchLink != null) Client_SearchLink(this, EventArgs.Empty);

            // Transactions
            TransactionList = new HashSet<Data.Transactions.Transaction>();

            var searchList = DMS.TransactionManager.GetDataList(i => i.ReceiptAllocationList != null &&
                (i.ReceiptAllocationList.Where(qi => qi.ReceiptID == Receipt.ID).Count() > 0));

            foreach (var i in searchList)
                TransactionList.Add(i);

            if (Transaction_SearchLink != null) Transaction_SearchLink(this, EventArgs.Empty);
        }

        public void SetClient(Data.People.Client Client)
        {
            if (Client == null) return;

            // Transactions
            TransactionList = new HashSet<Data.Transactions.Transaction>();

            var transList = DMS.TransactionManager.GetDataList(i => i.Account == Client.Account);

            foreach (var i in transList)
                TransactionList.Add(i);

            if (Transaction_SearchLink != null) Transaction_SearchLink(this, EventArgs.Empty);

            // Receipts
            ReceiptList = new HashSet<Data.Accounts.Receipt>();

            var receiptList = DMS.AccountsManager.ReceiptList.Where(i => i.Account == Client.Account);

            foreach (var i in receiptList)
                ReceiptList.Add(i);

            if (Receipt_SeachLink != null) Receipt_SeachLink(this, EventArgs.Empty);
        }

        public void SetTransacion(Data.Transactions.Transaction Transaction)
        {
            // Client
            ClientList = new HashSet<Data.People.Client>();

            var clientList = DMS.ClientManager.GetDataList(i => i.Account == Transaction.Account);
            foreach (var i in clientList)
                ClientList.Add(i);

            if (Client_SearchLink != null) Client_SearchLink(this, EventArgs.Empty);

            // Receipts
            ReceiptList = new HashSet<Data.Accounts.Receipt>();

            var receiptList = DMS.AccountsManager.ReceiptList.Where(i => i.ReceiptAllocationList != null &&
                (i.ReceiptAllocationList.Where(qi => qi.TransactionID == Transaction.ID).Count() > 0));

            foreach (var i in receiptList)
                ReceiptList.Add(i);

            if (Receipt_SeachLink != null) Receipt_SeachLink(this, EventArgs.Empty);
        }
    }
}