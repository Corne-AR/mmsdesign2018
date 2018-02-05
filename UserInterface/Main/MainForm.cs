using AMS;
using Data;
using Data.Search;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UserInterface.Main
{
    public partial class MainForm : Form
    {
        private AMS_Certificate.Forms.Certificates certificates_Form;

        private Point MouseDownLocation;
        private bool searching;
        private UserInterface.Utilities.Forms.MailTemplateEditor mailTemplateEditor;

        public MainForm()
        {
            InitializeComponent();

            ThemeColors.SetControls(this.menuStrip1, ThemeColors.ControlType.Menu);
            this.Text = AMS.Settings.Program.Name;
        }

        // Load

        private void MainForm_Load(object sender, EventArgs e)
        {
            #region Theme Colors

            ThemeColors.SetControls(toolStrip1, ThemeColors.ControlType.MenuBorder);
            ThemeColors.SetControls(searchOptions_Panel, ThemeColors.ControlType.MenuBorder);
            ThemeColors.SetControls(searchPanelContent_Panel, ThemeColors.ControlType.Menu);
            search_ToolStripComboBox.BackColor = ThemeColors.InputControl;
            search_ToolStripComboBox.ForeColor = ThemeColors.InputText;

            #endregion Theme Colors

            Bitmap b = Properties.Resources.Thumbnail;
            this.Icon = Icon.FromHandle(b.GetHicon());

            searchOptions_Panel.Visible = false;

            List<Form> formlist = new List<Form>
            {
                new UserInterface.People.Forms.Clients(),
                new UserInterface.Accounting.Forms.AccountsManagerForm(),
                // formlist.Add(new Schedule.Courses.Forms.CourseManager());
                new UserInterface.People.Forms.PeopleManager()
            };

            tabControl1.AddMdiForms(this, formlist);

            tabControl1.LoadTab();
            tabControl1.SetTabColors();

            IndexingFiles();
        }

        int cataIndex = 0;
        int clientIndex = 0;
        int peopleIdex = 0;
        int productIdex = 0;
        int quoteIndex = 0;
        int transIndex = 0;

        private void IndexingFiles()
        {
            //miCheckLatestFiles.Click += (s, e) => { AMS.Data.GobalManager.RaiseUpdateIndexer(); };

            //DMS.CatalogManager.Indexing.ExecuteCompleted += (s, e) => { cataIndex = GetCount(DMS.CatalogManager); UpdateBtn(); };
            //DMS.ClientManager.Indexing.ExecuteCompleted += (s, e) => { clientIndex = GetCount(DMS.ClientManager); UpdateBtn(); };
            //DMS.PeopleManager.Indexing.ExecuteCompleted += (s, e) => { peopleIdex = GetCount(DMS.PeopleManager); UpdateBtn(); };
            //DMS.ProductManager.Indexing.ExecuteCompleted += (s, e) => { productIdex = GetCount(DMS.ProductManager); UpdateBtn(); };
            //DMS.QuoteManager.Indexing.ExecuteCompleted += (s, e) => { quoteIndex = GetCount(DMS.QuoteManager); UpdateBtn(); };
            //DMS.TransactionManager.Indexing.ExecuteCompleted += (s, e) => { transIndex = GetCount(DMS.TransactionManager); UpdateBtn(); };
        }

        //private int GetCount<T>(AMS.Data.DataManager<T> DataManager) => DataManager.ChangedCount;
        //private void UpdateBtn()
        //{
        //    var count = cataIndex + clientIndex + +peopleIdex + productIdex + quoteIndex + transIndex;
        //    btnReloadData.Text = count > 0 ? $"Reload Data ({count})" : "Reload Data";
        //}


        // Events

        private void DataFolder_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(AMS.Settings.Program.Directories.RootData);
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LocalFolder_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(AMS.Settings.Program.Directories.LocalData);
        }

        #region Export

        private void Export_Click(object sender, EventArgs e)
        {
            //using (IO.Forms.Import f = new IO.Forms.Import())
            //    f.ShowDialog();

            IO.Forms.Export export = new IO.Forms.Export();
            export.ShowDialog();
        }

        private void AllTelephoneNumbersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog savedialog = new SaveFileDialog
            {
                DefaultExt = "xml",
                FileName = string.Format("Contact Numbers {0:dd MM yy}.xml", DateTime.Now),

                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            };
            if (savedialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (string.IsNullOrEmpty(savedialog.FileName)) { AMS.MessageBox_v2.Show("No file name was specified"); return; }

                DataTable dt = new DataTable("ContactNumbers");
                dt.Columns.Add("Client Name");
                dt.Columns.Add("Person");
                dt.Columns.Add("Contact");

                var clientList = DMS.ClientManager.GetDataList();
                int count = clientList.Count;
                int nr = 0;
                foreach (var client in clientList)
                {
                    nr++;
                    AMS.MessageBox_v2.ShowProcess("Reading " + count + " Client Data\r\n" + client.Name, nr, count);

                    object[] clientVals = new object[3];
                    clientVals[0] = client.Name;
                    clientVals[1] = client.GetMainContact.DisplayName;

                    foreach (var i in ContactList(client.Telephone))
                    {
                        clientVals[2] = i;
                        dt.Rows.Add(clientVals);
                    }

                    foreach (var person in client.GetPeopleList())
                    {
                        object[] personVals = new object[3];
                        personVals[0] = client.Name;
                        personVals[1] = person.DisplayName;

                        foreach (var i in ContactList(person.ContactNumber))
                        {
                            clientVals[2] = i;
                            dt.Rows.Add(personVals);
                        }
                    }
                }

                AMS.MessageBox_v2.ShowProcess("Saving Contact Data\r\n" + savedialog.FileName);
                dt.WriteXml(savedialog.FileName);
                AMS.MessageBox_v2.EndProcess();
            }
        }

        private List<string> ContactList(string Contact)
        {
            var contactList = new List<string>();
            if (Contact == null) return contactList;

            bool add = true;

            Contact = Contact.Replace(',', ';').Replace("or", ";").Replace('|', ';').Replace('/', ';').Replace("-", "").Replace("(", "").Replace(")", "");
            if (Contact.Contains(";"))
            {
                add = false;
                var splitOne = Contact.Split(';');

                foreach (var i in splitOne)
                    contactList.Add(i.Replace(" ", ""));
            }

            if (add) contactList.Add(Contact.Replace(" ", ""));

            return contactList;
        }

        private void ExportPeopleList_Click(object sender, EventArgs e)
        {
            SaveFileDialog savedialog = new SaveFileDialog
            {
                DefaultExt = "xml",
                FileName = string.Format("People List {0:dd MM yy}.xml", DateTime.Now),
                Filter = "*XML (*.xml)|*.xml",

                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            };
            if (savedialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (string.IsNullOrEmpty(savedialog.FileName)) { AMS.MessageBox_v2.Show("No file name was specified"); return; }

                AMS.MessageBox_v2.ShowProcess("Reading People Data");

                DataTable dt = new DataTable("People");
                dt.Columns.Add(new DataColumn("First Name"));
                dt.Columns.Add(new DataColumn("Email"));

                var peopleList = DMS.PeopleManager.GetDataList();
                int nr = 0;
                int count = peopleList.Count;

                foreach (var person in peopleList)
                {
                    AMS.MessageBox_v2.ShowProcess("Reading " + count + " People Data\r\n" + person.DisplayName, nr, count);
                    nr++;

                    object[] rowVals = new object[2];
                    rowVals[0] = person.FirstName;
                    rowVals[1] = person.Email;

                    dt.Rows.Add(rowVals);
                }

                // Split emails with ;
                if (AMS.MessageBox_v2.Show("Would you like to split emails into separate lines?", MessageType.Question) == MessageOut.YesOk)
                {
                    List<DataRow> removeList = new List<DataRow>();
                    DataTable addListDT = new DataTable("People");
                    addListDT.Columns.Add(new DataColumn("First Name"));
                    addListDT.Columns.Add(new DataColumn("Email"));

                    AMS.MessageBox_v2.ShowProcess("Querying Email for split");

                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["Email"] != null && row["Email"].ToString().Contains(";"))
                        {
                            // Add row to remove list to be removed later
                            removeList.Add(row);

                            // Split into additional rows then add to list later
                            var emailSplit = row["Email"].ToString().Split(';');

                            foreach (var split in emailSplit)
                            {
                                addListDT.Rows.Add(new object[] { row[0].ToString(), split.ToString() });
                            }
                        }
                    }

                    // Finally Remove and Add the differences
                    nr = 0;
                    count = removeList.Count;
                    foreach (DataRow row in removeList)
                    {
                        AMS.MessageBox_v2.ShowProcess("Removing Split Emails " + count, nr, count);
                        nr++;

                        var queryRow = (from i in dt.AsEnumerable()
                                        where i["Email"] == row["Email"]
                                        select i).FirstOrDefault();

                        dt.Rows.Remove(queryRow);
                    }

                    nr = 0;
                    count = addListDT.Rows.Count;
                    foreach (DataRow row in addListDT.Rows)
                    {
                        AMS.MessageBox_v2.ShowProcess("Adding New Emails " + count, nr, count);
                        nr++;
                        dt.Rows.Add(row.ItemArray);
                    }
                }

                AMS.MessageBox_v2.ShowProcess("Saving People Data\r\n" + savedialog.FileName);
                dt.WriteXml(savedialog.FileName);
                AMS.MessageBox_v2.EndProcess();
            }
        }

        #endregion Export

        private void UserManager_Click(object sender, EventArgs e)
        {
            using (AMS.Users.Forms.Network_Administration f = new AMS.Users.Forms.Network_Administration())
                f.ShowDialog();
        }

        private void onlineUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string onlineusers = "";

            foreach (var i in AMS.Users.UserManager.OnlineNetworkUsers)
                onlineusers += i + "\r\n";

            AMS.MessageBox_v2.Show("Online Users:\r\n" + onlineusers);
        }

        private void Certificates_Click(object sender, EventArgs e)
        {
            // Certificates
            //AMS.Courses.Course course = new AMS.Courses.Course();
            //course.Date = DateTime.Now;
            //course.Name = "Survey Maker";

            //var attendeeList = new List<AMS.Courses.Attendee>();
            //AMS.Tasks.Task_Manager.TaskList();
            //AMS.Tasks.Task_Manager.TaskItemList();
            //var task = AMS.Tasks.Task_Manager.GetTask("T01");

            //foreach (var i in AMS.Tasks.Task_Manager.TaskItemList(task))
            //{
            //    attendeeList.Add(new AMS.Courses.Attendee()
            //    {
            //        CPD = "PVT046b",
            //        CourseDescription = course.Name,
            //        Date = course.Date,
            //       FullName = i.Description
            //    });
            //}

            //course.AttendeeList = attendeeList;

            //certificates_Form = new AMS_Certificate.Forms.Certificates(course);
            //certificates_Form.Show();

            certificates_Form = new AMS_Certificate.Forms.Certificates();
            certificates_Form.Show();
        }

        private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Data.Utilities.ProgramUtilities.CheckForUpdate(true, "MMS Design Installer.msi")) this.Close();
        }

        private void CatalogManager_Click(object sender, EventArgs e)
        {
            using (UserInterface.Catalogs.Forms.Commerce_Manager f = new UserInterface.Catalogs.Forms.Commerce_Manager())
                f.ShowDialog();
        }

        private void ReloadData_Click(object sender, EventArgs e)
        {
            AMS.Data.GobalManager.SuspendEvents();

            int count = 7;
            AMS.MessageBox_v2.ShowProcess("Reloading all data\r\nClients", 1, count);
            DMS.ClientManager.LoadData();
            AMS.MessageBox_v2.ShowProcess("Reloading all data\r\nCatelogs", 2, count);
            DMS.CatalogManager.LoadData();
            AMS.MessageBox_v2.ShowProcess("Reloading all data\r\nPeople", 3, count);
            DMS.PeopleManager.LoadData();
            AMS.MessageBox_v2.ShowProcess("Reloading all data\r\nProducts", 4, count);
            DMS.ProductManager.LoadData();
            AMS.MessageBox_v2.ShowProcess("Reloading all data\r\nQuotes", 5, count);
            DMS.QuoteManager.LoadData();
            AMS.MessageBox_v2.ShowProcess("Reloading all data\r\nTasks", 6, count);
            DMS.TaskManager.LoadData();
            AMS.MessageBox_v2.ShowProcess("Reloading all data\r\nTransactions", 7, count);
            DMS.TransactionManager.LoadData();
            AMS.MessageBox_v2.EndProcess();

            AMS.Data.GobalManager.ResumeEvents();

            if (DMS.ClientManager.CurrentData != null)
                DMS.ClientManager.SetCurrent(i => i.Account == DMS.ClientManager.CurrentData.Account);
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            if (AMS.MessageBox_v2.Show("Are you sure you want to log out?\r\nThis will close the program.", AMS.MessageType.Question) == AMS.MessageOut.YesOk)
            {
                AMS.Users.UserManager.LocalData.FastLogin = false;
                AMS.Users.UserManager.SaveLocalData();
                this.Close();
            }
        }

        private void changeDB_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AMS.MessageBox_v2.Show("Are you sure you want to change the database location?\r\nThis will close the program.", AMS.MessageType.Question) == AMS.MessageOut.YesOk)
            {
                AMS.Settings.Program.SetDataRootDirectory();
                this.Close();
            }
        }

        private void Profile_Click(object sender, EventArgs e)
        {
            using (UserInterface.Utilities.Forms.ProfileEditor f = new UserInterface.Utilities.Forms.ProfileEditor())
                f.ShowDialog();
        }

        private void About_Click(object sender, EventArgs e)
        {
            var version = System.Reflection.Assembly.GetEntryAssembly().GetName().Version;
            var versionString = version.Major + "." + version.Minor + "." + version.Build;

            AMS.MessageBox_v2.Show(
                AMS.Settings.Program.Name + " " + versionString + "\r\n" +
                "Firstlight Studio©  2013\r\n" +
                "All Rights Reserved\r\n\r" +
                "This computer program is protected by copyright law and international treaties.\r\n" +
                "Unauthorized reproduction  or distribution of this program, or any portion of it, may result in\r\n" +
                "criminal penalties and will be prosecuted to the maximum extent possible under the law.");
        }

        private void EULA_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("EULA.rtf");
        }

        private void AccountsFolder_Click(object sender, EventArgs e)
        {
            if (DMS.ClientManager.CurrentData == null) return;
            FileInfo file = new FileInfo(DMS.ClientManager.CurrentData.File.FullName);
            System.Diagnostics.Process.Start(file.DirectoryName);
        }

        #region Search

        private void DoSearch_Event(object sender, KeyEventArgs e)
        {
            if (searching) return;

            if (e.KeyData == System.Windows.Forms.Keys.Enter)
            {
                searching = true;

                DMS.SearchManager.DoSearch(search_ToolStripComboBox.Text, SearchType.All);

                searching = false;
            }
        }

        private void clearSearch_ToolStripButton_Click(object sender, EventArgs e)
        {
            DMS.SearchManager.ClearSearch();
            searchResultsPanel1.ClearResults();
            searchOptions_Panel.Visible = false;
        }

        private void clientSearch_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DMS.SearchManager.DoSearch(search_ToolStripComboBox.Text, SearchType.Client);
        }

        private void productSearch_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DMS.SearchManager.DoSearch(search_ToolStripComboBox.Text, SearchType.Product);
        }

        private void transactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DMS.SearchManager.DoSearch(search_ToolStripComboBox.Text, SearchType.Transaction);
        }

        private void receiptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DMS.SearchManager.DoSearch(search_ToolStripComboBox.Text, SearchType.Receipt);
        }

        private void ShowSearchPanel_Event(object sender, EventArgs e)
        {
            searchOptions_Panel.Visible = true;
            search_Timer.Start();
        }

        private void search_Timer_Tick(object sender, EventArgs e)
        {
            searchOptions_Panel.Visible = false;
            search_Timer.Stop();
        }

        private void SearchPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
            }
        }

        private void SearchPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                int searchPanelX = 0;
                int searchPanelY = 0;
                int padding = 15;

                int limitRight = Screen.PrimaryScreen.WorkingArea.Width - searchOptions_Panel.Width - padding;
                int limitBot = Screen.PrimaryScreen.WorkingArea.Height - searchOptions_Panel.Height - padding * 2;

                searchPanelX = e.X + searchOptions_Panel.Left - MouseDownLocation.X;
                searchPanelY = e.Y + searchOptions_Panel.Top - MouseDownLocation.Y;

                if (searchPanelX < padding) searchPanelX = padding;
                if (searchPanelY < 3) searchPanelY = 3;

                if (searchPanelX > limitRight) searchPanelX = limitRight;
                if (searchPanelY > limitBot) searchPanelY = limitBot;

                searchOptions_Panel.Location = new Point(searchPanelX, searchPanelY);
            }
        }

        private void searchOptionsClose_Label_Click(object sender, EventArgs e)
        {
            searchOptions_Panel.Visible = false;
        }

        #endregion Search

        private void mailTemplates_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mailTemplateEditor == null || mailTemplateEditor.IsDisposed)
                mailTemplateEditor = new UserInterface.Utilities.Forms.MailTemplateEditor();

            mailTemplateEditor.Show(this);
        }

        #region Utilites

        // Accounts

        private void RemoveReceiptProcessInfo__Click(object sender, EventArgs e)
        {
            if (AMS.MessageBox_v2.Show("This will clear any processing info from receipts without any accounts.\r\nWould you like to proceed?", AMS.MessageType.Question) == AMS.MessageOut.YesOk)
            {
                int count = DMS.AccountsManager.ReceiptList.Count;
                int nr = 0;
                foreach (var receipt in DMS.AccountsManager.ReceiptList)
                {
                    nr++;
                    AMS.MessageBox_v2.ShowProcess("Updating Receipt " + receipt.ID, nr, count);
                    receipt.BeingProcessedReference = "";
                }
                DMS.AccountsManager.SaveReceipts();
                AMS.MessageBox_v2.EndProcess();
            }
        }

        private void RemoveAllReceiptAccounts_Click(object sender, EventArgs e)
        {
            if (AMS.MessageBox_v2.Show("Are you sure you want to remove all receipts' account?\r\nWARNING, this cannot be undone.", AMS.MessageType.Question) == AMS.MessageOut.YesOk)
            {
                int count = DMS.AccountsManager.ReceiptList.Count;
                int nr = 0;
                foreach (var receipt in DMS.AccountsManager.ReceiptList)
                {
                    nr++;
                    AMS.MessageBox_v2.ShowProcess("Updating Receipt " + receipt.ID, nr, count);
                    receipt.Account = "";
                }
                DMS.AccountsManager.SaveReceipts();
                AMS.MessageBox_v2.EndProcess();
            }
        }

        private void RemoveAllReceiptLinks_Click(object sender, EventArgs e)
        {
            if (AMS.MessageBox_v2.Show("Are you sure you want to unlink all receipts and transactions?\r\nWARNING, this cannot be undone.", AMS.MessageType.Question) == AMS.MessageOut.YesOk)
            {
                AMS.Data.GobalManager.SuspendEvents();

                int count = DMS.AccountsManager.ReceiptList.Count;
                int nr = 0;
                foreach (var receipt in DMS.AccountsManager.ReceiptList.Where(i => i.ReceiptAllocationList != null && i.ReceiptAllocationList.Count > 0))
                {
                    nr++;
                    AMS.MessageBox_v2.ShowProcess("Updating Receipt " + receipt.ID, nr, count);
                    receipt.ReceiptAllocationList = new HashSet<Data.Accounts.ReceiptAllocation>();
                }

                var transList = DMS.TransactionManager.GetDataList(i => i.ReceiptAllocationList != null && i.ReceiptAllocationList.Count > 0);
                count = transList.Count;
                nr = 0;
                foreach (var trans in transList)
                {
                    nr++;
                    AMS.MessageBox_v2.ShowProcess("Updating Transaction " + trans.ID, nr, count);
                    trans.ReceiptAllocationList = new HashSet<Data.Accounts.ReceiptAllocation>();
                    trans.Save("Updating receipt allocation", true, false);
                }
                AMS.Data.GobalManager.ResumeEvents();
                DMS.AccountsManager.SaveReceipts();
                AMS.MessageBox_v2.EndProcess();
            }
        }

        private void RemoveOlderThanMarch2013_Click(object sender, EventArgs e)
        {
            if (AMS.MessageBox_v2.Show("Are you sure you want to remove all transactions before March 2013?", AMS.MessageType.Question) == AMS.MessageOut.YesOk)
            {
                var list = DMS.TransactionManager.GetDataList(i => i.TransactionDate < new DateTime(2013, 3, 1));
                list = list.OrderBy(i => i.ID).ToList();
                foreach (var i in list)
                    DMS.TransactionManager.Delete("Old Transaction", i, true);
            }
        }

        // Products

        private void fixSupplierLinksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Data.Products.Utilities.UpdateSupplierID();
        }

        // People

        private void DeleteUsedPeople_Click(object sender, EventArgs e)
        {
            var peoplelist = DMS.PeopleManager.GetDataList();
            HashSet<string> peopleIdRemoveLsit = new HashSet<string>();
            HashSet<string> peopleRemoveLsit = new HashSet<string>();

            foreach (var p in peoplelist)
            {
                var queryClient = DMS.ClientManager.GetData(qi => qi.PeopleIDList.Contains(p.ID));

                if (queryClient == null)
                {
                    peopleRemoveLsit.Add(p.FirstName + " " + p.LastName + " - " + p.ID);
                    peopleIdRemoveLsit.Add(p.ID);
                }
            }

            if (peopleRemoveLsit == null || peoplelist.Count == 0)
            {
                AMS.MessageBox_v2.Show("No unallocated people found.", 1500);
                return;
            }

            StringBuilder sb = new StringBuilder();
            foreach (var i in peopleRemoveLsit)
                sb.AppendLine(i);

            if (AMS.MessageBox_v2.Show("The following (" + peopleRemoveLsit.Count + ") People are not associated with a client\r\n\r\n" + sb.ToString(), AMS.MessageType.Question) == AMS.MessageOut.YesOk)
            {
                AMS.Data.GobalManager.SuspendEvents();

                foreach (var i in peopleIdRemoveLsit)
                {
                    var person = DMS.PeopleManager.GetData(qi => qi.ID == i);

                    DMS.PeopleManager.Delete("Deleting Person", person, true);
                }

                AMS.Data.GobalManager.ResumeEvents();
                DMS.PeopleManager.LoadData();
            }
        }

        private void FormatData_Click(object sender, EventArgs e)
        {
            if (AMS.MessageBox_v2.Show("This will format all clients and people's data to preferred style.", AMS.MessageType.Question) == AMS.MessageOut.YesOk)
            {
                AMS.Data.GobalManager.SuspendEvents();
                var peopleList = DMS.PeopleManager.GetDataList();
                var clientList = DMS.ClientManager.GetDataList();

                int nr = 0;
                foreach (var i in clientList)
                {
                    nr++;
                    AMS.MessageBox_v2.ShowProcess("Formatting Clients", nr, clientList.Count);

                    if (!string.IsNullOrEmpty(i.PostalAddress)) i.PostalAddress = FixMultiLine(i.PostalAddress.Trim());
                    if (!string.IsNullOrEmpty(i.PhysicalAddress)) i.PhysicalAddress = FixMultiLine(i.PhysicalAddress.Trim());
                    if (!string.IsNullOrEmpty(i.Email)) i.Email = i.Email.ToLower().Trim();
                    if (!string.IsNullOrEmpty(i.Telephone)) i.Telephone = i.Telephone.ToLower().Trim();

                    i.Save("", true, false);
                }

                nr = 0;
                foreach (var i in peopleList)
                {
                    nr++;
                    AMS.MessageBox_v2.ShowProcess("Formatting People", nr, peopleList.Count);
                    if (!string.IsNullOrEmpty(i.Email)) i.Email = i.Email.ToLower().Trim();
                    if (!string.IsNullOrEmpty(i.ContactNumber)) i.ContactNumber = i.ContactNumber.ToLower().Trim();
                    i.Save(true);
                }

                AMS.MessageBox_v2.EndProcess();

                AMS.Data.GobalManager.ResumeEvents();
            }
        }

        /// <summary>
        /// Removes any empty lines in example the address
        /// </summary>
        private string FixMultiLine(string input)
        {
            StringBuilder sb = new StringBuilder();

            var lines = input.Split('\r', '\n');

            foreach (var i in lines)
                if (!string.IsNullOrEmpty(i)) sb.AppendLine(i.Trim());

            return sb.ToString();
        }

        private string FixAddress(string input)
        {
            StringBuilder sb = new StringBuilder();

            var lines = input.Split('\r', '\n');
            var newInput = "";

            for (int i = 0; i < lines.Count(); i++)
            {
                if (!string.IsNullOrEmpty(lines[i]) &&
                    (lines[i].ToLower().Trim() == "sa" || lines[i].ToLower().Trim() == "south africa"))
                    lines[i] = "";
                newInput += lines[i] + "\r\n";
            }
            var words = newInput.Split(' ');

            foreach (var i in words)
            {
                string word = i;
                if (!string.IsNullOrEmpty(word) && word.ToLower() == "po")
                    word = "PO";
                sb.Append(word + " ");
            }

            return FixMultiLine(sb.ToString()).Trim();
        }

        private void FixPOBox_Click(object sender, EventArgs e)
        {
            if (AMS.MessageBox_v2.Show("This will format all clients 'PO' in postal addresses.", AMS.MessageType.Question) == AMS.MessageOut.YesOk)
            {
                AMS.Data.GobalManager.SuspendEvents();
                var clientList = DMS.ClientManager.GetDataList();

                int nr = 0;
                foreach (var i in clientList)
                {
                    nr++;
                    AMS.MessageBox_v2.ShowProcess("Formatting Client", nr, clientList.Count);

                    string oldPO = i.PostalAddress;
                    string newPO = i.PostalAddress;

                    string oldAddress = i.PhysicalAddress;
                    string newAddress = i.PhysicalAddress;

                    if (!string.IsNullOrEmpty(i.PostalAddress)) newPO = FixAddress(i.PostalAddress.Trim());
                    if (!string.IsNullOrEmpty(i.PhysicalAddress)) newAddress = FixAddress(i.PhysicalAddress.Trim());

                    if (newPO != oldPO)
                    {
                        i.PostalAddress = newPO;
                        i.Save("PO Changed from " + oldPO + " to " + newPO, true, true);
                    }
                    if (newAddress != oldAddress)
                    {
                        i.PhysicalAddress = newAddress;
                        i.Save("Address Changed from " + oldAddress + " to " + newAddress, true, true);
                    }
                }

                AMS.MessageBox_v2.EndProcess();
                AMS.Data.GobalManager.ResumeEvents();
            }
        }

        // Maintenance

        private void CustomMaintenance_Click(object sender, EventArgs e)
        {
            if (searching) return;
            searching = true;

            DMS.SearchManager.DoMaintenanceSearch();

            searching = false;
        }

        private void currentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (searching) return;
            searching = true;

            DMS.SearchManager.DoMaintenanceSearch(0);

            searching = false;
        }

        private void nextMonthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (searching) return;
            searching = true;

            DMS.SearchManager.DoMaintenanceSearch(1);

            searching = false;
        }

        private void lastMonthToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (searching) return;
            searching = true;

            DMS.SearchManager.DoMaintenanceSearch(-1);

            searching = false;
        }

        private void twoMonthsBackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (searching) return;
            searching = true;

            DMS.SearchManager.DoMaintenanceSearch(-2);

            searching = false;
        }
        // Clients

        private void inActiveClints_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (searching) return;
            searching = true;

            DMS.SearchManager.DoInactiveClientSearch();

            searching = false;
        }

        #endregion Utilites

        private void AccountsClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ActiveMdiChild.WindowState = FormWindowState.Maximized;

            int width = this.ActiveMdiChild.Width - 16;
            int height = this.ActiveMdiChild.Height - 41;

            int accountWidth = width;
            int accountHeight = Convert.ToInt32(height / 3.5);

            int clientY = accountHeight;
            int clientWidth = accountWidth;
            int clientHeight = Convert.ToInt32(height / 0.5);

            var clientForm = MdiChildren[0];
            var accountForm = MdiChildren[1];

            clientForm.Show();
            clientForm.WindowState = FormWindowState.Normal;
            clientForm.Size = new Size(clientWidth, clientHeight);
            clientForm.Location = new Point(0, clientY);

            accountForm.Show();
            accountForm.WindowState = FormWindowState.Normal;
            accountForm.Size = new Size(accountWidth, accountHeight);
            accountForm.Location = new Point(0, 0);
        }

        private void quoteChaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (searching) return;
            searching = true;

            DMS.SearchManager.DoQuoteChase();

            searching = false;
        }

        private void vendorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (searching) return;
            searching = true;

            DMS.SearchManager.DoVendorSeach();

            searching = false;
        }

        private void quoteWithNoQuoteDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (searching) return;
            searching = true;

            DMS.SearchManager.DoQuotesNoQuoteDate();

            searching = false;
        }

        private void fixQuoteDatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AMS.Data.GobalManager.SuspendEvents();
            AMS.Data.GobalManager.SuspendControls();

            var quoteListNow = (from i in DMS.QuoteManager.GetDataList()
                                where
                                i.QuoteDate.Year == 2014 && i.QuoteDate.Month == 7 && i.QuoteDate.Day == 24
                                && i.ProgressType != Data.Quotes.ProgressType.Finalized
                                select i).ToList();

            foreach (var i in quoteListNow)
            {
                i.QuoteDate = new DateTime();
            }

            var quoteList = (from i in DMS.QuoteManager.GetDataList()
                             where
                             i.QuoteDate < new DateTime(2000, 1, 1)
                             && i.ProgressType != Data.Quotes.ProgressType.Finalized
                             select i).ToList();

            foreach (var i in quoteList)
            {
                string message = "QuoteDate is null";

                if (i.ProgressType == Data.Quotes.ProgressType.New)
                {
                    i.QuoteDate = i.Metadata.Created;
                    message = "QuoteDate was null and set to Created Date";
                }

                if (i.ProgressType == Data.Quotes.ProgressType.Mailed)
                {
                    i.QuoteDate = i.Metadata.EmailDate;
                    message = "QuoteDate was null and set to Last Emailed Date";
                }

                i.Save(message, true, true, i.ProgressType);
            }

            AMS.Data.GobalManager.ResumeEvents();
            AMS.Data.GobalManager.ResumeControls();
        }

        private void editorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var window = new UserInterface.Products.Forms.ProductList();
            window.Show();
        }

        private void maintenanceRenewalsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        //Statements

        private void statementsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (searching) return;
            searching = true;

            DMS.SearchManager.DoStatementSearch();

            searching = false;
        }

        private void resetOfficeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AMS.Users.UserManager.LocalData.LocationOutlook = null;
            AMS.Users.UserManager.LocalData.LocationWord = null;
        }

        //private void Reports_Button_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        ReportManager.Manager.ShowTemplates();
        //    }
        //    catch (Exception ex) { MessageBox.Show(ex.Message); }
        //}

        //private void VatPayable_Click(object sender, EventArgs e)
        //{
        //    string value = (sender as ToolStripMenuItem).Text;
        //    DateTime start = DateTime.Now;
        //    DateTime end;

        //    if (value.Contains("P1")) start = new DateTime(DateTime.Now.Year, 3, 1);
        //    if (value.Contains("P2")) start = new DateTime(DateTime.Now.Year, 5, 1);
        //    if (value.Contains("P3")) start = new DateTime(DateTime.Now.Year, 7, 1);
        //    if (value.Contains("P4")) start = new DateTime(DateTime.Now.Year, 9, 1);
        //    if (value.Contains("P5")) start = new DateTime(DateTime.Now.Year, 11, 1);
        //    if (value.Contains("P6")) start = new DateTime(DateTime.Now.Year + 1, 1, 1);

        //    end = start.AddMonths(2).AddDays(-1);

        //    if (value.Contains("Cust"))
        //    {
        //        var f = new AMS.Utilities.Forms.DatePicker("Start Date", new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(-1));
        //        f.ShowDialog();
        //        start = f.DateTimeValue;

        //        f = new AMS.Utilities.Forms.DatePicker("End Date", DateTime.Now)
        //        {
        //            DateTimeValue = DateTime.Now
        //        };
        //        f.ShowDialog();
        //        end = f.DateTimeValue;
        //    }

        //    ReportManager.Manager.ShowVATPayable(start, end);
        //}

        private void createTransactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var win = new Accounting.Forms.MultiCreatorForm();
            win.Show();
        }

        private void ReplaceCatalogNames_Click(object sender, EventArgs e)
        {
            var win = new Products.Forms.SearchReplace();
            win.Show();
        }

        private void clientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AMS.MessageBox_v2.Show("Are you sure you would like to re save all clients?", MessageType.Question) != MessageOut.YesOk)
                return;

            AMS.Data.GobalManager.SuspendControls();
            AMS.Data.GobalManager.SuspendEvents();

            foreach (var i in Data.DMS.ClientManager.GetDataList())
                i.Save("", true, false);

            AMS.Data.GobalManager.ResumeControls();
            AMS.Data.GobalManager.ResumeEvents();

            AMS.MessageBox_v2.Show("Done");
        }
    }
}