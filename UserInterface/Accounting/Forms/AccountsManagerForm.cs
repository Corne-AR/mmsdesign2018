using AMS;
using Data;
using Data.Search;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterface.Accounting.Forms
{
    public partial class AccountsManagerForm : Form
    {
        // Variables

        bool loading = false;
        bool filterOnCLient = false;

        // Constructor

        public AccountsManagerForm()
        {
            InitializeComponent();

            btnMMSReceipt.Click += (s, e) => { new MMSReceiptsGenerator().ShowDialog(); };
        }

        private void AccountingManager_Load(object sender, EventArgs e)
        {
            if (DesignMode == false)
                AMS.MessageBox_v2.ShowProcess("Initializing Accounts\r\nPlease wait");

            #region ThemeColors

            ThemeColors.SetControls(splitContainer1, ThemeColors.ControlType.MenuBorder);

            ThemeColors.SetControls(main_ToolStrip, ThemeColors.ControlType.MenuBorder);
            foreach (var i in main_ToolStrip.Controls)
            {
                if (i.GetType() == typeof(ToolStripLabel) || i.GetType() == typeof(ToolStripSeparator))
                {
                    ((Control)i).BackColor = ThemeColors.Menu;
                    ((Control)i).ForeColor = ThemeColors.MenuText;
                }
                else
                {
                    ((Control)i).BackColor = ThemeColors.MenuBorder;
                    ((Control)i).ForeColor = ThemeColors.MenuBorderText;
                }
            }

            ThemeColors.SetControls(suppliers_ToolStrip, ThemeColors.ControlType.MenuBorder);
            foreach (var i in suppliers_ToolStrip.Controls)
            {
                if (i.GetType() == typeof(ToolStripLabel) || i.GetType() == typeof(ToolStripSeparator))
                {
                    ((Control)i).BackColor = ThemeColors.Menu;
                    ((Control)i).ForeColor = ThemeColors.MenuText;
                }
                else
                {
                    ((Control)i).BackColor = ThemeColors.MenuBorder;
                    ((Control)i).ForeColor = ThemeColors.MenuBorderText;
                }
            }

            link_ToolStripButton.BackColor = ThemeColors.Primary;
            link_ToolStripButton.ForeColor = ThemeColors.PrimaryText;

            #endregion

            #region ToolTip

            refresh_ToolStripButton.ToolTipText = "Refreshing the transaction and receipt lists in memory";
            link_ToolStripButton.ToolTipText = "Link the selected receipt to selected transaction(s)";
            reload_ToolStripButton.ToolTipText = "Cancel all changes and reload the original data";
            filterClient_ToolStripButton.ToolTipText = "Filters transaction list and receipt to to current selected client.";
            addReceipt_ToolStripButton.ToolTipText = "NOTE: Adding a new receipt will save the list.";
            paste_ToolStripButton.ToolTipText = "Pastes from excel\r\nPlease use the following format: [Amount] [Description] [Date]";
            saveReceipts_ToolStripButton1.ToolTipText = "Save changes made to receipt list, with no update to any transaction(s) to database";
            saveTransactions_ToolStripButton.ToolTipText = "Save both receipts and all linked transactions to database";

            #endregion

            DMS.SearchLinkManager.Transaction_SearchLink += SearchManager_Transaction_Search;
            DMS.SearchLinkManager.Receipt_SeachLink += SearchManager_Receipt_Search;
            DMS.SearchLinkManager.Client_SearchLink += SearchManager_Client_Search;
            DMS.ClientManager.OnSelect_Enter += ClientSelected_Event;

            paymentsReport_ToolStripButton.Enabled = (DMS.ClientManager.CurrentData.Catagory == "Supplier");

            receiptGridView1.receiptDataGridView.SelectionChanged += (s, e1) => link_Label.Text = LinkStatus();
            transactionGridView1.transactionList_DataGridView.SelectionChanged += (s, e1) => link_Label.Text = LinkStatus();

            // Get Search Range Items
            foreach (var i in Enum.GetNames(typeof(SearchRange)))
                filterRange_ToolStripComboBox.Items.Add(i.ToString());
            filterRange_ToolStripComboBox.SelectedItem = SearchRange.Month.ToString();

            filterRange_ToolStripComboBox.SelectedIndexChanged += new EventHandler(filterRange_ToolStripComboBox_SelectedIndexChanged);

            FilterAndLoad();

            AMS.MessageBox_v2.EndProcess();
        }

        private void AccountingManager_Enter(object sender, EventArgs e)
        {
            SetStatusUpdate();
            receiptGridView1.SetStatus();
            transactionGridView1.SetStatus();
        }

        // Methods

        public void FilterAndLoad()
        {
            loading = true;
            saveAccount_ToolStripButton.Enabled = filterOnCLient;
            //saveReceipts_ToolStripButton1.Enabled = !filterOnCLient;
            saveTransactions_ToolStripButton.Enabled = !filterOnCLient;

            SearchData searchData = new SearchData(SearchType.All);

            if (filterOnCLient)
            {
                searchData = new SearchData(SearchType.Client);
                searchData.Clear();
                searchData.SetClient(DMS.ClientManager.CurrentData, SearchType.Client);

                filterClient_ToolStripButton.BackColor = ThemeColors.Primary;
                filterClient_ToolStripButton.ForeColor = ThemeColors.PrimaryText;
                selectedPayements_ToolStripButton.Enabled = true;
            }
            else
            {
                filterClient_ToolStripButton.BackColor = main_ToolStrip.BackColor;
                filterClient_ToolStripButton.ForeColor = main_ToolStrip.ForeColor;
                selectedPayements_ToolStripButton.Enabled = false;
            }

            // Set Range
            searchData.SetRange((SearchRange)Enum.Parse(typeof(SearchRange), filterRange_ToolStripComboBox.Text));

            receiptGridView1.SearchData = searchData;
            transactionGridView1.SearchData = searchData;

            receiptGridView1.LoadReceipts();
            transactionGridView1.LoadTransactions();
            SetStatusUpdate();

            loading = false;
        }

        public void SetReceiptClient(string Account)
        {
            receiptGridView1.SetReceiptClient(Account);
        }

        private void SetStatusUpdate()
        {
            if (filterOnCLient)
            {
                receiptGridView1.SetStatus();
                transactionGridView1.SetStatus();
            }

            int receiptCount = 0;
            int transactionsCount = 0;

            if (DMS.AccountsManager.ReceiptList != null) receiptCount = DMS.AccountsManager.ReceiptList.Count;
            if (DMS.TransactionManager != null) transactionsCount = DMS.TransactionManager.GetDataList(i => i.Type != Data.Transactions.TransactionType.Proforma && i.Type != Data.Transactions.TransactionType.Quote).Count;
            AMS.StatusUpdate.UpdateDataCount(DMS.ClientManager.CurrentData.Name + "  |  " + transactionsCount + " Transactions  |  " + receiptCount + " Receipts");
            ToDoListLabel.Text = ToDoUpdates();
            link_Label.Text = LinkStatus();
        }

        private string ToDoUpdates()
        {
            var sb = new StringBuilder();

            //Unsent PO's 
            //Unsent PO's that was fully paid by client
            //Unsent invoices
            //Upprocessed Pro Formas that was mailed to client


            var polist = DMS.TransactionManager
                .GetDataList(x => x.Type == Data.Transactions.TransactionType.PurchaseOrder)
                .Where(x => !x.IsMailed)
                .ToList();
            var paidcount = polist.Where(x => !x.HasUnpaidInvoices()).Count();

            if (polist.Count > 0)
            {
                sb.Append($"Purchase Orders not completed: {polist.Count}");
                if (paidcount > 0) sb.Append($" - Client has paid : {paidcount}");
                sb.AppendLine();
            }


            //Invoices not mailed and not mailed but paid

            var invlist = DMS.TransactionManager
                .GetDataList(x => x.Type == Data.Transactions.TransactionType.Invoice)
                .Where(x => !x.IsMailed)
                .ToList();
            paidcount = invlist.Where(x => x.IsPaid()).Count();

            if (invlist.Count > 0)
            {
                sb.Append($"Invoices not mailed to client: {invlist.Count}");
                if (paidcount > 0) sb.Append($" - Client has paid : {paidcount}");
                sb.AppendLine();
            }

            //Invoices without purchse orders
            invlist = DMS.TransactionManager
                .GetDataList(x => x.Type == Data.Transactions.TransactionType.Invoice)
                .Where(x => !string.IsNullOrEmpty(x.POGenerated))
                .Where(x => x.TransactionDate.Year > 2015)
                .ToList();
            paidcount = invlist.Where(x => x.IsPaid()).Count();


            if (invlist.Count > 0)
            {
                sb.Append($"Invoices without purchase orders: {invlist.Count}");
                if (paidcount > 0) sb.Append($" - Client has paid : {paidcount}");
                sb.AppendLine();
            }

            return sb.ToString().Trim();
        }

        private string LinkStatus()
        {
            var sb = new StringBuilder();

            if (receiptGridView1.SelectedReceipt != null) sb.AppendLine($"Receipt: {receiptGridView1.SelectedReceipt}");
            if(transactionGridView1.SelectedTransactions?.Count > 0)
            {
                foreach (var t in transactionGridView1.SelectedTransactions)
                    sb.AppendLine($"Transaction {t}");
            }

            // transactionGridView1.SelectedTransactions, receiptGridView1.SelectedReceipt

            return sb.ToString().Trim();
        }


        // Events


        private void ClientSelected_Event(object sender, EventArgs e)
        {
            paymentsReport_ToolStripButton.Enabled = (DMS.ClientManager.CurrentData.Catagory == "Supplier");
            SetStatusUpdate();
        }

        private void LoadTransactions_Click(object sender, EventArgs e)
        {
            if (loading) return;

            try
            {
                receiptGridView1.Validate();
                transactionGridView1.Validate();
            }
            catch (Exception ex)
            {
                AMS.MessageBox_v2.Show("Error 1974\r\nPotenial bug fix\r\n" + ex.Message, AMS.MessageType.Error);
            }

            FilterAndLoad();
        }

        private void PasteReceipts_Click(object sender, EventArgs e)
        {
            if (loading) return;

            receiptGridView1.PasteReceipts();

            if (loading) return;

            try
            {
                receiptGridView1.Validate();
                transactionGridView1.Validate();
            }
            catch (Exception ex)
            {
                AMS.MessageBox_v2.Show(ex.Message, AMS.MessageType.Error);
            }

            DMS.AccountsManager.SaveReceipts();
            //FilterSelected();
            //AMS.MessageBox_v2.Show("Remember to save before trying to link transactions!");
        }

        #region Save

        private void SaveReceipts_Click(object sender, EventArgs e)
        {
            if (loading) return;

            try
            {
                receiptGridView1.Validate();
                transactionGridView1.Validate();
            }
            catch (Exception ex)
            {
                AMS.MessageBox_v2.Show(ex.Message, AMS.MessageType.Error);
            }

            DMS.AccountsManager.SaveReceipts();
            FilterAndLoad();
        }

        private void saveAccount_Button_Click(object sender, EventArgs e)
        {
            if (loading) return;

            try
            {
                receiptGridView1.Validate();
                transactionGridView1.Validate();
            }
            catch (Exception ex)
            {
                AMS.MessageBox_v2.Show(ex.Message, AMS.MessageType.Error);
            }

            DMS.AccountsManager.Save(DMS.ClientManager.CurrentData.Account, receiptGridView1.ReceiptList);
        }

        private void saveAll_Button_Click(object sender, EventArgs e)
        {
            if (loading) return;

            try
            {
                receiptGridView1.Validate();
                transactionGridView1.Validate();
            }
            catch (Exception ex)
            {
                AMS.MessageBox_v2.Show(ex.Message, AMS.MessageType.Error);
            }

            DMS.AccountsManager.SaveReceipts();
            DMS.AccountsManager.SaveTransactions();
        }

        #endregion

        private void LinkReceipts_Button(object sender, EventArgs e)
        {
            if (loading) return;

            try
            {
                receiptGridView1.Validate();
                transactionGridView1.Validate();
            }
            catch (Exception ex)
            {
                AMS.MessageBox_v2.Show(ex.Message, AMS.MessageType.Error);
            }

            DMS.AccountsManager.LinkTransactions(transactionGridView1.SelectedTransactions, receiptGridView1.SelectedReceipt);
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            if (loading) return;

            DMS.AccountsManager.RevertData();
            transactionGridView1.LoadTransactions();
            receiptGridView1.LoadReceipts();

            try
            {
                receiptGridView1.Validate();
                transactionGridView1.Validate();
            }
            catch (Exception ex)
            {
                AMS.MessageBox_v2.Show(ex.Message, AMS.MessageType.Error);
            }

            FilterAndLoad();
        }

        private void addReceipt_Button_Click(object sender, EventArgs e)
        {
            if (loading) return;

            DMS.AccountsManager.AddReceipt();
            receiptGridView1.LoadReceipts();
        }

        void SearchManager_Receipt_Search(object sender, EventArgs e)
        {
            if (loading) return;

            receiptGridView1.SetFound(DMS.SearchLinkManager.ReceiptList);
        }

        void SearchManager_Transaction_Search(object sender, EventArgs e)
        {
            if (loading) return;

            transactionGridView1.SetFound(DMS.SearchLinkManager.TransactionList);
        }

        void SearchManager_Client_Search(object sender, EventArgs e)
        {
            if (loading) return;

            clientSelect1.SetFound(DMS.SearchLinkManager.ClientList);
        }

        private void Process_Click(object sender, EventArgs e)
        {
            if (loading) return;

            DMS.AccountsManager.ProcessReceipts();
            receiptGridView1.ShowProcess();
        }

        private void ProcessPrefrences_Click(object sender, EventArgs e)
        {
            if (loading) return;

            using (ProcessPreferences f = new ProcessPreferences())
                f.ShowDialog();
        }

        private void FilterClient_Click(object sender, EventArgs e)
        {
            if (loading) return;

            try
            {
                receiptGridView1.Validate();
                transactionGridView1.Validate();
            }
            catch (Exception ex)
            {
                AMS.MessageBox_v2.Show(ex.Message, AMS.MessageType.Error);
            }

            filterOnCLient = !filterOnCLient;

            FilterAndLoad();
        }

        private void filterRange_ToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loading) return;
            FilterAndLoad();
        }

        private void currentPayment_ToolStripButton_Click(object sender, EventArgs e)
        {
            if (MessageBox_v2.Show("Send outstanding payment notifications to suppliers?\r\n\r\nOnly transactions which has been paid will be processed", MessageType.Question) == MessageOut.YesOk)
            {
                int nr = 0; //Koos was hier
                foreach (var supplier in DMS.GetSupplierList)
                {
                    var poList = DMS.TransactionManager.GetDataList(i => i.Account == supplier.Account && (i.Type == Data.Transactions.TransactionType.PurchaseOrder || i.Type == Data.Transactions.TransactionType.CancellationOrder));

                    poList = (from i in poList
                              where !i.SendtoSupplier && i.TotalDue <= 0.05m
                              select i).ToList();

                    poList = (from i in poList
                              where i.InvoiceList().Where(qi => qi.TotalDue <= 0.05m).Count() > 0 || i.InvoiceList().Count == 0
                              select i).ToList();

                    Data.Transactions.Utilities.SendToSupplier(poList);

                    if (poList.Count == 0) nr++; //Koos was hier

                }
                if (nr > 0) MessageBox_v2.Show("Nothing to pay. Some invoices may still have outstanding ballances."); //Koos was hier
            }
        }

        private void selectedPayements_ToolStripButton_Click(object sender, EventArgs e)
        {
            if (AMS.MessageBox_v2.Show("Send outstanding payment notifications from selected Purchase Orders?", AMS.MessageType.Question) == AMS.MessageOut.YesOk)
            {
                var poList = new List<Data.Transactions.Transaction>();

                foreach (var trans in transactionGridView1.SelectedTransactions)
                    if (trans.Type == Data.Transactions.TransactionType.PurchaseOrder) poList.Add(trans);

                Data.Transactions.Utilities.SendToSupplier(poList);
            }
        }

        private void paymentsReport_ToolStripButton_Click(object sender, EventArgs e)
        {
            if (DMS.ClientManager.CurrentData == null) return;
            if (AMS.MessageBox_v2.Show("Send a report of all Purchase Orders for " + DMS.ClientManager.CurrentData.Name + "?", AMS.MessageType.Question) == AMS.MessageOut.YesOk)
            {
                var poList = DMS.TransactionManager.GetDataList(i => i.Account == DMS.ClientManager.CurrentData.Account && i.Type == Data.Transactions.TransactionType.PurchaseOrder);

                Data.Transactions.Utilities.SendToSupplier(poList);
            }
        }

        private void profit_ToolStripButton_Click(object sender, EventArgs e)
        {
            DateTime monthStart = DateTime.Now;
            monthStart = new DateTime(monthStart.Year, monthStart.Month, 1);

            Data.Transactions.Utilities.Profit(monthStart, monthStart.AddMonths(1).AddDays(-1));
        }

        private void lastMonthProfilt_ToolStripButton_Click(object sender, EventArgs e)
        {
            DateTime monthStart = DateTime.Now.AddMonths(-1);
            monthStart = new DateTime(monthStart.Year, monthStart.Month, 1);

            Data.Transactions.Utilities.Profit(monthStart, monthStart.AddMonths(1).AddDays(-1));
        }

        private void customProfit_ToolStripButton_Click(object sender, EventArgs e)
        {
            DateTime startDate = DateTime.Now;
            DateTime endDate = DateTime.Now;

            using (AMS.Utilities.Forms.DatePicker f = new AMS.Utilities.Forms.DatePicker("Start Date", startDate))
            {
                f.ShowDialog();
                startDate = f.DateTimeValue;
            }

            using (AMS.Utilities.Forms.DatePicker f = new AMS.Utilities.Forms.DatePicker("End Date", endDate))
            {
                f.ShowDialog();
                endDate = f.DateTimeValue;
            }

            Data.Transactions.Utilities.Profit(startDate, endDate);
        }

        private void filterRange_ToolStripComboBox_Click(object sender, EventArgs e)
        {

        }

        private void transactionGridView1_Load(object sender, EventArgs e)
        {

        }

        private void AllPayable_Button_Click(object sender, EventArgs e)
        {
            // lys al die PurchaseOrders wat gereed is vir payment, 
            //kliente het klaar betaal, 
            //PO mailed status true
            //supplier invoioce reeds linked

            var polist = DMS.TransactionManager.GetDataList(i =>
                i.Type == Data.Transactions.TransactionType.PurchaseOrder &&
                !i.SendtoSupplier && i.TotalDue <= 0.05m &&
                //i.ReceiptAllocationList?.Count > 0 &&
                i.InvoiceList().Where(x => x.TotalDue <= 0.05m).Count() > 0 || i.InvoiceList().Count == 0);

            StringBuilder sb = new StringBuilder();
            decimal amount = 0m;
            decimal receiptAmount = 0m;

            polist.ForEach(po =>
            {
                if (po.ReceiptList() != null && po.ReceiptList().Count == 1)
                {
                    // var transaction = po.InvoiceList()[0];
                    var receipt = po.ReceiptList()[0];

                    sb.AppendLine(receipt.ID + " - " + receipt.Description + " - " + po.GetClientInfo + " - R" + receipt.Amount);
                    receiptAmount += receipt.Amount;
                }

                amount += po.TotalDue;
            });

            AMS.MessageBox_v2.Show($"Amount: {amount}\r\nReceipts: {receiptAmount}\r\n\r\n{sb.ToString()}");
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            switch (splitContainer1.Orientation)
            {
                case Orientation.Horizontal:
                    splitContainer1.Orientation = Orientation.Vertical;
                    splitContainer1.SplitterDistance = (int)splitContainer1.Width / 2;
                    break;

                case Orientation.Vertical:
                    splitContainer1.Orientation = Orientation.Horizontal;
                    splitContainer1.SplitterDistance = (int)splitContainer1.Height / 2;
                    break;
            }
        }
    }
}
