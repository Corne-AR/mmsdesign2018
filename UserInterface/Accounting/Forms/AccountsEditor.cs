using AMS;
using Data;
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
    public partial class AccountsEditor : Form
    {
        #region DropShadow

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

        #endregion

        List<Data.Transactions.Transaction> transactionList = new List<Data.Transactions.Transaction>();
        List<Data.Transactions.Transaction> wtf_TransactionList = new List<Data.Transactions.Transaction>();
        HashSet<Data.Accounts.Receipt> receiptList = new HashSet<Data.Accounts.Receipt>();

        public AccountsEditor()
        {
            InitializeComponent();
        }

        public AccountsEditor(Data.Transactions.Transaction transaction)
        {
            InitializeComponent();

            HashSet<string> transList = new HashSet<string>();
            transactionGridView1.SearchData = new Data.Search.SearchData(transaction);

            // Get intended transactions
            foreach (var i in transaction.LinkedIDList)
            {
                var trans = DMS.TransactionManager.GetData(qi => qi.ID == i);
                if (trans != null) transactionList.Add((Data.Transactions.Transaction)trans.Clone());
            }

            // Get a list of un-intended transactions, this should ideally by 0
            foreach (var trans in transactionList)
            {
                foreach (var id in transaction.LinkedIDList)
                {
                    var queryTrans = DMS.TransactionManager.GetData(qi => qi.ID == id);
                    var queryList = transactionList.Where(qi => qi.ID == id).FirstOrDefault();

                    if (queryTrans != null && queryTrans.ID != queryList.ID)
                        wtf_TransactionList.Add((Data.Transactions.Transaction)queryTrans.Clone());
                }
            }

            // Add those WTF to the list
            if (wtf_TransactionList.Count > 0)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var i in wtf_TransactionList)
                {
                    transactionList.Add(i);
                    sb.AppendLine(i.ID);
                }

                AMS.MessageBox_v2.Show("The following transactions have questionable links, please review them\r\n\r\n" + sb.ToString());
            }

            foreach (var trans in transactionList)
            {
                // Create Receipt List
                foreach (var receipt in trans.ReceiptList())
                    receiptList.Add((Data.Accounts.Receipt)receipt.Clone());
            }
        }

        // Load

        private void AccountsEditor_Load(object sender, EventArgs e)
        {
            #region Theme

            ThemeColors.SetBorders(this);
            ThemeColors.SetControls(this.Controls);
            header1.UseControls(this, true, false, true);

            #endregion

            BindData();
        }
    
        // Methods

        private void BindData()
        {
            receiptGridView1.LoadReceipts(receiptList);
            transactionGridView1.LoadTransactions(transactionList);
        }

        // Events

        private void reload_Button_Click(object sender, EventArgs e)
        {

        }

        private void save_Button_Click(object sender, EventArgs e)
        {

        }

        private void close_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
