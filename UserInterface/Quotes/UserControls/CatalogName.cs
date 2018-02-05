using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data.Catalogs;
using Data;
using AMS;

namespace UserInterface.Quotes.UserControls
{
    public partial class CatalogName : UserControl
    {
        public Catalog Catalog = new Catalog();
        public bool IsSelected { get { return (this.BackColor == ThemeColors.Primary); } }

        public CatalogName()
        {
            InitializeComponent();
        }

        public CatalogName(Catalog Catalog)
        {
            InitializeComponent();

            this.Catalog = Catalog;

            catalogBindingSource.DataSource = this.Catalog;

            Remove_Button.Tag = Catalog.Name;
        }

        // Load

        private void CatalogName_Load(object sender, EventArgs e)
        {
            this.existingProductColor_Panel.BackColor = ThemeColors.Menu;

            if(Catalog.Count < 1) Catalog.Count = 1;

            productName_TextBox.Visible = !Catalog.NonProduct;
        }

        // Methods
       
        internal void SetSelected()
        {
            this.BackColor = ThemeColors.Primary;
            this.ForeColor = ThemeColors.PrimaryText;
        }

        internal void SetUnSelected()
        {
            this.BackColor = ThemeColors.ControlList;
            this.ForeColor = ThemeColors.ControlText;
        }

        // Events

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Verify if product is existing.

            if (Catalog.NonProduct) return;

            Catalog.ProductName = productName_TextBox.Text;

            string catalogName = Catalog.Name;
            if (!string.IsNullOrEmpty(Catalog.CatalogReference)) catalogName = Catalog.CatalogReference;
            string productName = Catalog.ProductName;

            var product = DMS.ProductManager.GetData(i => i.Name.ToLower() == productName.ToLower() && i.CatalogName == catalogName);
            if (product != null)
            {
                var client = DMS.ClientManager.GetData(i => i.Account == product.Account);

                this.existingProductColor_Panel.BackColor = ThemeColors.Orange;
                string message = "Product belongs to  [" + client.Account + "] " + client.Name;
                toolTip1.SetToolTip(this, message);
                toolTip1.SetToolTip(existingProductColor_Panel, message);
                toolTip1.SetToolTip(productName_TextBox, message);
            }
            else
            {
                this.existingProductColor_Panel.BackColor = this.BackColor;
                string message = "";
                toolTip1.SetToolTip(this, message);
                toolTip1.SetToolTip(existingProductColor_Panel, message);
                toolTip1.SetToolTip(productName_TextBox, message);
            }
        }
      
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            productName_TextBox.Visible = !Catalog.NonProduct;
            productName_TextBox.Visible = numericUpDown1.Value == 1;
            
            if (!productName_TextBox.Visible) Catalog.ProductName = "";
        }
    }
}
