using AMS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AMS_Script.Forms
{
    public partial class FactorEditor : Form
    {
        private List<Commands.Variable> factorList { get; set; }
        public HashSet<Commands.Variable> FactorList { get {
            var list = new HashSet<Commands.Variable>();
            foreach (var i in factorList)
                list.Add(i);
            return list; } }

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

        public FactorEditor(HashSet<Commands.Variable> FactorList)
        {
            InitializeComponent();

            this.factorList = FactorList.ToList();
        }

        private void FactorEditor_Load(object sender, EventArgs e)
        {
            #region

            ThemeColors.SetBorders(this);
            ThemeColors.SetControls(save_Button, ThemeColors.ControlType.Menu);

            #endregion

            foreach (var i in Enum.GetNames(typeof(Script.VariableType)))
                VariableType.Items.Add("" + i.ToString());

            variableBindingSource.DataSource = factorList;
        }

        private void save_Button_Click(object sender, EventArgs e)
        {
            factorList = (List<Commands.Variable>)variableBindingSource.DataSource;
            this.Close();
        }

        private void variableDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
    }
}
