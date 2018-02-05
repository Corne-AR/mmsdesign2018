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
    public partial class ProductUpgradeForm : Form
    {
        private Product product;
        public Product Product
        {
            get
            {
                return product;
            }
        }

        // Construction

        public ProductUpgradeForm(Product Product)
        {
            InitializeComponent();
            this.product = Product;
        }

        // Load

        private void ProductUpgradeForm_Load(object sender, EventArgs e)
        {
            #region ThemeColors

            ThemeColors.SetBorders(this);
            ThemeColors.SetControls(this.Controls);
            resultProduct_Label.BackColor = ThemeColors.Menu;
            result_Label.BackColor = ThemeColors.Menu;

            #endregion

            if (product.Name == "")
            {
                AMS.MessageBox_v2.Show("Please enter a valid product number.", MessageType.QuestionInput);
                product.Name = AMS.MessageBox_v2.MessageValue;
            }
          
            UpgradeProduct();
        }

        // Methods

        private void UpgradeProduct()
        {
            upgradeProduct_Label.Text = ProductInfo(product.Upgrade().QuotedProduct);
            existingProduct_Llabel.Text = ProductInfo(product.Upgrade().ExistingProduct);
            resultProduct_Label.Text = ProductInfo(product.Upgrade().ResultProduct);
        }

        private string ProductInfo(Product product)
        {
            if (product == null) return "No valid data found";

            // Build text data
            StringBuilder sb = new StringBuilder();

            // Client info
            var client = DMS.ClientManager.GetData(i => i.Account == product.Account);
            if (client == null) client = new Data.People.Client();
            sb.AppendLine("Account: " + client.Account);
            sb.AppendLine("Client: " + client.Name);

            sb.AppendLine("Name: " + product.Name);         // Product Name ex: dongle nr
            // sb.AppendLine("Description: " + product.Description);
            sb.AppendLine("Value: " + Math.Round(product.PriceExVat, 2));
            sb.AppendLine("Version: " + product.Version);
            sb.AppendLine("Added: " + product.Metadata.Created);

            return sb.ToString();
        }

        // Events

        private void Upgrade_Click(object sender, EventArgs e)
        {
            // product = product.Upgrade().Product;
            this.Close();
        }
    }
}