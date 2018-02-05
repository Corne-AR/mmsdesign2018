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

namespace UserInterface.Catalogs.UserControls
{
    public partial class CatalogDataGrid : UserControl
    {
        Catalog catalog = new Catalog();
        bool loading;

        public CatalogDataGrid()
        {
            InitializeComponent();
        }

        // Load

        private void CatalogInfo_Load(object sender, EventArgs e)
        {
            #region ThemeColor

            RetailPrice.DefaultCellStyle.BackColor = ThemeColors.Primary;
            RetailPrice.DefaultCellStyle.ForeColor = ThemeColors.PrimaryText;

            ThemeColors.SetControls(scripts_Label, ThemeColors.ControlType.Menu);
            ThemeColors.SetControls(forexScripts_Label, ThemeColors.ControlType.Menu);
            ThemeColors.SetControls(terms_Button, ThemeColors.ControlType.Menu);

            #endregion

            #region Tool Tips

            toolTip1.SetToolTip(group_ComboBox, "To which group does this catalog belong to?");
            toolTip1.SetToolTip(catalogReference_ComboBox, "The reference will be use instead of the catalog name for products. ex. Upgrading from this catalog, but using the referenced name at quote/product time.");

            toolTip1.SetToolTip(codOnly_Label, "This will remove the option to pay over 30 days on a quote");
            toolTip1.SetToolTip(itemizedQuote_Label, "On quote, this catalog will not summarize");
            toolTip1.SetToolTip(noProduct_Label, "This catalog contains no products to be saved in database");
            toolTip1.SetToolTip(priceIncludeVAT_Label, "All the prices already include Vat");
            toolTip1.SetToolTip(singleProduct_Label, "Only one of these items can be selected for a quote/invoice");

            SupplierID_Column.ToolTipText = DMS.GetSupplierListInfo;
            toolTip1.SetToolTip(supplierID_ComboBox, DMS.GetSupplierListInfo);
            toolTip1.SetToolTip(suppliers_Button, DMS.GetSupplierListInfo);

            #endregion

            if (DMS.CatalogManager == null || DMS.ClientManager == null || AMS.Suite.SuiteManager.Profile == null) return;

            // Supplier
            supplierID_ComboBox.Items.Clear();
            supplierID_ComboBox.Items.Add("");

            SupplierID_Column.Items.Clear();
            SupplierID_Column.Items.Add("");

            foreach (var i in DMS.GetSupplierList)
            {
                supplierID_ComboBox.Items.Add(i.ID);
                SupplierID_Column.Items.Add(i.ID);
            }

            LoadGroups();
            LoadCatalog(catalog);
        }

        // Methods

        public void LoadData()
        {
            // Retail Scripts
            RetailScript.Items.Clear();
            RetailScript.Items.Add("");
            ScriptName.Items.Clear();
            ScriptName.Items.Add("");
            defaultScript_ComboBox.Items.Clear();
            defaultScript_ComboBox.Items.Add("");

            foreach (var script in AMS_Script.ScriptManager.GetScriptList())
            {
                RetailScript.Items.Add(script.Name.ToString());
                ScriptName.Items.Add(script.Name.ToString());
                defaultScript_ComboBox.Items.Add(script.Name.ToString());
            }

            defaultScript_ComboBox.Text = catalog.DefaultScript;

            // Forex List for catalog
            if (catalog.ForexList == null) catalog.ForexList = new List<Forex>();
            foreach (var i in AMS.Suite.SuiteManager.Profile.ForexList)
            {
                var forex = (from qi in catalog.ForexList
                             where qi.Name == i
                             select qi).FirstOrDefault();
                if (forex == null) catalog.ForexList.Add(new Forex() { Name = i });
            }

            forexBindingSource.DataSource = catalog.ForexList;

            // Get list of Terms & Conditions
            terms_ComboBox.Items.Clear();
            maintTerms_ComboBox.Items.Clear();
            terms_ComboBox.Items.Add("");
            maintTerms_ComboBox.Items.Add("");

            foreach (var i in AMS.Reports.Report_Manager.Terms)
            {
                terms_ComboBox.Items.Add(i.File.Name);
                maintTerms_ComboBox.Items.Add(i.File.Name);
            }
            terms_ComboBox.Text = catalog.TermsFileName;
            maintTerms_ComboBox.Text = catalog.MaintTermsFileName;

            // Catalog References
            catalogReference_ComboBox.Items.Clear();
            catalogReference_ComboBox.Items.Add("");

            foreach (var i in DMS.CatalogManager.GetDataList(qi => qi.CatalogGroup == catalog.CatalogGroup && qi.Name != catalog.Name))
                catalogReference_ComboBox.Items.Add(i.Name);

            catalogReference_ComboBox.Text = catalog.CatalogReference;

            // Supplier (Note suppliers only need to load once at load time)
            var checkValidSupplierID = DMS.ClientManager.GetData(i => i.ID == catalog.DefaultSupplierID && i.Catagory == "Supplier");
            if (checkValidSupplierID != null)
                supplierID_ComboBox.Text = catalog.DefaultSupplierID;
            else
                supplierID_ComboBox.Text = "";
        }

        public void LoadGroups()
        {
            group_ComboBox.Items.Clear();
            group_ComboBox.Items.Add("");

            foreach (var i in DMS.CatalogGroupManager.CatalogGroup)
            {
                group_ComboBox.Items.Add(i.ToString());
            }
        }

        public void SaveCatalog()
        {
            bindingNavigatorMoveFirstItem.Select();
            catalog.SelectedForex = null;
            UpdateCatalog();

            var supplier = DMS.ClientManager.GetData(i => ("[" + i.Account + "] " + i.Name) == supplierID_ComboBox.Text);
            // if (supplier != null) catalog.SupplierID = supplier.ID;
            catalog.Save();
        }

        public void CopyCatalog(bool All)
        {
            AMS.MessageBox_v2.ShowProcess("Copying Data");

            try
            {
                if (catalogItemBindingSource.DataSource == null) return;

                if (All)
                    foreach (DataGridViewRow Row in catalogItemDataGridView.Rows)
                        Row.Selected = true;

                StringBuilder sb = new StringBuilder();

                foreach (DataGridViewRow Row in catalogItemDataGridView.SelectedRows)
                {
                    var item = (CatalogItem)Row.DataBoundItem;

                    if (item != null)
                    {
                        sb.Append(("" + item.PartNr).Trim() + "\t");
                        sb.Append(("" + item.Code).Trim() + "\t");
                        sb.Append(("" + item.Name).Trim() + "\t");
                        sb.Append(("" + item.Version).Trim() + "\t");
                        sb.Append(("" + item.ListPrice).Trim() + "\t");
                        sb.Append(("" + item.RetailPrice).Trim() + "\t");
                        sb.Append(item.COD + "\t");
                        sb.Append(item.BulkDiscount + "\t");
                        sb.Append(item.Maintenance + "\t");
                        sb.Append(item.GlobalDiscount + "\t");
                        sb.Append(item.Stolen + "\t");
                        sb.Append(("" + item.SupplierID).Trim() + "\t");
                        sb.Append(("" + item.RetailScript).Trim() + "\t");
                        sb.Append("\"" + ("" + item.Content).Trim().Replace("\r\n", "\n") + "\"");

                        sb.AppendLine();
                    }
                }
                string s = sb.ToString();
                Clipboard.SetText(s);
            }
            catch { }

            System.Windows.Forms.Application.DoEvents();
            System.Threading.Thread.Sleep(10);
            AMS.MessageBox_v2.EndProcess();
        }

        public void PasteCatalog(int Index, bool UseIndex)
        {
            string status = "";

            try
            {
                AMS.MessageBox_v2.ShowProcess("Pasting Data");

                char[] rowSplitter = { '\r' };
                char[] columnSplitter = { '\t' };
                //get the text from clipboard
                IDataObject dataInClipboard = Clipboard.GetDataObject();
                string stringInClipboard = (string)dataInClipboard.GetData(DataFormats.Text);

                //split it into lines
                string[] rowsInClipboard = stringInClipboard.Split(rowSplitter, StringSplitOptions.RemoveEmptyEntries);

                // loop through the lines, split them into cells and place the values in the corresponding cell.
                for (int iRow = 0; iRow < rowsInClipboard.Length; iRow++)
                {
                    CatalogItem item = new CatalogItem();
                    //split row into cell values
                    string[] valuesInRow = rowsInClipboard[iRow].Split(columnSplitter);
                    string values = "";
                    for (int iCol = 0; iCol < valuesInRow.Length; iCol++)
                    {
                        values += " - " + valuesInRow[iCol].ToString() + " - ";
                    }

                    status = values;

                    AMS.MessageBox_v2.ShowProcess("Pasting Data\r\n\r\n" + values);
                    System.Windows.Forms.Application.DoEvents();
                    System.Threading.Thread.Sleep(10);

                    //cycle through cell values
                    for (int iCol = 0; iCol < valuesInRow.Length; iCol++)
                    {
                        //sb.Append(("" + item.PartNr).Trim() + "\t");
                        //sb.Append(("" + item.Code).Trim() + "\t");
                        //sb.Append(("" + item.Name).Trim() + "\t");
                        //sb.Append(("" + item.Version).Trim() + "\t");
                        //sb.Append(item.ListPrice + "\t");
                        //sb.Append(item.RetailPrice + "\t");
                        //sb.Append(item.COD + "\t");
                        //sb.Append(item.BulkDiscount + "\t");
                        //sb.Append(item.Maintenance + "\t");
                        //sb.Append(item.GlobalDiscount + "\t");
                        //sb.Append(item.Stolen + "\t");
                        //sb.Append(("" + item.SupplierID).Trim() + "\t");
                        //sb.Append(("" + item.RetailScript).Trim() + "\t");
                        //sb.Append("\"" + ("" + item.Content).Trim().Replace("\r\n", "\n") + "\"");

                        if (iCol == 0) item.PartNr = valuesInRow[iCol].ToString();
                        if (iCol == 1) item.Code = valuesInRow[iCol].ToString();
                        if (iCol == 2) item.Name = valuesInRow[iCol].ToString();
                        if (iCol == 3) item.Version = valuesInRow[iCol].ToString();
                        if (iCol == 4) item.ListPrice = Convert.ToDecimal(valuesInRow[iCol].ToString());
                        // if (iCol == 5) item.RetailPrice = Convert.ToDecimal(valuesInRow[iCol].ToString());
                        if (iCol == 6) if (valuesInRow[iCol].ToUpper() == "TRUE" || valuesInRow[iCol].ToUpper() == "1") item.COD = true;
                        if (iCol == 7) if (valuesInRow[iCol].ToUpper() == "TRUE" || valuesInRow[iCol].ToUpper() == "1") item.BulkDiscount = true;
                        if (iCol == 8) if (valuesInRow[iCol].ToUpper() == "TRUE" || valuesInRow[iCol].ToUpper() == "1") item.Maintenance = true;
                        if (iCol == 9) if (valuesInRow[iCol].ToUpper() == "TRUE" || valuesInRow[iCol].ToUpper() == "1") item.GlobalDiscount = true;
                        if (iCol == 10) if (valuesInRow[iCol].ToUpper() == "TRUE" || valuesInRow[iCol].ToUpper() == "1") item.Stolen = true;
                        if (iCol == 11) item.SupplierID = valuesInRow[iCol].ToString();
                        if (iCol == 12) item.RetailScript = valuesInRow[iCol].ToString();
                        if (iCol == 13) item.Content = ("" + valuesInRow[iCol].ToString().Replace("\n", "\r\n").Replace("\"", ""));
                    }
                    if (UseIndex)
                        catalog.ItemList.Insert(Index, item);
                    else
                        catalog.ItemList.Add(item);
                }

                System.Windows.Forms.Application.DoEvents();
                System.Threading.Thread.Sleep(10);
                AMS.MessageBox_v2.EndProcess();
            }
            catch (Exception ex) { AMS.MessageBox_v2.Show("Clipboard data is incorrect format!\r\n\r\n" + ex.Message + "\r\n" + ex.InnerException, AMS.MessageType.Error); AMS.MessageBox_v2.EndProcess(); }

            System.Windows.Forms.Application.DoEvents();

            var updatedCatalog = (Catalog)catalog.Clone();

            LoadCatalog(new Catalog());
            this.Refresh();
            LoadCatalog(updatedCatalog);
        }

        public void LoadCatalog(Catalog Catalog)
        {
            loading = true;

            catalogItemDataGridView.Visible = (Catalog != null && Catalog.Name != null && Catalog.Name.Length > 1);
            panel1.Visible = catalogItemDataGridView.Visible;
            if (Catalog == null) return;

            catalog = Catalog;
            // var supplier = DMS.ClientManager.GetData(i => i.Account == catalog.SupplierID);
            // if (supplier != null) supplierID_ComboBox.Text = "[" + supplier.Account + "] " + supplier.Name;
            // else supplierID_ComboBox.Text = "";
            catalogItemBindingSource.DataSource = catalog.ItemList;
            catalogBindingSource.DataSource = catalog;

            LoadData();

            loading = false;
        }

        public void UpdateCatalog()
        {
            if (loading) return;

            foreach (var i in catalog.ItemList)
            {
                i.Forex = catalog.SelectedForex;
                i.CatalogDefaultScript = catalog.DefaultScript;
            }

            catalogItemDataGridView.DataSource = null;
            catalogItemDataGridView.DataSource = catalogItemBindingSource;

            LoadCatalog(catalog);
        }

        // Events

        #region DataGridView


        private void catalogItemDataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void MoveItemUp_Click(object sender, EventArgs e)
        {
            try
            {
                if (catalogItemBindingSource.DataSource == null) return;

                int idx = catalogItemDataGridView.CurrentRow.Index;

                CatalogItem item = catalog.ItemList[idx];
                catalog.ItemList.Remove(item);
                catalog.ItemList.Insert(idx - 1, item);

                UpdateCatalog();
            }
            catch { }
        }

        private void MoveItemDown_Click(object sender, EventArgs e)
        {
            try
            {
                if (catalogItemBindingSource.DataSource == null) return;

                int idx = catalogItemDataGridView.CurrentRow.Index;

                CatalogItem item = catalog.ItemList[idx];
                catalog.ItemList.Remove(item);
                catalog.ItemList.Insert(idx + 1, item);

                UpdateCatalog();
            }
            catch { }
        }

        private void InsertRow_Click(object sender, EventArgs e)
        {
            try
            {
                if (catalogItemBindingSource.DataSource == null) return;

                int idx = catalogItemDataGridView.CurrentRow.Index;

                catalog.ItemList.Insert(idx + 1, new CatalogItem());

                UpdateCatalog();
            }
            catch { }
        }

        private void DeleteRow_Click(object sender, EventArgs e)
        {
            try
            {
                if (catalogItemBindingSource.DataSource == null) return;

                int idx = catalogItemDataGridView.CurrentRow.Index;
                CatalogItem item = catalog.ItemList[idx];
                catalog.ItemList.Remove(item);

                UpdateCatalog();
            }
            catch { }
        }

        private void CopyRow_Click(object sender, EventArgs e)
        {
            CopyCatalog(false);
            UpdateCatalog();
        }

        private void Paste_Click(object sender, EventArgs e)
        {
            try
            {
                string[] s = Clipboard.GetText().Split(',');
                if (catalogItemBindingSource.DataSource == null) return;

                int idx = catalogItemDataGridView.CurrentRow.Index;
                PasteCatalog(idx, true);

                UpdateCatalog();
            }
            catch { }

        }

        private void Paste_Event(object sender, KeyEventArgs e)
        {
            if (loading) return;

            //if user clicked Shift+Ins or Ctrl+V (paste from clipboard)
            if ((e.Shift && e.KeyCode == System.Windows.Forms.Keys.Insert) || (e.Control && e.KeyCode == System.Windows.Forms.Keys.V))
            {
                PasteCatalog(0, false);
            }
        }

        private void pastExcel_Button_Click(object sender, EventArgs e)
        {
            if (loading) return;

            PasteCatalog(0, false);
        }

        private void catalogItemDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (loading || e.RowIndex == -1 || e.ColumnIndex == -1) return;

            #region Content Button

            if (catalogItemDataGridView.Columns[e.ColumnIndex].Name == "Content")
            {
                var item = (CatalogItem)catalogItemDataGridView.Rows[e.RowIndex].DataBoundItem;

                using (Forms.ContentEditor f = new Forms.ContentEditor(item.Content))
                {
                    f.ShowDialog();
                    string oldContent = item.Content;

                    if (f.Content == null) item.Content = oldContent;
                    else item.Content = f.Content;
                }
            }

            #endregion
        }

        private void DataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (loading) return;

            string colname = "";
            string value = "";
            string senderName = "";

            if ((DataGridView)sender == catalogItemDataGridView)
            {
                colname = catalogItemDataGridView.Columns[e.ColumnIndex].Name;
                value = catalogItemDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                senderName = "Catalog Items";
            }

            if ((DataGridView)sender == forex_DataGridView)
            {
                colname = forex_DataGridView.Columns[e.ColumnIndex].Name;
                value = forex_DataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                senderName = "Forex";
            }

            if (((DataGridView)sender).Columns[e.ColumnIndex].GetType() == typeof(DataGridViewComboBoxCell) ||
                ((DataGridView)sender).Columns[e.ColumnIndex].GetType() == typeof(DataGridViewComboBoxColumn)) return;

            AMS.MessageBox_v2.Show("Error in " + senderName + "\r\n\r\nColumn: " + colname + "\r\nRow: " + e.RowIndex + "\r\nValue: " + value + "\r\n\r\n" + e.Exception, AMS.MessageType.Error);
        }

        #endregion

        private void preview_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loading) return;

            catalog.DefaultScript = defaultScript_ComboBox.SelectedItem.ToString();

            UpdateCatalog();
        }

        private void ForexSelect_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (loading) return;

            catalog.SelectedForex = (Forex)forex_DataGridView.Rows[e.RowIndex].DataBoundItem; ;
            UpdateCatalog();
        }

        private void EditTerms_Click(object sender, EventArgs e)
        {
            if (loading) return;

            AMS.Reports.Report_Manager.EditTerms(terms_ComboBox.Text);
            LoadData();
        }

        private void Terms_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loading) return;

            catalog.TermsFileName = AMS.Reports.Report_Manager.GetTerms(terms_ComboBox.Text).File.Name;
        }

        private void group_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loading) return;

            if (group_ComboBox.SelectedItem != null) catalog.CatalogGroup = group_ComboBox.SelectedItem.ToString();
        }

        private void suppliers_Button_Click(object sender, EventArgs e)
        {
            AMS.MessageBox_v2.Show(DMS.GetSupplierListInfo);
        }

        private void EditMaintTerms_Click(object sender, EventArgs e)
        {
            if (loading) return;

            AMS.Reports.Report_Manager.EditTerms(maintTerms_ComboBox.Text);
            LoadData();
        }

        private void maintTerms_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loading) return;

            catalog.MaintTermsFileName = AMS.Reports.Report_Manager.GetTerms(maintTerms_ComboBox.Text).File.Name;
        }
    }
}