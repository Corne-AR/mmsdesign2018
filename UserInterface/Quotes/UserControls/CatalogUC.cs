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
using Data.Quotes;

namespace UserInterface.Quotes.UserControls
{
    public partial class CatalogUC : UserControl
    {
        private Catalog oldCatalog;
        private Catalog catalog;
        private Quote quote;
        bool loading;
        private CatalogItem selectetCatalogItem;

        public CatalogUC()
        {
            InitializeComponent();
        }

        private void CatalogUC_Load(object sender, EventArgs e)
        {
            #region ThemeColors

            catalogItemDataGridView.DefaultCellStyle.SelectionBackColor = ThemeColors.Primary;
            catalogItemDataGridView.DefaultCellStyle.SelectionForeColor = ThemeColors.PrimaryText;

            catalogSpecific_Label.BackColor = ThemeColors.MenuBorder;
            catalogSpecific_Label.ForeColor = ThemeColors.MenuBorderText;

            addRow_Button.BackColor = ThemeColors.Menu;
            addRow_Button.ForeColor = ThemeColors.MenuText;

            panel2.BackColor = ThemeColors.Menu;
            panel2.ForeColor = ThemeColors.MenuText;

            priceIncVAT_Label.BackColor = ThemeColors.Primary;
            priceIncVAT_Label.ForeColor = ThemeColors.PrimaryText;
            priceIncVAT_Label.Visible = false;

            international_Label.BackColor = ThemeColors.Primary;
            international_Label.ForeColor = ThemeColors.PrimaryText;

            maint_Label.BackColor = ThemeColors.Primary;
            maint_Label.ForeColor = ThemeColors.PrimaryText;

            singleProduct_Label.BackColor = ThemeColors.Primary;
            singleProduct_Label.ForeColor = ThemeColors.PrimaryText;
            singleProduct_Label.Visible = false;

            #endregion

            // Hide ListPrice by default
            ListPrice_Column.Visible = false;
            
            // Load all Exchange Factor scripts
            exchangeScriptComboBox.Items.Clear();
            exchangeScriptComboBox.Items.Add("");
            foreach (var i in AMS_Script.ScriptManager.GetScriptList())
                exchangeScriptComboBox.Items.Add(i.Name);

            foreach (DataGridViewColumn col in catalogItemDataGridView.Columns)
                col.ContextMenuStrip = cell_ContextMenuStrip;
        }

        // Methods

        public void LoadCatalog(Catalog Catalog, Quote Quote)
        {
            loading = true;

            this.catalog = Catalog;
            this.oldCatalog = (Catalog)Catalog.Clone();

            this.quote = Quote;

            loading = false;

            UpdateCatalog();
        }

        public void UpdateCatalog()
        {
            loading = true;

            if (catalog == null) catalog = new Catalog();

            catalogSpecific_Label.Text = catalog.Name + " Catalog";
            catalogItemBindingSource.DataSource = catalog.GetItemList();

            foreach (DataGridViewRow row in catalogItemDataGridView.Rows)
            {
                if (row.Index != -1)
                {
                    var catalogItem = (CatalogItem)row.DataBoundItem;
                    var cell = ((DataGridViewComboBoxCell)row.Cells["Version"]);
                    cell.Items.Clear();

                    // Only if this product uses a version, then add all versions to this product in catalog
                    if (catalogItem != null && !string.IsNullOrEmpty(catalogItem.Version))
                    {
                        foreach (var i in catalogItem.GetVersions(catalog)) if (i != null) cell.Items.Add(i.ToString());
                    }
                }
            }

            loading = false;

            UpdateControls();
        }

        private void UpdateControls()
        {
            if (quote == null) return;

            loading = true;

            // Add Catalog Options
            cataDiscount_TextBox.Text = catalog.Discount.ToString();
            cataItemized_CheckBox1.Checked = catalog.Itemized;
            stolen_CheckBox.Checked = catalog.UseStolen;
            exchangeScriptComboBox.Text = catalog.DefaultScript;

            // Labels
            priceIncVAT_Label.Visible = catalog.PriceIncludeVAT;
            international_Label.Text = "Location: " + quote.GeoLocation().ToString();
            maint_Label.Text = "Maintenance: " + quote.Client.GetMaintenanceType().ToString();
            singleProduct_Label.Visible = catalog.SingleProduct;

            loading = false;
        }

        // Events

        private void catalogItemDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (catalogItemDataGridView.Columns[e.ColumnIndex].Name == Version.Name) return;
            AMS.MessageBox_v2.Show(e.Exception.Message, AMS.MessageType.Error);
        }

        private void Item_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Set row to selected, visuals mostly
            if (e.RowIndex == -1 || e.ColumnIndex == -1) return;
            var row = catalogItemDataGridView.Rows[e.RowIndex];
            row.Selected = true;
            ((UserInterface.Quotes.Forms.QuoteForm)Parent).UpdateQuote();
        }

        private void Item_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1) return;

            var cell = catalogItemDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
            var catalogItem = (CatalogItem)catalogItemDataGridView.Rows[e.RowIndex].DataBoundItem;

            // Change Version
            if (cell.ColumnIndex == Version.Index && cell.Value != null)
            {
                var version = (from i in oldCatalog.ItemList
                               where i.Name == catalogItem.Name && i.Version == cell.Value.ToString()
                               select i).FirstOrDefault();

                if (version != null)
                {
                    catalogItem.Version = version.Version;
                    catalogItem.ListPrice = version.ListPrice;
                    catalogItem.RetailScript = version.RetailScript;
                }
            }

            // Make sure only one item is selected on Single Product Catalogs
            if (catalog.SingleProduct && cell.ColumnIndex == SelectedColumn.Index && cell.Value != null)
            {
                foreach (DataGridViewRow row in catalogItemDataGridView.Rows)
                {
                    var rowItem = (CatalogItem)row.DataBoundItem;
                    if (rowItem != null)
                        if (rowItem != catalogItem)
                            rowItem.Selected = false;
                }
            }

            Validate();
            UpdateCatalog();
        }

        private void AddCustomItem_Click(object sender, EventArgs e)
        {
            if (catalog == null || catalog.ItemList == null) return;

            catalog.ItemList.Add(new CatalogItem()
            {
                COD = false,
                Code = catalog.ItemList.Count + 1 + "",
                Content = "",
                GlobalDiscount = false,
                ListPrice = 0,
                Maintenance = false,
                Name = "Custom Item",
                Notes = "",
                Selected = true,
                Stolen = false,
            });
            UpdateCatalog();
        }

        private void ShowListPrice_Click(object sender, EventArgs e)
        {
            if (((ToolStripMenuItem)sender).Text == "Show List Price")
            {
                ListPrice_Column.Visible = true;
                ((ToolStripMenuItem)sender).Text = "Hide List Price";

                UpdateCatalog();
                return;
            }

            if (((ToolStripMenuItem)sender).Text == "Hide List Price")
            {
                ListPrice_Column.Visible = false;
                ((ToolStripMenuItem)sender).Text = "Show List Price";

                UpdateCatalog();
                return;
            }
        }

        private void CatalogUpdate_Event(object sender, EventArgs e)
        {
            if (catalog == null || loading) return;

            catalog.Itemized = cataItemized_CheckBox1.Checked;
            catalog.UseStolen = stolen_CheckBox.Checked;
            catalog.DefaultScript = exchangeScriptComboBox.Text;

            try
            {
                catalog.Discount = Convert.ToDecimal(cataDiscount_TextBox.Text.ToString());
            }
            catch { }
        }

        private void Item_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1) return;

            // Right Click Menu
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                selectetCatalogItem = (CatalogItem)catalogItemDataGridView.Rows[e.RowIndex].DataBoundItem;
                if (selectetCatalogItem == null) return;
                cell_ContextMenuStrip.Show(catalogItemDataGridView, catalogItemDataGridView.PointToClient(Cursor.Position));
            }
        }

        private void ShowScript_Click(object sender, EventArgs e)
        {
            if (selectetCatalogItem == null || selectetCatalogItem.UsedScript == null) return;

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(selectetCatalogItem.UsedScript.Name);
            sb.AppendLine("");
            sb.AppendLine(selectetCatalogItem.UsedScript.ScriptContent);

            AMS.MessageBox_v2.Show(sb.ToString());
        }

        private void ItemDetails_Click(object sender, EventArgs e)
        {
            if (selectetCatalogItem == null) return;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Name: " + selectetCatalogItem.Name);
            sb.AppendLine("Version: " + selectetCatalogItem.Version);
            sb.AppendLine("List Price: " + selectetCatalogItem.ListPrice);
            sb.AppendLine("Retail Price: " + selectetCatalogItem.RetailPrice);
            sb.AppendLine("Bulk Discount: " + selectetCatalogItem.BulkDiscount);
            sb.AppendLine("COD Discount: " + selectetCatalogItem.COD);
            sb.AppendLine("GlobalDiscount Discount: " + selectetCatalogItem.GlobalDiscount);
            sb.AppendLine("Maintenance Discount: " + selectetCatalogItem.Maintenance);
            sb.AppendLine("SupplierID: " + selectetCatalogItem.SupplierID);

            AMS.MessageBox_v2.Show(sb.ToString());
        }

        private void ItemContent_Click(object sender, EventArgs e)
        {
            if (selectetCatalogItem == null) return;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Content\r\n\r\n" + selectetCatalogItem.Content);
            AMS.MessageBox_v2.Show(sb.ToString());

        }

        private void VATAdd_Click(object sender, EventArgs e)
        {
            var row = catalogItemDataGridView.SelectedCells[0].OwningRow;

            var item = (CatalogItem)row.DataBoundItem;

            item.ListPrice *= DMS.VatRateValue;
        }

        private void VATRemove_Click(object sender, EventArgs e)
        {
            var row = catalogItemDataGridView.SelectedCells[0].OwningRow;

            var item = (CatalogItem)row.DataBoundItem;

            item.ListPrice /= DMS.VatRateValue;
        }

        private void editContentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var row = catalogItemDataGridView.SelectedCells[0].OwningRow;
            var item = (CatalogItem)row.DataBoundItem;

            using (UserInterface.Catalogs.Forms.ContentEditor f = new Catalogs.Forms.ContentEditor(item.Content))
            {
                f.ShowDialog();
                string oldContent = item.Content;

                if (f.Content == null) item.Content = oldContent;
                else item.Content = f.Content;
            }
        }
    }
}