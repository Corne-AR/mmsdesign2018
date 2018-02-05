using AMS_Script;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Catalogs
{
    [Serializable]
    public class CatalogItem : AMS.Data.DataClass
    {
        public string CatalogID { get; set; }

        public string PartNr { get; set; }         // Order number for supplier
        public string Code { get; set; }            // Part Numbers or Item Code
        public string Name { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string Version { get; set; }
        public double Quantity { get; set; }

        public bool Maintenance { get; set; }
        public bool COD { get; set; }
        public bool BulkDiscount { get; set; }
        public bool GlobalDiscount { get; set; }
        public bool Stolen { get; set; }

        public bool Selected { get; set; }
        public Quotes.ProgressType ProgressType { get; set; }

        // Catalog and Scripts

        public Forex Forex { get; set; }
        public string CatalogDefaultScript { get; set; }
        public string RetailScript { get; set; }
        public string SupplierID { get; set; }
        public AMS_Script.Script.aScript UsedScript
        {
            get
            {
                string scriptName = "";

                if (!string.IsNullOrEmpty(RetailScript)) scriptName = RetailScript.Trim();
                if (!string.IsNullOrEmpty(CatalogDefaultScript) && string.IsNullOrEmpty(scriptName)) scriptName = CatalogDefaultScript;

                if (!string.IsNullOrEmpty(scriptName)) return ScriptManager.GetScript(scriptName);
                else return null;
            }
        }
        public string CalculationInfo { get; set; }

        // Prices
        public decimal ListPrice { get; set; }
        public decimal RetailPrice
        {
            get
            {
                var retailPrice = ListPrice;

                // Apply script
                var script = UsedScript;
                if (script != null)
                {
                    script.InValue = retailPrice.ToString();
                    retailPrice = Convert.ToDecimal(script.OutValue);
                }

                // Apply Forex
                if (Forex != null)
                {
                    var forexScript = ScriptManager.GetScript(Forex.ScriptName);
                    if (forexScript != null)
                    {
                        forexScript.InValue = retailPrice.ToString();
                        retailPrice = Convert.ToDecimal(forexScript.OutValue);
                    }
                }

                if (Quantity > 0) retailPrice = retailPrice * (decimal)Quantity;
                return retailPrice;
            }
        }

        private HashSet<string> versionList;
        public HashSet<string> GetVersions(Catalog catalog)
        {
            if (versionList == null) versionList = new HashSet<string>();

            foreach (var i in catalog.ItemList)
            {
                if (i.Name != null && i.Name.ToLower().Trim() == this.Name.ToLower().Trim())
                    versionList.Add(i.Version);
            }

            return versionList;
        }
    }
}