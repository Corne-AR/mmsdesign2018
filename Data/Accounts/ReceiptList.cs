using AMS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Accounts
{
    [Serializable]
    public class ReceiptList : AMS.Data.DataClass
    {
        public HashSet<Receipt> ClientReceiptList { get; set; }
    }
}
