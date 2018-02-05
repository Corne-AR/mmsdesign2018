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
using Data.People;

namespace UserInterface.People.UserControls
{
    public partial class People_Info_List : UserControl
    {
        // Variables

        Client client;
        private HashSet<string> peopleList;

        // Constructors

        public People_Info_List()
        {
            InitializeComponent();

            this.flowLayoutPanel1.VerticalScroll.Visible = true;
        }

        // Load

        private void People_Info_List_Load(object sender, EventArgs e)
        {
            #region Theme

            ThemeColors.SetControls(this.Controls);
            ThemeColors.SetControls(panel1, ThemeColors.ControlType.Menu);

            #endregion

            if (Data.DMS.ClientManager == null) return;

            Data.DMS.ClientManager.OnSaved_Event += ClientSelect_Event;
            Data.DMS.ClientManager.OnSelect_Enter += ClientSelect_Event;
            AMS.Utilities.Controls.FlowlayoutPanel.CleanUp(flowLayoutPanel1);

            client = new Client();
            peopleList = new HashSet<string>();
        }

        // Events
        private void ClientSelect_Event(object sender, EventArgs e)
        {
            client = Data.DMS.ClientManager.CurrentData;
            if (client == null) return;

            if (client.PeopleIDList != null) peopleList = client.PeopleIDList;
            else peopleList = new HashSet<string>();

            AMS.Utilities.Controls.FlowlayoutPanel.CleanUp(flowLayoutPanel1);

            foreach (var i in Data.DMS.PeopleManager.GetDataList())
            {
                if (peopleList.Contains(i.ID))
                {
                    Person_Info pInfo = new Person_Info(i);
                    flowLayoutPanel1.Controls.Add(pInfo);
                }
            }
        }

        private void EditList_Click(object sender, EventArgs e)
        {
            using (Forms.Select_People f = new Forms.Select_People(client.PeopleIDList))
            {
                f.ShowDialog();
                client.PeopleIDList = f.PeopleIDList;
                client.Save(null, false, false);
            }
        }
    }
}