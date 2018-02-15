using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Reports
{
    public class FinantialYear
    {
        public DateTime Date => DateTime.Now;
        public List<Data.Transactions.Transaction> Invoices => DMS.TransactionManager
            .GetDataList(x => x.Type == Data.Transactions.TransactionType.Invoice)
            .Where(x => x.TransactionDate < Date)
            .ToList();
    }
}
