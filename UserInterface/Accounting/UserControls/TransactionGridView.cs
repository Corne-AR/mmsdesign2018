using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data.Transactions;
using Data;
using UserInterface.Quotes.Forms;
using AMS;
using Data.People;
using Data.Search;

namespace UserInterface.Transactions.UserControls
{
    public partial class TransactionGridView : UserControl
    {
        // Transaction is a sales point summary on an invoice/quote/purchase order
        // Quote is the collected data for creating a transaction. Itemized and calculations

        //private HashSet<Transaction> transactionList;
        //public HashSet<Transaction> TransactionList
        //{
        //    get { return transactionList; }
        //}
        private List<Transaction> transactionViewedList;
        public List<Transaction> TransactionViewedList
        {
            get { return transactionViewedList; }
        }
        public List<Transaction> SelectedTransactions
        {
            get
            {
                var list = new List<Transaction>();

                foreach (DataGridViewCell cell in transactionList_DataGridView.SelectedCells)
                    transactionList_DataGridView.Rows[cell.RowIndex].Selected = true;

                foreach (DataGridViewRow row in transactionList_DataGridView.SelectedRows)
                {
                    list.Add((Transaction)row.DataBoundItem);
                }
                return list;
            }
        }

        private HashSet<Transaction> transactionList;

        private SearchData searchData;
        public SearchData SearchData
        {
            get { return searchData; }
            set { searchData = value; }
        }

        private bool loading = false;
        DataGridViewColumn column;
        private bool doColumnReverse;

        Client client;
        private Transaction transaction;
        private bool checkColReverse;

        #region Visual Studio

        [Description("If True, this control will filter columns for accounts"), Category("AMS")]
        public bool AccountingOnly { get; set; }

        [Description("Show Links Column"), Category("AMS")]
        public bool IsLinksVisible { get; set; }

        [Description("Allow user to filter the control"), Category("AMS")]
        public bool CanFilter { get; set; }

        #endregion

        // Constructors

        public TransactionGridView()
        {
            InitializeComponent();
        }

        private void TransactionList_Load(object sender, EventArgs e)
        {
            #region Theme

            ThemeColors.SetControls(this.Controls);
            ThemeColors.SetControls(flowLayoutPanel1, ThemeColors.ControlType.Menu);

            transactionList_DataGridView.DefaultCellStyle.BackColor = ThemeColors.ControlList;
            transactionList_DataGridView.DefaultCellStyle.ForeColor = ThemeColors.ControlText;

            Select_Column.DefaultCellStyle.SelectionBackColor = ThemeColors.Primary;
            transactionList_DataGridView.DefaultCellStyle.SelectionBackColor = ThemeColors.Primary;
            transactionList_DataGridView.DefaultCellStyle.SelectionForeColor = ThemeColors.PrimaryText;
            FlagPOMissing_Column.DefaultCellStyle.ForeColor = Color.White;

            id_ToolStripMenuItem.BackColor = ThemeColors.Primary;
            id_ToolStripMenuItem.ForeColor = ThemeColors.PrimaryText;

            summary_Panel.BackColor = ThemeColors.Menu;
            summary_Panel.ForeColor = ThemeColors.MenuText;
            receipt_Label.BackColor = ThemeColors.Blue;
            receipt_Label.ForeColor = Color.White;

            panel1.BackColor = ThemeColors.Menu;
            panel1.Size = new Size(Parent.Width - 6, 3);
            panel2.BackColor = ThemeColors.Menu;
            panel2.Size = new Size(Parent.Width - 6, 3);
            ThemeColors.SetControls(size_Button, ThemeColors.ControlType.Menu);

            ThemeColors.SetControls(panel3, ThemeColors.ControlType.Menu);

            #endregion

            loading = true;

            #region Visual Studio

            if (AccountingOnly)
            {
                flowLayoutPanel1.Visible = false;
                unpaid_CheckBox.Checked = true;
                quote_CheckBox.Checked = false;
                order_CheckBox.Checked = false;
                profroma_CheckBox.Checked = false;

                SupplierColumn.Visible = false;
                ContactColumn.Visible = false;
                EmailColumn.Visible = false;
                LinkedColumn.Visible = false;
            }
            else
            {
                unpaid_CheckBox.Checked = true;
                paid_CheckBox.Checked = true;
                processing_CheckBox.Visible = false;
            }

            LinkedColumn.Visible = IsLinksVisible;
            ReceiptListColumn.Visible = IsLinksVisible;
            showPanelButton_Label.Visible = CanFilter;

            #endregion

            if (DesignMode == true) return;

            AMS.MessageBox_v2.ShowProcess("Loading Transactions\r\nPlease wait");

            if (DMS.ClientManager == null || AMS.Suite.SuiteManager.Preferences == null) return;

            client = new Client();

            DMS.ClientManager.OnSaved_Event += TransactionLoad_Event;
            DMS.ClientManager.OnSelect_Enter += TransactionLoad_Event;
            DMS.QuoteManager.OnSaved_Event += TransactionLoad_Event;
            DMS.TransactionManager.OnSaved_Event += TransactionLoad_Event;
            //DMS.TransactionManager.OnSelect_Enter += TransactionLoad_Event;
            DMS.SearchManager.Transaction_Search += SearchManager_Receipt_Search;

            SupplierColumn.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            ReceiptListColumn.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            flowLayoutPanel1.Visible = AMS.Suite.SuiteManager.Preferences.ClientManager.TransactionPanel;

            FlagPOMissing_Column.ToolTipText = "Does all items have a valid supplier or 'not applicable'\r\n" +
                "Does the Purchase Orders equal to the selected amount of suppliers\r\n" +
                "   ex: each supplier has a PO";

            foreach (DataGridViewColumn column in transactionList_DataGridView.Columns)
                transactionList_DataGridView.Columns[column.Name].SortMode = DataGridViewColumnSortMode.NotSortable;

            LoadTransactions();

            AMS.MessageBox_v2.EndProcess();

            loading = false;
        }

        // Methods

        public void LoadTransactions()
        {
            System.Windows.Forms.Application.DoEvents();
            loading = true;

            AccountColumn.Visible = (searchData == null || searchData.SearchType != SearchType.Client);

            transactionList = new HashSet<Transaction>();
            client = DMS.ClientManager.CurrentData;

            AMS.MessageBox_v2.ShowProcess("Loading Transactions");

            // client or account view
            if (AccountingOnly)
            {
                if (searchData != null && (searchData.SearchType == SearchType.Client ||
                    searchData.SearchType == SearchType.Transaction || searchData.SearchType == SearchType.Receipt))
                {
                    #region Do Search Results

                    client = searchData.Client;

                    foreach (var i in DMS.TransactionManager.GetDataList(i =>
                             (searchData.SearchType == SearchType.Client && i.Account == client.Account) ||
                             (searchData.SearchType == SearchType.Transaction && i.ID == searchData.Transaction.ID) ||
                             (searchData.SearchType == SearchType.Receipt && i.ReceiptAllocationList != null && i.ReceiptAllocationList.Where(qi => qi.ReceiptID == searchData.Receipt.ID).Count() > 0)
                        ))
                        transactionList.Add(i);

                    // Load transactions from client Quotes
                    foreach (var i in DMS.QuoteManager.GetDataList(i =>
                             (searchData.SearchType == SearchType.Client && i.Account == client.Account) ||
                             (searchData.SearchType == SearchType.Transaction && i.ID == searchData.Transaction.ID)
                        ))
                        transactionList.Add(i.Transaction);

                    #endregion
                }
                else
                {
                    #region Load Everything

                    AMS.MessageBox_v2.ShowProcess("Loading Transactions");
                    transactionList = new HashSet<Transaction>(DMS.TransactionManager.GetDataList());

                    if (quote_CheckBox.Checked)
                    {
                        AMS.MessageBox_v2.ShowProcess("Loading Quotes");
                        foreach (var i in DMS.QuoteManager.GetDataList())
                            transactionList.Add(i.Transaction);
                    }
                    #endregion
                }
            }
            else
            {
                #region Filter on Client's Account

                foreach (var i in DMS.TransactionManager.GetDataList(i => i.Account == client.Account))
                    transactionList.Add(i);

                foreach (var i in DMS.QuoteManager.GetDataList(i => i.Account == client.Account))
                    transactionList.Add(i.Transaction);

                #endregion
            }

            AMS.MessageBox_v2.ShowProcess("Initializing Transactions");

            // Finally add ALL transactions to Control
            LoadTransactions(transactionList.ToList());
            loading = false;

            AMS.MessageBox_v2.EndProcess();
        }

        internal void LoadTransactions(Data.Accounts.Receipt receipt)
        {
            loading = true;

            var transactionList = new HashSet<Transaction>();

            foreach (var id in receipt.ReceiptAllocationList)
                transactionList.Add(DMS.TransactionManager.GetData(i => i.ID == id.TransactionID));

            LoadTransactions(transactionList.ToList());

            loading = false;
        }

        public void LoadTransactions(List<Transaction> TransactionList)
        {
            if (TransactionList == null) TransactionList = new List<Transaction>();

            var transactionList = new HashSet<Transaction>();

            foreach (var i in TransactionList)
                transactionList.Add(i);

            transactionList_DataGridView.RowHeadersVisible = false;
            //transactionList_DataGridView.DataSource = CheckFilter(transactionList.ToList());
            transactionBindingSource.DataSource = CheckFilter(transactionList.ToList());
            transactionList_DataGridView.RowHeadersVisible = true;

            SetCurrent();
            SetColors();
            SetStatus();
            AutoSizeGrid();
        }

        internal void SetFound(HashSet<Transaction> TransactionList)
        {
            foreach (DataGridViewRow row in transactionList_DataGridView.Rows)
            {
                string id = row.Cells[IDColumn.Index].Value.ToString();

                var query = (from i in TransactionList
                             where i.ID == id
                             select i).FirstOrDefault();

                var foreColor = transactionList_DataGridView.DefaultCellStyle.ForeColor;
                var backColor = transactionList_DataGridView.DefaultCellStyle.BackColor;

                if (query != null)
                {
                    foreColor = ThemeColors.SearchText;
                    backColor = ThemeColors.Search;
                }

                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.ColumnIndex != FlagMailed_Column.Index || cell.ColumnIndex != FlagPaid_Column.Index || cell.ColumnIndex != FlagPOMissing_Column.Index)
                    {
                        cell.Style.BackColor = backColor;
                        cell.Style.ForeColor = foreColor;
                    }
                }
            }
        }

        private List<Transaction> CheckFilter(List<Transaction> TransactionList)
        {
            var transactionViewList = new List<Transaction>();

            if (CanFilter)
            {
                #region Do filters

                if (quote_CheckBox.Checked)
                    transactionViewList.AddRange((from i in TransactionList
                                                  where i.Type == TransactionType.Quote && (i.InvoiceList() == null || i.InvoiceList().Count == 0) //Load only quotes with no invoices associated
                                                  select i).ToList());

                if (profroma_CheckBox.Checked)
                    transactionViewList.AddRange((from i in TransactionList
                                                  where i.Type == TransactionType.Proforma
                                                  select i).ToList());

                if (order_CheckBox.Checked)
                    transactionViewList.AddRange((from i in TransactionList
                                                  where i.Type == TransactionType.PurchaseOrder
                                                  select i).ToList());

                if (invoice_CheckBox.Checked)
                    transactionViewList.AddRange((from i in TransactionList
                                                  where i.Type == TransactionType.Invoice
                                                  select i).ToList());

                if (creditNote_CheckBox.Checked)
                    transactionViewList.AddRange((from i in TransactionList
                                                  where i.Type == TransactionType.CreditNote
                                                  select i).ToList());


                if (cancelTrans_CheckBox.Checked)
                    transactionViewList.AddRange((from i in TransactionList
                                                  where i.Type == TransactionType.CancellationOrder
                                                  select i).ToList());

                // Add unpaid proformas
                /* CA excluded this option to be able to hide proformas also
                 if (unpaid_CheckBox.Checked)
                    transactionViewList.AddRange((from i in TransactionList
                                                  where i.Type == TransactionType.Proforma && (i.InvoiceList() == null || i.InvoiceList().Count == 0)
                                                  select i).ToList());
                */

                transactionViewList = (from i in transactionViewList
                                       where
                                       (unpaid_CheckBox.Checked && i.Type == TransactionType.PurchaseOrder && !i.SendtoSupplier) || 
                                       (unpaid_CheckBox.Checked && !i.IsPaid()) ||
                                       (paid_CheckBox.Checked && i.IsPaid()) ||
                                       (mailed_ChkBox.CheckState != CheckState.Indeterminate && i.IsMailed == mailed_ChkBox.Checked) ||
                                       (processing_CheckBox.Checked && i.BeingProcessed)
                                       select i).ToList();

                #endregion
            }
            else
            {
                transactionViewList = TransactionList;
            }


            if (searchData != null)
            {
                transactionViewList = (from i in transactionViewList
                                       where searchData.WithinRange(i.TransactionDate)
                                       select i).ToList();
            }

            #region Sort List


            if (column == IDColumn)
                transactionViewList = (from i in transactionViewList
                                       orderby i.ID ascending
                                       select i).ToList();

            if (column == AccountColumn)
                transactionViewList = (from i in transactionViewList
                                       orderby i.Account ascending
                                       select i).ToList();

            if (column == ReceiptListColumn)
                transactionViewList = (from i in transactionViewList
                                       orderby i.ReceiptAllocationList.Count ascending
                                       select i).ToList();

            if (column == DateColumn)
                transactionViewList = (from i in transactionViewList
                                       orderby i.TransactionDate ascending
                                       select i).ToList();

            if (column == TotalDueColumn)
                transactionViewList = (from i in transactionViewList
                                       orderby i.TotalDue ascending
                                       select i).ToList();

            if (column == SupplierColumn)
                transactionViewList = (from i in transactionViewList
                                       orderby i.SupplierId ascending
                                       select i).ToList();

            if (column == ContactColumn)
                transactionViewList = (from i in transactionViewList
                                       orderby i.Contact ascending
                                       select i).ToList();

            if (column == EmailColumn)
                transactionViewList = (from i in transactionViewList
                                       orderby i.IsMailed ascending
                                       select i).ToList();

            if (column == FlagPOMissing_Column)
                transactionViewList = (from i in transactionViewList
                                       orderby i.POGenerated ascending
                                       select i).ToList();

            if (column == FlagPaid_Column)
                transactionViewList = (from i in transactionViewList
                                       orderby i.IsPaid() ascending
                                       select i).ToList();

            if (column == FlagMailed_Column)
                transactionViewList = (from i in transactionViewList
                                       orderby i.Email ascending
                                       select i).ToList();
            if (checkColReverse)
            {
                if (doColumnReverse)
                    transactionViewList.Reverse();

                checkColReverse = false;
            }

            #endregion

            transactionViewedList = transactionViewList;
            return transactionViewList;
        }

        public void SetCurrent()
        {
            if (transaction == null) return;

            transactionList_DataGridView.ClearSelection();

            var row = transactionList_DataGridView.Rows
                .Cast<DataGridViewRow>()
                .FirstOrDefault(r => ((Transaction)r.DataBoundItem).ID == transaction.ID);

            if (row != null)
            {
                row.Cells[0].Selected = true;

                transactionList_DataGridView.Rows[row.Index].Selected = true;
                transactionList_DataGridView.Rows[row.Index].Cells[0].Selected = true;
            }
        }

        private void SetColors()
        {
            foreach (DataGridViewRow row in transactionList_DataGridView.Rows)
            {
                var trans = (Transaction)row.DataBoundItem;
                if (trans != null)
                {
                    row.Cells[FlagPaid_Column.Name].Style.BackColor = ThemeColors.Primary;
                    row.Cells[FlagMailed_Column.Name].Style.BackColor = ThemeColors.Primary;
                    row.Cells[FlagPOMissing_Column.Name].Style.BackColor = ThemeColors.Primary;

                    if (trans.TotalDue > 0) row.Cells[FlagPaid_Column.Name].Style.BackColor = ThemeColors.Orange;
                    if (trans.TotalDue < 0 || trans.TotalDue == trans.Total) row.Cells[FlagPaid_Column.Name].Style.BackColor = ThemeColors.Red;
                    if (trans.TotalDue == 0 || trans.Type == TransactionType.Quote || trans.Type == TransactionType.Proforma) row.Cells[FlagPaid_Column.Name].Style.BackColor = ThemeColors.Primary;
                    if (trans.Type == TransactionType.PurchaseOrder && !trans.SendtoSupplier) row.Cells[FlagPaid_Column.Name].Style.BackColor = ThemeColors.Red;

                    if (!trans.IsMailed) row.Cells[FlagMailed_Column.Name].Style.BackColor = ThemeColors.UserControl;

                    if (trans.Type == TransactionType.Quote || trans.Type == TransactionType.Proforma && trans.IsMailed) row.Cells[FlagMailed_Column.Name].Style.BackColor = ThemeColors.Primary;

                    if (trans.POGenerated != "") row.Cells[FlagPOMissing_Column.Name].Style.BackColor = ThemeColors.Blue;
                    if (trans.Type == TransactionType.PurchaseOrder && trans.HasUnpaidInvoices()) row.Cells[FlagPOMissing_Column.Name].Style.BackColor = ThemeColors.Orange;
                    row.Cells[FlagPaid_Column.Name].Style.SelectionBackColor = row.Cells[FlagPaid_Column.Name].Style.BackColor;
                    row.Cells[FlagMailed_Column.Name].Style.SelectionBackColor = row.Cells[FlagMailed_Column.Name].Style.BackColor;
                    row.Cells[FlagPOMissing_Column.Name].Style.SelectionBackColor = row.Cells[FlagPOMissing_Column.Name].Style.BackColor;
                }
            }
        }

        public void SetStatus()
        {
            try
            {
                string summary = "";
                int visibleCount = transactionList_DataGridView.Rows.Count;
                int totalCount = DMS.TransactionManager.GetDataList(i => i.Type != TransactionType.Proforma && i.Type != TransactionType.Statement && i.Type != TransactionType.Quote).Count;

                bool accountOnly = !AccountingOnly || (searchData != null && searchData.SearchType == SearchType.Client);

                decimal totalInvoiceAmount = (from i in transactionViewedList
                                              where !accountOnly || i.Account == client.Account
                                              where i.Type == TransactionType.Invoice || i.Type == TransactionType.CreditNote
                                              where !i.IsPaid()
                                              select i).Sum(i => i.TotalDue);

                decimal totalPOAmount = (from i in transactionViewedList
                                         where i.Type == TransactionType.PurchaseOrder
                                         where !i.SendtoSupplier
                                         select i).Sum(i => i.Total);

                var receipts = (from i in Data.DMS.AccountsManager.ReceiptList
                                where !accountOnly || i.Account == client.Account
                                where i.AmountRemaining > 0
                                select i).ToList();

                decimal totalReceipt = receipts.Sum(i => i.AmountRemaining);

                if (totalInvoiceAmount != 0) summary += " Transactions   -   " + totalInvoiceAmount;
                if (totalPOAmount != 0) summary += "       Purchase Orders   -   " + totalPOAmount;
                if (receipts.Count != 0)
                {
                    receipt_Label.Text = "Credit   -   " + string.Format("{0:### ### ### ###.00}", totalReceipt).Trim();

                    string tooltip = "";
                    foreach (var i in receipts)
                    {
                        tooltip += i.ID + " - " + i.Description + " - " + i.GetInvoiceIDList + "\r\n";
                    }

                    toolTip1.SetToolTip(this.receipt_Label, tooltip);
                }
                summary += "     " + visibleCount + "/" + totalCount;
                summary_Label.Text = summary;

                if (totalInvoiceAmount > 0)
                {
                    summary_Panel.BackColor = ThemeColors.Red;
                    if (totalInvoiceAmount < 0) summary_Panel.BackColor = ThemeColors.Blue;
                    if (totalInvoiceAmount == 0) summary_Panel.BackColor = ThemeColors.Primary;

                    StringBuilder sb = new StringBuilder();

                    int nr = 0;
                    foreach (var i in SelectedTransactions)
                    {
                        nr++;
                        sb.Append(i.ID);
                        if (nr < SelectedTransactions.Count) sb.Append(" - ");
                    }

                    if (AccountingOnly) AMS.StatusUpdate.UpdateSelectionOne("Transactions", sb.ToString());
                    else AMS.StatusUpdate.UpdateSelectionTwo("Transactions", sb.ToString());

                    receipt_Label.Visible = totalReceipt > 0.05m;
                }
            }
            catch { }
        }

        private void AutoSizeGrid()
        {
            transactionList_DataGridView.AutoResizeRows();
            transactionList_DataGridView.AutoResizeColumns();
            Select_Column.Width = 5;
            FlagMailed_Column.Width = 5;
            FlagPaid_Column.Width = 5;
            FlagPOMissing_Column.Width = 5;
        }

        // Events

        private void SearchManager_Receipt_Search(object sender, TransactionSearchArgs e)
        {
            paid_CheckBox.Checked = true;
            unpaid_CheckBox.Checked = true;
            LoadTransactions(e.TransactionList.ToList());
        }

        private void TransactionLoad_Event(object sender, EventArgs e)
        {
            if (loading) return;

            Form parentForm = this.FindForm();
            Form mdiParentForm = (Form)this.TopLevelControl;

            if (mdiParentForm != null && parentForm != null && (!AccountingOnly || mdiParentForm.ActiveMdiChild == parentForm))
                LoadTransactions();
        }

        private void DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (loading) return;

            if (e.RowIndex < 0) return;
            if (e.ColumnIndex < 0) return;

            string id = ((Transaction)transactionList_DataGridView.Rows[e.RowIndex].DataBoundItem).ID;

            transaction = (Transaction)transactionList_DataGridView.Rows[e.RowIndex].DataBoundItem;

            if (transaction == null) return;

            if (transaction.Type == TransactionType.Quote)
            {
                var qForm = new Quotes.Forms.QuoteForm(transaction);
                qForm.Show();
            }
            else
            {
                using (UserInterface.Transactions.Forms.TransactionForm f = new Forms.TransactionForm(transaction))
                {
                    f.ShowDialog();
                    transaction.Copy(f.Transaction);
                }
            }
        }

        private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (loading) return;

            if (e.ColumnIndex < 0) return;

            #region Sort Columns

            if (e.RowIndex < 0)
            {
                checkColReverse = true;

                var slectedColumn = transactionList_DataGridView.Columns[e.ColumnIndex];
                if (column != null && column == slectedColumn) doColumnReverse = !doColumnReverse;
                column = slectedColumn;
                LoadTransactions();
                //string sortype = "asc";
                //if (doColumnReverse) sortype = "desc";
                //transactionBindingSource.Sort = slectedColumn.DataPropertyName + " " + sortype;
                return;
            }

            #endregion

            var transaction = (Transaction)transactionList_DataGridView.Rows[e.RowIndex].DataBoundItem;

            loading = true;

            if (transactionList_DataGridView.Columns[e.ColumnIndex] == AccountColumn)
                DMS.ClientManager.SetCurrent(i => i.Account == transaction.Account);

            loading = false;

            DMS.TransactionManager.SetCurrent(transaction);

            transactionList_DataGridView.Rows[e.RowIndex].Cells[0].Selected = true;
            DMS.SearchLinkManager.SetTransacion(transaction);
        }

        #region Right click Menu

        private void transactionList_DataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right && e.RowIndex >= 0)
            {
                transaction = (Transaction)transactionList_DataGridView.Rows[e.RowIndex].DataBoundItem;
                if (transaction == null) return;

                id_ToolStripMenuItem.Text = transaction.Type + " " + transaction.ID;

                var quote = DMS.QuoteManager.GetData(i => i.ID == transaction.ID);

                override_ToolStripMenuItem.Enabled = (transaction.Type == TransactionType.Quote && quote != null && quote.ProgressType != Data.Quotes.ProgressType.New);
                edit_ToolStripMenuItem.Enabled = !override_ToolStripMenuItem.Enabled;
                void_ToolStripMenuItem.Enabled = transaction.Type == TransactionType.Invoice;
                delete_ToolStripMenuItem.Enabled = (transaction.Type == TransactionType.Quote || transaction.Type == TransactionType.Proforma);
                cancelTrans_ToolStripMenuItem.Enabled = transaction.Type == TransactionType.Invoice || transaction.Type == TransactionType.PurchaseOrder;
                contextMenuStrip.Show(transactionList_DataGridView, transactionList_DataGridView.PointToClient(Cursor.Position));
            }
        }

        private void SendMail_Event(object sender, EventArgs e)
        {
            foreach (var t in SelectedTransactions)
            {
                if (t.Type == TransactionType.Quote)
                {

                    try
                    {
                        ReportManager.QuoteReport(t.ID);
                    }
                    catch (Exception ex)
                    {
                        MessageBox_v2.Show("Could not save before mailing.\r\n" + ex.ToString());
                        return;
                    }
                }
                else
                {
                    try
                    {
                        ReportManager.TransactionReport(t);
                    }
                    catch (Exception ex)
                    {
                        MessageBox_v2.Show("Could not save before mailing.\r\n" + ex.ToString());
                        return;
                    }
                }
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (loading) return;

            if (transaction.Type == TransactionType.Invoice || transaction.Type == TransactionType.Proforma)
            {
                if (transaction.ReceiptAllocationList.Count > 0)
                {
                    AMS.MessageBox_v2.Show("Receipts are allocated to this transaction. Unlink them first");
                    return;
                }
            }

            if (transaction.Type == TransactionType.Quote)
            {
                if (AMS.MessageBox_v2.Show("Remove " + transaction.Type + "?", AMS.MessageType.Question) == AMS.MessageOut.YesOk)
                {
                    var q = DMS.QuoteManager.GetData(i => i.ID == transaction.ID);
                    DMS.QuoteManager.Delete("Are you sure you want to remove Quote:" + q.ID + "?", q);
                }
            }

            if (transaction.Type == TransactionType.Proforma)
            {
                if (AMS.MessageBox_v2.Show("Remove " + transaction.Type + "?", AMS.MessageType.Question) == AMS.MessageOut.YesOk)
                {
                    DMS.TransactionManager.Delete("Are you sure you want to remove " + transaction.Type + ":" + transaction.ID + "?", transaction);
                }
            }

            LoadTransactions();
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            if (transaction.Type == TransactionType.Quote)
            {
                using (QuoteForm f = new QuoteForm(transaction))
                    f.ShowDialog();
            }
            else
            {
                using (Forms.TransactionForm f = new Forms.TransactionForm(transaction))
                    f.ShowDialog();
            }
        }

        private void MultiEdit_Click(object sender, EventArgs e)
        {
            var win = new Accounting.Forms.MultiCreatorForm(SelectedTransactions);
            win.Show();
        }

        private void Override_Click(object sender, EventArgs e)
        {
            if (transaction.Type == TransactionType.Quote)
            {
                if (AMS.MessageBox_v2.Show("Are you sure you want to overwrite the original quote?\r\nWARNING! This action may replace the Proforma Invoice and Products\r\n\r\nPlease add a note.", AMS.MessageType.Question) == AMS.MessageOut.YesOk)
                {
                    string message = "Overwrite " + transaction.Type + " " + transaction.ID + Environment.NewLine + "Note: \"" + AMS.MessageBox_v2.MessageValue + "\"";
                    var quote = DMS.QuoteManager.GetData(i => i.ID == transaction.ID);

                    quote.ProgressType = Data.Quotes.ProgressType.New;
                    quote.Save(message, true, true, Data.Quotes.ProgressType.New);

                    using (QuoteForm f = new QuoteForm(quote.Transaction))
                        f.ShowDialog();
                }
            }
        }

        private void Void_Click(object sender, EventArgs e)
        {
            if (transaction.Type == TransactionType.Invoice)
            {
                AMS.MessageBox_v2.Show("TODO!");
            }
        }

        private void ViewLog_Click(object sender, EventArgs e)
        {
            transaction.ViewDatalog();
        }

        private void duplicate_MenuItem_Click(object sender, EventArgs e)
        {
            if (transaction.Type == TransactionType.Quote)
            {
                var quote = DMS.QuoteManager.GetData(i => i.ID == transaction.ID);
                if (quote != null)
                {
                    string newID = quote.DuplicateQuote();

                    using (QuoteForm f = new QuoteForm(newID))
                        f.ShowDialog();
                }
            }
            else
            {
                transaction.DuplicateTransaction(transaction);
            }
        }

        private void CancelTrans_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            transaction.CancelTransaction();
        }

        #endregion

        private void Filter_Event(object sender, EventArgs e)
        {
            if (loading) return;

            LoadTransactions();
        }

        private void ShowPanel_Event(object sender, EventArgs e)
        {
            if (!AccountingOnly)
            {
                AMS.Suite.SuiteManager.Preferences.ClientManager.TransactionPanel = !AMS.Suite.SuiteManager.Preferences.ClientManager.TransactionPanel;
                flowLayoutPanel1.Visible = AMS.Suite.SuiteManager.Preferences.ClientManager.TransactionPanel;
            }
            else
            {
                flowLayoutPanel1.Visible = !flowLayoutPanel1.Visible;
            }
        }

        private void dataGridView1_MouseUp(object sender, MouseEventArgs e)
        {
            // For Linking Purpose
            if (AccountingOnly) DMS.AccountsManager.SetTransactions(SelectedTransactions);

            SetStatus();
        }

        private void SizeGrid_Click(object sender, EventArgs e)
        {
            AutoSizeGrid();
        }

        private void acounts_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //using (Accounting.Forms.AccountsEditor f = new Accounting.Forms.AccountsEditor(transaction))
            //    f.ShowDialog();

            DMS.SearchManager.DoTransactionLinkSearch(transaction);
        }

        private void removeLinks_LoolStripMenuItem_Click(object sender, EventArgs e)
        {
            transaction.Unlink();
        }
    }
}