using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Suite.Data
{
    [Serializable]
    public class Profile
    {

        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
        public bool VatRegisterd { get; set; }
        public string CustomsNumber { get; set; }
        public string CompanyContactNr { get; set; }
        public string Website { get; set; }
        public List<string> ClientCatagoryList { get; set; }
        public List<string> CourierServicesList { get; set; }
        public List<string> ForexList { get; set; }
        public List<ThemeColorInfo> ThemeColorList { get; set; }
        public DateTime TaxClearanceRenewal { get; set; }
        public DateTime BEERenewal { get; set; }
        public decimal MinMaint { get; set; }
        public decimal VatRate { get; set; }
        public decimal MaintRate { get; set; }

        public Profile()
        {
            CourierServicesList = new List<string>();
            ThemeColorList = new List<ThemeColorInfo>();
            ClientCatagoryList = new List<string>();
            ForexList = new List<string>();
        }
    }
}