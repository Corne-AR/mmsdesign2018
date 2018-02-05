using Data;
using Data.People;
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
    public partial class CourierLog : Form
    {
        private Client client;

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

        public CourierLog()
        {
            InitializeComponent();
        }

        private void CourierLog_Load(object sender, EventArgs e)
        {
            #region ThemeColors

            AMS.ThemeColors.SetBorders(this);
            AMS.ThemeColors.SetControls(this.Controls);

            #endregion

            client = Data.DMS.ClientManager.CurrentData;
            address_TextBox.Text = client.PostalAddress;
            footer1.UpdateFooterText(client.Name);

            service_ComboBox.Items.Clear();
            service_ComboBox.Items.Add("");

            if (AMS.Suite.SuiteManager.Profile.CourierServicesList != null)
                foreach (var i in AMS.Suite.SuiteManager.Profile.CourierServicesList)
                    service_ComboBox.Items.Add(i);
        }

        private void MailInfo_Click(object sender, EventArgs e)
        {
            string courierContent = "Service Provider: " + service_ComboBox.Text.Trim() + " \r\n" +
               "Tracking Nr: " + trackingNr_TextBox.Text.Trim() + " \r\n" +
               "Date: " + string.Format("{0:dd MMMM yyyy}", dateTimePicker1.Value) + " \r\n" +
               "Content: " + content_TextBox.Text.Trim() + " \r\n" +
               "Address: " + address_TextBox.Text.Trim() + " ";

            var mail = DMS.MailManager.NewMail(
                client.Account,
                true,
                "Courier from " + AMS.Suite.SuiteManager.Profile.CompanyName,
                courierContent,
                null,
                Data.Communications.TemplateTypes.Courier);

            DMS.MailManager.SendGeneralMail(mail);

            client.AddDataLog("Email", courierContent, AMS.Data.DataType.Task);
            client.Save("Courier Sent.", true, false);


            this.Close();
        }

        private void cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void address_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (address_ComboBox.SelectedItem.ToString() == "Postal") address_TextBox.Text = client.PostalAddress;
            if (address_ComboBox.SelectedItem.ToString() == "Physical") address_TextBox.Text = client.PhysicalAddress;
        }

        // Events
    }
}
