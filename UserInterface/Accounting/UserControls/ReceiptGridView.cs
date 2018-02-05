using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data.Accounts;
using Data;
using AMS;
using Data.Search;

namespace UserInterface.Accounting.UserControls
{
    public partial class ReceiptGridView : UserControl
    {
        // Variables and Properties

        private List<Receipt> receiptList;
        public List<Receipt> ReceiptList { get { return receiptList; } }

        private int receiptIndex;
        private Receipt receipt;
        public Receipt SelectedReceipt
        {
            get
            {
                return receipt;
            }
        }
        bool requiresSave;
        DataGridViewColumn column;
        private bool doColumnReverse;
        bool loading;

        private SearchData searchData;
        public SearchData SearchData
        {
            get { return searchData; }
            set { searchData = value; }
        }


        #region Visual Studio

        [Description("Show Links Column"), Category("AMS")]
        public bool IsLinksVisible { get; set; }

        [Description("Allow user to filter the control"), Category("AMS")]
        public bool CanFilter { get; set; }

        #endregion

        // Constructors

        public ReceiptGridView()
        {
            InitializeComponent();
        }

        // Load

        private void ReceiptGridView_Load(object sender, EventArgs e)
        {
            #region ThemeColors

            ThemeColors.SetControls(this.Controls);
            ThemeColors.SetControls(right_flowLayoutPanel, ThemeColors.ControlType.Menu);

            summary_Panel.ForeColor = ThemeColors.MenuText;

            receiptDataGridView.DefaultCellStyle.BackColor = ThemeColors.ControlList;
            receiptDataGridView.DefaultCellStyle.ForeColor = ThemeColors.ControlText;

            receiptDataGridView.DefaultCellStyle.SelectionBackColor = ThemeColors.Primary;
            receiptDataGridView.DefaultCellStyle.SelectionForeColor = ThemeColors.PrimaryText;

            panel1.BackColor = ThemeColors.Menu;
            panel1.Size = new Size(Parent.Width - 6, 3);

            panel2.BackColor = ThemeColors.Menu;
            panel2.Size = new Size(Parent.Width - 6, 3);

            ThemeColors.SetControls(receipts_Label, ThemeColors.ControlType.Menu);
            ThemeColors.SetControls(size_Button, ThemeColors.ControlType.Menu);
            iD_ToolStripMenuItem.BackColor = ThemeColors.Primary;
            iD_ToolStripMenuItem.ForeColor = ThemeColors.PrimaryText;

            #endregion

            #region Visual Studio

            InvoiceListColumn.Visible = IsLinksVisible;

            #endregion

            if (DesignMode == true) return;

            loading = true;

            AMS.MessageBox_v2.ShowProcess("Loading " + DMS.AccountsManager.ReceiptList.Count + " Receipts\r\nPlease wait");

            DMS.ClientManager.OnSelect_Enter += LoadReceipts_Event;
            DMS.AccountsManager.Saved_Event += AccountsManager_Saved_Event;
            DMS.AccountsManager.Load_Event += LoadReceipts_Event;
            DMS.SearchManager.Receipt_Search += SearchManager_Receipt_Search;

            InvoiceListColumn.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            BeingProcessedReference.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            ReceiptDateColumn.DefaultCellStyle.Format = "dd MMM yy";

            paid_CheckBox.Checked = false;
            unpiad_CheckBox.Checked = true;

            if (receiptDataGridView.Rows.Count > 0) receiptDataGridView.Rows[0].Selected = true;
            right_flowLayoutPanel.Visible = false;
            unpiad_CheckBox.Checked = true;
            LoadReceipts();
            requiresSave = false;
            SetStatus();

            DMS.AccountsManager.ReceiptAdded += (s, ev) => LoadReceipts();

            AMS.MessageBox_v2.EndProcess();

            loading = false;
        }

        // Methods

        internal void SetReceiptClient(string Account)
        {
            try
            {
                // ((Receipt)receiptDataGridView.SelectedCells[receiptIndex].OwningRow.DataBoundItem).Account = Account;
                receipt.Account = Account;
                LoadReceipts();
                requiresSave = true;
            }
            catch { return; }
       
        }

        public void PasteReceipts()
        {
            loading = true;

            string header = "Pasting from Excel";
            string message = "";
            AMS.MessageBox_v2.ShowProcess(header + "\r\n\r\n" + message);

            int count = 0;
            int beforeCount = DMS.AccountsManager.ReceiptList.Count;

            try
            {
                string clipboard = Clipboard.GetText();
                string[] lines = clipboard.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

                message = lines.Count() + " of Data";
                AMS.MessageBox_v2.ShowProcess(header + "\r\n\r\n" + message);
                count = lines.Count();
                int nr = 0;

                foreach (string rows in lines)
                {
                    string[] cells = rows.Split('\t');

                    var newReceipt = new Receipt();
                    newReceipt.ID = "Temp" + nr;
                    newReceipt.Amount = Convert.ToDecimal(cells[0]);
                    newReceipt.Description = cells[1];
                    newReceipt.ReceiptDate = DateTime.Parse(cells[2]);
                    var checkReipt = (from i in DMS.AccountsManager.ReceiptList
                                      where string.Format("{0:dd MMM yyyy}", i.ReceiptDate) == string.Format("{0:dd MMM yyyy}", newReceipt.ReceiptDate) &&
                                       i.Description == newReceipt.Description &&
                                       i.Amount == newReceipt.Amount
                                      select i).FirstOrDefault();

                    if (checkReipt == null || AMS.MessageBox_v2.Show(string.Format("Possible Duplicate Receipt - {0} - {1:C} - {2:dd MMM yyyy}\r\nWould you like to add it again?", newReceipt.Description, newReceipt.Amount, newReceipt.ReceiptDate), AMS.MessageType.Question) == AMS.MessageOut.YesOk)
                    {
                        DMS.AccountsManager.AddReceipt(newReceipt);
                    }

                    nr++;
                    message = nr + "/" + lines.Count() + " " + newReceipt.ID + " " + newReceipt.Description;
                    AMS.MessageBox_v2.ShowProcess(header + "\r\n\r\n" + message, nr, lines.Count());
                }

                LoadReceipts();
                requiresSave = true;
            }
            catch (Exception ex) { AMS.MessageBox_v2.Show("Could not paste from excel.\r\n\r\n \r\n\r\n" + ex.Message + "\r\n" + ex.InnerException, AMS.MessageType.Error); }

            count = 0 + DMS.AccountsManager.ReceiptList.Count - beforeCount;

            AMS.MessageBox_v2.EndProcess();
            AMS.MessageBox_v2.Show(count + " data was added", 2000);

            loading = false;
        }

        public void LoadReceipts()
        {
            LoadReceipts(DMS.AccountsManager.ReceiptList);
        }

        public void LoadReceipts(HashSet<Receipt> ReceiptList)
        {
            if (DMS.AccountsManager.ReceiptList == null || DMS.AccountsManager.ReceiptList.Count == 0) return;

            loading = true;

            int finalizedcount = (from i in DMS.AccountsManager.ReceiptList
                                  where new DateTime(i.DateFinalized.Year, i.DateFinalized.Month, i.DateFinalized.Day) < new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)
                                  select i).ToList().Count;
            decimal percent = finalizedcount / DMS.AccountsManager.ReceiptList.Count() * 100;

            receiptList = ReceiptList.ToList();

            if (searchData != null && (searchData.SearchType == SearchType.Client || searchData.SearchType == SearchType.Receipt || searchData.SearchType == SearchType.Transaction))
            {
                receiptList = (from i in receiptList
                               where
                                    i.Account == searchData.Client.Account ||
                                    string.IsNullOrEmpty(i.Account)
                               select i).ToList();
            }


            receiptList = (from i in receiptList
                           where
                            ((paid_CheckBox.Checked && i.AmountRemaining <= 0.05m) && (paid_CheckBox.Checked && i.AmountRemaining >= -0.05m)) ||
                           ((unpiad_CheckBox.Checked && i.AmountRemaining >= 0.05m) || (unpiad_CheckBox.Checked && i.AmountRemaining <= -0.05m)) || (unpiad_CheckBox.Checked && string.IsNullOrEmpty(i.Account)) ||
                           (processed_CheckBox.Checked && i.BeingProcessed) ||
                           (noAccount_CheckBox.Checked && string.IsNullOrEmpty(i.Account))
                           where (searchData != null &&
                                searchData.WithinRange(i.ReceiptDate))
                           select i).ToList();

            SortReceipts();

            receiptDataGridView.RowHeadersVisible = false;
            receiptBindingSource.DataSource = null;
            receiptBindingSource.DataSource = receiptList;
            receiptDataGridView.RowHeadersVisible = true;

            ClientInfoColumn.Visible = clientInfo_CheckBox.Checked;
            BeingProcessedReference.Visible = processInfo_CheckBox.Checked;

            loading = false;

            SetStatus();
        }

        internal void ShowProcess()
        {
            loading = true;

            right_flowLayoutPanel.Visible = true;
            processed_CheckBox.Checked = true;
            processInfo_CheckBox.Checked = true;
            paid_CheckBox.Checked = false;
            unpiad_CheckBox.Checked = true;
            clientInfo_CheckBox.Checked = true;

            loading = false;

            LoadReceipts();
        }

        internal void LoadReceipts(Receipt receipt)
        {
            if (DMS.AccountsManager.ReceiptList == null || DMS.AccountsManager.ReceiptList.Count == 0) return;

            int finalizedcount = (from i in DMS.AccountsManager.ReceiptList
                                  where new DateTime(i.DateFinalized.Year, i.DateFinalized.Month, i.DateFinalized.Day) < new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)
                                  select i).ToList().Count;
            decimal percent = finalizedcount / DMS.AccountsManager.ReceiptList.Count() * 100;

            receiptList = DMS.AccountsManager.ReceiptList.Where(i => i.ID == receipt.ID).ToList();
            receiptBindingSource.DataSource = receiptList;

            SetStatus();
        }

        private void SortReceipts()
        {
            if (column == IDColumn)
                receiptList = (from i in receiptList
                               orderby i.ID ascending
                               select i).ToList();

            if (column == InvoiceListColumn)
                receiptList = (from i in receiptList
                               orderby i.ReceiptAllocationList.Count ascending
                               select i).ToList();

            if (column == AccountColumn)
                receiptList = (from i in receiptList
                               orderby i.Account ascending
                               select i).ToList();

            if (column == AmountColumn)
                receiptList = (from i in receiptList
                               orderby i.Amount ascending
                               select i).ToList();

            if (column == AmountRemaining_Column)
                receiptList = (from i in receiptList
                               orderby i.AmountRemaining ascending
                               select i).ToList();

            if (column == DescriptionColumn)
                receiptList = (from i in receiptList
                               orderby i.Description ascending
                               select i).ToList();

            if (column == ReceiptDateColumn)
                receiptList = (from i in receiptList
                               orderby i.ReceiptDate ascending
                               select i).ToList();

            if (column == DateFinalizedColumn)
                receiptList = (from i in receiptList
                               orderby i.DateFinalized ascending
                               select i).ToList();

            if (column == BeingProcessedReference)
                receiptList = (from i in receiptList
                               orderby i.BeingProcessedReference ascending
                               select i).ToList();

            if (doColumnReverse) receiptList.Reverse();

            receiptBindingSource.DataSource = receiptList;
        }

        internal void SetFound(HashSet<Receipt> ReceiptList)
        {
            foreach (DataGridViewRow row in receiptDataGridView.Rows)
            {
                string id = row.Cells[IDColumn.Index].Value.ToString();

                var query = (from i in ReceiptList
                             where i.ID == id
                             select i).FirstOrDefault();

                var foreColor = receiptDataGridView.DefaultCellStyle.ForeColor;
                var backColor = receiptDataGridView.DefaultCellStyle.BackColor;

                if (query != null)
                {
                    foreColor = ThemeColors.SearchText;
                    backColor = ThemeColors.Search;
                }

                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.ColumnIndex != FlagProcessed_Column.Index)
                    {
                        cell.Style.BackColor = backColor;
                        cell.Style.ForeColor = foreColor;
                    }
                }
            }
        }

        public void SetStatus()
        {
            string summary = "";

            decimal totalAmount = (from i in DMS.AccountsManager.ReceiptList
                                   where i.ReceiptAllocationList.Count == 0
                                   select i).Sum(i => i.AmountRemaining);

            int visibleCount = receiptDataGridView.Rows.Count;
            int totalCount = DMS.AccountsManager.ReceiptList.Count;

            if (searchData != null && searchData.SearchType == SearchType.Client)
            {
                totalAmount = (from i in receiptList
                               where i.ReceiptAllocationList.Count == 0
                               select i).Sum(i => i.AmountRemaining);

                totalCount = receiptList.Count;
            }

            summary = visibleCount + "/" + totalCount + " Receipts   -   " + totalAmount + " Outstanding";
            summary_Label.Text = summary;

            if (totalAmount > 0) summary_Panel.BackColor = ThemeColors.Red;
            if (totalAmount < 0) summary_Panel.BackColor = ThemeColors.Blue;
            if (totalAmount == 0) summary_Panel.BackColor = ThemeColors.Primary;

            if (requiresSave)
            {
                receipts_Label.BackColor = ThemeColors.Red;
                receipts_Label.ForeColor = Color.White;
            }
            else
                ThemeColors.SetControls(receipts_Label, ThemeColors.ControlType.Menu);

            StringBuilder sb = new StringBuilder();
            if (SelectedReceipt != null && SelectedReceipt.ID != null) sb.Append(SelectedReceipt.ID);
            AMS.StatusUpdate.UpdateSelectionTwo("Receipt", sb.ToString());
        }

        // Events

        private void LoadReceipts_Event(object sender, EventArgs e)
        {
            if (loading) return;

            //if (seachData != null && seachData.SearchType == SearchType.Client)
            LoadReceipts();

            // receiptDataGridView.Rows[receiptIndex].Selected = true;
        }

        private void SearchManager_Receipt_Search(object sender, ReciptSearchArgs e)
        {
            if (loading) return;
            paid_CheckBox.Checked = true;
            unpiad_CheckBox.Checked = true;
            LoadReceipts(e.ReceiptList);
        }

        private void AccountsManager_Saved_Event(object sender, EventArgs e)
        {
            LoadReceipts();
            requiresSave = false;
            SetStatus();
        }

        private void Receipt_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0) return;

            if (e.RowIndex < 0)
            {
                var slectedColumn = receiptDataGridView.Columns[e.ColumnIndex];
                if (column != null && column == slectedColumn) doColumnReverse = !doColumnReverse;
                column = slectedColumn;
                LoadReceipts();
                return;
            }

            if (e.ColumnIndex <= IDColumn.Index) receiptDataGridView.Rows[e.RowIndex].Selected = true;

            // receiptDataGridView.Rows[e.RowIndex].Cells[0].Selected = true;
            receipt = (Receipt)receiptDataGridView.Rows[e.RowIndex].DataBoundItem;
            receiptIndex = e.RowIndex;

            if (receiptDataGridView.Columns[e.ColumnIndex] == AccountColumn)
                DMS.ClientManager.SetCurrent(i => i.Account == receipt.Account);
            else
            {
                DMS.AccountsManager.SetRecipt(SelectedReceipt);
                DMS.SearchLinkManager.SetReceipt(SelectedReceipt);
            }

            SetStatus();
        }

        private void showPanelButton_Label_Click(object sender, EventArgs e)
        {
            right_flowLayoutPanel.Visible = !right_flowLayoutPanel.Visible;
        }

        private void MaintenanceInvoice_Click(object sender, EventArgs e)
        {
            if (receipt.BeingProcessed)
            {
                AMS.MessageBox_v2.Show("Please finish the link process before trying to generate new invoice.");
                return;
            }

            receipt.CreateMaintInvoice();
        }

        private void CreateInvoice_Click(object sender, EventArgs e)
        {
            if (receipt.BeingProcessed)
            {
                AMS.MessageBox_v2.Show("Please finish the link process before trying to generate new invoice.");
                return;
            }

            receipt.CreateInvoice(SelectedReceipt.Description, SelectedReceipt.Amount);
        }

        private void receiptDataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right && e.RowIndex >= 0)
            {
                receipt = (Receipt)receiptDataGridView.Rows[e.RowIndex].DataBoundItem;
                if (receipt == null) return;

                contextMenuStrip.Show(receiptDataGridView, receiptDataGridView.PointToClient(Cursor.Position));
            }
        }

        private void receiptDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in receiptDataGridView.Rows)
            {
                var receipt = (Receipt)row.DataBoundItem;
                row.Cells[FlagProcessed_Column.Name].Style.BackColor = ThemeColors.Menu;

                if (receipt.AmountRemaining > 0) row.Cells[FlagProcessed_Column.Name].Style.BackColor = ThemeColors.Orange;
                if (receipt.AmountRemaining < 0 || receipt.AmountRemaining == receipt.Amount) row.Cells[FlagProcessed_Column.Name].Style.BackColor = ThemeColors.Red;
                if (receipt.AmountRemaining == 0) row.Cells[FlagProcessed_Column.Name].Style.BackColor = ThemeColors.Primary;

                row.Cells[FlagProcessed_Column.Name].Style.SelectionBackColor = row.Cells[FlagProcessed_Column.Name].Style.BackColor;
            }
        }

        private void receiptDataGridView_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (loading || requiresSave) return;

            try
            {
                var receipt = (Receipt)receiptDataGridView.Rows[e.RowIndex].DataBoundItem;

                if (receipt == null) return;
                if (string.IsNullOrEmpty(receipt.ID)) { requiresSave = true; return; }

                var queryRecipt = (from i in DMS.AccountsManager.OriginalReceiptList
                                   where i.ID == receipt.ID
                                   select i).FirstOrDefault();

                if (queryRecipt.Account != receipt.Account) requiresSave = true;
                if (queryRecipt.Amount != receipt.Amount) requiresSave = true;
                if (queryRecipt.DateFinalized != receipt.DateFinalized) requiresSave = true;
                if (queryRecipt.Description != receipt.Description) requiresSave = true;
                if (queryRecipt.ID != receipt.ID) requiresSave = true;
                if (queryRecipt.Notes != receipt.Notes) requiresSave = true;
                if (queryRecipt.ReceiptAllocationList.Count != receipt.ReceiptAllocationList.Count) requiresSave = true;
                if (queryRecipt.ReceiptDate != receipt.ReceiptDate) requiresSave = true;

                try
                {
                    SetStatus();
                }
                catch { }
            }
            catch { requiresSave = true; }
        }

        private void size_Button_Click(object sender, EventArgs e)
        {
            receiptDataGridView.AutoResizeColumns();
            receiptDataGridView.AutoResizeRows();
            Selected_Column.Width = 5;
            FlagProcessed_Column.Width = 5;
        }

        private void removeLinks_LoolStripMenuItem_Click(object sender, EventArgs e)
        {
            receipt.Unlink(false);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DMS.SearchManager.DoTransactionLinkSearch(receipt);
        }

        private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            if (receipt == null) return;
               
            iD_ToolStripMenuItem.Text = "Receipt " + receipt.ID;

            // removeLinks_LoolStripMenuItem.Enabled = (receipt.ReceiptAllocationList != null && receipt.ReceiptAllocationList.Count > 0);
            maintenanceInvoice_lToolStripMenuItem.Enabled = receipt.ReceiptAllocationList?.Count == 0;
        }
    }
}
