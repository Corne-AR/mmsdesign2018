using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMS_Design.IO.Forms
{
    [Serializable]
    public class NewIDData
    {
        public string NewID { get; set; }
        public string OldID { get; set; }
        public string CompanyName { get; set; }
    }
}
