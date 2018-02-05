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

namespace UserInterface.Products.Forms
{
    public partial class ProductList : Form
    {
        public ProductList()
        {
            InitializeComponent();
        }

        private void ProductList_Load(object sender, EventArgs e)
        {
            productListUC.ShowClientInfo = true;
            productListUC.LoadProductList(DMS.ProductManager.GetDataList(), false);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            foreach (var id in productListUC.ChangeList)
            {
                var product = productListUC.ProductList.Where(i => i.ID == id).FirstOrDefault();
                product.Save("", false, false);
            }
        }
    }
}
