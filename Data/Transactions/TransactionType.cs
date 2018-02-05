using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Transactions
{
    public enum TransactionType
    {
        Invoice,
        Proforma,
        PurchaseOrder,
        Quote,
        CreditNote,
        Statement,
        CancellationOrder,
    }
}