using AMS;
using AMS.Data.People;
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

namespace UserInterface.People.Forms
{
    public partial class ClientExtra : Form
    {
        private Client oldClient;
        private Client client;

        public ClientExtra(Client Client)
        {
            InitializeComponent();

            this.client = Client;
            this.oldClient = (Client)Client.Clone();
        }

        // Load

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

        private void ClientManager_Load(object sender, EventArgs e)
        {
            #region Theme

            ThemeColors.SetBorders(this);
            ThemeColors.SetControls(this.Controls);

            #endregion

            LoadKeywords();
        }

        // Methods

        private void LoadKeywords()
        {
            textBox1.Text = client.Keywords;
        }

        // Events

        private void save_Button_Click(object sender, EventArgs e)
        {
            client.Keywords = textBox1.Text;
            client.Save("Client Manager Updated", true, false);
            this.Close();
        }

        private void cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
