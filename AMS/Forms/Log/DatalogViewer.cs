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

namespace AMS.Forms.Log
{
    public partial class DatalogViewer : Form
    {
        private DataClass dataClass;
        public bool RequireSave;
        public HashSet<Datalog> DatalogList;

        public DatalogViewer(DataClass DataClass)
        {
            InitializeComponent();
            this.dataClass = DataClass;
        }

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

        private void DatalogViewer_Load(object sender, EventArgs e)
        {
            #region ThemeColors

            ThemeColors.SetBorders(this);

            #endregion

            dataLog1.SetDataLog(dataClass);
            header1.UseControls(this, true, false, false);
        }

        private void close_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DatalogList = new HashSet<Datalog>();

            foreach (var i in dataLog1.LogData)
                DatalogList.Add(i);

            RequireSave = true;
            this.Close();
        }
    }
}
