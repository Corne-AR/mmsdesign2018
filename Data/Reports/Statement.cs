using AMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Reports
{
    public class Statement
    {
        public Data.People.Client Client { get; }

        public decimal? Total => itemList?.LastOrDefault()?.Total;
        public DateTime? FirstDate => itemList?.FirstOrDefault()?.Date;
        public DateTime? LastDate => itemList?.FirstOrDefault()?.Date;

        public IEnumerable<StatementItem> ItemList => itemList.AsEnumerable();
        private HashSet<StatementItem> itemList;

        public IEnumerable<Transactions.Transaction> InvoiceList => invoiceList.AsReadOnly();
        private List<Transactions.Transaction> invoiceList;

        /*
        public decimal TotalDebit
        {
            get
            {
                decimal value = 0m;

                foreach (var i in itemList)
                    value += i.Debit;

                return value;
            }
        }
        public decimal TotalCredit
        {
            get
            {
                decimal value = 0m;

                foreach (var i in itemList)
                    value += i.Credit;

                return value;
            }
        }
        public decimal TotalDue
        {
            get
            {
                decimal value = TotalDebit - TotalCredit;
                return value;
            }
        }
        public decimal Total30Day
        {
            get
            {
                decimal value = 0m;

                var iList = (from i in itemList
                             where i.Date >= DateTime.Now.AddDays(-30)
                             select i).ToList();

                foreach (var i in iList)
                {
                    value += i.Debit;
                    value -= i.Credit;
                }

                return value;
            }

        }
        public decimal Total60Day
        {
            get
            {
                decimal value = 0m;


                var ilist = (from i in itemList
                             where i.Date >= DateTime.Now.AddDays(-60)
                             where i.Date <= DateTime.Now.AddDays(-30)
                             select i).ToList();

                foreach (var i in ilist)
                {
                    value += i.Debit;
                    value -= i.Credit;
                }

                return value;
            }
        }
        public decimal Total90Day
        {
            get
            {
                decimal value = 0m;

                var iList = (from i in itemList
                             where i.Date >= DateTime.Now.AddDays(-90)
                             where i.Date <= DateTime.Now.AddDays(-60)
                             select i).ToList();

                foreach (var i in iList)
                {
                    value += i.Debit;
                    value -= i.Credit;
                }

                return value;
            }
        }
        public decimal Total90PlusDay
        {
            get
            {
                decimal value = 0m;

                var iList = (from i in itemList
                             where i.Date < DateTime.Now.AddDays(-90)
                             select i).ToList();

                foreach (var i in iList)
                {
                    value += i.Debit;
                    value -= i.Credit;
                }

                return value;
            }
        }
        */

        public Statement(People.Client Client)
        {
            this.Client = Client;

            var data = GetData();
            var receipts = data.Receipts;
            var invoices = data.Invoices;

            var firstReceipt = receipts.FirstOrDefault();
            var firstInvoice = invoices.FirstOrDefault();

            itemList = new HashSet<StatementItem>();

            invoiceList = new List<Transactions.Transaction>(invoices);
            var receiptList = receipts;

            foreach (var i in invoiceList)
                itemList.Add(new StatementItem()
                {
                    Date = i.TransactionDate,
                    Debit = i.Total,
                    Description = $"{i.Type.ToString().ToSpaceAfterCapital()} #{i.ID}",
                    InoiceID = i.ID,
                });

            foreach (var i in receiptList)
            {
                bool add = true;

                // Check if the receipt is an invoice and not PO
                if (i.ReceiptAllocationList.Count > 0)
                {
                    var trans = i.ReceiptAllocationList.ToList()[0].Transaction;
                    add = trans.Type == Transactions.TransactionType.Invoice || trans.Type == Transactions.TransactionType.CreditNote; //CASaw
                }

                if (add)
                {
                    string inv = i.GetInvoices()
                        .Select(x => x.ID)
                        .BuildString(", ");

                    itemList.Add(new StatementItem()
                    {
                        Date = i.ReceiptDate,
                        Credit = i.Amount,
                        Description = $"Payment #{i.ID} for #{inv}",
                        InoiceID = i.ID,
                    });
                }
            }
            var sortList = itemList.ToList();
            itemList = new HashSet<StatementItem>();
            sortList = sortList.OrderBy(i => i.Date).ToList();
            foreach (var i in sortList)
                itemList.Add(i);

            var total = 0m;
            foreach (var i in itemList)
            {
                total += i.Credit - i.Debit;
                i.Total = total;
            }
        }

        (IEnumerable<Transactions.Transaction> Invoices, IEnumerable<Accounts.Receipt> Receipts) GetData()
        {
            bool linkAccounts = false;
            var linkedAccounts = string.IsNullOrEmpty(Client.VatNr) ?
                new List<string>() :
                DMS.ClientManager.GetDataList(x => x.VatNr == Client.VatNr).Select(x => x.Account).Distinct().ToList();

            if (linkedAccounts.Count > 1)
                linkAccounts = AMS.MessageBox_v2.Show($"Inculcate all {linkedAccounts.Count} Accounts with same VAT?", MessageType.Question) == MessageOut.YesOk;

            var receipts = linkAccounts ?
                DMS.AccountsManager.ReceiptList.Where(x => linkedAccounts.Contains(x.Account)).OrderBy(x => x.ReceiptDate).ToList() :
                DMS.AccountsManager.ReceiptList.Where(x => x.Account == Client.Account).OrderBy(x => x.ReceiptDate).ToList();

            var invoices = linkAccounts ?
                DMS.TransactionManager.GetDataList(x => linkedAccounts.Contains(x.Account)).OrderBy(x => x.TransactionDate).ToList() :
                DMS.TransactionManager.GetDataList(x => x.Account == Client.Account).OrderBy(x => x.TransactionDate).ToList();

            invoices = invoices.Where(x => x.Type == Transactions.TransactionType.Invoice || x.Type == Transactions.TransactionType.CreditNote).ToList(); //CASaw

            return (invoices, receipts);
        }
    }
}
