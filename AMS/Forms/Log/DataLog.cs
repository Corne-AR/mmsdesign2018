using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AMS.Forms.Log
{
    public partial class DataLog : UserControl
    {
        private List<Data.Datalog> log;
        public List<Data.Datalog> LogData {get{return log;}}

        public DataLog()
        {
            InitializeComponent();
        }

        private void DataLog_Load(object sender, EventArgs e)
        {
            message_Column.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }

        // Methods

        public void SetDataLog(Data.DataClass DataClass)
        {
            log = DataClass.DatalogList.OrderBy(i => i.Created).ToList();
            log.Reverse();
            datalogBindingSource.DataSource = log;
            
            datalogDataGridView.AutoResizeRows();
            datalogDataGridView.AutoResizeColumns();
        }
    }
}
