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

namespace UserInterface.Utilities.Forms
{
    public partial class ProfileEditor : Form
    {
        public ProfileEditor()
        {
            InitializeComponent();
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

        // Load

        private void ProfileEditor_Load(object sender, EventArgs e)
        {
            #region ThemeColors

            ThemeColors.SetBorders(this);
            ThemeColors.SetControls(this.Controls);

            #endregion

            profileBindingSource.DataSource = AMS.Suite.SuiteManager.Profile;
            clientCatagoryListBindingSource.DataSource = AMS.Suite.SuiteManager.Profile.ClientCatagoryList;
            forexBindingSource.DataSource = AMS.Suite.SuiteManager.Profile.ForexList;
            courier_BindingSource.DataSource = AMS.Suite.SuiteManager.Profile.CourierServicesList;
            RIL_bindingSource.DataSource = Data.DMS.ProcessPreferencesManager.WordList.ToList();

        }

        // Close

        private void close_Button_Click(object sender, EventArgs e)
        {
            AMS.Suite.SuiteManager.LoadProfile();
            this.Close();
        }

        private void save_Button_Click(object sender, EventArgs e)
        {
            AMS.Suite.SuiteManager.SaveProfile();
            Data.DMS.ProcessPreferencesManager.Save();
        }

        private void AddCategory_Click(object sender, EventArgs e)
        {
            AMS.MessageBox_v2.Show("Please add category name.", AMS.MessageType.QuestionInput);
            AMS.Suite.SuiteManager.Profile.ClientCatagoryList.Add(AMS.MessageBox_v2.MessageValue);

            clientCatagoryListBindingSource.DataSource = AMS.Suite.SuiteManager.Profile.ClientCatagoryList;
            clientCatagories_ListBox.DataSource = null;
            clientCatagories_ListBox.DataSource = clientCatagoryListBindingSource;
        }

        private void RemoveCategory_Click(object sender, EventArgs e)
        {
            AMS.Suite.SuiteManager.Profile.ClientCatagoryList.Remove(clientCatagories_ListBox.Items[clientCatagories_ListBox.SelectedIndex].ToString());
            
            clientCatagoryListBindingSource.DataSource = AMS.Suite.SuiteManager.Profile.ClientCatagoryList;
            clientCatagories_ListBox.DataSource = null;
            clientCatagories_ListBox.DataSource = clientCatagoryListBindingSource;
        }

        private void AddForex_Click(object sender, EventArgs e)
        {
            AMS.MessageBox_v2.Show("Please add forex name.", AMS.MessageType.QuestionInput);
            AMS.Suite.SuiteManager.Profile.ForexList.Add(AMS.MessageBox_v2.MessageValue);

            forexBindingSource.DataSource = AMS.Suite.SuiteManager.Profile.ForexList;
            forex_ListBox.DataSource = null;
            forex_ListBox.DataSource = forexBindingSource;
        }

        private void RemoveForex_Click(object sender, EventArgs e)
        {
            AMS.Suite.SuiteManager.Profile.ForexList.Remove(forex_ListBox.Items[forex_ListBox.SelectedIndex].ToString());

            forexBindingSource.DataSource = AMS.Suite.SuiteManager.Profile.ForexList;
            forex_ListBox.DataSource = null;
            forex_ListBox.DataSource = forexBindingSource;
        }

        private void AddCourier_Click(object sender, EventArgs e)
        {
            AMS.MessageBox_v2.Show("Please add courier or service name.", AMS.MessageType.QuestionInput);
            AMS.Suite.SuiteManager.Profile.CourierServicesList.Add(AMS.MessageBox_v2.MessageValue);

            courier_BindingSource.DataSource = AMS.Suite.SuiteManager.Profile.CourierServicesList;
            courier_ListBox.DataSource = null;
            courier_ListBox.DataSource = courier_BindingSource;
        }

        private void RemoveCourier_Click(object sender, EventArgs e)
        {
            AMS.Suite.SuiteManager.Profile.CourierServicesList.Remove(courier_ListBox.Items[courier_ListBox.SelectedIndex].ToString());
            
            courier_BindingSource.DataSource = AMS.Suite.SuiteManager.Profile.CourierServicesList;
            courier_ListBox.DataSource = null;
            courier_ListBox.DataSource = courier_BindingSource;
        }

        private void AddRIL_Click(object sender, EventArgs e)
        {
            AMS.MessageBox_v2.Show("Please add receipt keyword need to be ignored.", AMS.MessageType.QuestionInput);
            Data.DMS.ProcessPreferencesManager.WordList.Add(AMS.MessageBox_v2.MessageValue);

            RIL_bindingSource.DataSource = Data.DMS.ProcessPreferencesManager.WordList.ToList();
            RIL_listBox.DataSource = null;
            RIL_listBox.DataSource = RIL_bindingSource;
        }

        private void RemoveRIL_Click(object sender, EventArgs e)
        {
            var value = RIL_listBox.Items[RIL_listBox.SelectedIndex].ToString();
            Data.DMS.ProcessPreferencesManager.WordList.Remove(value);

            RIL_bindingSource.DataSource = Data.DMS.ProcessPreferencesManager.WordList.ToList();
            RIL_listBox.DataSource = null;
            RIL_listBox.DataSource = RIL_bindingSource;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void MinMaintenanceTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void faxTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void companyContactNrTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void profileBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
