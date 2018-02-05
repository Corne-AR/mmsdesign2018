using Data.Transactions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterface.Accounting.Forms
{
    public partial class MultiCreatorForm : Form
    {
        public BindingList<Transaction> Transactions { get; set; } = new BindingList<Transaction>();

        DateTime newdate = DateTime.Now;
        DateTime newduedate = DateTime.Now;

        public MultiCreatorForm()
        {
            InitializeComponent();
            btnGenerate.Text = "Create New";
            this.Load += (s, e) => Initialize();
        }

        public MultiCreatorForm(IList<Transaction> Transactions)
        {
            InitializeComponent();
            btnGenerate.Text = "Save All";
            this.Transactions = new BindingList<Transaction>(Transactions);
            this.Load += (s, e) => Initialize();
        }

        private void Initialize()
        {

            btnGenerate.Click += SaveTransactions_Event;
            btnCancel.Click += (s, e) => this.Close();
            btnAdd.Click += AddTransaction_Event;
            btnAddPlus.Click += AddTransactionPlus_Event;
            btnRemove.Click += Remove_Event;

            TransactionsListBox.DataSource = Transactions;
            TransactionsListBox.Click += (s, e) => SetTransaction();

            Data.DMS.ClientManager.OnSaved_Event += (s, e) => AccountsComboBox.DataSource = Data.DMS.ClientManager.GetDataList().OrderBy(i => i.Name).ToList();

            AccountsComboBox.DataSource = Data.DMS.ClientManager.GetDataList().OrderBy(i => i.Name).ToList();
            AccountsComboBox.DisplayMember = "Name";
            AccountsComboBox.ValueMember = "Account";
            AccountsComboBox.Text = "";
            AccountsComboBox.SelectedValueChanged += (s, e) =>
            {
                var trans = TransactionsListBox.SelectedItem as Transaction;
                if (trans == null) return;
                trans.SetClient(AccountsComboBox.SelectedItem as Data.People.Client);
                SetTransaction();
            };

            typeComboBox.Items.AddRange(Enum.GetNames(typeof(TransactionType)));
            typeComboBox.Text = TransactionType.Proforma.ToString();

            datePicker.ValueChanged += (s, e) =>
            {
                newdate = datePicker.Value;
                var trans = TransactionsListBox.SelectedItem as Transaction;
                if (trans != null) trans.TransactionDate = newdate;
            };

            dueDatePicker.ValueChanged += (s, e) =>
            {
                newduedate = dueDatePicker.Value;
                var trans = TransactionsListBox.SelectedItem as Transaction;
                if (trans != null) trans.DueDate = newduedate;
            };

            SetTransaction();
        }

        private void AddTransaction_Event(object sender, EventArgs e)
        {
            var trans = new Transaction();

            trans.Account = "NOT SPECIFIED " + Transactions.Count;
            trans.TransactionDate = newdate;
            trans.DueDate = newduedate;

            Transactions.Add(trans);
            TransactionsListBox.SelectedIndex = TransactionsListBox.Items.Count - 1;
        }

        private void AddTransactionPlus_Event(object sender, EventArgs e)
        {
            var trans = new Transaction();
            var lasttrans = Transactions.LastOrDefault();
            if (lasttrans != null && lasttrans.ItemList.Count > 0)
            {
                foreach (var i in lasttrans.ItemList)
                    trans.ItemList.Add((Data.Products.Product)i.Clone());
            }

            trans.Account = "NOT SPECIFIED " + Transactions.Count;
            trans.TransactionDate = newdate;
            trans.DueDate = newduedate;

            Transactions.Add(trans);
            TransactionsListBox.SelectedIndex = TransactionsListBox.Items.Count - 1;
        }

        private void SaveTransactions_Event(object sender, EventArgs e)
        {
            AMS.Data.GobalManager.SuspendEvents();

            try
            {
                foreach (var i in Transactions)
                {
                    var tt = typeComboBox.Text;
                    i.Type = (TransactionType)Enum.Parse(typeof(TransactionType), tt);
                    i.Save("Generated Transaction", !string.IsNullOrEmpty(i.ID), string.IsNullOrEmpty(i.ID));
                }

                AMS.Data.GobalManager.ResumeEvents();
                Data.DMS.TransactionManager.LoadData();

                this.Close();
            }
            catch (Exception ex) { AMS.Data.GobalManager.ResumeEvents(); throw ex; }
        }

        private void SetTransaction()
        {
            var trans = TransactionsListBox.SelectedItem as Transaction;

            AccountsComboBox.Text = trans?.Account;

            if (trans != null)
            {
                itemListEditor1.LoadTransactionItems(trans);
                transactionHeader1.LoadTransaction(trans);
                datePicker.Value = trans.TransactionDate;
                dueDatePicker.Value = trans.DueDate;


                splitContainer1.Panel2.Enabled = true;
            }
            else
            {
                splitContainer1.Panel2.Enabled = false;
            }
        }

        private void Remove_Event(object sender, EventArgs e)
        {
            var index = TransactionsListBox.SelectedIndex;
            Transactions.RemoveAt(index);
        }
    }
}
