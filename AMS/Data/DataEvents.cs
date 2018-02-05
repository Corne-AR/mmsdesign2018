using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Data
{
    public delegate void DataSaved(object sender, AMSEventArgs e);

    public class AMSEventArgs : EventArgs
    {
        public string ID;
    }
}
