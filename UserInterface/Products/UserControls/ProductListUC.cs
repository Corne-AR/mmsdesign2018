using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data.Products;
using Data;
using AMS;

namespace UserInterface.Products.UserControls
{
    public partial class ProductListUC : UserControl
    {
        // Variables

        private Data.People.Client client;
        private List<Product> productList;
        public List<Product> ProductList { get { return productList; } }
        public List<Product> SelectedProducts
        {
            get
            {
                var list = new List<Product>();

                foreach (DataGridViewCell cell in productDataGridView.SelectedCells)
                    cell.OwningRow.Selected = true;

                foreach (DataGridViewRow row in productDataGridView.SelectedRows)
                    list.Add((Product)row.DataBoundItem);

                return list;
            }
        }
        private Product contextProduct;
        private bool fromQuote;
        public bool ShowClientInfo;

        public HashSet<string> ChangeList = new HashSet<string>();

        private bool loading;

        // Constructors

        public ProductListUC()
        {
            InitializeComponent();
        }

        // Load

        private void ProductListUC_Load(object sender, EventArgs e)
        {
            #region Theme

            ThemeColors.SetControls(this.Controls);
            ThemeColors.SetControls(products_Label, ThemeColors.ControlType.Menu);

            iD_ToolStripMenuItem.BackColor = ThemeColors.Primary;
            iD_ToolStripMenuItem.ForeColor = ThemeColors.PrimaryText;

            productDataGridView.DefaultCellStyle.BackColor = ThemeColors.ControlList;
            productDataGridView.DefaultCellStyle.ForeColor = ThemeColors.ControlText;

            productDataGridView.DefaultCellStyle.SelectionBackColor = ThemeColors.Primary;
            productDataGridView.DefaultCellStyle.SelectionForeColor = ThemeColors.PrimaryText;

            #endregion

            if (DMS.ClientManager == null) return;

            client = new Data.People.Client();

            Notes_Column.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            DMS.ClientManager.OnSelect_Enter += LoadProducts_Event;
            DMS.ClientManager.OnSaved_Event += LoadProducts_Event;
            DMS.QuoteManager.OnSaved_Event += LoadProducts_Event;
            DMS.TransactionManager.OnSaved_Event += LoadProducts_Event;
            DMS.SearchManager.Product_Search += SearchManager_SearchEvent;
            DMS.SearchManager.Clear_Search += LoadProducts_Event;

            SupplierID_Column.Items.Clear();
            SupplierID_Column.Items.Add("");
            foreach (var i in DMS.GetSupplierList)
                SupplierID_Column.Items.Add(i.ID);

            System.Windows.Forms.Application.DoEvents();
        }

        // Methods

        private void SortBy(DataGridViewColumn Column)
        {
            if (Column == CatalogName_Column) productList = productList.OrderBy(i => i.CatalogName).ToList();
            if (Column == Content_Column) productList = productList.OrderBy(i => i.Content).ToList();
            if (Column == ExpiryDate_Column) productList = productList.OrderBy(i => i.ExpiryDate).ToList();
            if (Column == Name_Column) productList = productList.OrderBy(i => i.Name).ToList();
            if (Column == Notes_Column) productList = productList.OrderBy(i => i.Notes).ToList();
            if (Column == PriceExVat_Column) productList = productList.OrderBy(i => i.PriceExVat).ToList();
            if (Column == SupplierID_Column) productList = productList.OrderBy(i => i.SupplierID).ToList();
            if (Column == SupplierName_Column) productList = productList.OrderBy(i => i.SupplierName).ToList();
            if (Column == UserCount_Column) productList = productList.OrderBy(i => i.UserCount).ToList();
            if (Column == Version_Column) productList = productList.OrderBy(i => i.Version).ToList();

            LoadProductList();
        }

        internal void LoadProductList(List<Product> productList, bool FromQuote)
        {
            fromQuote = FromQuote;
            if (FromQuote)
            {
                productDataGridView.ReadOnly = false;
            }

            this.productList = productList;

            LoadProductList();
        }

        private void LoadProductList()
        {
            if (productList == null) return;
            loading = true;

            productBindingSource.DataSource = productList;

            foreach (DataGridViewRow row in productDataGridView.Rows)
            {
                var item = (Product)row.DataBoundItem;

                if (item != null)
                {
                    if (!fromQuote) item.Selected = false;

                    // Set flags

                    #region Maintenance

                    if (item.HasMaintenance == false)
                    {
                        row.DefaultCellStyle.BackColor = Color.Red;
                        row.DefaultCellStyle.ForeColor = Color.White;
                    }

                    #endregion

                    #region Stolen

                    if (item.Stolen)
                    {
                        row.DefaultCellStyle.BackColor = Color.Black;
                        row.DefaultCellStyle.ForeColor = Color.DarkGray;
                    }

                    #endregion
                }
            }


            ClientName.Visible = ShowClientInfo;
            ClientExpiryDate.Visible = ShowClientInfo;

            loading = false;
        }

        // Event

        private void LoadProducts_Event(object sender, EventArgs e)
        {
            if (DMS.ClientManager.CurrentData == null || DMS.ClientManager.CurrentData.Account == null) return;
            productList = DMS.ProductManager.GetDataList(i => i.Account == DMS.ClientManager.CurrentData.Account);
            client = DMS.ClientManager.CurrentData;
            LoadProductList();
        }

        private void SearchManager_SearchEvent(object sender, Data.Search.ProductSearchArgs e)
        {
            foreach (DataGridViewRow row in productDataGridView.Rows)
            {
                string productName = row.Cells[Name_Column.Index].Value.ToString();

                var queryList = (from i in e.ProductList
                                 where i.Name == productName
                                 select i).FirstOrDefault();

                var foreColor = productDataGridView.DefaultCellStyle.ForeColor;
                var backColor = productDataGridView.DefaultCellStyle.BackColor;

                if (queryList != null)
                {
                    foreColor = ThemeColors.SearchText;
                    backColor = ThemeColors.Search;
                }

                if (e.Product != null && e.Product.Name == productName)
                {
                    foreColor = ThemeColors.SearchMatchText;
                    backColor = ThemeColors.SearchMatch;
                }

                foreach (DataGridViewCell cell in row.Cells)
                {
                    //if (cell.ColumnIndex != Flag_Processed.Index)
                    //{
                    cell.Style.BackColor = backColor;
                    cell.Style.ForeColor = foreColor;
                    //}
                }
            }
        }

        internal void RemoveProduct(Product product)
        {
            productList.Remove(product);
            LoadProductList();
        }

        public new void Dispose()
        {
            DMS.ClientManager.OnSelect_Enter -= LoadProducts_Event;
            DMS.QuoteManager.OnSaved_Event -= LoadProducts_Event;
            DMS.TransactionManager.OnSaved_Event -= LoadProducts_Event;

            LoadProductList(new List<Product>(), false);
            this.Dispose(true);
        }

        private void productDataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (e.RowIndex == -1)
            {
                SortBy(productDataGridView.Columns[e.ColumnIndex]);
            }

            if (e.Button == System.Windows.Forms.MouseButtons.Right && e.RowIndex >= 0)
            {
                contextProduct = (Product)productDataGridView.Rows[e.RowIndex].DataBoundItem;
                if (contextProduct == null) return;
                iD_ToolStripMenuItem.Text = "Product " + contextProduct.Name;

                rightclick_ContextMenuStrip.Show(productDataGridView, productDataGridView.PointToClient(Cursor.Position));
            }
        }

        private void ItemLog_Click(object sender, EventArgs e)
        {
            if (contextProduct != null) contextProduct.ViewDatalog();
        }

        private void RemoveItem_Click(object sender, EventArgs e)
        {
            if (contextProduct != null && fromQuote)
            {
                productList.Remove(contextProduct);
                ((Quotes.Forms.QuoteConfirmation)this.Parent).ValidateProducts();
            }

            if (contextProduct != null && !fromQuote && AMS.MessageBox_v2.Show("Why are you removing this item?", AMS.MessageType.Question) == AMS.MessageOut.YesOk)
            {
                if (DMS.ProductManager.Delete(AMS.MessageBox_v2.MessageValue, contextProduct))
                {
                    contextProduct.Client.AddDataLog(contextProduct.CatalogName + " " + contextProduct.Name, "Product " + contextProduct.CatalogName + " " + contextProduct.Name + " Removed\r\nNote: " + AMS.MessageBox_v2.MessageValue, AMS.Data.DataType.Product);
                    contextProduct.Client.Save("", true, false);
                }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (contextProduct != null)
            {
                using (Products.Forms.ProductEditor f = new Forms.ProductEditor(contextProduct))
                {
                    f.ShowDialog();
                    productList = DMS.ProductManager.GetDataList(i => i.Account == DMS.ClientManager.CurrentData.Account);
                    LoadProductList();
                }
            }
        }

        private void SetupFileRequest_Click(object sender, EventArgs e)
        {
            /// TODO add email templates at catalog level

            StringBuilder sb = new StringBuilder();
            foreach (var i in SelectedProducts)
                sb.Append(i.Name + " ");

            var supplier = SelectedProducts[0].GetSupplier;

            if (sb.Length > 2) sb.Length -= 1;

            var mail = DMS.MailManager.NewMail(
                supplier.Account,
                true,
                sb.ToString() + " Setup File(s)",
                sb.ToString(),
                null,
                Data.Communications.TemplateTypes.SupplierSetupInfo);

            DMS.MailManager.SendGeneralMail(mail);

            client.AddDataLog("Email", "Setup File Request for: " + sb.ToString(), AMS.Data.DataType.Product);
            client.Save("Setup file request", true, false);
        }

        private void UpgradeQuoteRequest_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Client Ref:");
            foreach (var i in SelectedProducts)
                sb.Append(i.Name + " ");

            var supplier = SelectedProducts[0].GetSupplier;

            if (sb.Length > 2) sb.Length -= 1;

            sb.AppendLine();
            sb.AppendLine();
            sb.AppendLine("Client Info");
            sb.AppendLine();
            sb.AppendLine(client.GetSummary);

            var mail = DMS.MailManager.NewMail(
               supplier.Account,
               true,
               sb.ToString(),
               sb.ToString(),
               null,
               Data.Communications.TemplateTypes.SupplierUpgrade);

            DMS.MailManager.SendGeneralMail(mail);

            client.AddDataLog("Email", "Upgrade Quotation Request for: " + sb.ToString(), AMS.Data.DataType.Product);
            client.Save("Upgrade Quotation Request", true, false);
        }

        private void rightclick_ContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            if (SelectedProducts.Count > 0)
            {
                supplier_ToolStripMenuItem.Enabled = true;
                supplier_ToolStripMenuItem.Text = "Supplier (" + SelectedProducts.Count + ")";

                supplier_ToolStripMenuItem.Enabled = true;
                updateMaintSelected_ToolStripMenuItem.Text = "Update (" + SelectedProducts.Count + ")";
            }
            else
            {
                supplier_ToolStripMenuItem.Enabled = false;
                updateMaintSelected_ToolStripMenuItem.Enabled = false;
            }
        }

        private void RenewMaintenance_Click(object sender, EventArgs e)
        {
            if (((ToolStripMenuItem)sender).Name == updateMaintSelected_ToolStripMenuItem.Name)
            {
                if (AMS.MessageBox_v2.Show(string.Format("Would you like to update the " + SelectedProducts.Count + " product(s) to {0:MMM yyyy}?", client.Expirydate), AMS.MessageType.Question) == AMS.MessageOut.YesOk)
                {
                    foreach (var i in SelectedProducts)
                    {
                        string message = string.Format("{0} {1} maintenance updated from {2:dd MMM yyyy} to {3:dd MMM yyyy}", i.CatalogName, i.Name, i.ExpiryDate, i.Client.Expirydate);
                        i.ExpiryDate = i.Client.Expirydate;
                        i.Save(message, true, true);
                    }
                }

            }
        }

        private void Transfer_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Data.Products.Utilities.MoveProduct(contextProduct.ID);
        }

        private void mailToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void maintenanceToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void productDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (loading || e.RowIndex < 0) return;

            var product = productDataGridView.Rows[e.RowIndex].DataBoundItem as Data.Products.Product;

            if (product != null)
                ChangeList.Add(product.ID);
        }

        private void productDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception.Message == "DataGridViewComboBoxCell value is not valid.")
            {
                object value = productDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (!((DataGridViewComboBoxColumn)productDataGridView.Columns[e.ColumnIndex]).Items.Contains(value))
                {
                    ((DataGridViewComboBoxColumn)productDataGridView.Columns[e.ColumnIndex]).Items.Add(value);
                    e.ThrowException = false;
                }
            }
        }

        private void productDataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var product = productDataGridView.Rows[e.RowIndex].DataBoundItem as Data.Products.Product;
            if (product == null) return;

            using (Products.Forms.ProductEditor f = new Forms.ProductEditor(product))
            {
                f.ShowDialog();
                productList = DMS.ProductManager.GetDataList(i => i.Account == DMS.ClientManager.CurrentData.Account);
                LoadProductList();
            }
        }

        private void maintenanceInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var msg = AMS.MessageBox_v2.Show("Create a 1 year software support subscription invoice?", MessageType.Question);
            if (msg != MessageOut.YesOk) return;

            var trans = Data.Transactions.Utilities.CreateMaintenanceInvoice(client.Account, 1, SelectedProducts);

            using (var form = new UserInterface.Transactions.Forms.TransactionForm(trans))
            {
                form.ShowDialog();
            }
        }

        private void maintenance2YearInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var msg = AMS.MessageBox_v2.Show("Create a 2 year software support subscription invoice?", MessageType.Question);
            if (msg != MessageOut.YesOk) return;

            var trans = Data.Transactions.Utilities.CreateMaintenanceInvoice(client.Account, 2, SelectedProducts);

            using (var form = new UserInterface.Transactions.Forms.TransactionForm(trans))
            {
                form.ShowDialog();
            }
        }

        private void exchangeKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var msg = AMS.MessageBox_v2.Show("Enter new security key nr. e.g. 2017123.", MessageType.QuestionInput);
            if (msg != MessageOut.YesOk) return;

            var value = MessageBox_v2.MessageValue;

            foreach (var p in SelectedProducts)
            {
                var log = $"{p.Name} changed to {value}";
                p.Notes += "\r\n" + log;
                p.Notes = p.Notes.Trim();
                p.Name = value;
                p.Save(log, true, true);
            }

        }

        private void rightClick_MenuItem_ChangedContactDetails_Click(object sender, EventArgs e)
        {
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendLine("Client Reference:");
                foreach (var i in SelectedProducts)
                    sb.Append(i.Name + " ");

                var supplier = SelectedProducts[0].GetSupplier;

                if (sb.Length > 2) sb.Length -= 1;

                sb.AppendLine();
                sb.AppendLine();
                sb.AppendLine("New Contact person:");
                sb.AppendLine();
                sb.AppendLine(client.GetContact);

                var mail = DMS.MailManager.NewMail(
                   supplier.Account,
                   true,
                   sb.ToString(),
                   sb.ToString(),
                   null,
                   Data.Communications.TemplateTypes.NewContactPerson);

                DMS.MailManager.SendGeneralMail(mail);

                client.AddDataLog("Email", "New Contact person for: " + sb.ToString(), AMS.Data.DataType.Product);
                client.Save("New Contact person", true, false);
            }
        }
    }
}