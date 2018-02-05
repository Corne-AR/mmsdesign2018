using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AMS;
using Data.Search;
using Data;

namespace UserInterface.Utilities.UserControls
{
    public partial class SearchResultsPanel : UserControl
    {
        // Variables

        bool isCollapsed = true;
        int height = 100;
        int width = 100;
        private Point MouseDownLocation;
        private List<SearchData> searchlist;
        private Timer clickTimer;
        bool beenClicked = false;

        public bool IsShowing
        {
            get { return splitContainer1.Panel2Collapsed; }
            set { splitContainer1.Panel2Collapsed = value; }
        }

        DataGridViewColumn column;
        private bool doColumnReverse;
        private SearchType searchType;

        // Constructors

        public SearchResultsPanel()
        {
            InitializeComponent();

            clickTimer = new Timer();
            // clickTimer.Interval = SystemInformation.DoubleClickTime - 1;
            clickTimer.Interval = 1500;
            clickTimer.Tick += clickTimer_Tick;

        }

        private void SearchResultsPanel_Load(object sender, EventArgs e)
        {
            ThemeColors.SetControls(this, ThemeColors.ControlType.MenuBorder);
            ThemeColors.SetControls(splitContainer1.Panel1, ThemeColors.ControlType.MenuBorder);
            ThemeColors.SetControls(splitContainer1.Panel2, ThemeColors.ControlType.Menu);
            ThemeColors.SetControls(maint_ToolStrip, ThemeColors.ControlType.Menu);
            ThemeColors.SetControls(credit_ToolStrip, ThemeColors.ControlType.Menu);
            searchDataDataGridView.DefaultCellStyle.BackColor = ThemeColors.InputControl;
            searchDataDataGridView.DefaultCellStyle.ForeColor = ThemeColors.InputText;

            DMS.SearchManager.All_Search += SearchManager_All;
            DMS.SearchManager.SearchSummary += SearchManager_StatusUpdate;

            height = this.Height;
            width = this.Width;
            searchType = SearchType.All;

            CheckCollapsed();
        }

        // Methods

        private void CheckCollapsed()
        {
            splitContainer1.Panel2Collapsed = isCollapsed;
            if (height < 100) height = 120;
            if (height > 500) height = 500;

            if (isCollapsed) // unclasped
            {
                this.Size = new Size(width, 24);
                showHide_Label.Text = "Show";
            }
            else // Collapse
            {
                this.Size = new Size(width, height);
                showHide_Label.Text = "Hide";
            }
        }

        private void SetSortOrder()
        {
            if (column == Account_Column)
                searchlist = searchlist.OrderBy(i => i.Account).ToList();

            if (column == ClientName_Column)
                searchlist = searchlist.OrderBy(i => i.ClientName).ToList();

            if (column == Contact_Column)
                searchlist = searchlist.OrderBy(i => i.Contact).ToList();

            if (column == Results_Column)
                searchlist = searchlist.OrderBy(i => i.Results).ToList();

            if (column == ProductID_Column)
                searchlist = searchlist.OrderBy(i => i.ProductID).ToList();

            if (column == TransactionID_Column)
                searchlist = searchlist.OrderBy(i => i.TransactionID).ToList();

            if (column == QuoteID_Column)
                searchlist = searchlist.OrderBy(i => i.QuoteID).ToList();

            if (column == ReceiptID_Column)
                searchlist = searchlist.OrderBy(i => i.ReceiptID).ToList();

            if (column == Amount_Column)
                searchlist = searchlist.OrderBy(i => i.Amount).ToList();

            if (doColumnReverse) searchlist.Reverse();

            SetDataBinding();
        }

        private void SetDataBinding()
        {
            maint_ToolStrip.Visible = searchType == SearchType.Maintenance;
            credit_ToolStrip.Visible = searchType == SearchType.Statement;
            ReceiptID_Column.Visible = searchType == SearchType.Transaction || searchType == SearchType.All;
            TransactionID_Column.Visible = searchType == SearchType.Transaction || searchType == SearchType.All;
            ProductID_Column.Visible = searchType == SearchType.Product || searchType == SearchType.All;
            QuoteID_Column.Visible = searchType == SearchType.Quote || searchType == SearchType.All;
            Amount_Column.Visible = searchType == SearchType.Quote || searchType == SearchType.Transaction || searchType == SearchType.Maintenance || searchType == SearchType.Receipt || searchType == SearchType.All;

            if (searchlist != null) searchDataBindingSource.DataSource = searchlist.ToList();
        }

        public void ClearResults()
        {
            searchlist = new List<SearchData>();
            SetDataBinding();
        }

        // Events

        private void SearchManager_All(object sender, AllSearchArgs e)
        {
            if (e.SearchDataList == null) return;

            searchType = e.SearchType;
            searchlist = e.SearchDataList.ToList();

            isCollapsed = false;
            CheckCollapsed();

            SetDataBinding();
        }

        private void SearchManager_StatusUpdate(object sender, EventArgs e)
        {
            resultsSummary_Label.Text = DMS.SearchManager.Summary;
        }

        private void SetCollaped_Click(object sender, EventArgs e)
        {
            isCollapsed = !isCollapsed;
            CheckCollapsed();
        }

        #region Size Panel

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
            }
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left && !isCollapsed)
            {
                int addHeight = MouseDownLocation.Y - e.Y;
                height = this.Height + addHeight;

                AMS.StatusUpdate.UpdateArea("Search Panel Height: " + height);
            }
        }

        private void label1_MouseUp(object sender, MouseEventArgs e)
        {
            CheckCollapsed();
        }

        #endregion

        void clickTimer_Tick(object sender, EventArgs e)
        {
            clickTimer.Stop();
        }


        private void SearchCel_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (beenClicked) return;

            DataGridViewCell selectedCell;

            var selectedColumn = searchDataDataGridView.Columns[e.ColumnIndex];
            if (e.RowIndex > 0 && e.ColumnIndex > 0) selectedCell = searchDataDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];

            //if (clickTimer.Enabled) return;
            //else
            //{
            //    clickTimer.Start();
            //}

            // Sort Columns

            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                if (column != null && column == selectedColumn) doColumnReverse = !doColumnReverse;
                column = selectedColumn;
                SetSortOrder();
                return;
            }

            // Account Cell

            if (selectedColumn == ClientName_Column || selectedColumn == Account_Column)
            {
                string account = ("" + searchDataDataGridView.Rows[e.RowIndex].Cells[Account_Column.Index].Value).ToString();

                if (account != DMS.ClientManager.CurrentData.Account)
                    Data.DMS.ClientManager.SetCurrent(i => i.Account == account);
            }

            // Transaction Cell

            if (selectedColumn == TransactionID_Column)
            {
                string transID = ("" + searchDataDataGridView.Rows[e.RowIndex].Cells[TransactionID_Column.Index].Value).ToString();
                var item = DMS.TransactionManager.GetData(i => i.ID == transID);
                if (item != null)
                {
                    Data.DMS.ClientManager.SetCurrent(i => i.Account == item.Account);
                    Data.DMS.TransactionManager.SetCurrent(i => i.ID == item.ID);
                }
            }

            // Quote Cell

            if (selectedColumn == QuoteID_Column)
            {
                string quoteID = ("" + searchDataDataGridView.Rows[e.RowIndex].Cells[QuoteID_Column.Index].Value).ToString();
                var item = DMS.QuoteManager.GetData(i => i.ID == quoteID);
                if (item != null)
                {
                    Data.DMS.ClientManager.SetCurrent(i => i.Account == item.Account);
                    Data.DMS.QuoteManager.SetCurrent(i => i.ID == item.ID);
                }
            }

            // Product Cell

            if (selectedColumn == ProductID_Column)
            {
                string productID = ("" + searchDataDataGridView.Rows[e.RowIndex].Cells[ProductID_Column.Index].Value).ToString();
                var item = DMS.ProductManager.GetData(i => i.ID == productID);
                if (item != null)
                {
                    Data.DMS.ClientManager.SetCurrent(i => i.Account == item.Account);
                    Data.DMS.ProductManager.SetCurrent(i => i.ID == item.ID);
                }
            }

            // Receipt Cell

            if (selectedColumn == ReceiptID_Column)
            {
                string receiptID = ("" + searchDataDataGridView.Rows[e.RowIndex].Cells[ReceiptID_Column.Index].Value).ToString();
                // DMS.SearchManager.DoSearch(receiptID, SearchType.Receipt);
            }
        }

        private void SearchCel_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            beenClicked = true;

            var selectedColumn = searchDataDataGridView.Columns[e.ColumnIndex];

            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                if (column != null && column == selectedColumn) doColumnReverse = !doColumnReverse;
                column = selectedColumn;
                SetSortOrder();
                return;
            }

            // Transaction

            if (selectedColumn == TransactionID_Column)
            {
                string transID = searchDataDataGridView.Rows[e.RowIndex].Cells[TransactionID_Column.Index].Value.ToString();
                var trans = DMS.TransactionManager.GetData(i => i.ID == transID);
                if (trans != null)
                {
                    if (trans.Type == Data.Transactions.TransactionType.Quote)
                    {
                        UserInterface.Quotes.Forms.QuoteForm qform = new Quotes.Forms.QuoteForm(trans);
                        qform.ShowDialog();
                    }
                    else
                    {
                        using (UserInterface.Transactions.Forms.TransactionForm f = new Transactions.Forms.TransactionForm(trans))
                            f.ShowDialog();
                    }
                }
            }

            // Product

            if (selectedColumn == ProductID_Column)
            {
                string productID = searchDataDataGridView.Rows[e.RowIndex].Cells[ProductID_Column.Index].Value.ToString();
                var product = DMS.ProductManager.GetData(i => i.ID == productID);
                if (product != null)
                    using (UserInterface.Products.Forms.ProductEditor f = new Products.Forms.ProductEditor(product))
                        f.ShowDialog();
            }

            beenClicked = false;
        }


        private void SendSelectedMaintReminders_Click(object sender, EventArgs e)
        {
            if (searchDataDataGridView.SelectedRows.Count == 0 && searchDataDataGridView.SelectedCells.Count == 0)
            {
                AMS.MessageBox_v2.Show("Nothing was selected", 1200);
                return;
            }

            foreach (DataGridViewCell cell in searchDataDataGridView.SelectedCells)
                cell.OwningRow.Selected = true;

            int rowCount = searchDataDataGridView.SelectedRows.Count;

            if (!(AMS.MessageBox_v2.Show("Warning this will send maintenance reminders to " + rowCount + " clients\r\nWould you like to proceed?", AMS.MessageType.Question) == AMS.MessageOut.YesOk))
                return;

            AMS.MessageBox_v2.ShowProcess("Generating Reminders");
            int nr = 0;

            foreach (DataGridViewRow row in searchDataDataGridView.SelectedRows)
            {
                nr++;
                AMS.MessageBox_v2.ShowProcess("Generating Reminder", nr, rowCount);
                var search = (SearchData)row.DataBoundItem;
                ReportManager.NEWReporter.MaintenanceQuoteReport(search.Client);
            }

            AMS.MessageBox_v2.EndProcess();
        }

        private void SendAllMaintReminders_Click(object sender, EventArgs e)
        {
            int rowCount = searchDataDataGridView.Rows.Count;

            if (!(AMS.MessageBox_v2.Show("Warning this will send maintenance reminders to " + rowCount + " clients\r\nWould you like to proceed?", AMS.MessageType.Question) == AMS.MessageOut.YesOk))
                return;

            AMS.MessageBox_v2.ShowProcess("Generating Reminders");
            int nr = 0;

            foreach (DataGridViewRow row in searchDataDataGridView.Rows)
            {
                nr++;
                AMS.MessageBox_v2.ShowProcess("Generating Reminder", nr, rowCount);

                var search = (SearchData)row.DataBoundItem;
                ReportManager.NEWReporter.MaintenanceQuoteReport(search.Client);
            }

            AMS.MessageBox_v2.EndProcess();
        }

        private void reminderasQuote_ToolStripButton_Click(object sender, EventArgs e)
        {
            if (searchDataDataGridView.SelectedRows.Count == 0 && searchDataDataGridView.SelectedCells.Count == 0)
            {
                AMS.MessageBox_v2.Show("Nothing was selected", 1200);
                return;
            }

            foreach (DataGridViewCell cell in searchDataDataGridView.SelectedCells)
                cell.OwningRow.Selected = true;

            int rowCount = searchDataDataGridView.SelectedRows.Count;

            if (!(AMS.MessageBox_v2.Show("Warning this will send maintenance reminder quotes to " + rowCount + " clients\r\nWould you like to proceed?", AMS.MessageType.Question) == AMS.MessageOut.YesOk))
                return;

            AMS.MessageBox_v2.ShowProcess("Generating Quotes");
            int nr = 0;

            foreach (DataGridViewRow row in searchDataDataGridView.SelectedRows)
            {
                nr++;
                AMS.MessageBox_v2.ShowProcess("Generating Quotes", nr, rowCount);
                var search = (SearchData)row.DataBoundItem;
                ReportManager.NEWReporter.MaintenanceQuoteReport(search.Client);
            }

            AMS.MessageBox_v2.EndProcess();
        }

        private void maint_ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void SendAllStatements_ToolStripButton_Click(object sender, EventArgs e)
        {
            int rowCount = searchDataDataGridView.Rows.Count;

            if (!(AMS.MessageBox_v2.Show("Warning this will send statements to " + rowCount + " clients\r\nWould you like to proceed?", AMS.MessageType.Question) == AMS.MessageOut.YesOk))
                return;

            AMS.MessageBox_v2.ShowProcess("Generating Statements");
            int nr = 0;

            foreach (DataGridViewRow row in searchDataDataGridView.Rows)
            {
                nr++;
                AMS.MessageBox_v2.ShowProcess("Generating Statement", nr, rowCount);

                var search = (SearchData)row.DataBoundItem;
                ReportManager.NEWReporter.MaintenanceQuoteReport(search.Client);
            }

            AMS.MessageBox_v2.EndProcess();

        }


        private void selectedStatements_ToolStripButton_Click(object sender, EventArgs e)
        {
            if (searchDataDataGridView.SelectedRows.Count == 0 && searchDataDataGridView.SelectedCells.Count == 0)
            {
                AMS.MessageBox_v2.Show("Nothing was selected", 1200);
                return;
            }

            foreach (DataGridViewCell cell in searchDataDataGridView.SelectedCells)
                cell.OwningRow.Selected = true;

            int rowCount = searchDataDataGridView.SelectedRows.Count;

            if (!(AMS.MessageBox_v2.Show("Warning this will send statements to " + rowCount + " clients\r\nWould you like to proceed?", AMS.MessageType.Question) == AMS.MessageOut.YesOk))
                return;

            AMS.MessageBox_v2.ShowProcess("Generating Statements");
            int nr = 0;

            foreach (DataGridViewRow row in searchDataDataGridView.SelectedRows)
            {
                nr++;
                AMS.MessageBox_v2.ShowProcess("Generating Statement", nr, rowCount);

                var search = (SearchData)row.DataBoundItem;
                ReportManager.NEWReporter.StatementReport(search.Client.Account);
            }

            AMS.MessageBox_v2.EndProcess();
        }
    }
}