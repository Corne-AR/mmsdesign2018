using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.People
{
    [Serializable]
    public class Company
    {
        public string Name { get; set; }
        public string ContactNr { get; set; }
        public string Email { get; set; }
    }
}
