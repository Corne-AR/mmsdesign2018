using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Products
{
    class RecalcValue
    {
        public string Summary;

        /// <summary>
        /// Creates a quote based on the product's Catalog Name and selected Items. 30Day with no Maintenance
        /// </summary>
        /// <returns>quote.SubTotal</returns>
        public RecalcValue(Product Product)
        {
            try
            {
                Summary = string.Format("{0:### ### ### ##0.00}", CalcProduct(Product));
            }
            catch
            {
                Summary = "Unable to Calculate";
            }
        }

        /// <summary>
        /// Creates a quote based on the product's Catalog Name and selected Items. 30Day with no Maintenance
        /// </summary>
        /// <returns>quote.SubTotal</returns>
        public RecalcValue(List<Product> ProductList)
        {
            try
            {
                decimal calculated = 0m;

                foreach (var i in ProductList)
                {
                    calculated += CalcProduct(i);
                }

                Summary = string.Format("{0:### ### ### ##0.00}", calculated);
            }
            catch
            {
                Summary = "Unable to Calculate";
            }
        }

        // Methods

        /// <summary>
        /// Creates a quote based on the product's Catalog Name and selected Items. 30Day with no Maintenance
        /// </summary>
        /// <returns>quote.SubTotal</returns>
        private decimal CalcProduct(Product Product)
        {
            var catalog = (Catalogs.Catalog)DMS.CatalogManager.GetData(i => i.Name == Product.CatalogName).Clone();

            foreach (var i in Product.ItemList)
            {
                if (i.Selected)
                {
                    var item = catalog.ItemList.Where(
                        qi => qi.Code == i.Code && 
                        (qi.Version == Product.Version || string.IsNullOrEmpty("" +  qi.Version))
                    ).FirstOrDefault();
                
                    if (item != null) 
                        item.Selected = true;
                }
            }

            var quote = new Data.Quotes.Quote();

            quote.Account = Product.Account;
            quote.UseMaintence = false;
            quote.AddToCatalog(catalog);
            quote.PaymentTerms = "30Day";
            quote.Calculate();

            return quote.SubTotal;
        }
    }
}
