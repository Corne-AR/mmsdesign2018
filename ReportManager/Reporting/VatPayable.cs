using Data.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporting.Reporting
{
   public class VatPayable
    {
        public List<Transaction> Invoices { get; private set; }
        public List<Transaction> CreditNotes { get; private set; }
        public List<Transaction> PurchaseOrders { get; private set; }

        public static DateTime PrefDateStart { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.AddMonths(-1).Month, 1);
        public static DateTime PrefDateEnd { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.AddMonths(1).Month, 1).AddDays(-1);

        public DateTime DateStart { get; private set; } = PrefDateStart;
        public DateTime DateEnd { get; private set; } = PrefDateEnd;

        public decimal TotalInvoiceVAT { get; private set; }
        public decimal TotalCreditNoteVAT { get; private set; }
        public decimal TotalPurchaseOrderVAT { get; private set; }
        public decimal PayableValue { get { return TotalInvoiceVAT - TotalPurchaseOrderVAT + TotalCreditNoteVAT; } }

        public VatPayable()
        {
            Invoices = Data.DMS.TransactionManager.GetDataList(i => i.Type == TransactionType.Invoice && i.TransactionDate >= DateStart && i.TransactionDate <= DateEnd);
            CreditNotes = Data.DMS.TransactionManager.GetDataList(i => i.Type == TransactionType.CreditNote && i.TransactionDate >= DateStart && i.TransactionDate <= DateEnd);
            PurchaseOrders = Data.DMS.TransactionManager.GetDataList(i => i.Type == TransactionType.PurchaseOrder && i.TransactionDate >= DateStart && i.TransactionDate <= DateEnd);

            TotalInvoiceVAT = Invoices.Where(i => i.UseVat && i.IsVoid == false).Sum(i => i.TotalVat);
            TotalCreditNoteVAT = CreditNotes.Where(i => i.UseVat && i.IsVoid==false).Sum(i => i.TotalVat);
            TotalPurchaseOrderVAT = PurchaseOrders.Where(i => i.UseVat && i.IsVoid == false).Sum(i => i.TotalVat);
        }
    }
}