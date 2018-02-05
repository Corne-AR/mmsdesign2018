using AMS.Data.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Data.Equipment
{
    [Serializable]
    public class RepairHistory : DataClass
    {
        public string Condition { get; set; }
        public DateTime Date { get; set; }
        public aPerson Technician { get; set; }
    }
}
