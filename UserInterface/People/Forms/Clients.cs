using AMS.Data.People;
using AMS.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AMS.Suite;
using Data.Transactions;
using Data;
using AMS;

namespace UserInterface.People.Forms
{
    public partial class Clients : Form
    {
        Data.People.Client client;

        public Clients()
        {
            InitializeComponent();
        }

        // Load

        private void Clients_Load(object sender, EventArgs e)
        {
            #region ThemeColors

            ThemeColors.SetControls(this.Controls);

            ThemeColors.SetControls(this.toobar_Panel, ThemeColors.ControlType.MenuBorder);
            ThemeColors.SetControls(splitContainer1, ThemeColors.ControlType.MenuBorder);
            ThemeColors.SetControls(transProd_SplitContainer, ThemeColors.ControlType.MenuBorder);

            panel3.ForeColor = clientEditor.ForeColor;
            panel3.BackColor = clientEditor.BackColor;

            ThemeColors.SetControls(toobar_Panel.Controls);

            #endregion

            if (DMS.ClientManager == null) return;

            clientSelect.UseSearch = false;
            DMS.ClientManager.OnSelect_Enter += ClientSelect_Event;
            DMS.TransactionManager.OnSelect_Enter += ClientSelect_Event;

            if (AMS.Suite.SuiteManager.Preferences.ClientManager.LastAccount != null) DMS.ClientManager.SetCurrent(i => i.Account == AMS.Suite.SuiteManager.Preferences.ClientManager.LastAccount);
            if (Data.DMS.ClientManager.CurrentData != null) client = Data.DMS.ClientManager.CurrentData;
            else client = new Data.People.Client();

            SetControls();
        }

        // Methods

        private void SetControls()
        {
            bool readOnly = DMS.ClientManager.CurrentData != null && DMS.ClientManager.CurrentData.Account != null;
            invoice_Button.Enabled = readOnly;
            quote_Button.Enabled = readOnly;
            product_Button.Enabled = readOnly;
            purchaseOrder_Button.Enabled = DMS.ClientManager.CurrentData != null && DMS.ClientManager.CurrentData.Catagory == "Supplier";

            StringBuilder sb = new StringBuilder();

           if (client.IsVatClient)
            {
                sb.AppendLine($"1 Year Support: {client.GetMMSMaintenanceValue(1) * DMS.VatRateValue:n2} incl.");
                sb.AppendLine($"2 Year Support: {client.GetMMSMaintenanceValue(2) * DMS.VatRateValue:n2} incl.");
            }
            else
            {
                sb.AppendLine($"1 Year Support: {client.GetMMSMaintenanceValue(1):n2} excl.");
                sb.AppendLine($"2 Year Support: {client.GetMMSMaintenanceValue(2):n2} excl.");
            }

            sb.AppendLine();
            if (client.GetMainContact != null) sb.AppendLine($"Main Contact: {client.GetMainContact.DisplayName}    {client.GetMainContact.ContactNumber}");
            if (client.GetAccountant != null) sb.AppendLine($"Accountant: {client.GetAccountant.DisplayName}   {client.GetAccountant.ContactNumber}");
            if (client.GetPurchaseOrderContact != null && client.GetPurchaseOrderContact.DisplayName != "")
                sb.AppendLine($"PO Contact: {client.GetPurchaseOrderContact.DisplayName}   {client.GetPurchaseOrderContact.ContactNumber}");

            clientMaintenanceValue_Label.Text = sb.ToString();
        }

        // Events

        private void ClientSelect_Event(object sender, EventArgs e)
        {
            if (DMS.ClientManager.CurrentData == null || DMS.ClientManager.CurrentData.Account == null) return;
            client = DMS.ClientManager.CurrentData;

            if (DMS.TransactionManager.CurrentData != null && DMS.TransactionManager.CurrentData.ID != null)
                AMS.StatusUpdate.UpdateSelectionTwo(DMS.TransactionManager.CurrentData.Type.ToString(), DMS.TransactionManager.CurrentData.ID);

            clientEditor.SetStatus();
            SuiteManager.Preferences.ClientManager.LastAccount = client.Account;

            SetControls();
        }

        // Tool bar

        private void quickQuote_Button_Click(object sender, EventArgs e)
        {
            try
            {
                var quote_Form = new UserInterface.Quotes.Forms.QuoteForm();
                quote_Form.Show(this);
            }
            catch { };
        }

        private void quote_Button_Click(object sender, EventArgs e)
        {
            try
            {
                if (DMS.ClientManager.CurrentData.Account != null)
                {
                    var qform = new UserInterface.Quotes.Forms.QuoteForm(DMS.ClientManager.CurrentData);
                    qform.Show(this);
                }
            }
            catch (ArgumentException ex) { AMS.MessageBox_v2.Show(ex.Message + "\r\n" + ex.InnerException, MessageType.Error); }
        }

        private void invoice_Button_Click(object sender, EventArgs e)
        {
            try
            {
                if (DMS.ClientManager.CurrentData.Account != null)
                {
                    var trans = new Transaction();
                    trans.SetClient(DMS.ClientManager.CurrentData);
                    trans.Type = TransactionType.Invoice;

                    trans.DueDate = DateTime.Now;
                    trans.TransactionDate = DateTime.Now;
                    using (var tf = new Transactions.Forms.TransactionForm(trans))
                    {
                        tf.ShowDialog();
                    }
                }
            }
            catch (Exception ex) { AMS.MessageBox_v2.Show(ex.Message + "\r\n" + ex.InnerException, MessageType.Error); }
        }

        private void proforma_Button_Click(object sender, EventArgs e)
        {
            try
            {
                if (DMS.ClientManager.CurrentData.Account != null)
                {
                    var trans = new Transaction();
                    trans.SetClient(DMS.ClientManager.CurrentData);
                    trans.Type = TransactionType.Proforma;
                    trans.DueDate = DateTime.Now;
                    trans.TransactionDate = DateTime.Now;
                    using (var tf = new Transactions.Forms.TransactionForm(trans))
                    {
                        tf.ShowDialog();
                    }
                }
            }
            catch (Exception ex) { AMS.MessageBox_v2.Show(ex.Message + "\r\n" + ex.InnerException, MessageType.Error); }
        }

        private void purchaseOrder_Button_Click(object sender, EventArgs e)
        {
            try
            {
                if (DMS.ClientManager.CurrentData.Account != null)
                {
                    var trans = new Transaction();
                    trans.SetClient(DMS.ClientManager.CurrentData);
                    trans.Type = TransactionType.PurchaseOrder;
                    trans.ClientID = DMS.ClientManager.CurrentData.ID;
                    trans.DueDate = DateTime.Now;
                    trans.TransactionDate = DateTime.Now;
                    trans.SupplierId = DMS.ClientManager.CurrentData.ID;
                    using (UserInterface.Transactions.Forms.TransactionForm tf = new UserInterface.Transactions.Forms.TransactionForm(trans))
                    {
                        tf.ShowDialog();
                    }
                }
            }
            catch (Exception ex) { AMS.MessageBox_v2.Show(ex.Message + "\r\n" + ex.InnerException, MessageType.Error); }
        }


        private void product_Button_Click(object sender, EventArgs e)
        {
            if (DMS.ClientManager.CurrentData.Account != null)
            {
                var product = new Data.Products.Product(DMS.ClientManager.CurrentData.Account);
                product.ExpiryDate = client.Expirydate;
                using (UserInterface.Products.Forms.ProductEditor f = new UserInterface.Products.Forms.ProductEditor(product))
                {
                    f.ShowDialog();
                }
            }
        }

        private void Clients_Enter(object sender, EventArgs e)
        {
            transactionList1.SetStatus();
            clientEditor.SetStatus();
            AMS.StatusUpdate.UpdateDataCount(DMS.ClientManager.GetDataList(i => i.Active).Count + " Clients | " + DMS.ProductManager.GetDataList(i => !i.Stolen).Count + " Products");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (UserInterface.Utilities.Forms.CourierLog f = new UserInterface.Utilities.Forms.CourierLog())
                f.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var f = new MMS_Upgrade_Quotes();
            f.ShowDialog();
        }

        private void clientEditor_Load(object sender, EventArgs e)
        {

        }
    }
}