using Data.Catalogs;
using Data.Quotes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Products
{
    /// <summary>
    /// Primary Class to keep Product Information, both for saving for xml data and Pricelist data
    /// </summary>
    [Serializable]
    public class Product : AMS.Data.DataClass
    {
        public string Account { get; set; }

        public People.Client Client { get { return DMS.ClientManager.GetData(i => i.Account == Account); } }
        public string ClientName { get { return Client?.Name; } }
        public DateTime? ClientExpiryDate { get { return Client?.Expirydate; } }
        public string Code { get; set; }
        public string Name { get; set; }            // Ex: a serial nr
        public string Version { get; set; }
        public string Description { get; set; }     // Short description, ex: Model Maker (9000) 1-5, 7
        public int UserCount { get; set; }
        public decimal PriceInVat { get; set; }
        public decimal PriceExVat { get; set; }
        public string CatalogName { get; set; }
        public decimal Discount { get; set; }
        public decimal ItemTotal { get { return Math.Round(PriceExVat * (100m - Discount) / 100m, 2); } }

        /// <summary>
        /// ONLY being used for the Quote editor and will display the item value * current global VAT.
        /// </summary>
        public decimal QUOTE_ItemTotalInVat { get { return Math.Round(ItemTotal * DMS.VatRateValue, 2); } }
        public string SupplierID { get; set; } // Transaction Manager will use this to make separate transaction to the correct suppliers
        public Data.People.Client GetSupplier { get { var supplier = DMS.ClientManager.GetData(i => i.Account == SupplierID); if (supplier == null) supplier = new People.Client(); return supplier; } }


        public string SupplierName { get { if (GetSupplier != null) return GetSupplier.Name; else return "N/A"; } }
        public DateTime ExpiryDate { get; set; }    // Maintenance expiry date
        public bool Selected { get; set; } // When in a list, these items will be selected or unselected
        public bool SingleProduct { get; set; }
        public bool Stolen { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool DoMaintenanceCalcuation { get; set; } // Item can have maintenance
        public bool HasMaintenance
        {
            get
            {
                if (Client == null) return false;
                if (Client.Expirydate.Year < 2000) return false;
                if (Client.Expirydate < DateTime.Now) return false;
                if (ExpiryDate < DateTime.Now) return false;

                return ExpiryDate >= Client.Expirydate;
            }
        }
        public List<Product> ItemList { get; set; } // Each Item can contain multiple items
        public string Content { get; set; }
        public string ContentSummary
        {
            get
            {
                StringBuilder sb = new StringBuilder();

                if (SingleProduct)
                {
                    sb.Append(Description);
                }
                else
                {
                    foreach (var i in ItemList)
                    {
                        if (i.Selected) sb.Append(("" + i.Code).Trim());
                        else sb.Append("  ");
                        sb.Append(" ");
                    }
                }

                return sb.ToString().Trim();
            }
        }
        public HashSet<string> TransactionIDList { get; set; }
        public string GetStatus
        {
            get
            {
                string status = "";
                if (Stolen) status = "Stolen";
                return status;
            }
        }

        [field: NonSerialized]
        public string CalculationInfo;

        [field: NonSerialized]
        private Upgrade upgrade;
        public Upgrade Upgrade()
        {
            if (Name != null) upgrade = new Upgrade((Product)this.Clone());
            return upgrade;
        }

        public Product()
        {
            this.ItemList = new List<Product>();
            this.TransactionIDList = new HashSet<string>();
        }

        public Product(string Account)
        {
            this.ItemList = new List<Product>();
            this.TransactionIDList = new HashSet<string>();
            this.Account = Account;
        }

        public bool Save(string Message, bool Overwrite, bool UseLog)
        {
            bool saved = false;

            // Create a unique product name if from Custom Catalog
            if (CatalogName == "Custom" && (Name == null || Name.Trim() == ""))
                Name = AMS.Data.Keys.UserPKManager.NewUserPK(AMS.Data.Keys.KeyType.CustomProduct);

            // Check for valid data
            if (Name == null || Name == "" || Account == null || Account == "" || CatalogName == null || CatalogName == "")
            {
                string message = "Please enter a valid ";
                if (Name == null || Name == "") message += "name";
                else if (Account == null || Account == "") message += "account";
                else if (CatalogName == null || CatalogName == "") message += "catalog";

                AMS.MessageBox_v2.Show(message + " for this product!", AMS.MessageType.Error);
                return false;
            }

            ID = Name + " " + CatalogName;

            SetFile(ID, AMS.Settings.Program.Directories.Clients + Account + "\\Products", AMS.Data.DataType.Product);

            if (UseLog) AddDataLog(ID, Message, AMS.Data.DataType.Product);
            saved = DMS.ProductManager.Save(this, Message, Overwrite, true);
            AMS.Data.Keys.UserPKManager.UpdatePk(AMS.Data.Keys.KeyType.CustomProduct, this.Name);
            return saved;
        }

        // Methods

        /// <summary>
        /// Will check if product exists, and ask if you need to do an update.
        /// </summary>
        public void CheckUpgrade()
        {
            if (Name == null) return;

            // If Product does not exist, exit this method
            var queryExisting = DMS.ProductManager.GetData(i => i.Name == Name && i.CatalogName == CatalogName);
            if (queryExisting == null) return;

            ID = queryExisting.ID;

            string message = "";

            // Make sure this product belongs to the quoted client
            if (queryExisting.Account != Account)
            {
                var existingClient = DMS.ClientManager.GetData(i => i.Account == queryExisting.Account);
                message += "WARNING! This product belongs to " + existingClient.Name + "!\r\n\r\n";
            }

            var client = DMS.ClientManager.GetData(i => i.Account == Account);
            message += "Invoiced Client - " + client.Name + "\r\n" + "Product - " + Name;

            if (ExistingProduct(ID) && AMS.MessageBox_v2.Show(message + "\r\n\r\nThis product already exist.\r\nIs this an upgrade?", AMS.MessageType.Question) == AMS.MessageOut.YesOk)
            {
                // Do upgrade
                Upgrade();

                // Apply upgrade
                // Meta is nog missing, meskien moet die hele object this = upgrade result wees
                this.PriceExVat = upgrade.ResultProduct.PriceExVat;
                this.Version = upgrade.ResultProduct.Version;
                this.ExpiryDate = upgrade.ResultProduct.ExpiryDate;
                this.ItemList = upgrade.ResultProduct.ItemList;
                this.Account = queryExisting.Account;

                foreach (var i in upgrade.QuotedProduct.DatalogList)
                    this.DatalogList.Add(i);
                this.DatalogList.Add(new AMS.Data.Datalog()
                {
                    Message = upgrade.ExistingProduct.PriceExVat + " updated to " + upgrade.ResultProduct.PriceExVat
                });
                foreach (var i in upgrade.ResultProduct.DatalogList)
                    this.DatalogList.Add(i);
            }
        }

        public Product ExistingNameProduct(string Name)
        {
            if (Name == null) return null;
            var queryExisting = DMS.ProductManager.GetData(i => i.Name == Name);
            return queryExisting;
        }

        public bool ExistingProduct(string ID)
        {
            if (Name == null) return false;
            var queryExisting = DMS.ProductManager.GetData(i => i.ID == ID);
            return queryExisting != null;
        }

        public Product OldCheckExistingProduct(string Name, string Catalog)
        {
            // Make a backup for the existing product form quotation
            var originalProduct = (Product)this.Clone();

            // Checking if the product already exists, then giving the option to append the data
            var queryExisting = DMS.ProductManager.GetData(i => i.Name.ToLower() + " " + i.CatalogName.ToLower() == Name.ToLower() + " " + Catalog.ToLower());

            // Set Question box message
            string message = "Product: " + Name.ToUpper() + "\r\nCatalog: " + Catalog;
            string input = "";
            if (queryExisting != null)
            {
                input = queryExisting.PriceExVat.ToString();
                var client = DMS.ClientManager.GetData(i => i.Account == queryExisting.Account);

                if (client.Account != Account) message += "\r\n\r\nWARNING!\r\nThis product has been assigned to [" + client.Account + "] " + client.Name;
                message += "\r\n\r\nWould you like to append the new data to the existing product?";
            }
            else
            {
                message += "\r\n\r\nAre you sure you want to add new product?\r\nPressing 'No' will replace the original product data.";
            }

            // if product exist, show question box to continue
            if (queryExisting != null && AMS.MessageBox_v2.Show(message, input) == AMS.MessageOut.YesOk)
            {
                PriceExVat += queryExisting.PriceExVat;           // Add price
                foreach (var i in queryExisting.ItemList)  // Make sure all products are selected
                    if (i.Selected)
                    {
                        var queryProduct = (from qi in ItemList
                                            where qi.Name == i.Name
                                            select qi).FirstOrDefault();
                        queryProduct.Selected = true;
                    }

                this.Account = queryExisting.Account;    // Make sure account is the same
                this.ID = queryExisting.ID;              // Get same ID, this will add relationship, if/where needed
                this.Version = originalProduct.Version;    // use quoteProduct for quoted version
                this.Name = queryExisting.Name;
                this.CatalogName = Catalog;
            }
            else
            {
                this.Name = Name;
                this.CatalogName = Catalog;
            }

            return this;
        }

        public void ViewDatalog()
        {
            using (AMS.Forms.Log.DatalogViewer f = new AMS.Forms.Log.DatalogViewer(this))
            {
                f.ShowDialog();
                if (f.RequireSave)
                {
                    this.DatalogList = f.DatalogList;
                    this.Save("", true, false);
                }
            }
        }

        public override string ToString()
        {
            return $"{CatalogName} | {ID} | {ExpiryDate: yyyy MMM dd}";
        }
    }
}