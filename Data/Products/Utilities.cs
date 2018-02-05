using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Products
{
    public static class Utilities
    {
        // Value

        /// <summary>
        /// Creates a quote based on the product's Catalog Name and selected Items. 30Day with no Maintenance
        /// </summary>
        /// <returns>quote.SubTotal</returns>
        public static string GetProductValue(Product Product)
        {
            RecalcValue re = new RecalcValue(Product);
            return re.Summary;
        }

        /// <summary>
        /// Creates a quote based on the product's Catalog Name and selected Items. 30Day with no Maintenance
        /// </summary>
        /// <returns>quote.SubTotal</returns>
        public static string GetProductValue(List<Product> ProductList)
        {
            RecalcValue re = new RecalcValue(ProductList);
            return re.Summary;
        }

        // Move

        public static void MoveProduct(string ProductId)
        {
            var product = DMS.ProductManager.GetData(i => i.ID == ProductId);

            if (AMS.MessageBox_v2.Show(string.Format("Please specify the new client's account number for which Product {0} needs to move to.", product.Name), AMS.MessageType.QuestionInput) == AMS.MessageOut.YesOk)
                MoveProduct(ProductId, AMS.MessageBox_v2.MessageValue);
        }

        public static void MoveProduct(string ProductId, string ToAccount)
        {
            var product = DMS.ProductManager.GetData(i => i.ID == ProductId);
            var productList = DMS.ProductManager.GetDataList(i => i.Name == product.Name);
            var fromClient = DMS.ClientManager.GetData(i => i.Account == product.Account);
            var toClient = DMS.ClientManager.GetData(i => i.Account == ToAccount);

            // Check for valid data

            if (product == null) { AMS.MessageBox_v2.Show("Aborting!\r\nProduct " + ProductId + " was invalid"); return; }
            if (fromClient == null) { AMS.MessageBox_v2.Show("Aborting!\r\nProduct" + ProductId + " Account was not found."); return; }
            if (toClient == null) { AMS.MessageBox_v2.Show("Aborting!\r\nNo Client found with Account " + ToAccount); return; }

            // Proceed

            if (AMS.MessageBox_v2.Show(string.Format("Would you like to transfer Product {0} from {1} to {2}?\r\nLeave Note if needed.", product.Name, fromClient.Name, toClient.Name), AMS.MessageType.QuestionInput) == AMS.MessageOut.YesOk)
            {
                string note = AMS.MessageBox_v2.MessageValue;

                StringBuilder sb = new StringBuilder();
                sb.Append(string.Format("Product {0} transferred from {1} to {2}", product.Name, fromClient.Name, toClient.Name));
                if (!string.IsNullOrEmpty(note)) sb.Append("\r\n" + note);

                // Get all products with same name in different catalogs
                foreach (var p in productList)
                {
                    p.Account = toClient.Account;
                    p.Save(sb.ToString(), true, true);
                }

                fromClient.Save(sb.ToString(), true, true);
                toClient.Save(sb.ToString(), true, true);
            }
        }

        // Update

        public static void UpdateSupplierID()
        {
            if (AMS.MessageBox_v2.Show("This will fix any missing product's supplier link\r\nIf the product's supplier is not the same as the supplier's id, the link will also be fixed\r\n\r\nWould you like to proceed?", 
                AMS.MessageType.Question) == AMS.MessageOut.No) return;

            foreach (var supplier in DMS.GetSupplierList)
            {
                var cataLogList = DMS.CatalogManager.GetDataList(qi => qi.DefaultSupplierID == supplier.ID);

                if (cataLogList != null)
                {
                    foreach (var catalog in cataLogList)
                    {
                        var queryProductList = DMS.ProductManager.GetDataList(qi => ("" + qi.CatalogName).ToUpper().Trim() == ("" + catalog.Name).ToUpper().Trim());

                        foreach (var product in queryProductList)
                        {
                            if (product.SupplierID == null || product.SupplierID != supplier.ID)
                            {
                                if (product.SupplierID != supplier.ID)
                                {
                                    product.SupplierID = supplier.ID;
                                    product.Save("Fixing Supplier Link", true, true);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}