using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Products
{
    public class Upgrade
    {
        public Product ResultProduct { get { return resultProduct; } }
        private Product resultProduct;

        public Product QuotedProduct { get { return quotedProduct; } }
        private Product quotedProduct;

        public Product ExistingProduct { get { return existingProduct; } }
        private Product existingProduct;

        private Data.Catalogs.Catalog catalog;

        public Upgrade(Product NewUpgradeProduct)
        {
            // NB! using clones to not interfere with current data unexpectedly
            // 1. Get Catalog name
            // 2. Use three Products to determine upgrade. 1. Get Existing Product, 2. Get Upgrade from Quote 3. Result the Upgrade
            // 3. Add upgrade's 0.8%
            // 4. Use Description to get the catalog name
            // 5. Do upgrades to Model Maker catalog

            // Get upgrade data 1st for catalog info
            this.quotedProduct = (Product)NewUpgradeProduct.Clone();
            if (quotedProduct == null || quotedProduct.Name == null)
            {
                AMS.MessageBox_v2.Show("Cannot upgrade product: " + quotedProduct.Name);
                return;
            }

            // #1 Get Catalog Name from Upgrade
            catalog = DMS.CatalogManager.GetData(i => i.Name == NewUpgradeProduct.CatalogName);
            if (catalog == null) return;

            // #2 3 products
            resultProduct = (Product)DMS.ProductManager.GetData(i => i.Name == quotedProduct.Name && i.CatalogName.ToUpper() == catalog.Name.ToUpper()).Clone();
            existingProduct = (Product)resultProduct.Clone();

            // #3 return class if upgrade or existing products are null
            if (existingProduct == null)
            {
                AMS.MessageBox_v2.Show("Cannot upgrade product: " + quotedProduct.Name);
                return;
            }

            // Increase price
            resultProduct.PriceExVat += quotedProduct.PriceExVat;
            resultProduct.ExpiryDate = NewUpgradeProduct.ExpiryDate;  // Wont work on upgrade

            // Add version if needed
            if (quotedProduct.Version != null && quotedProduct.Version.Trim() != "")
            {
                resultProduct.AddDataLog("Upgrade", resultProduct.Version + " to " + quotedProduct.Version, AMS.Data.DataType.Product);
                resultProduct.Version = quotedProduct.Version;
            }

            UpdateItemList();
        }

        private void OLDCustomUpgrade()
        {
            // Upgrading Versions (ex: Number of Points)
            if (quotedProduct.Version != null && quotedProduct.Version.Trim() != "")
            {
                // Increase price
                resultProduct.PriceExVat += quotedProduct.PriceExVat / 1.08m;

                // Add version if needed
                if (quotedProduct.Version != null && quotedProduct.Version.Trim() != "") resultProduct.Version = quotedProduct.Version;
                UpdateItemList();
            }
            else
            {
                // Use catalog to get the corresponding items to match
                if (catalog == null) { AMS.MessageBox_v2.Show("Cannot find associated catalog\r\nClosing"); return; }

                foreach (var i in existingProduct.ItemList)
                {
                    var queryCatalog = (from qi in catalog.ItemList
                                        where qi.Code == i.Code
                                        where qi.Name == i.Name
                                        select qi).FirstOrDefault();

                    if (i.Selected) queryCatalog.Selected = true;
                }

                // Use quote class for upgrade value, this can be done in future from calculations class directly perhaps?

                Data.Quotes.Quote quote = new Data.Quotes.Quote();

                quote.Account = quotedProduct.Account;
                quote.AddToCatalog(catalog);
                quote.UseMaintence = false;
                quote.PaymentTerms = "30DAY"; //Note by Corne, if this is COD, then International client upgrade quote values 
                                              //are given as COD exVAT, but it should be 30Day exVAT. 
                                                //I am trying to catch it so that this does not happen.
                quote.Calculate();

                if (quote.Transaction.SubTotal > existingProduct.PriceExVat) resultProduct.PriceExVat = quote.Transaction.SubTotal;
                // Quote COD value, compare existing value to quote. take highest value
            }
        }

        private void UpdateItemList()
        {
            string log = "";
            string message = "";
            // add selected items from upgrade to existing
            foreach (var i in quotedProduct.ItemList)
            {
                if (i.Selected)
                {
                    var queryExistingItem = (from qi in existingProduct.ItemList
                                             where qi.Code == i.Code
                                             select qi).FirstOrDefault();

                    if (queryExistingItem != null)
                    {
                        // Warn if new item in product has been selected previously
                        if (queryExistingItem.Selected == true)
                        {
                            log += "WARNING: Product '" + existingProduct.ID + "' has been upgraded with a duplicated item.\r\n" + queryExistingItem.Code + " - " + queryExistingItem.Name;
                            message = log;
                        }
                        else
                        {
                            var queryResulting = (from qi in resultProduct.ItemList
                                                  where qi.Code == i.Code
                                                  select qi).FirstOrDefault();

                            if (queryResulting != null) queryResulting.Selected = true;

                            log += "Added Item: " + queryExistingItem.ID + " | " + queryExistingItem.Code + "\r\n";
                        }
                    }
                }
            }

            if (!string.IsNullOrEmpty(message)) AMS.MessageBox_v2.Show(message);
            resultProduct.AddDataLog(resultProduct.ID, log, AMS.Data.DataType.Product);
        }
    }
}
