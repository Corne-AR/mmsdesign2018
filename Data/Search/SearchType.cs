using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Search
{
    public enum SearchType
    {
        Null,
        All,
        Maintenance,
        Normal,
        Client,
        Receipt,
        Transaction,
        //Invoice,
        Quote,
        //Proforma,
        //PurchaseOrder,
        Product,
        Statement
    }
}
