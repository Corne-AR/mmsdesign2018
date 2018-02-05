using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Suite.Data
{
    [Serializable]
    public class General
    {
        public bool HideRightPanel { get; set; }
        public int MainTab { get; set; }
        public string InvoiceListPath { get; set; }
    }
}
