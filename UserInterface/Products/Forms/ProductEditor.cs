using AMS;
using Data;
using Data.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterface.Products.Forms
{
    public partial class ProductEditor : Form
    {
        bool loading;
        private Product product;
        public Product Product { get { return product; } }
        private Product oldProduct;

        public ProductEditor(Product Product)
        {
            InitializeComponent();
            this.product = Product;
            this.oldProduct = (Product)Product.Clone(); ;
        }

        #region DropShadow

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
        private void ProductEditor_Load(object sender, EventArgs e)
        {
            #region ThemeColors

            ThemeColors.SetBorders(this);

            #endregion

            #region ToolTip

            toolTip1.SetToolTip(supplier_ComboBox, DMS.GetSupplierListInfo);
            toolTip1.SetToolTip(supplier_Label, DMS.GetSupplierListInfo);

            #endregion

            priceNumbox.Maximum = decimal.MaxValue;

            accountComboBox.Items.Clear();
            accountComboBox.Items.Add(product.Account); // Current Account
            accountComboBox.Items.Add(product.Account);
            accountComboBox.Items.Add("----------");

            catalog_ComboBox.Items.Add("");
            foreach (var i in DMS.CatalogManager.GetDataList())
                catalog_ComboBox.Items.Add(i.Name);

            supplier_ComboBox.Items.Clear();
            supplier_ComboBox.Items.Add("");
            foreach (var i in DMS.GetSupplierList)
                supplier_ComboBox.Items.Add(i.ID);

            LoadProduct();
        }

        // Methods

        private void LoadProduct()
        {
            loading = true;

            // Defaults
            if (product.ExpiryDate < new DateTime(1900, 1, 1)) product.ExpiryDate = new DateTime(1900, 1, 1);

            accountComboBox.Text = product.Account;
            catalog_ComboBox.Text = product.CatalogName;
            descriptionTextBox.Text = product.Description;
            expiryDateDateTimePicker.Value = product.ExpiryDate;
            iDTextBox.Text = product.Name;
            notesTextBox.Text = product.Notes;
            priceNumbox.Text = product.PriceExVat.ToString();
            stolenCheckBox.Checked = product.Stolen;
            userCountTextBox.Text = product.UserCount.ToString();
            versionTextBox.Text = product.Version;
            supplier_ComboBox.Text = product.SupplierID;
            dataLog1.SetDataLog(product);

            LoadProductItems();
            loading = false;
        }

        /// Load all Items from the product itemList, or add a description textbox
        private void LoadProductItems()
        {
            AMS.Utilities.Controls.FlowlayoutPanel.CleanUp(items_FlowLayoutPanel);
            if (product.ItemList == null) product.ItemList = new List<Data.Products.Product>();

            try
            {
                if (product.SingleProduct)
                {
                    Label l = new Label();
                    l.Text = "N/A";
                    l.Margin = new Padding(0);
                    l.Font = new Font(l.Font.FontFamily, 9, FontStyle.Regular);
                    l.AutoSize = true;
                    l.Click += ProductItem_Click;
                    items_FlowLayoutPanel.Controls.Add(l);
                }
                else
                {
                    foreach (var i in product.ItemList)
                    {
                        Label l = new Label();
                        l.Text = i.Code.Trim() + "";
                        l.Margin = new Padding(0);
                        l.Font = new Font(l.Font.FontFamily, 9, FontStyle.Regular);
                        l.AutoSize = true;
                        l.Click += ProductItem_Click;
                        if (i.Selected) { l.BackColor = ThemeColors.Primary; l.ForeColor = ThemeColors.PrimaryText; }
                        items_FlowLayoutPanel.Controls.Add(l);
                    }
                }
            }
            catch { }
        }

        private void ProductItem_Click(object sender, EventArgs e)
        {
            if (loading) return;

            Label label = (Label)sender;
            label.Click -= ProductItem_Click;

            foreach (var i in product.ItemList)
            {
                if ((i.Code + "").Trim() == label.Text)
                    i.Selected = !i.Selected;
            }

            LoadProductItems();
        }

        // Events

        private void save_Button_Click(object sender, EventArgs e)
        {
            if (loading) return;

            product.Account = accountComboBox.Text;
            product.CatalogName = catalog_ComboBox.Text;
            product.ExpiryDate = expiryDateDateTimePicker.Value;
            product.Name = iDTextBox.Text;
            product.Notes = notesTextBox.Text;
            product.PriceExVat = Convert.ToDecimal(priceNumbox.Text.ToString());
            product.Stolen = stolenCheckBox.Checked;
            product.UserCount = Convert.ToInt32(userCountTextBox.Text.ToString());
            product.Version = versionTextBox.Text;
            product.SupplierID = supplier_ComboBox.Text;
            product.Description = descriptionTextBox.Text;

            string message = product.Name + " updated.";

            if (product.Save(message, false, false))
            {
                if (product.Account != oldProduct.Account)
                    foreach (var i in DMS.ProductManager.GetDataList(qi => qi.Name == product.Name))
                    {
                        string msg = i.Name + " was moved to " + product.Account;
                        i.Account = product.Account;
                        i.Save(msg, false, true);
                    }

                this.Close();
            }
        }

        private void cancel_Button_Click(object sender, EventArgs e)
        {

            product = oldProduct;
            this.Close();
        }

        private void accountComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (loading) return;

            if (e.KeyData == System.Windows.Forms.Keys.Enter)
            {
                string search = accountComboBox.Text.ToLower();

                var clientList = (from i in DMS.ClientManager.GetDataList()
                                  where
                                  i.Account.ToLower().Contains(search) ||
                                  i.Name.ToLower().Contains(search)
                                  select i).ToList();

                accountComboBox.Items.Clear();
                accountComboBox.Items.Add(product.Account); // Current Account
                accountComboBox.Items.Add(product.Account);
                accountComboBox.Items.Add("----------");

                foreach (var i in clientList)
                    accountComboBox.Items.Add(i.Account + " - " + i.Name);
                System.Windows.Forms.Application.DoEvents();
                accountComboBox.DroppedDown = true;
            }
        }

        private void accountComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loading) return;

            if (accountComboBox.SelectedItem == null) return;
            accountComboBox.SelectedIndexChanged -= accountComboBox_SelectedIndexChanged;

            string selection = accountComboBox.SelectedItem.ToString();
            var client = DMS.ClientManager.GetData(i => i.Account + " - " + i.Name == selection);

            if (accountComboBox.SelectedIndex > 2)
            {
                product.Account = client.Account;
                accountComboBox.Items[1] = client.Account;
                accountComboBox.SelectedItem = 1;
            }
            else
            {
                accountComboBox.SelectedItem = 0;
                product.Account = accountComboBox.Items[0].ToString();
            }

            accountComboBox.SelectedIndexChanged += accountComboBox_SelectedIndexChanged;
            LoadProduct();
        }

        private void catalog_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loading) return;

            var catalog = DMS.CatalogManager.GetData(i => i.Name == catalog_ComboBox.Text);
            if (catalog == null) return;

            AMS.Utilities.Controls.FlowlayoutPanel.CleanUp(items_FlowLayoutPanel);
            product.ItemList = new List<Data.Products.Product>();

            foreach (var i in catalog.ItemList)
            {
                if (oldProduct.ItemList == null) oldProduct.ItemList = new List<Data.Products.Product>();
                Data.Products.Product existingItem = (from qi in oldProduct.ItemList
                                                      where i.Code != null && qi.Code == i.Code
                                                      select qi).FirstOrDefault();

                bool add = true;
                foreach (var pi in product.ItemList)
                    if (pi.Code == i.Code) add = false;

                if (add)
                    product.ItemList.Add(new Data.Products.Product()
                    {
                        Code = i.Code,
                        Name = i.Name,
                        Selected = (existingItem != null && existingItem.Selected)
                    });
            }

            LoadProductItems();
        }

        private void remove_Button_Click(object sender, EventArgs e)
        {
            if (loading) return;

            if (DMS.ProductManager.Delete("Are you sure you want to remove Product: " + product.Name + "?", product))
                this.Close();
        }

        private void iDTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (loading) return;

            timer1.Enabled = true;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer1.Stop();

            if (product.ExistingProduct(product.ID))
            {
                iDTextBox.BackColor = ThemeColors.Red;
                iDTextBox.ForeColor = ThemeColors.MenuText;
            }
            else
            {
                iDTextBox.BackColor = this.BackColor;
                iDTextBox.ForeColor = Color.Black;
            }
        }

        private void supplier_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            product.SupplierID = supplier_ComboBox.Text;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(product.GetSupplier.Name);
            sb.AppendLine(product.GetSupplier.GetMainContact.DisplayName);
            sb.AppendLine(product.GetSupplier.Telephone);
            sb.AppendLine(product.GetSupplier.GetMainContact.Email);

            supplierInfo_Label.Text = sb.ToString();
        }
    }
}