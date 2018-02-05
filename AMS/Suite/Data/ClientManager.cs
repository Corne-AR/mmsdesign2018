
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Suite.Data
{
    [Serializable]
    public class ClientManager
    {
        public string LastAccount { get; set; }
        public bool ClientSelectHide { get; set; }
        public int ClientSelectSize { get; set; }

        public bool TransactionPanel { get; set; }
    }
}
