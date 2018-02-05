using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AMS.Suite.UserControls
{
    public partial class ThemeColorsEditor : UserControl
    {
        public ThemeColorsEditor()
        {
            InitializeComponent();
        }

        private void ThemeColorsEditor_Load(object sender, EventArgs e)
        {
            if(AMS.Suite.SuiteManager.Profile != null) dataGridView1.DataSource = AMS.Suite.SuiteManager.Profile.ThemeColorList;
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                e.CellStyle.BackColor = Color.FromArgb((int)e.Value);
                e.CellStyle.ForeColor = Color.FromArgb((int)e.Value);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                ColorDialog cdialog = new ColorDialog();
                cdialog.Color = Color.FromArgb((int)row.Cells[1].Value);
                cdialog.ShowDialog();
                row.Cells[1].Value = cdialog.Color.ToArgb();

                AMS.Suite.SuiteManager.SaveProfile();
            }
        }
    }
}
