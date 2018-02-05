using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Catalogs
{
    [Serializable]
    public class Catalog : AMS.Data.DataClass
    {
        // Used for both the Commerce Manager and Quotation data

        public string ParentID { get; set; }                // For quoting a nested link
        public string Name { get; set; }
        public bool Itemized { get; set; }                  // For quotation
        public decimal Discount { get; set; }               // For quotation's total
        public string ProductName { get; set; }             // Search for product related to this catalog and the product name
        public bool PriceIncludeVAT { get; set; }           // Required to remove Vat for quotes/transactions
        public bool HasBulkdiscount { get; set; }           // Used to display if this catalog is part of a list and BulkDiscount applies
        public int Count { get; set; }                      // Might be unnecessary code here, but the idea would be to be able to multiply this catalog at quote time
        public string Currency { get; set; }                // In which Currency is this catalog
        public decimal CODValue { get; set; }               // Holds calculated COD value
        public decimal TotalValue { get; set; }             // Holds calculated Value
        public decimal MaintenanceValue { get; set; }       // Holds maintanece value
        public string TermsFileName { get; set; }
        public string MaintTermsFileName { get; set; }
        public string SummaryDescription { get; set; }      // Used on a Quote summary line. ex: "Modules" in Model Maker (9000) Modules 1-5;
        public string CatalogGroup { get; set; }            // To which group does this catalog belong too?
        public string CatalogReference { get; set; }        // This is for items to refer to another catalog for upgrading
        public bool NonProduct { get; set; }                // Set this to not make a product after quote
        public string DefaultSupplierID { get; set; }
        public bool CODOnly { get; set; }                   // This catalog cannot have other payment type
        public bool SingleProduct { get; set; }
        public bool UseStolen { get; set; }
        public bool HasSLKeyOption { get; set; }

        // Sctipts
        public string DefaultScript { get; set; }
        public List<Forex> ForexList { get; set; }
        public Forex SelectedForex { get; set; }

        public string QuotedScript { get; set; }            // On quote time save the used script
        public string QuotedFactors { get; set; }            // On quote time save the used script
        public string QuotedForex { get; set; }            // on quote time save the used forex

        /// <summary>
        /// All data in this catalog. Use GetItemList() for a version filtered list
        /// </summary>
        public List<CatalogItem> ItemList { get; set; }

        public Catalog()
        {
            ItemList = new List<CatalogItem>();
            ForexList = new List<Forex>();
        }

        /// <summary>
        /// Filters out all version products into one data string.
        /// </summary>
        /// <returns></returns>
        public List<CatalogItem> GetItemList()
        {
            List<CatalogItem> itemList = new List<CatalogItem>();
            HashSet<string> checklist = new HashSet<string>();
            foreach (var i in ItemList)
            {
                bool add = false;

                // Check if product has already been added via a HashSet
                string filter = i.Name;
                add = !(checklist.Contains(filter));

                if (add || string.IsNullOrEmpty(i.Version) || Name == "Custom")
                {
                    checklist.Add(filter); // Add to HashSet if product was added
                    itemList.Add(i);
                }
            }
            return itemList;
        }

        // Save

        public bool Save()
        {
            return Save(true);
        }

        public bool Save(bool OverWrite)
        {
            if (string.IsNullOrEmpty(ID)) ID = Guid.NewGuid().ToString();

            SetFile(Name, AMS.Settings.Program.Directories.Commerce + Name, AMS.Data.DataType.Catalog);

            foreach (var i in ItemList)
                i.CatalogID = ID;

            return DMS.CatalogManager.Save(this, "", OverWrite, true);
        }

        // Methods

        public void SaveQuotedCatalog()
        {
            // Save Catalog's Items' retail prices

            #region Save Scripts for viewing later

            StringBuilder retailScript = new StringBuilder();

            if (!string.IsNullOrEmpty(DefaultScript))
            {
                var script = AMS_Script.ScriptManager.GetScript(DefaultScript);
                retailScript.AppendLine(script.Summary);
            }
            else
            {
                retailScript.AppendLine("No Script was applied.");
            }

            QuotedScript = retailScript.ToString();

            // Factors
            StringBuilder factors = new StringBuilder();

            if (AMS_Script.ScriptManager.FactorList != null)
            {
                foreach (var i in AMS_Script.ScriptManager.FactorList)
                    factors.AppendLine(i.Name + " " + i.value + " " + i.VariableType);
            }
            else
            {
                factors.Append("No factors");
            }

            QuotedFactors = factors.ToString();

            // Forex

            StringBuilder forexScript = new StringBuilder();

            if (SelectedForex != null)
            {
                forexScript.AppendLine("Forex: " + SelectedForex.Name);
                forexScript.AppendLine();
                if (!string.IsNullOrEmpty(SelectedForex.ScriptName))
                {
                    forexScript.AppendLine(AMS_Script.ScriptManager.GetScript(SelectedForex.ScriptName).ScriptContent);

                    forexScript.AppendLine();
                    forexScript.AppendLine("----------");
                    forexScript.AppendLine();
                    forexScript.AppendLine("Factor List");
                    forexScript.AppendLine();
                    foreach (var i in AMS_Script.ScriptManager.GetScript(SelectedForex.ScriptName).VriableList)
                        forexScript.AppendLine(i.Name + " - " + i.value);
                }
                else
                {
                    forexScript.AppendLine("Forex has no script.");
                }

            }
            else
            {
                forexScript.AppendLine("No Forex was selected.");
            }

            QuotedForex = forexScript.ToString();

            #endregion
        }

        public void ViewQuotedRetailScript()
        {
            AMS.MessageBox_v2.Show(QuotedScript);
        }

        public void ViewQuotedForex()
        {
            AMS.MessageBox_v2.Show(QuotedForex);
        }

    }
}