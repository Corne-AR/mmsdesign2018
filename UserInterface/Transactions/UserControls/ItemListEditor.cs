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
using Data.Products;
using Data;

namespace UserInterface.Transactions.UserControls
{
    public partial class ItemListEditor : UserControl
    {
        bool loading;

        private Transaction transaction;
        private List<Data.Products.Product> productList;

        // Constructor

        public ItemListEditor()
        {
            InitializeComponent();
        }

        // Load

        private void TransactionItems_Load(object sender, EventArgs e)
        {
            if (DMS.TransactionManager == null || DMS.ClientManager == null) return;

            productList = new List<Data.Products.Product>();
            transaction = new Transaction();
            transaction.ItemList = new List<Data.Products.Product>();
            PriceExVat.DefaultCellStyle.Format = "0.00";
            PriceInVat.DefaultCellStyle.Format = "0.00";

            string supplierNames = "";
            SupplierID.Items.Clear();
            SupplierID.Items.Add("");
            SupplierID.Items.Add("Not Applicable");
            foreach (var i in DMS.ClientManager.GetDataList(qi => qi.Catagory == "Supplier"))
            {
                SupplierID.Items.Add(i.ID);
                supplierNames += i.ID + " - " + i.Name + "\r\n";
            }
            SupplierID.ToolTipText = supplierNames.Trim();

            LoadTransaction();
        }

        // Methods

        public void LoadTransactionItems(Transaction Transaction)
        {
            loading = true;

            transaction = Transaction;
            productList = transaction.ItemList;

            LoadTransaction();

            loading = false;
        }

        private void LoadTransaction()
        {
            loading = true;

            // Bind Data
            productListBindingSource.DataSource = productList;
            loading = false;
        }

        // Events

        private void productListDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (loading) return;

            loading = true;

            try
            {
                var product = (Product)productList_DataGridView.Rows[e.RowIndex].DataBoundItem;
                decimal value = Convert.ToDecimal(productList_DataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);

                // Price Ex Vat 
                if (productList_DataGridView.Columns[e.ColumnIndex].DataPropertyName == "PriceExVat")
                {
                    if (transaction.UseVat) product.PriceInVat = Math.Round(value * 1.14m, 2);
                    else product.PriceInVat = 0;
                }

                // Price In Vat
                if (productList_DataGridView.Columns[e.ColumnIndex].DataPropertyName == "PriceInVat")
                {
                    if (transaction.UseVat) product.PriceExVat = Math.Round(value / 1.14m, 2);
                    else AMS.MessageBox_v2.Show("Client does not have VAT\r\nPlease use the PriceExVat column");
                }
            }
            catch { }
            loading = false;

            if (transaction != null) transaction.CalculateTotals();
        }

        private void productListDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception.Message == "DataGridViewComboBoxCell value is not valid.")
            {
                object value = productList_DataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (!((DataGridViewComboBoxColumn)productList_DataGridView.Columns[e.ColumnIndex]).Items.Contains(value))
                {
                    ((DataGridViewComboBoxColumn)productList_DataGridView.Columns[e.ColumnIndex]).Items.Add(value);
                    e.ThrowException = false;
                }
            }
        }
    }
}