using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Data.Keys
{
    [Serializable]
    public class UserPK
    {
        public int Account { get; set; }
        public int Quote { get; set; }
        public int Invoice { get; set; }
        public int PurchaseOrder { get; set; }
        public int Proforma { get; set; }
        public int Task { get; set; }
        public int CustomProduct { get; set; }
        public int Person { get; set; }
        public int Receipt { get; set; }
    }

    public enum KeyType
    {
        Account,
        Quote,
        Invoice,
        Proforma,
        PurchaseOrder,
        Task,
        CustomProduct,
        Person,
        Receipt,
        CreditNote //CA_NewLine Credit note
    }
}
