using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Data.Users
{
    [Serializable]
    public class UserRoles
    {
        public bool Administartor { get; set; }
        
        // Accounting
        public bool CreateInvoices { get; set; }
        public bool ViewInvoices { get; set; }

        // Sales
        public bool CreateQuotes { get; set; }
        public bool ViewQuotes { get; set; }

        // Management
        public bool CreateTasks { get; set; }
        public bool ViewTasks { get; set; }
        
        // Data
        public bool CreateClients { get; set; }
        public bool ViewClients { get; set; }

        // Commerce
        public bool CreateCommerce { get; set; }
        public bool ViewCommerce { get; set; }

    }
}
