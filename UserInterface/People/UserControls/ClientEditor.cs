using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using AMS;
using AMS.Data.Keys;
using Data.People;
using Data;
using System.Text.RegularExpressions;
using UserInterface.Common;

namespace UserInterface.People.UserControls
{
    public partial class ClientEditor : UserControl
    {
        public event Action<string, string> ClientSaved; // (account, displayName)
        AMS.EditMode editMode;
        Client client;
        Client oldClient;

        // Contractors

        public ClientEditor()
        {
            InitializeComponent();
        }

        // ChatGPT: rationale — allow parent to know when edit mode toggles,
        // without changing existing behavior or signatures.
        public event EventHandler EditModeChanged; // ChatGPT: fired whenever CheckEditMode updates

        // ChatGPT: rationale — simple way for parent to query current state.
        public bool IsEditing
        {
            get { return editMode == AMS.EditMode.Edit || editMode == AMS.EditMode.New; }
        }

        // ChatGPT: rationale — standard event invoker (no exception text changes).
        private void OnEditModeChanged()
        {
            var handler = EditModeChanged; // ChatGPT: copy to local to avoid race
            if (handler != null) handler(this, EventArgs.Empty);
        }


        // Load

        private void Client_Info_Load(object sender, EventArgs e)
        {
            #region Theme

            ThemeColors.SetControls(this.Controls);
            this.BackColor = ThemeColors.WorkSpace;
            this.panel1.BackColor = ThemeColors.Menu;
            this.panel2.BackColor = ThemeColors.Menu;

            foreach (Control c in this.Controls)
            {
                if (c.GetType() == typeof(TextBox)) c.BackColor = this.BackColor;
                if (c.GetType() == typeof(TextBox)) ((TextBox)c).ReadOnly = true;
                if (c.GetType() == typeof(Label)) c.ForeColor = ThemeColors.ControlText;
            }

            ThemeColors.SetControls(this.nameTextBox, ThemeColors.ControlType.Menu);

            #endregion

            if (Data.DMS.ClientManager == null || AMS.Suite.SuiteManager.Profile == null) return;

            editMode = new AMS.EditMode();
            CheckEditMode(AMS.EditMode.Normal);

            Data.DMS.ClientManager.OnSelect_Enter += SelectClient_Event;
            Data.DMS.ClientManager.OnSaved_Event += SelectClient_Event;

            catagoryComboBox.DataSource = AMS.Suite.SuiteManager.Profile.ClientCatagoryList;
            //currencyUsedComboBox.DataSource = AMS.Suite.SuiteManager.Profile.ForexList;
            currencyUsedComboBox.Items.Add("");
            currencyUsedComboBox.Items.AddRange(AMS.Suite.SuiteManager.Profile.ForexList.ToArray());

            email_LinkLabel.Visible = true;
            emailTextBox.Visible = false;
        }

        // Methods

        private void SelectCurrentClient()
        {
            client = (Client)Data.DMS.ClientManager.CurrentData.Clone();
            clientBindingSource.DataSource = client;
            MaintStatus_Label.Text = client.MaintenanceSummary();

            SetColors();
        }

        private void CheckEditMode(AMS.EditMode editMode)
        {
            this.editMode = editMode;
            OnEditModeChanged(); // ChatGPT: rationale — notify listeners of state change.
            
            switch (editMode)
            {
                case AMS.EditMode.New:
                    EditModeNew();
                    nameTextBox.Select();
                    break;

                case AMS.EditMode.Edit:
                    EditMode_Edit();
                    nameTextBox.Select();
                    oldClient = (Client)client.Clone();
                    break;

                case AMS.EditMode.Normal:
                    EditMode_Normal();
                    editCancel_Button.Select();
                    SetColors();
                    break;
            }
        }

        private void EditMode_Normal()
        {
            foreach (Control c in this.Controls)
            {
                if (c.GetType() == typeof(TextBox)) c.BackColor = this.BackColor;
                if (c.GetType() == typeof(TextBox)) ((TextBox)c).ReadOnly = true;
            }

            nameTextBox.BackColor = ThemeColors.Menu;
            panel1.BackColor = ThemeColors.Menu;
            panel2.BackColor = ThemeColors.Menu;
            addSave_Button.BackColor = ThemeColors.Menu;
            editCancel_Button.BackColor = ThemeColors.Menu;
            extra_Button.BackColor = ThemeColors.Menu;

            addSave_Button.Text = "Add";
            editCancel_Button.Text = "Edit";

            removeMaint_Button.Visible = false;
            vendorRenewal_CheckBox.Visible = false;
            email_LinkLabel.Visible = true;
            emailTextBox.Visible = false;
        }

        private void EditMode_Edit()
        {
            foreach (Control c in this.Controls)
            {
                if (c.GetType() == typeof(TextBox)) c.BackColor = ThemeColors.InputControl;
                if (c.GetType() == typeof(TextBox)) ((TextBox)c).ReadOnly = false;
            }

            nameTextBox.BackColor = ThemeColors.Blue;
            panel1.BackColor = ThemeColors.Blue;
            panel2.BackColor = ThemeColors.Blue;
            addSave_Button.BackColor = ThemeColors.Blue;
            editCancel_Button.BackColor = ThemeColors.Blue;
            extra_Button.BackColor = ThemeColors.Blue;

            addSave_Button.Text = "Save";
            editCancel_Button.Text = "Cancel";

            expiry_Panel.Visible = true;
            removeMaint_Button.Visible = true;
            vendorRenewal_CheckBox.Visible = true;
            email_LinkLabel.Visible = false;
            emailTextBox.Visible = true;
        }

        private void EditModeNew()
        {
            foreach (Control c in this.Controls)
            {
                if (c.GetType() == typeof(TextBox)) c.BackColor = ThemeColors.InputControl;
                if (c.GetType() == typeof(TextBox)) ((TextBox)c).ReadOnly = false;
            }

            nameTextBox.BackColor = ThemeColors.Green;
            panel1.BackColor = ThemeColors.Green;
            panel2.BackColor = ThemeColors.Green;
            addSave_Button.BackColor = ThemeColors.Green;
            editCancel_Button.BackColor = ThemeColors.Green;
            extra_Button.BackColor = ThemeColors.Green;

            addSave_Button.Text = "Save";
            editCancel_Button.Text = "Cancel";

            expiry_Panel.Visible = true;
            email_LinkLabel.Visible = false;
            emailTextBox.Visible = true;
            
        }

        private void SetColors()
        {
            if (client == null) return;

            expiry_Panel.BackColor = this.BackColor;

            if (client.Expirydate < new DateTime(1900, 1, 1)) expiry_Panel.Visible = false;
            else expiry_Panel.Visible = true;

            if (client.HasSupport) expiry_Panel.BackColor = AMS.ThemeColors.Green;
            if (client.Expirydate < DateTime.Now) expiry_Panel.BackColor = AMS.ThemeColors.Blue;
            if (client.Expirydate < DateTime.Now.AddMonths(-1)) expiry_Panel.BackColor = AMS.ThemeColors.Orange;
            if (!client.HasSupport && client.Expirydate < DateTime.Now.AddMonths(-3)) expiry_Panel.BackColor = AMS.ThemeColors.Red;

            if (client != null && !client.Active)
            {
                nameTextBox.BackColor = ThemeColors.Red;
                nameTextBox.ForeColor = Color.White;
            }
            else
            {
                nameTextBox.BackColor = ThemeColors.Menu;
                nameTextBox.ForeColor = ThemeColors.MenuText;
            }

            if (MaintStatus_Label.Text.Contains("Fully Covered"))
            {
                MaintStatus_Label.BackColor = ThemeColors.Green;
                MaintStatus_Label.ForeColor = Color.White;
            }
            else
            {
                MaintStatus_Label.BackColor = ThemeColors.Orange;
                MaintStatus_Label.ForeColor = Color.White;
            }

            if (string.IsNullOrEmpty(MaintStatus_Label.Text))
            {
                MaintStatus_Label.BackColor = Color.Transparent;
                MaintStatus_Label.ForeColor = Color.Transparent;
            }
        }

        public void SetStatus()
        {
            if (client?.Name != null) AMS.StatusUpdate.UpdateSelectionOne("Client", client.Name);
        }

        private void Save()
        {
            string message = "";
            bool updateRecords = false;

            #region Save New Client

            if (editMode == EditMode.New)
            {
                message = "Add new Client?";
                client.AddDataLog("Client", "Client was Added.", AMS.Data.DataType.Client);
            }

            #endregion

            #region Save Existing Client

            if (editMode == EditMode.Edit)
            {
                message = "Client details was updated.";

                if (client.Account != oldClient.Account)
                    if (AMS.MessageBox_v2.Show("Are you sure you want to change the client's account number?\r\nAll current records will update to new account", AMS.MessageType.Question) == AMS.MessageOut.YesOk)
                        updateRecords = true;
                    else
                        return;

                if (client.Active != oldClient.Active)
                    client.AddDataLog("Client", "Client active set to '" + client.Active + "'", AMS.Data.DataType.Client);

                if (client.Expirydate != oldClient.Expirydate)
                {
                    string msg = string.Format("Client Maintenance changed from {0:dd MMM yyyy} to {1:dd MMM yyyy}", oldClient.Expirydate, client.Expirydate);

                    if (AMS.MessageBox_v2.Show("Would you like to update current products as well?\r\n\r\nIt is possible to update selected products using the Product Controls.", AMS.MessageType.Question) == AMS.MessageOut.YesOk)
                    {
                        var productList = DMS.ProductManager.GetDataList(i => i.Account == oldClient.Account);
                        foreach (var i in productList)
                        {
                            if (string.Format("{0:MMM yyyy}", i.ExpiryDate) == string.Format("{0:MMM yyyy}", oldClient.Expirydate))
                            {
                                i.ExpiryDate = client.Expirydate;
                                i.Save(msg, true, true);
                            }
                        }
                    }

                    client.AddDataLog("Client", msg, AMS.Data.DataType.Client);
                }
            }

            #endregion

            AMS.Data.GobalManager.SuspendControls();

            bool saved = client.Save(message, false, false);

            if (editMode == EditMode.New && saved)
            {
                using (Forms.Select_People f = new Forms.Select_People(client.PeopleIDList))
                {
                    f.ShowDialog();
                    client.PeopleIDList = f.PeopleIDList;
                    client.Save(null, true, false);
                }
            }

            #region Update Account Records

            if (saved && updateRecords)
            {
                AMS.MessageBox_v2.ShowProcess("Updating Account Number");

                var transList = DMS.TransactionManager.GetDataList(i => i.Account == oldClient.Account);
                var qouteList = DMS.QuoteManager.GetDataList(i => i.Account == oldClient.Account);
                var productList = DMS.ProductManager.GetDataList(i => i.Account == oldClient.Account);
                var suppliedProductList = DMS.ProductManager.GetDataList(i => i.SupplierID == oldClient.Account);
                var receiptList = DMS.AccountsManager.ReceiptList.Where(i => i.Account == oldClient.Account);
                var catalogList = DMS.CatalogManager.GetDataList();

                int nr = 0;
                foreach (var i in transList)
                {
                    nr++;
                    AMS.MessageBox_v2.ShowProcess("Updating " + transList.Count + " Account Number\r\nTransaction: " + i.ID, nr, transList.Count);

                    i.Account = client.Account;
                    i.Save("Account changed from " + oldClient.Account + " to " + client.Account, true, true);
                }

                nr = 0;
                foreach (var i in receiptList)
                {
                    nr++;
                    AMS.MessageBox_v2.ShowProcess("Updating " + transList.Count + " Account Number\r\nReceipt: " + i.ID, nr, receiptList.Count());
                    i.Account = client.Account;
                }
                DMS.AccountsManager.SaveReceipts();

                nr = 0;
                foreach (var i in qouteList)
                {
                    nr++;
                    AMS.MessageBox_v2.ShowProcess("Updating " + qouteList.Count + " Account Number\r\nQuote: " + i.ID, nr, qouteList.Count);

                    i.Account = client.Account;
                    i.Save("Account changed from " + oldClient.Account + " to " + client.Account, true, true, i.ProgressType);
                }

                nr = 0;
                foreach (var i in productList)
                {
                    nr++;
                    AMS.MessageBox_v2.ShowProcess("Updating " + productList.Count + " Account Number\r\nProduct: " + i.ID, nr, productList.Count);

                    i.Account = client.Account;
                    i.Save("Account changed from " + oldClient.Account + " to " + client.Account, true, true);
                }

                if (client.Catagory == "Supplier" && suppliedProductList.Count > 0)
                {
                    AMS.MessageBox_v2.Show("Warning. This supplier has supplied " + suppliedProductList.Count + " products\r\nPlease wait while all the products are being updated");
                    nr = 0;
                    foreach (var i in suppliedProductList)
                    {
                        nr++;
                        AMS.MessageBox_v2.ShowProcess("Updating " + suppliedProductList.Count + " Account Number\r\nSupplied Products: " + i.ID, nr, suppliedProductList.Count);
                        i.SupplierID = client.Account;
                        i.Save("Supplier changed from " + oldClient.Account + " to " + client.Account, true, true);
                    }
                }

                nr = 0;
                foreach (var i in catalogList)
                {
                    nr++;
                    AMS.MessageBox_v2.ShowProcess("Updating Catalog Supplier ID Number\r\nCatalog: " + i.Name, nr, catalogList.Count);
                    foreach (var item in i.ItemList)
                    {
                        if (item.SupplierID == oldClient.Account)
                        {
                            item.SupplierID = client.Account;
                        }
                    }
                    i.DefaultSupplierID = client.Account;
                    i.Save(true);
                }

                AMS.MessageBox_v2.EndProcess();
            }

            #endregion
            AMS.Data.GobalManager.ResumeControls();

            if (saved) Data.DMS.ClientManager.SetCurrent(i => i.Account == client.Account);
            if (saved) CheckEditMode(AMS.EditMode.Normal);            if (saved)
            {
                var handler = ClientSaved;
                if (handler != null) handler(client.Account, client.Name);
            }

        }

        private string CapitalizeWordsExcept(string input, List<string> lowercaseExceptions)
        {
            // Define a regular expression pattern to match words
            string pattern = @"\b\w+\b";

            // Use a MatchEvaluator to customize the replacement logic
            string result = Regex.Replace(input, pattern, match =>
            {
                string word = match.Value.ToLower();

                // Check if the word is in the list of lowercase exceptions
                if (lowercaseExceptions.Contains(word))
                {
                    return word; // Keep the word in lowercase
                }

                // Capitalize the first letter of each word
                return char.ToUpper(word[0]) + word.Substring(1);
            });

            return result;
        }

        private List<string> lowercaseWords = new List<string> { "du", "of", "and", "the", "in", "van", "der", "den", /* Add more words if needed */ };

        // Events

        private void SelectClient_Event(object sender, EventArgs e)
        {
            SelectCurrentClient();
            SetStatus();
        }

        private void AddSaveClient_Click(object sender, EventArgs e)
        {
            #region Add New Client

            if (editMode == AMS.EditMode.Normal)
            {
                CheckEditMode(EditMode.New);

                client = new Client
                {
                    Active = true,
                    CurrencyUsed = "ZAR",
                    Account = UserPKManager.NewUserPK(KeyType.Account)
                };
                clientBindingSource.DataSource = client;

                return;
            }

            #endregion

            if (editMode == AMS.EditMode.New || editMode == AMS.EditMode.Edit)
            {
                Save();
                return;
            }
        }

        private void EditCancelClient_Click(object sender, EventArgs e)
        {
            if (editMode == AMS.EditMode.Normal)
            {
                CheckEditMode(AMS.EditMode.Edit);
                return;
            }

            if (editMode == AMS.EditMode.Edit || editMode == AMS.EditMode.New)
            {
                CheckEditMode(AMS.EditMode.Normal);

                if (oldClient == null) oldClient = new Client();
                client = (Client)oldClient.Clone();
                clientBindingSource.DataSource = client;

                return;
            }
        }

        private void extra_Button_Click(object sender, EventArgs e)
        {
            using (Forms.ClientExtra cm = new Forms.ClientExtra(client))
                cm.ShowDialog();
        }

        private void removeMaint_Button_Click(object sender, EventArgs e)
        {
            if (AMS.MessageBox_v2.Show("Are you sure you want to remove this client's maintenance record?", AMS.MessageType.Question) == AMS.MessageOut.YesOk)
            {
                client.Expirydate = new DateTime();
            }
        }

        private void email_LinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DMS.MailManager.SendGeneralMail(client.Account, client.Name, email_LinkLabel.Text);
        }

        private void postalAddressLabel_MouseClick(object sender, MouseEventArgs e)
        {
            string mailingLable = client.Name + "\r\n" +
                client.PostalAddress + "\r\n" +
                "Att: " + client.GetMainContact.FirstName + " " + client.GetMainContact.LastName + "\r\n" +
                "Email: " + client.GetMainContact.Email + "\r\n" +
                "Tel: " + client.GetMainContact.ContactNumber;

            System.Windows.Forms.Clipboard.SetText(mailingLable);

            AMS.MessageBox_v2.Show("The following info was copied to the Clipboard:" + "\r\n" + mailingLable);
        }

        private void physicalAddressLabel_MouseClick(object sender, MouseEventArgs e)
        {
            string mailingLable = client.Name + "\r\n" +
                client.PhysicalAddress + "\r\n" +
                "Att: " + client.GetMainContact.FirstName + " " + client.GetMainContact.LastName + "\r\n" +
                "Email: " + client.GetMainContact.Email + "\r\n" +
                "Tel: " + client.GetMainContact.ContactNumber;

            System.Windows.Forms.Clipboard.SetText(mailingLable);

            AMS.MessageBox_v2.Show("The following info was copied to the Clipboard:" + "\r\n" + mailingLable);
        }

        private void vatNrTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void physicalAddressTextBox_TextChanged(object sender, EventArgs e)
        {
            // Change text case using regular expression
            physicalAddressTextBox.Text = CapitalizeWordsExcept(physicalAddressTextBox.Text, lowercaseWords);
        }

        private void physicalAddressTextBox_Leave(object sender, EventArgs e)
        {
            // Change text case when the textbox loses focus
            physicalAddressTextBox.Text = CapitalizeWordsExcept(physicalAddressTextBox.Text, lowercaseWords);
        }

        private void postalAddressTextBox_TextChanged(object sender, EventArgs e)
        {
            // Change text case using regular expression
            postalAddressTextBox.Text = CapitalizeWordsExcept(postalAddressTextBox.Text, lowercaseWords);
        }

        private void postalAddressTextBox_Leave(object sender, EventArgs e)
        {
            // Change text case when the textbox loses focus
            postalAddressTextBox.Text = CapitalizeWordsExcept(postalAddressTextBox.Text, lowercaseWords);
        }

        private void nameTextBox_Leave(object sender, EventArgs e)
        {
            string raw = nameTextBox.Text?.Trim();

            if (string.IsNullOrEmpty(raw))
                return;

            // Reload latest rules from TextCaseLibrary.Data
            UserInterface.Common.TextCaseHelper.ReloadRules();

            // Step 1: Remove periods (a.b.c → abc)
            raw = raw.Replace(".", "");

            // Step 2: Tokenize and uppercase 3-letter words if NOT in override rules
            var tokens = raw.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < tokens.Length; i++)
            {
                string t = tokens[i];
                string lowered = t.ToLowerInvariant();

                bool isLetters = t.All(char.IsLetter);
                bool isShort = t.Length <= 3;

                // Only capitalize if not in override list
                if (isLetters && isShort && !TextCaseHelper.HasOverride(lowered))
                {
                    tokens[i] = t.ToUpperInvariant();
                }
            }

            // Step 3: Reassemble and apply smart casing (final override layer)
            string rejoined = string.Join(" ", tokens);
            string formatted = TextCaseHelper.ApplySmartTitleCase(rejoined);

            // Update textbox only if changed
            if (!string.Equals(nameTextBox.Text, formatted, StringComparison.Ordinal))
            {
                nameTextBox.Text = formatted;
            }

            // Assign to your model
            client.Name = formatted;
            clientBindingSource.ResetBindings(false);
        }

    }
}
