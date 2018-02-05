using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Communications
{
    [Serializable]
    public class MailTemplate
    {
        public string Name { get; set; }
        public bool AddSignature { get; set; }
        public string ContentTop { get; set; }
        public string ContentMiddle { get; set; }
        public string ContentBottom { get; set; }
        public string Greeting { get; set; }
        public HashSet<string> DefaultAttachments { get; set; }
    }
}
