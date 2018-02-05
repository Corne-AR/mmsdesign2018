using AMS;
using UserInterface.Products.Forms;
using Data;
using Data.Products;
using Data.Quotes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterface.Quotes.Forms
{
    public partial class QuoteConfirmation : Form
    {
        public bool Saved = false;
        public bool HasMaintenance = false;
        private List<Product> productList;
        public List<Product> ProductList { get { return productList; } }
        private List<Product> backupProductList;
        private List<Product> validProductList = new List<Product>();
        private Quote Quote;

        // Constructors

        public QuoteConfirmation(Quote Quote)
        {
            InitializeComponent();

            this.Quote = Quote;
            // OLDLoadProducts();
            LoadProducts();
            quoteBindingSource.DataSource = this.Quote;
        }

        #region Drop Shadow

        private const int CS_DROPSHADOW = 0x20000;


        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        #endregion

        // Load

        private void ProductManager_Load(object sender, EventArgs e)
        {
            #region Theme

            ThemeColors.SetControls(this.Controls);
            ThemeColors.SetBorders(this);

            #endregion

            footer1.UpdateFooterText("Quote Confirmation");

            StringBuilder sb = new StringBuilder();
            sb.Append("Summary");
            sb.AppendLine();
            sb.AppendLine();

            if (Quote.PaymentTerms == "COD") sb.Append(string.Format("COD - {0:0.00}", Quote.CODTotal));
            else sb.Append(string.Format("Total - {0:0.00}", Quote.Total));

            label1.Text = sb.ToString();
        }

        // Methods

        private void LoadProducts()
        {
            productList = new List<Product>();
            backupProductList = new List<Product>();

            foreach (var catalog in Quote.CaluclatedCatalogList)
            {
                var newProduct = new Product();
                var ItemList = new List<Data.Products.Product>();
                var version = "";

                if (catalog.SingleProduct)
                {
                    foreach (var i in catalog.ItemList)
                    {
                        if (i.Selected)
                            newProduct.Description = i.Name;

                        if (i.Maintenance && i.Selected) newProduct.DoMaintenanceCalcuation = true;
                    }
                }
                else
                {
                    foreach (var i in catalog.GetItemList())
                    {
                        if (string.IsNullOrEmpty(version) && i.Selected) version = i.Version;

                        ItemList.Add(new Data.Products.Product()
                        {
                            CatalogName = catalog.Name,
                            Code = i.Code,
                            Name = i.Name,
                            Description = i.Description,
                            PriceExVat = i.RetailPrice / 1.14m,
                            SupplierID = i.SupplierID,
                            Version = i.Version,
                            Selected = i.Selected
                        });

                        if (i.Maintenance) newProduct.DoMaintenanceCalcuation = true;
                    }
                }

                newProduct.Account = Quote.Account;
                newProduct.CatalogName = catalog.Name;
                if (!string.IsNullOrEmpty(catalog.CatalogReference)) newProduct.CatalogName = catalog.CatalogReference;
                newProduct.Name = catalog.ProductName;
                if (newProduct.DoMaintenanceCalcuation)
                {
                    newProduct.ExpiryDate = Quote.ExtendDate;
                    HasMaintenance = true;
                }
                newProduct.PriceExVat = Math.Round(catalog.TotalValue, 2);
                if (Quote.PaymentTerms == "COD") newProduct.PriceExVat = Math.Round(catalog.CODValue, 2);
                newProduct.ItemList = ItemList;
                newProduct.Version = version;
                newProduct.SingleProduct = catalog.SingleProduct;
                newProduct.SupplierID = catalog.DefaultSupplierID;

                string description = "" + catalog.Name;
                var split = description.Split(' ');

                if (split.First() != "Maintenance" && !catalog.NonProduct)
                {
                    productList.Add(newProduct);
                }
            }

            // Make a backup to be able reload the original data
            foreach (var i in productList)
                backupProductList.Add((Product)i.Clone());

            quote_productListUC.LoadProductList(productList, true);
            SetButtonColors();
        }

        private void OLDLoadProducts()
        {
            productList = new List<Product>();
            backupProductList = new List<Product>();

            foreach (var p in Quote.Transaction.ItemList)
            {
                var newProduct = new Product();

                newProduct.Account = Quote.Account;
                newProduct.CatalogName = p.CatalogName;
                // newProduct.Description = p.Description;
                newProduct.Name = p.Name;
                newProduct.ExpiryDate = DMS.ClientManager.GetData(i => i.Account == Quote.Account).Expirydate;
                newProduct.PriceExVat = p.PriceExVat;
                newProduct.ItemList = p.ItemList;
                newProduct.Version = p.Version;

                // Query if catalog is from custom, and is an upgrade
                if (p.CatalogName == "Custom")
                {
                    var splitName = p.Name.Split(' ');
                    string catalog = "Custom";
                    if (splitName.Count() > 1)
                    {
                        if (splitName[0].ToString().ToUpper() == "UPGRADE")
                        {
                            catalog = splitName[1] + " " + splitName[2];
                        }
                        else catalog = "Custom";
                    }

                    p.CatalogName = catalog;
                }

                string description = "" + p.Name;
                var split = description.Split(' ');

                if (split.First() != "Maintenance")
                {
                    productList.Add(newProduct);
                }
            }

            // Make a backup to be able reload the original data
            foreach (var i in productList)
                backupProductList.Add((Product)i.Clone());

            quote_productListUC.LoadProductList(productList, true);
        }

        public void ValidateProducts()
        {
            // AMS.MessageBox_v2.Show("Validate Products are Under development, Please update manually for now.", 2500);

            validProductList = new List<Product>();
            foreach (var i in productList)
            {
                 i.CheckUpgrade();
                validProductList.Add(i);
            }

            quote_productListUC.LoadProductList(validProductList, true);
        }

        private void SetButtonColors()
        {
            bool colorValidate = false;

            foreach(var i in productList)
            {
                var checkExisting = DMS.ProductManager.GetData(qi => qi.ID == i.ID);
                if(checkExisting != null)
                {
                    colorValidate = true;
                    break;
                }
            }

            bool colorSave = !colorValidate;
            
            if (colorSave) ThemeColors.SetControls(save_Button, ThemeColors.ControlType.Primary);
            else ThemeColors.SetControls(save_Button, ThemeColors.ControlType.Menu);

            if (colorValidate) ThemeColors.SetControls(validate_Button, ThemeColors.ControlType.Primary);
            else ThemeColors.SetControls(validate_Button, ThemeColors.ControlType.Menu);

            ThemeColors.SetControls(reload_Button, ThemeColors.ControlType.Menu);
            ThemeColors.SetControls(close_Button, ThemeColors.ControlType.Menu);
        }

        // Events

        private void save_Button_Click(object sender, EventArgs e)
        {
            ValidateProducts();

            foreach (var i in validProductList)
            {
                if (!i.Save("Product " + i.Name + " was Added/Updated from Quote: " + Quote.ID, false, true))
                {
                    Saved = false;
                    break;
                }
                Quote.AddDataLog("Quote", "Product " + i.Name + " was Added/Updated.", AMS.Data.DataType.Quote);
                Saved = true;
            }

            if (!Saved)
            {
                var msg = AMS.MessageBox_v2.Show("There are unsaved products, are you sure you want to continue", MessageType.Question);
                Saved = msg == MessageOut.YesOk;
            }

            if (Saved)
            {
                Quote.Save("Updating Log", true, false, ProgressType.Finalized);
                this.Close();
            }
        }

        private void close_Button_Click(object sender, EventArgs e)
        {
            // Forces Memory to clear, else the eventhandlers will try to call the closed items while in memory
            quote_productListUC.Dispose();
            productList = null;

            // Finally close
            this.Close();
        }

        private void reload_Button_Click(object sender, EventArgs e)
        {
            quote_productListUC.LoadProductList(backupProductList, true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ValidateProducts();
        }

        private void QuoteConfirmation_Shown(object sender, EventArgs e)
        {
            SetButtonColors();
        }
    }
}