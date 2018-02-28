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
using Data.Transactions;
using Data;

namespace UserInterface.Transactions.UserControls
{
    public partial class TransactionFooter : UserControl
    {
        Transaction transaction;

        // Constructors

        public TransactionFooter()
        {
            InitializeComponent();
        }

        // Load

        private void TransactionFooter_Load(object sender, EventArgs e)
        {
            if (DMS.TransactionManager == null || DMS.ClientManager == null) return;

            ThemeColors.SetControls(totalDue_button, ThemeColors.ControlType.Menu);
            transaction = new Transaction();
        }

        // Methods

        public void GetTotals()
        {
            transaction.CalculateTotals();

            subTotal_Label.Text = string.Format("{0:0.00}", transaction.SubTotal);
            vat_Label.Text = string.Format("{0:0.00}", transaction.TotalVat);
            total_Label.Text = string.Format("{0:0.00}", transaction.Total);
            totalDue_Label.Text = string.Format("{0:0.00}", transaction.TotalDue);
        }

        internal void LoadTransaction(Transaction transaction)
        {
            this.transaction = transaction;
            if (transaction == null || transaction.Client == null) return;

            GetTotals();
            transaction_BindingSource.DataSource = transaction;
            
            //Credit or debit Lable
            existingCredit_Label.Visible = this.transaction.Client.Credit != 0;

            if (transaction.Client.Credit < 0)
            {
                existingCredit_Label.Text = string.Format("{0:0.00}", "Credit : " + transaction.Client.Credit);
            }
            else
            {
                existingCredit_Label.Text = string.Format("{0:0.00}", "Debit : " + transaction.Client.Credit);
                existingCredit_Label.ForeColor = Color.Red;
            }
        }

        private void GetTotals_Event(object sender, EventArgs e)
        {
            GetTotals();
        }
    }
}
