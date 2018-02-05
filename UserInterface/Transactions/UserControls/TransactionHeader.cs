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
using AMS.Data.Keys;
using AMS.Data.People;
using Data.Transactions;
using Data;

namespace UserInterface.Transactions.UserControls
{
    public partial class TransactionHeader : UserControl
    {
        bool loading;

        private Transaction oldTransaction;
        private Transaction transaction;
        public Transaction Transaction
        {
            get { return transaction; }
        }

        public TransactionHeader()
        {
            InitializeComponent();

            oldTransaction = new Transaction();
            transaction = new Transaction();
        }

        private void TransactionHeader_Load(object sender, EventArgs e)
        {
            if (DMS.TransactionManager == null || DMS.ClientManager == null) return;

            #region ThemeColors

            SetColors();

            #endregion

            transaction_BindingSource.DataSource = transaction;
            LoadTransaction();
        }

        // Methods

        public void LoadTransaction(Transaction Transaction)
        {
            transaction = Transaction;
            oldTransaction = (Transaction)Transaction.Clone();
            LoadTransaction();
        }

        private void LoadTransaction()
        {
            loading = true;

            // Get Client Info and set contacts
            if (transaction.Account == null) transaction.Account = DMS.ClientManager.CurrentData.Account;
            if (transaction.Client == null || transaction.Client.Account == null) return;
            SetContactList();

            // Set Data
            if (transaction.Contact == null && transaction.Client != null && transaction.Client.GetMainContact != null)
            {
                transaction.Contact = transaction.Client.GetMainContact.DisplayName;
                transaction.Email = transaction.Client.GetMainContact.Email;
            }

            contact_ComboBox.Text = transaction.Contact;
            email_TextBox.Text = transaction.Email;
            telephone_TextBox.Text = transaction.ContactNr;

            date_Label.Text = string.Format("{0:dd MMMM yyyy}", transaction.TransactionDate);
            due_Label.Text = string.Format("{0:dd MMMM yyyy}", transaction.DueDate);
            paid_CheckBox.Checked = transaction.IsPaid();
            audit_CheckBox.Checked = transaction.IsAudit;
            useVatCheckBox.Checked = transaction.UseVat;
            void_CheckBox.Checked = transaction.IsVoid;
            transactionNrTextBox.Text = transaction.ID;
            payementTerms_Label.Text = transaction.PaymentTerms;
            account_TextBox.Text = transaction.Account;

            transaction_BindingSource.DataSource = transaction;

            afr_checkBox.Checked = transaction.Client.LanguageAfr;

            SetColors();

            loading = false;

            this.Refresh();
        }

        private void SetColors()
        {
            if (this.Parent == null) return;

            ThemeColors.SetControls(this.Controls);
            this.BackColor = SystemColors.Control;

            if (transaction.Type == TransactionType.Proforma) transactionNrTextBox.BackColor = ThemeColors.Orange;
            if (transaction.Type == TransactionType.Invoice) transactionNrTextBox.BackColor = ThemeColors.Green;
            if (transaction.Type == TransactionType.PurchaseOrder) transactionNrTextBox.BackColor = ThemeColors.Blue;
            if (transaction.Type == TransactionType.CancellationOrder) transactionNrTextBox.BackColor = ThemeColors.Red;
            if (transaction.Type == TransactionType.CreditNote) transactionNrTextBox.BackColor = ThemeColors.Yellow;
            transactionNrTextBox.ForeColor = Color.White;

            paid_CheckBox.Enabled = !(transaction.Type == TransactionType.Proforma);
            void_CheckBox.Enabled = !(transaction.Type == TransactionType.Proforma);
            audit_CheckBox.Enabled = !(transaction.Type == TransactionType.Proforma);

            panel1.BackColor = ThemeColors.MenuText;
            panel2.BackColor = ThemeColors.MenuText;
            panel3.BackColor = ThemeColors.MenuText;

            label2.ForeColor = ThemeColors.SubText;
            label3.ForeColor = ThemeColors.SubText;
            label4.ForeColor = ThemeColors.SubText;
            label5.ForeColor = ThemeColors.SubText;
            label6.ForeColor = ThemeColors.SubText;
            label7.ForeColor = ThemeColors.SubText;
            label9.ForeColor = ThemeColors.SubText;

            account_TextBox.BackColor = this.BackColor;
            vat_TextBox.BackColor = this.BackColor;
            telephone_TextBox.BackColor = this.BackColor;
            type_TextBox.BackColor = this.BackColor;
            currency_TextBox.BackColor = this.BackColor;

            if (//(oldTransaction.Account != transaction.Account) ||
                (oldTransaction.ClientRef != transaction.ClientRef) //||
                                                                    //(oldTransaction.Contact != transaction.Contact) ||
                                                                    //(oldTransaction.ContactNr != transaction.ContactNr) ||
                                                                    //(oldTransaction.CreationDate != transaction.CreationDate) ||
                                                                    //(oldTransaction.Currency != transaction.Currency) ||
                                                                    //(oldTransaction.Email != transaction.Email) ||
                                                                    //(oldTransaction.Forex != transaction.Forex) ||
                                                                    //(oldTransaction.ID != transaction.ID) ||
                                                                    //(oldTransaction.IsAudit != transaction.IsAudit) ||
                                                                    //(oldTransaction.IsCreditNote != transaction.IsCreditNote) ||
                                                                    //(oldTransaction.IsPaid != transaction.IsPaid) ||
                                                                    //(oldTransaction.IsVoid != transaction.IsVoid) ||
                                                                    //(oldTransaction.Notes != transaction.Notes) ||
                                                                    //(oldTransaction.PaymentDate != transaction.PaymentDate) ||
                                                                    //(oldTransaction.PaymentTerms != transaction.PaymentTerms) ||
                                                                    //(oldTransaction.SetupFileVersion != transaction.SetupFileVersion) ||
                                                                    //(oldTransaction.SpecialNote != transaction.SpecialNote) ||
                                                                    //(oldTransaction.SubTotal != transaction.SubTotal) ||
                                                                    //(oldTransaction.SupplierId != transaction.SupplierId) ||
                                                                    //(oldTransaction.Terms != transaction.Terms) ||
                                                                    //(oldTransaction.TotalDue != transaction.TotalDue) ||
                                                                    //(oldTransaction.Type != transaction.Type) ||
                                                                    //(oldTransaction.UseVat != transaction.UseVat) ||
                                                                    //(oldTransaction.Value != transaction.Value)
                )
            {
                Parent.BackColor = ThemeColors.Red;
            }
            else
            {
                Parent.BackColor = this.BackColor;
            }
        }

        private void SetContactList()
        {
            if (transaction.Client == null || transaction.Client.Account == null) return;

            contact_ComboBox.Items.Clear();

            // Add Client Name
            contact_ComboBox.Items.Add(transaction.Client.Name);

            // Add associated people
            foreach (var p in DMS.PeopleManager.GetDataList())
                if (transaction.Client.PeopleIDList != null && transaction.Client.PeopleIDList.Contains(p.ID))
                    contact_ComboBox.Items.Add(p.DisplayName);
        }

        private void UpdateContactInfo()
        {
            if (transaction.Client == null)
            {
                transaction.Email = "";
                transaction.Contact = "";

                return;
            }
            // Look into Client's contact list 1st for relative info
            //if (transaction.Client == null) return;
            var contacts = new HashSet<Data.People.Person>();

            // Add Client's info to the list
            contacts.Add(new Data.People.Person()
            {
                ID = transaction.Account,
                FirstName = transaction.Client.Name,
                Email = transaction.Client.Email,
                ContactNumber = transaction.Client.Telephone
            });

            foreach (var i in transaction.Client.PeopleIDList)
                contacts.Add(DMS.PeopleManager.GetData(qi => qi.ID == i));

            // Get contact
            var contact = (from i in contacts.AsEnumerable()
                           where i != null && i.DisplayName != null && i.DisplayName.ToLower().Equals(contact_ComboBox.Text.ToLower())
                           select i).FirstOrDefault();

            if (contact == null || contact.DisplayName == "")
                contact = transaction.Client.GetPurchaseOrderContact;

            if (contact == null || contact.DisplayName == "")
                contact = transaction.Client.GetAccountant;

            if (contact == null || contact.DisplayName == "")
                contact = transaction.Client.GetMainContact;

            if (contact != null)
            {
                string email = contact.Email;
                string telephone = contact.ContactNumber;

                if (email == null || email.Length < 3) email = transaction.Client.Email;
                if (telephone == null || telephone.Length < 3) telephone = transaction.Client.Telephone;

                transaction.Contact = contact.DisplayName;
                transaction.Email = email;
                transaction.ContactNr = telephone;
            }
            else
            {
                if (transaction.Client != null && AMS.MessageBox_v2.Show("Would you like to add a new contact?", MessageType.Question) == MessageOut.YesOk)
                {
                    var newPerson = new Data.People.Person();
                    newPerson.FirstName = contact_ComboBox.Text;

                    using (UserInterface.People.Forms.PersonEditor f = new People.Forms.PersonEditor(newPerson))
                    {
                        f.ShowDialog();
                        if (f.Person != null)
                        {
                            transaction.Contact = f.Person.DisplayName;
                            transaction.Email = f.Person.Email;
                            transaction.ContactNr = f.Person.ContactNumber;

                            transaction.Client.PeopleIDList.Add(f.Person.ID);
                            transaction.Client.Save("Added " + f.Person.DisplayName, false, true);
                        }
                    }
                }
                else
                {
                    transaction.Contact = contact_ComboBox.Text;
                    transaction.Email = email_TextBox.Text;
                    transaction.ContactNr = "";
                }
            }

            LoadTransaction();
        }

        // Event

        private void TransactionLoad_Event(object sender, EventArgs e)
        {
            if (loading) return;

            transaction.Account = account_TextBox.Text;
            transaction.ClientRef = clientRef_Textbox.Text;
            transaction.ClientID = ClientID_textBox.Text;
            transaction.Contact = contact_ComboBox.Text;
            transaction.Email = email_TextBox.Text;
            transaction.Forex = textBox3.Text;

            timer1.Start();
        }

        private void ContactSelect_Event(object sender, EventArgs e)
        {
            if (loading) return;
            UpdateContactInfo();
        }

        private void Void_Event(object sender, EventArgs e)
        {
            if (loading) return;

            transaction.SetVoid();

            LoadTransaction();
        }

        private void Paid_Event(object sender, EventArgs e)
        {
            if (loading) return;

            //if (transaction.IsPaid == false)
            //{
            //    if (AMS.MessageBox.Show("You are trying to do a manual payment.\r\nPlease add a note as reference.", AMS.MessageBox.MessageType.Question))
            //    {
            //        string message = "Paid - " + AMS.MessageBox.MessageValue;

            //        transaction.IsPaid = true;
            //        transaction.AddNote(message);
            //        transaction.Save(message, false, true);
            //    }
            //}
            //else
            //{
            //    if (AMS.MessageBox.Show("Transaction has already been paid.\r\nPlease add a note for the record.", AMS.MessageBox.MessageType.Question))
            //    {
            //        string message = "UnPaid - " + AMS.MessageBox.MessageValue;

            //        transaction.IsPaid = false;
            //        transaction.AddNote(message);
            //        transaction.Save(message, false, true);
            //    }
            //}

            LoadTransaction();
        }

        private void useVatCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (loading) return;
            transaction.UseVat = !transaction.UseVat;
            LoadTransaction();
        }

        private void SetDate_Event(object sender, EventArgs e)
        {
            if (loading) return;
            using (AMS.Utilities.Forms.DatePicker f = new AMS.Utilities.Forms.DatePicker("Transaction Date", transaction.TransactionDate))
            {
                f.ShowDialog();
                transaction.TransactionDate = f.DateTimeValue;
            }

            LoadTransaction();
        }

        private void SetDueDate_Event(object sender, EventArgs e)
        {
            if (loading) return;
            using (AMS.Utilities.Forms.DatePicker f = new AMS.Utilities.Forms.DatePicker("Due Date", transaction.DueDate))
            {
                f.ShowDialog();
                transaction.DueDate = f.DateTimeValue;
            }

            LoadTransaction();
        }

        private void LoadTransaction_Tick(object sender, EventArgs e)
        {
            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv") return;

            timer1.Stop();
            UpdateContactInfo();
        }

        private void contact_ComboBox_TextChanged(object sender, EventArgs e)
        {
            if (loading) return;
            timer1.Stop();
            timer1.Start();
        }

        private void afr_checkBox_Click(object sender, EventArgs e)
        {
            if (AMS.MessageBox_v2.Show("Are you sure you want to change the language preference for " + transaction.Client.Name + " ?", MessageType.Question) == MessageOut.YesOk)
            {
                transaction.Client.LanguageAfr = !transaction.Client.LanguageAfr;
                transaction.Client.Save("", true, false);

                afr_checkBox.Checked = transaction.Client.LanguageAfr;
            }
        }

        private void clientRef_Textbox_Leave(object sender, EventArgs e)
        {
            if (clientRef_Textbox != null || ClientID_textBox != null) ClientID_textBox = this.account_TextBox;
        }

        private void currency_TextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}