using AMS.Data.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Data.Equipment
{
    [Serializable]
    public class EquipmentItem : DataClass
    {
        public string Nane { get; set; }
        public string SerialNr { get; set; }
        public string PartNr { get; set; }
        public string Vendor { get; set; }
        public string Manufacturer { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public DateTime InstalmentDate { get; set; }
        public List<RepairHistory> RepairHistoryList { get; set; }
        public aPerson DefaultTechnician { get; set; }

        public EquipmentItem()
        {
            RepairHistoryList = new List<RepairHistory>();
            DefaultTechnician = new aPerson();
        }
    }
}