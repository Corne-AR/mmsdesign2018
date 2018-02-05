using AMS;
using AMS_Script.Script;
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
    public partial class ScriptEditor : Form
    {
        private aScript script;
        public aScript Script { get { return script; } }

        bool decoding;

        public ScriptEditor(aScript Script)
        {
            InitializeComponent();
            this.script = Script;
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

        private void ScriptEditor_Load(object sender, EventArgs e)
        {
            ThemeColors.SetBorders(this);
            ThemeColors.SetControls(this.Controls);
            ThemeColors.SetControls(label1, ThemeColors.ControlType.Menu);
            ThemeColors.SetControls(label2, ThemeColors.ControlType.Menu);
            ThemeColors.SetControls(label3, ThemeColors.ControlType.Menu);

            if (script == null) script = new aScript("0");

            if (script.VriableList != null) variableBindingSource.DataSource = script.VriableList.ToList();
            scriptName_TextBox.Text = script.Name;
            script_TextBox.Text = script.ScriptContent;

            Decode();
        }

        // Methods
        private void Decode()
        {
            decoding = true;

            script.Decode(script_TextBox.Text);
            result_TextBox.Text = script.Stats;
            if (script.VriableList != null) variableBindingSource.DataSource = script.VriableList.ToList();
            testInValue_TextBox.Text = script.InValue;

            // Set default variables to the primary color
            if (variableDataGridView.Rows.Count > 2)
            {
                variableDataGridView.Rows[0].DefaultCellStyle.BackColor = ThemeColors.Primary;
                variableDataGridView.Rows[0].DefaultCellStyle.ForeColor = ThemeColors.PrimaryText;
                variableDataGridView.Rows[1].DefaultCellStyle.BackColor = ThemeColors.Primary;
                variableDataGridView.Rows[1].DefaultCellStyle.ForeColor = ThemeColors.PrimaryText;
            }

            decoding = false;
        }

        // Events

        private void cancel_Button_Click(object sender, EventArgs e)
        {
            script = null;
            this.Close();
        }

        private void help_Button_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show(AMS_Script.Help.Instructions);
        }

        private void save_Button_Click(object sender, EventArgs e)
        {
            if (decoding) return;

            script.Name = scriptName_TextBox.Text;
           script.InValue = "";
            ScriptManager.Save(script);
            this.Close();
        }

        private void script_TextBox_TextChanged(object sender, EventArgs e)
        {
            Decode();
        }

        private void ScriptNameChange_Event(object sender, EventArgs e)
        {
            script.Name = script_TextBox.Text;
        }

        private void remove_Button_Click(object sender, EventArgs e)
        {
            if (decoding) return;

            ScriptManager.Remove(script);
            this.Close();
        }

        private void TestInValue_TextChanged(object sender, EventArgs e)
        {
            if (decoding) return;

            timer1.Stop();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            if (decoding) return;

            try
            {
                script.InValue = testInValue_TextBox.Text;
            }
            catch { }
            Decode();
        }
    }
}