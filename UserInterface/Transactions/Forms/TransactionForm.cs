using AMS;
using AMS.Data.Keys;
using Data;
using Data.Transactions;
using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UserInterface.Transactions.Forms
{
    public partial class TransactionForm : Form
    {
        private Transaction oldTransaction;
        private Transaction transaction;

        public Transaction Transaction { get { return transaction; } }

        private Data.People.Client client = new Data.People.Client();
        private bool saving = false;

        string currentAccount;

        // Constructors

        public TransactionForm(Transaction Transaction)
        {
            InitializeComponent();

            this.transaction = Transaction;
            try
            {
                this.oldTransaction = (Transaction)Transaction.Clone();
            }
            catch (Exception ex)
            {
                AMS.MessageBox_v2.Show(ex.ToString());
                this.Close();
            }
        }

        public TransactionForm(string QuoteID)
        {
            InitializeComponent();

            var quote = DMS.QuoteManager.GetData(i => i.ID == QuoteID);

            this.oldTransaction = (Transaction)quote.Transaction.Clone();
            this.transaction = quote.Transaction;
            this.transaction.LinkedIDList.Add(quote.ID);
            this.transaction.Type = TransactionType.Proforma;
            this.transaction.ID = AMS.Data.Keys.UserPKManager.NewUserPK(AMS.Data.Keys.KeyType.Proforma);
            string id = transaction.ID;
            this.transaction.Save("Transaction " + transaction.ID + " created.", false, true);
            transaction.ID = id; // Workaround for windows memory bug
            quote.LinkedIDList.Add(this.transaction.ID);
            quote.Save("Updating ID List", true, false, quote.ProgressType);
        }

        #region Drop Shadow

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

        #endregion Drop Shadow

        // Load

        private void Transaction_Load(object sender, EventArgs e)
        {
            #region Theme

            ThemeColors.SetControls(this.Controls);
            ThemeColors.SetBorders(this);
            this.BackColor = AMS.ThemeColors.UserControl;

            clientNotes_CheckBox.BackColor = ThemeColors.Menu;
            clientNotes_CheckBox.ForeColor = ThemeColors.MenuText;
            accountant_CheckBox.BackColor = ThemeColors.Menu;
            accountant_CheckBox.ForeColor = ThemeColors.MenuText;
            supplierInfo_checkBox.BackColor = ThemeColors.Menu;
            supplierInfo_checkBox.ForeColor = ThemeColors.MenuText;

            this.footer1.UpdateFooterText("Transaction");

            #endregion Theme

            // Tooltip
            toolTip1.SetToolTip(mail_Button, "Mail " + transaction.Type + " to " + transaction.Email);
            toolTip1.SetToolTip(generate_Button, "Generate Invoice and Purchase Orders");
            toolTip1.SetToolTip(save_Button, "Save " + transaction.Type);
            toolTip1.SetToolTip(close_Button, "Close " + transaction.Type);
            // toolTip1.SetToolTip(clientInfo_CheckBox, "Send the client info instead on a purchase order.");
            toolTip1.SetToolTip(clientNotes_CheckBox, "Add the Client Notes info to a print?");
            toolTip1.SetToolTip(accountant_CheckBox, "Include Accountant in the mail?");

            DMS.TransactionManager.OnSaved_Event += TransactionSaved_Event;

            client = DMS.ClientManager.GetData(i => i.Account == transaction.Account);
            if (client == null) AMS.MessageBox_v2.Show("No Client Associated");

            LoadTransaction();
        }

        // Methods

        private void LoadTransaction()
        {
            if (saving) return;
            // Get info from client
            transaction.ClientNotes = transaction.Client.TransactionNotes;
            if (transaction.Type == TransactionType.PurchaseOrder)
            {
                var client = DMS.ClientManager.GetData(i => i.ID == transaction.ClientID);
                transaction.ClientNotes = client.TransactionNotes;
            }

            transactionHeader1.LoadTransaction(transaction);
            itemListEditor.LoadTransactionItems(transaction);
            transactionFooter1.LoadTransaction(transaction);
            transactionFooter1.Refresh();
            transactionHeader1.Refresh();
            itemListEditor.Refresh();

            save_Button.Enabled = !transaction.IsAudit;
            generate_Button.Enabled = !transaction.IsAudit;
            clientNotes_CheckBox.Checked = transaction.PrintClientNotes;
            accountant_CheckBox.Checked = transaction.IncludeAccountant;
            supplierInfo_checkBox.Checked = transaction.UseSupplierInfo;
            supplierInfo_checkBox.Enabled = transaction.Type == TransactionType.PurchaseOrder;

            SetButtonColors();

            currentAccount = transaction.Account;

            if (!this.Visible) return;
            // Doen goed hier na loaded

            if (transaction?.Client?.Credit < -5 && (transaction?.Type == TransactionType.Invoice || transaction?.Type == TransactionType.Proforma))
            {
                AMS.MessageBox_v2.Show(transaction.Client.Name + "Account: " + transaction.Client.ID + " has " + transaction.Client.Credit + " credit, remember to apply it to next invoice");
            }

        }

        private bool GenerateTransactions()
        {
            AMS.MessageBox_v2.ShowProcess("Please wait");
            AMS.Data.GobalManager.SuspendControls();
            ReportManager.TransactionReport(transaction);

            AMS.MessageBox_v2.EndProcess();

            bool saved = transaction.GenerateTransactions(transaction);

            if (saved)
            {
                AMS.MessageBox_v2.ShowProcess("Please wait\r\nSaving Transaction");

                // Reloading Data, since Generated already saved it, but need to reload the new saved info
                transaction = DMS.TransactionManager.GetData(i => i.ID == transaction.ID);
                transaction.IsFinalized = true;
                transaction.Save("Finalized", true, true);
                this.Close();
                AMS.MessageBox_v2.EndProcess();
                int nr = 0;
                foreach (var po in transaction.PurchaseOrderList())
                {
                    nr++;
                    AMS.MessageBox_v2.ShowProcess("Please confirm that the generated Purchase Order has correct data", nr, transaction.PurchaseOrderList().Count);
                    System.Threading.Thread.Sleep(1000);
                    AMS.MessageBox_v2.EndProcess();
                    using (TransactionForm f = new TransactionForm(po))
                        f.ShowDialog();
                }
            }

            AMS.MessageBox_v2.EndProcess();
            AMS.Data.GobalManager.ResumeControls();

            DMS.ClientManager.SetCurrent(i => i.Account == transaction.Account);

            return saved;
        }

        private void SetButtonColors()
        {
            bool colorSave = transaction.Type == TransactionType.Proforma;
            bool colorMail = (transaction.Metadata.EmailDate < new DateTime(1900, 1, 1)); ;
            bool colorGenerate = transaction.Type == TransactionType.Proforma;
            bool colorClose = transaction.Type != TransactionType.Proforma;

            if (colorSave) ThemeColors.SetControls(save_Button, ThemeColors.ControlType.Primary);
            else ThemeColors.SetControls(save_Button, ThemeColors.ControlType.Menu);

            if (colorMail) ThemeColors.SetControls(mail_Button, ThemeColors.ControlType.Primary);
            else ThemeColors.SetControls(mail_Button, ThemeColors.ControlType.Menu);

            if (colorGenerate) ThemeColors.SetControls(generate_Button, ThemeColors.ControlType.Primary);
            else ThemeColors.SetControls(generate_Button, ThemeColors.ControlType.Menu);

            if (colorClose) ThemeColors.SetControls(close_Button, ThemeColors.ControlType.Primary);
            else ThemeColors.SetControls(close_Button, ThemeColors.ControlType.Menu);

            if (transaction.PurchaseOrderList().Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var i in transaction.PurchaseOrderList())
                    sb.AppendLine(i.ID + " - " + i.Total + " - " + i.Client.Name + " - " + i.GetTransactionDate);

                toolTip1.SetToolTip(generate_Button, sb.ToString());
                generate_Button.Enabled = false;
            }

            ThemeColors.SetControls(saveAndClose_Button, ThemeColors.ControlType.Menu);
        }

        private void Save()
        {
            if (transaction.Type == TransactionType.PurchaseOrder && string.IsNullOrEmpty(transaction.MMSOrderPaymentTerms))
            {
                MessageBox_v2.MessageValue = "COD";
                var msg = AMS.MessageBox_v2.Show("Verify Payment Terms?", MessageType.QuestionInput);
                if (msg == MessageOut.Cancel)
                {
                    MessageBox_v2.MessageValue = null;
                    return;
                }
                transaction.MMSOrderPaymentTerms = MessageBox_v2.MessageValue;
                MessageBox_v2.MessageValue = null;
            }


            try
            {
                itemListEditor.Validate();
            }
            catch (Exception ex)
            {
                AMS.MessageBox_v2.Show(ex.Message, AMS.MessageType.Error);
            }

            saving = true;

            transactionFooter1.GetTotals();
            transaction.IncludeAccountant = accountant_CheckBox.Checked;
            transaction.UseSupplierInfo = supplierInfo_checkBox.Checked;
            transaction.PrintClientNotes = clientNotes_CheckBox.Checked;

            if (transaction.Type == TransactionType.Invoice && string.IsNullOrEmpty(transaction.ID))
            {
                if (AMS.MessageBox_v2.Show("A new Invoice Number will be added to this invoice.\r\nWould you like to proceed?", AMS.MessageType.Question) == AMS.MessageOut.YesOk)
                {
                    transaction.ID = AMS.Data.Keys.UserPKManager.NewUserPK(KeyType.Invoice);
                }


                transaction.Save("Added '" + transaction.Type + "' " + transaction.ID, false, true);
            }
            else
            {
                transaction.Save("Saved '" + transaction.Type + "' " + transaction.ID, true, false);
            }

            if (string.IsNullOrEmpty(currentAccount)) currentAccount = transaction.Account; // If new 

            if (currentAccount.Trim().ToLower() != transaction.Account.Trim().ToLower())
            {
                StringBuilder sb = new StringBuilder();

                foreach (var ra in transaction.ReceiptAllocationList)
                {
                    var receipt = DMS.AccountsManager.ReceiptList.Where(i => i.ID == ra.ReceiptID).FirstOrDefault();
                    if (receipt != null)
                    {
                        receipt.Account = transaction.Account;
                        sb.AppendLine(receipt.ID);
                    }
                }

                AMS.MessageBox_v2.Show("NEW CODE, PLEASE CHECK!\r\nReceipts' account number should have updated too.\r\n" + sb.ToString(), MessageType.Warning);

                DMS.AccountsManager.SaveReceipts();

                currentAccount = transaction.Account;
            }

            saving = false;
        }

        private bool CheckPO()
        {
            bool canSave = true;

            if (transaction.Type == TransactionType.PurchaseOrder)
            {
                var noSupplierDiscounts = (from i in transaction.ItemList
                                           where i.Discount == 0
                                           select i).ToList();

                StringBuilder noSupplierProductList = new StringBuilder();

                foreach (var i in noSupplierDiscounts)
                {
                    noSupplierProductList.AppendLine(i.Description + " - " + i.ItemTotal);
                }

                if (noSupplierDiscounts.Count > 0)
                    if (AMS.MessageBox_v2.Show("The following items does not have any Supplier discount associated to.\r\n\r\n" + noSupplierProductList.ToString() + "\r\n\r\nWould you like to continue?", AMS.MessageType.Warning) != AMS.MessageOut.YesOk)
                        canSave = false;
            }

            return canSave;
        }

        // Events

        internal void UpdateTransaction(object sender, EventArgs e)
        {
            LoadTransaction();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.transaction = oldTransaction;
            this.Close();
        }

        private void Save_Click(object sender, EventArgs e)
        {

            if (!CheckPO()) return;
            save_Button.Enabled = false;
            Save();
            save_Button.Enabled = true;
        }

        private void Mail_Click(object sender, EventArgs e)
        {
            try
            {
                if (transaction.Email == null || transaction.Email.Trim() == "" || transaction.Contact == null || transaction.Contact.Trim() == "")
                {
                    AMS.MessageBox_v2.Show("Please enter a contact and an email address before sending the mail.");
                    return;
                }

                if (!CheckPO()) return;

                Save();
            }
            catch (Exception ex)
            {
                MessageBox_v2.Show("Could not save before mailing.\r\n" + ex.ToString());
                return;
            }

            try
            {
                if (transaction.Type == TransactionType.PurchaseOrder)
                {
                    transaction.UseSupplierInfo = supplierInfo_checkBox.Checked;
                    transaction.PrintClientNotes = clientNotes_CheckBox.Checked;
                }

                if (ReportManager.TransactionReport(transaction))
                {
                    if (transaction.Type == TransactionType.Invoice && transaction.POGenerated.Contains("missing"))

                        try
                        {
                            GenerateTransactions();
                        }
                        catch (Exception ex) { MessageBox_v2.Show("Something went wrong with the report\r\n" + ex.ToString()); }
                    this.Close();
                }
            }
            catch (Exception ex) { MessageBox_v2.Show("Could not create the report\r\n" + ex.ToString()); }
        }


        private void TransactionSaved_Event(object sender, EventArgs e)
        {
            oldTransaction = (Transaction)transaction.Clone();
            this.BackColor = AMS.ThemeColors.UserControl;

            LoadTransaction();
        }

        private void Generate_Click(object sender, EventArgs e)
        {
            generate_Button.Enabled = false;
            generate_Button.Visible = false;

            if (transaction.Type == TransactionType.Invoice && string.IsNullOrEmpty(transaction.ID))
            {
                Save();
            }

            if (transaction.Type == TransactionType.Proforma && string.IsNullOrEmpty(transaction.ID))
            {
                Save();
            }
            try
            {
                GenerateTransactions();
            }
            catch (Exception ex) { MessageBox_v2.Show("Something went wrong with the report\r\n" + ex.ToString()); }

            generate_Button.Visible = true;
            generate_Button.Enabled = true;
        }

        private void preview_Button_Click(object sender, EventArgs e)
        {
            transactionFooter1.GetTotals();
            var reportTransaction = (Transaction)transaction.Clone();

            if (reportTransaction.Type == TransactionType.PurchaseOrder)
            {
                reportTransaction.Contact = "";
                reportTransaction.Email = "";
                reportTransaction.PrintClientNotes = clientNotes_CheckBox.Checked;
                reportTransaction.UseSupplierInfo = supplierInfo_checkBox.Checked;
            }

            if (ReportManager.TransactionReport(transaction))
                this.Close();
        }

        private void TransactionForm_Shown(object sender, EventArgs e)
        {
            SetButtonColors();
        }

        private void saveAndClose_Button_Click(object sender, EventArgs e)
        {
            if (!CheckPO()) return;
            saveAndClose_Button.Enabled = false;
            Save();
            saveAndClose_Button.Enabled = true;
            this.Close();
        }

        private void convertToZAR_Click(object sender, EventArgs e)
        {
            try
            {
                var msg = AMS.MessageBox_v2.Show("What is the total ZAR amount?", transaction.Total.ToString());
                if (msg == MessageOut.YesOk)
                {
                    transaction.Currency = "ZAR";
                    var ZARamount = Convert.ToDecimal(AMS.MessageBox_v2.MessageValue);

                    decimal factor = (decimal)ZARamount / transaction.Total;

                    foreach (var i in transaction.ItemList)
                        i.PriceExVat = i.PriceExVat * factor;

                    LoadTransaction();
                }
            }
            catch (Exception ex) { AMS.MessageBox_v2.Show(ex.Message); }
        }

        private void supplierInfo_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}