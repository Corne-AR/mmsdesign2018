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
using Data;

namespace UserInterface.People.UserControls
{
    public partial class ClientSelect : UserControl
    {
        List<Client> clientList;
        bool clientNameAssending;
        bool clientAccoutAssending;
        private Point MouseDownLocation;
        int panelWidth;
        string typedText;
        public bool UseSearch;
        private Client contextClient;

        public ClientSelect()
        {
            InitializeComponent();
        }

        // Load

        private void RightPanel_Load(object sender, EventArgs e)
        {
            #region ThemeColors
            splitContainer1.Panel1.BackColor = ThemeColors.Menu;
            splitContainer1.Panel1.ForeColor = ThemeColors.MenuText;
            splitContainer1.Panel2.BackColor = ThemeColors.MenuBorder;
            splitContainer1.Panel2.ForeColor = ThemeColors.MenuBorderText;

            client_DataGridView.DefaultCellStyle.BackColor = ThemeColors.Menu;
            client_DataGridView.DefaultCellStyle.ForeColor = ThemeColors.MenuText;
            client_DataGridView.DefaultCellStyle.SelectionBackColor = ThemeColors.Primary;
            client_DataGridView.DefaultCellStyle.SelectionForeColor = ThemeColors.PrimaryText;

            iDToolStripMenuItem.BackColor = ThemeColors.Primary;
            iDToolStripMenuItem.ForeColor = ThemeColors.PrimaryText;

            #endregion

            // Startup with defaults
            if (Data.DMS.ClientManager == null || AMS.Suite.SuiteManager.Preferences == null) return;

            splitContainer1.Panel1Collapsed = !AMS.Suite.SuiteManager.Preferences.ClientManager.ClientSelectHide;
            panelWidth = AMS.Suite.SuiteManager.Preferences.ClientManager.ClientSelectSize;

            CheckCollapsed();

            Data.DMS.ClientManager.OnSaved_Event += LoadClients_Event;
            Data.DMS.ClientManager.OnLoad_Event += LoadClients_Event;
            Data.DMS.ClientManager.OnSelect_Enter += SelectClient_Event;
            DMS.SearchManager.All_Search += All_SearchEvent;
            DMS.SearchManager.Clear_Search += LoadClients_Event;
            DMS.SearchLinkManager.Client_SearchLink += LoadClients_Event;
            DMS.SearchManager.Client_Search += Client_SearchEvent;

            clientList = DMS.ClientManager.GetDataList();
            if (clientList.Count > 0) LoadClients(clientList);
        }

        // Methods

        private void CheckCollapsed()
        {
            bool collapsed = AMS.Suite.SuiteManager.Preferences.ClientManager.ClientSelectHide;
            int height = this.Height;
            if (AMS.Suite.SuiteManager.Preferences.ClientManager.ClientSelectSize < 100) AMS.Suite.SuiteManager.Preferences.ClientManager.ClientSelectSize = 200;
            int width = AMS.Suite.SuiteManager.Preferences.ClientManager.ClientSelectSize;

            if (collapsed) // unclasped
            {
                splitContainer1.Panel1Collapsed = false;
                splitContainer1.Size = new Size(width + 20, height);
                splitContainer1.SplitterDistance = width;
                label1.Text = "3";
            }
            else // Collapse
            {
                splitContainer1.Panel1Collapsed = true;
                splitContainer1.Size = new Size(15, height);
                splitContainer1.SplitterDistance = 1;
                label1.Text = "4";
            }
        }

        public void LoadClients(List<Client> ClientList)
        {
            client_DataGridView.DataSource = ClientList;

            foreach (DataGridViewRow row in client_DataGridView.Rows)
            {
                Client client = (Client)row.DataBoundItem;
                if (client != null && client.Account == Data.DMS.ClientManager.CurrentData.Account)
                    SetClient(client);
            }
        }

        public void SetClient(Client client)
        {
            try
            {
                if (client == null || client.Account == null) return;
                var row = client_DataGridView.Rows
                    .Cast<DataGridViewRow>()
                    .FirstOrDefault(r => ((Client)r.DataBoundItem).Account == client.Account);
                if (row != null) row.Cells[0].Selected = true;
            }
            catch { } // There is a phantom client created from search results, messing up the DataBoundItem convertions.
        }

        internal void SetFound(HashSet<Client> ClientList)
        {
            foreach (DataGridViewRow row in client_DataGridView.Rows)
            {
                string account = row.Cells[accountColumn.Index].Value.ToString();

                var query = (from i in ClientList
                             where i.Account == account
                             select i).FirstOrDefault();

                var foreColor = client_DataGridView.DefaultCellStyle.ForeColor;
                var backColor = client_DataGridView.DefaultCellStyle.BackColor;

                if (query != null)
                {
                    foreColor = ThemeColors.SearchText;
                    backColor = ThemeColors.Search;
                }

                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Style.BackColor = backColor;
                    cell.Style.ForeColor = foreColor;
                }
            }
        }

        // Events

        private void OpenClose_Event(object sender, EventArgs e)
        {
            AMS.Suite.SuiteManager.Preferences.ClientManager.ClientSelectHide = !AMS.Suite.SuiteManager.Preferences.ClientManager.ClientSelectHide;
            CheckCollapsed();
        }

        private void LoadClients_Event(object sender, EventArgs e)
        {
            clientList = DMS.ClientManager.GetDataList();
            if (clientList == null) return;

            clientList = (from i in clientList
                          orderby i.Name
                          where i.Active
                          select i).ToList();

            LoadClients(clientList);

            SetClient(DMS.ClientManager.CurrentData);
        }

        #region Size Panel

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            // 1. Mouse Location
            // 2. If Mouse goes right, add size to AMS.Suite.SuiteManager.Preferences.General.LeftPanelSize
            // 3. if Mouse goes left, remove size from AMS.Suite.SuiteManager.Preferences.General.LeftPanelSize

            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
            }
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                panelWidth = e.X + AMS.Suite.SuiteManager.Preferences.ClientManager.ClientSelectSize - MouseDownLocation.X;

                AMS.StatusUpdate.UpdateArea("Client width: " + panelWidth);
            }
        }

        private void label1_MouseUp(object sender, MouseEventArgs e)
        {
            AMS.Suite.SuiteManager.Preferences.ClientManager.ClientSelectSize = panelWidth;
            CheckCollapsed();
        }

        #endregion

        private void All_SearchEvent(object sender, Data.Search.AllSearchArgs e)
        {
            LoadClients(e.ClientList.ToList());
            if (e.ClientList != null && e.ClientList.Count > 0) DMS.ClientManager.SetCurrent(e.ClientList.ToList()[0]);
        }

        private void Client_SearchEvent(object sender, Data.Search.ClientSearchArgs e)
        {
            LoadClients(e.ClientList.ToList());
            if (e.Client != null && e.ClientList.Count == 1) DMS.ClientManager.SetCurrent(e.Client);
        }

        private void SelectClient_Event(object sender, EventArgs e)
        {
            SetClient(DMS.ClientManager.CurrentData);
        }

        private void client_DataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                #region Set Sort Order

                if (e.RowIndex < 0)
                {
                    if (e.ColumnIndex == 0)
                    {
                        clientList = (from i in clientList
                                      orderby i.Name ascending
                                      select i).ToList();
                        clientNameAssending = !clientNameAssending;
                        if (clientNameAssending) clientList.Reverse();

                        LoadClients(clientList);
                        return;
                    }

                    if (e.ColumnIndex == 1)
                    {
                        clientList = (from i in clientList
                                      orderby i.Account ascending
                                      select i).ToList();
                        clientAccoutAssending = !clientAccoutAssending;
                        if (clientAccoutAssending) clientList.Reverse();

                        LoadClients(clientList);
                        return;
                    }

                    return;
                }

                #endregion

                var client = (Client)client_DataGridView.Rows[e.RowIndex].DataBoundItem;
                Data.DMS.ClientManager.SetCurrent(client);
                DMS.SearchLinkManager.SetClient(client);
            }

            if (e.Button == System.Windows.Forms.MouseButtons.Right && e.RowIndex >= 0)
            {
                contextClient = (Client)client_DataGridView.Rows[e.RowIndex].DataBoundItem;
                if (contextClient == null) return;
                iDToolStripMenuItem.Text = contextClient.Name;

                cell_ContextMenuStrip.Show(client_DataGridView, client_DataGridView.PointToClient(Cursor.Position));
            }
        }

        private void viewLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            contextClient.ViewDatalog();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt) return;

            timer1.Stop();
            timer1.Start();

            string key = e.KeyCode.ToString();

            if (e.KeyCode == System.Windows.Forms.Keys.Space) key = " ";

            typedText += key;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            if (typedText.Count() < 3) return;

            typedText = typedText.ToLower();

            AMS.StatusUpdate.UpdateArea(typedText);

            foreach (DataGridViewRow row in client_DataGridView.Rows)
            {
                var client = (Client)row.DataBoundItem;

                if ((client.Name + "").ToLower().Contains(typedText))
                {
                    Data.DMS.ClientManager.SetCurrent(client);
                    break;
                }
            }

            typedText = "";
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;

            contextClient = (Client)client_DataGridView.Rows[e.RowIndex].DataBoundItem;
            if (contextClient == null) return;
            if (Parent.GetType() == typeof(Accounting.Forms.AccountsManagerForm))
                ((Accounting.Forms.AccountsManagerForm)Parent).SetReceiptClient(contextClient.Account);
        }

        private void keywords_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (contextClient != null)
                using (Forms.ClientExtra cm = new Forms.ClientExtra(contextClient))
                    cm.ShowDialog();
        }

        private void setupFileInstruciotnsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var mail = DMS.MailManager.NewMail(contextClient.Account, true, "Setup File Instructions", null, null, Data.Communications.TemplateTypes.MMSSetupInfo);
            DMS.MailManager.SendGeneralMail(mail);
        }

        private void maintenanceReminderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ReportManager.MaintenanceQuoteReport(contextClient);
            DMS.MaintenanceMail(contextClient);
        }

        private void statementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (contextClient != null)
                ReportManager.StatementReport(contextClient.Account);
        }
    }
}
