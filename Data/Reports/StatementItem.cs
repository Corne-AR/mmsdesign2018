using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Reports
{
    public class StatementItem
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public string InoiceID { get; set; }
        public string ReceiptID { get; set; }

        public decimal Total { get; internal set; }
    }
}
