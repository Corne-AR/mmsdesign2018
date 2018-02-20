using Data.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Quotes
{
    public partial class Quote
    {
        public Transaction GetTransaction(Quote Quote)
        {
            Transaction transaction = new Transaction();

            foreach (var catalog in Quote.CaluclatedCatalogList)
            {
                // For a typical catalog
                // 1. Get version from quote
                // 2. Get count of product codes, used to summarize modules for example
                // 3. Starts creating a line summary for each catalog
                // 4. Create a list of selected items in the catalog
                // 5. Add * for bulk discount when applied
                // 6. Using a Product Class to create the Catalog's final Data which will be used in the transaction
                // 7. Add place maintenance value from catalog into a separate value for a dedicated line of Maintenance Data

                // For Custom catalog
                // 1. Get a version, if needed
                // 2. Create a new Product Class, per line from Custom Catalog

                // Add Maintenance to Transaction
                // Using the accumulative maintenance value

                if (!Quote.Itemized && !catalog.Itemized)
                {
                    SummerizedCatalog(transaction, catalog);
                }
                else // If catalog is from Custom or Itemized
                {
                    ItemizedCatalog(transaction, catalog);
                }
            }

            #region Add Maintenance

            if (this.totalMaintenanceValue > 0 || this.totalCODMaintenanceValue > 0)
            {
                // Get the catalog and supplier info
                // With this info, the TransactionsForm will add this automatically to the Maintenance
                string supplierID = "";

                // supplierID = "[" + catalog.SupplierID + "]";

                // Get Supplier Name too, as SupplierID needs to look like "[AC001] Supplier Name"
                // var supplier = DMS.ClientManager.GetData(i => i.ID == catalog.SupplierID);
                // if (supplier != null) supplierID += " " + supplier.Name;


                // Finally add Maintenance as a product, with an associated supplier
                var maintItem = new Data.Products.Product();

                maintItem.SupplierID = supplierID;
                maintItem.Description = "Software subscription for new modules valid until: " + string.Format("{0:MMMM yyyy}", Quote.ExtendDate);
                maintItem.PriceExVat = Quote.totalMaintenanceValue;
                if (PaymentTerms == "COD") maintItem.PriceExVat = Quote.totalCODMaintenanceValue;

                transaction.ItemList.Add(maintItem);
            }

            #endregion

            // Set details
            transaction.Account = Quote.Account;
            transaction.Metadata = Quote.Metadata;
            transaction.ID = Quote.ID;
            transaction.Type = TransactionType.Quote;
            transaction.Currency = Quote.Currency;
            transaction.LinkedIDList.Add(Quote.ID);
            transaction.Contact = Quote.Contact;
            transaction.Email = Quote.Email;
            transaction.LinkedIDList = Quote.LinkedIDList;
            transaction.DatalogList = Quote.DatalogList;
            transaction.UseVat = !Quote.Client.IsInternational;
            if (!AMS.Suite.SuiteManager.Profile.VatRegisterd) transaction.UseVat = false;

            try
            {
                if (Quote.ProgressType == Quotes.ProgressType.New) transaction.TransactionDate = Quote.Metadata.Modified;
                if (Quote.ProgressType == Quotes.ProgressType.Mailed) transaction.TransactionDate = Quote.QuoteDate;
                if (Quote.ProgressType == Quotes.ProgressType.Finalized) transaction.TransactionDate = DateTime.Now;

                if (transaction.TransactionDate < new DateTime(2000, 1, 1) && Quote.Metadata != null) transaction.TransactionDate = Quote.Metadata.EmailDate;
                if (transaction.TransactionDate < new DateTime(2000, 1, 1) && Quote.Metadata != null) transaction.TransactionDate = Quote.Metadata.Modified;
            }
            catch { }

            if (Quote.PaymentTerms == "COD") transaction.DueDate = DateTime.Now;
            else transaction.DueDate = DateTime.Now.AddDays(30);

            return transaction;
        }

        private void ItemizedCatalog(Transaction transaction, Data.Catalogs.Catalog Catalog)
        {
            // #1 Get Version
            var queryVersion = (from qi in Catalog.ItemList
                                where qi.Version != null
                                where qi.Selected == true
                                select qi).FirstOrDefault();

            if (queryVersion == null) queryVersion = new Catalogs.CatalogItem();

            // #2 Separate into each new line
            foreach (var i in Catalog.ItemList)
            {
                if (i.Selected)
                {
                    var item = new Data.Products.Product();
                    string description = i.Name;

                    item.Version = queryVersion.Version;
                    item.Name = Catalog.ProductName;
                    item.PriceExVat = i.RetailPrice;
                    item.Content = i.Content;
                    item.Description = description;
                    item.SupplierID = i.SupplierID;
                    item.CalculationInfo = i.CalculationInfo;

                    transaction.ItemList.Add(item);
                }
            }
        }

        private void SummerizedCatalog(Transaction transaction, Data.Catalogs.Catalog Catalog)
        {
            var querySelectedItems = (from qi in Catalog.ItemList
                                      where qi.Selected == true
                                      select qi);

            if (querySelectedItems == null || querySelectedItems.Count() == 0) return;

            var queryCODE = (from qi in Catalog.ItemList
                             where qi.Selected == true && qi.Code != null && qi.Code.Trim().All(Char.IsNumber)
                             select qi);
            int selectCount = querySelectedItems.Count();
            int queryCODECount = queryCODE.Count();
            if (selectCount != queryCODECount)
            {
                ItemizedCatalog(transaction, Catalog);
            }
            else
            {
                StringBuilder lineName = new StringBuilder();
                if (!string.IsNullOrEmpty(Catalog.CatalogReference)) lineName.Append(Catalog.CatalogReference);
                else lineName.Append(Catalog.Name); // "Model Maker" - Adds catalog name

                #region Get Version

                var queryVersion = (from qi in Catalog.ItemList
                                    where qi.Version != null
                                    where qi.Selected == true
                                    select qi).FirstOrDefault();

                if (queryVersion != null && queryVersion.Version != "") lineName.Append(" (" + queryVersion.Version + ")"); // #3 "Model Maker (9000)" - Add version

                #endregion

                // #3 Add Module summary
                if (querySelectedItems.Count() > 0)
                {
                    if (!string.IsNullOrEmpty(Catalog.SummaryDescription)) lineName.Append(" " + Catalog.SummaryDescription + " "); // "Model Maker (9000) Modules " - Add Modules label

                    #region ----- Collected Summary -----

                    List<int> codeNrList = new List<int>();

                    foreach (var i in Catalog.ItemList)
                    {
                        if (i.Selected) codeNrList.Add(Convert.ToInt32(i.Code));
                    }

                    StringBuilder itemSummeries = new StringBuilder();
                    int itemNr = 0;
                    int itemLastNr = -1;
                    int itemNextNr = 0;

                    for (int i = 0; i < codeNrList.Count; i++)
                    {
                        bool firstChar = false;
                        bool dash = false;
                        bool lastChar = false;

                        itemNr = codeNrList[i];
                        if (i > 0) itemLastNr = codeNrList[i - 1];
                        if (i + 1 < codeNrList.Count) itemNextNr = codeNrList[i + 1];
                        else itemNextNr = 100000;

                        // Check for valid values
                        if (itemNr > itemLastNr + 1) firstChar = true;   // First
                        if (itemNr - 1 == itemLastNr) dash = true;      // Dash
                        if (itemNr + 1 < itemNextNr)
                        {
                            lastChar = true;
                            dash = false;
                        }
                        // remove extra dashes
                        if (itemSummeries.ToString().Count() > 0)
                            if (itemSummeries.ToString()[itemSummeries.ToString().Count() - 1].ToString() == "-") dash = false;

                        // add to string list
                        if (firstChar || lastChar) itemSummeries.Append(itemNr.ToString());
                        if (dash && !lastChar && !firstChar)
                        {
                            itemSummeries.Length -= 1;
                            itemSummeries.Append("-");
                        }
                        if (firstChar || lastChar) itemSummeries.Append(",");
                    }

                    // Removing the last ,
                    StringBuilder summery = itemSummeries;
                    summery.ToString().Trim();
                    if (summery.Length > 1) summery.Length -= 1;

                    #endregion

                    lineName.Append(summery.ToString()); // # "Model Maker (9000) Modules 1,2,3-6" - Add Module info
                }

                // #4 Selected items used to populate User Controls
                #region SelectItems

                //var selectedItems = new List<aProductItem>();
                //foreach (var pi in Catalog.GetItemList())
                //{
                //    selectedItems.Add(new aProductItem() { Selected = pi.Selected, Name = pi.Name, Code = pi.Code });
                //}

                #endregion

                // #5 Add * for Bulk discount
                #region Check for bulkdiscount

                //if (Catalog.HasBulkdiscount)
                //{
                //    hasBulkdiscount = true;
                //    string oldeLineName = lineName.ToString();
                //    lineName = new StringBuilder();
                //    lineName.Append("*" + oldeLineName);
                //}

                #endregion

                if (Catalog != null)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("Todo: add some content from summaries");

                    decimal value = 0m;
                    foreach (var i in Catalog.ItemList)
                        if (i.Selected)
                            value += i.RetailPrice;
                    var item = new Data.Products.Product();

                    if (queryVersion != null) item.Version = queryVersion.Version;
                    item.Name = Catalog.ProductName;
                    item.PriceExVat = value;
                    item.Description = lineName.ToString();

                    item.SupplierID = Catalog.DefaultSupplierID;

                    foreach (var i in Catalog.ItemList.Where(x => x.Selected))
                            item.CalculationInfo += $"{i.CalculationInfo}\n";

                    item.CalculationInfo.Trim();
                    transaction.ItemList.Add(item);
                }
            }
        }

        public void SetNewClient(People.Client client)
        {
            this.Account = client.Account;
        }

        public bool CODOnly { get; set; }
    }
}