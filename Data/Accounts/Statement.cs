using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMS;
using AMS.Utilities;

namespace Data.Accounts
{
    public class Statement
    {
        public string Account { get; set; }
        public Data.People.Client Client { get { return DMS.ClientManager.GetData(i => i.Account == Account); } }
        public DateTime Date { get; set; }
        private DateTime DateStart { get; set; }
        public List<StatementItem> ItemList
        {
            get
            {
                var list = new List<StatementItem>();

                if (OpeningBalance == 0)
                {
                    list.Add(new StatementItem()
                    {
                        Date = DateStart,
                        Debit = OpeningBalance,
                        Description = string.Format("Opening Balance on {0:dd MMMM yyyy}", DateStart),
                    });
                }


                if (OpeningBalance > 0)
                {
                    list.Add(new StatementItem()
                    {
                        Date = DateStart,
                        Debit = OpeningBalance,
                        Description = string.Format("Opening Balance on {0:dd MMMM yyyy}", DateStart),
                    });
                }

                if (OpeningBalance < 0)
                {
                    list.Add(new StatementItem()
                    {
                        Date = DateStart,
                        Credit = -OpeningBalance,
                        Description = string.Format("Opening Balance on {0:dd MMMM yyyy}", DateStart),
                    });
                }

                list.AddRange(itemList.Where(i => i.Date >= DateStart).ToList());

                return list;
            }
        }

        private HashSet<StatementItem> itemList;

        public decimal OpeningBalance;
        private List<Transactions.Transaction> invoiceList;
        public List<Transactions.Transaction> InvoiceList { get { return invoiceList; } }

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

        public Statement(People.Client Client, bool UseDates)
        {
            this.Account = Client.Account;
            this.DateStart = DateTime.Now;

            bool linkAccounts = false;
            var linkedAccounts = string.IsNullOrEmpty(Client.VatNr) ?
                new List<string>() :
                DMS.ClientManager.GetDataList(x => x.VatNr == Client.VatNr).Select(x => x.Account).Distinct().ToList();

            if (linkedAccounts.Count > 0)
                linkAccounts = AMS.MessageBox_v2.Show($"Inlculde all {linkedAccounts.Count} Accounts with same VAT?", MessageType.Question) == MessageOut.YesOk;

            var receipts = linkAccounts ?
                DMS.AccountsManager.ReceiptList.Where(x => linkedAccounts.Contains(x.Account)).OrderBy(x => x.ReceiptDate).ToList() :
                DMS.AccountsManager.ReceiptList.Where(x => x.Account == Client.Account).OrderBy(x => x.ReceiptDate).ToList();

            var invoices = linkAccounts ?
                DMS.TransactionManager.GetDataList(x => linkedAccounts.Contains(x.Account)).OrderBy(x => x.TransactionDate).ToList() :
                DMS.TransactionManager.GetDataList(x => x.Account == Client.Account).OrderBy(x => x.TransactionDate).ToList();

            invoices = invoices.Where(x => x.Type == Transactions.TransactionType.Invoice || x.Type == Transactions.TransactionType.CreditNote).ToList();

            var firstReceipt = receipts.FirstOrDefault();
            var firstInvoice = invoices.FirstOrDefault();


            if (firstInvoice != null && firstReceipt != null)
            {
                if (firstInvoice.TransactionDate < firstReceipt.ReceiptDate)
                    DateStart = firstInvoice.TransactionDate;
                else
                    DateStart = firstReceipt.ReceiptDate;
            }
            else if (firstReceipt != null) DateStart = firstReceipt.ReceiptDate;
            else if (firstInvoice != null) DateStart = firstInvoice.TransactionDate;

            if (UseDates)
            {
                DateStart = Client.Metadata.Created;
                AMS.Utilities.Forms.DatePicker dp = new AMS.Utilities.Forms.DatePicker("Statement Start Date", DateStart);
                dp.ShowDialog();
                DateStart = dp.DateTimeValue;
            }

            itemList = new HashSet<StatementItem>();

            var openingInvoices = invoices.Where(x => x.TransactionDate < DateStart);
            var openingReceipts = receipts.Where(x => x.ReceiptDate < DateStart);

            OpeningBalance = 0m;
            foreach (var i in openingInvoices)
                OpeningBalance += i.Total;

            foreach (var receipt in openingReceipts)
                foreach (var allocation in receipt.ReceiptAllocationList)
                    if (allocation.Transaction.Type == Transactions.TransactionType.Invoice || allocation.Transaction.Type == Transactions.TransactionType.CreditNote)
                        OpeningBalance -= allocation.Amount;

            invoiceList = invoices;
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
                    add = trans.Type == Transactions.TransactionType.Invoice || trans.Type == Transactions.TransactionType.CreditNote;
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
        }

        public Statement(People.Client Client, bool UseDates, bool OLD)
        {
            var queryFirstReceipt = DMS.AccountsManager.ReceiptList.Where(i => i.Account == Account).OrderBy(i => i.ReceiptDate).FirstOrDefault();
            var queryFirstTransaction = (from i in DMS.TransactionManager.GetDataList(qi => qi.Account == Account)
                                         orderby i.TransactionDate ascending
                                         select i).FirstOrDefault();

            if (queryFirstTransaction != null && queryFirstReceipt != null)
            {
                if (queryFirstTransaction.TransactionDate < queryFirstReceipt.ReceiptDate)
                    DateStart = queryFirstTransaction.TransactionDate;
                else
                    DateStart = queryFirstReceipt.ReceiptDate;
            }
            else if (queryFirstReceipt != null) DateStart = queryFirstReceipt.ReceiptDate;
            else if (queryFirstTransaction != null) DateStart = queryFirstTransaction.TransactionDate;

            if (UseDates)
            {
                DateStart = Client.Metadata.Created;
                AMS.Utilities.Forms.DatePicker dp = new AMS.Utilities.Forms.DatePicker("Statement Start Date", DateStart);
                dp.ShowDialog();
                DateStart = dp.DateTimeValue;
            }

            itemList = new HashSet<StatementItem>();

            var openingInvoices = DMS.TransactionManager.GetDataList(i => (i.Type == Transactions.TransactionType.Invoice || i.Type == Transactions.TransactionType.CreditNote) && i.Account == Account && i.TransactionDate < DateStart);
            var openingReceipts = DMS.AccountsManager.ReceiptList.Where(i => i.Account == Account && i.ReceiptDate < DateStart);

            OpeningBalance = 0m;
            foreach (var i in openingInvoices)
                OpeningBalance += i.Total;

            foreach (var receipt in openingReceipts)
                foreach (var allocation in receipt.ReceiptAllocationList)
                    if (allocation.Transaction.Type == Transactions.TransactionType.Invoice || allocation.Transaction.Type == Transactions.TransactionType.CreditNote)
                        OpeningBalance -= allocation.Amount;

            invoiceList = DMS.TransactionManager.GetDataList(i => (i.Type == Transactions.TransactionType.Invoice || i.Type == Transactions.TransactionType.CreditNote) && i.Account == Account);
            var receiptList = DMS.AccountsManager.ReceiptList.Where(i => i.Account == Account);


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
                    add = trans.Type == Transactions.TransactionType.Invoice || trans.Type == Transactions.TransactionType.CreditNote;
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
        }

    }
}
