using AMS;
using AMS.Data.People;
using Data;
using Data.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace MMS_Design.IO.Forms
{
    public partial class Import : Form
    {
        TextInfo tx;

        public Import()
        {
            InitializeComponent();
        }
        private List<NewIDData> NewIDList;
        private AMS.Data.IO.aFile NewIDFileName;
        DataSet access;
        int
            peopleNr,
            peopleTotal,
            clientNr,
            clientTotal,
            dongleNr,
            dongleTotal,
            transNr,
            transTotal;

        // Load

        private void Import_Load(object sender, EventArgs e)
        {
            #region ThemeColors

            ThemeColors.SetBorders(this);
            button6.BackColor = ThemeColors.Menu;
            button6.ForeColor = ThemeColors.MenuText;

            #endregion

            NewIDFileName = new AMS.Data.IO.aFile("NewIDList", AMS.Settings.Program.Directories.Templates, AMS.Data.DataType.Xml);

            access = new DataSet();
            tx = new CultureInfo("en-ZA", false).TextInfo;
            ImportOdDb();

            try
            {
                NewIDList = (List<NewIDData>)AMS.IO.XML_v1.Reader<List<NewIDData>>(AMS.Settings.Program.Directories.Templates + "\\" + NewIDFileName.Name + "." + NewIDFileName.Extension);
            }
            catch { }
            if (NewIDList == null) NewIDList = new List<NewIDData>();
        }

        // Methods

        private void ImportOdDb()
        {
            if (access.Tables.Count < 1)
            {
                //AMS.MessageBox_v2.ShowProcess("Getting Access Data");
                //using (MMS_Design_Import.Database db = new MMS_Design_Import.Database())
                //    access = db.DataSet;
                //AMS.MessageBox_v2.EndProcess();
            }
        }

        private void CreateCheckNewID()
        {
            AMS.MessageBox_v2.ShowProcess("Checking old ID list");

            try
            {
                NewIDList = (List<NewIDData>)AMS.IO.XML_v1.Reader<List<NewIDData>>(AMS.Settings.Program.Directories.Templates + "\\" + NewIDFileName.Name + "." + NewIDFileName.Extension);
            }
            catch { }
            if (NewIDList == null) NewIDList = new List<NewIDData>();
            // List of old IDs
            List<string> oldIDList = new List<string>();
            foreach (DataRow row in access.Tables["Customer"].Rows)
                oldIDList.Add(row["CustomerID"].ToString());

            AMS.MessageBox_v2.ShowProcess("Checking old ID list\r\nOld records: " + oldIDList.Count);

            int nr = 0;
            foreach (string id in oldIDList)
            {
                nr++;

                // Check if ID is already in the NewIDList, if null, add to list
                var queryCheck = (from i in NewIDList
                                  where i.OldID == id
                                  select i).FirstOrDefault();

                if (queryCheck == null)
                {
                    AMS.MessageBox_v2.ShowProcess("Checking old ID list\r\nAdding Record: " + id + " - " + nr + "/" + oldIDList.Count);

                    var oldClientDT = access.Tables["Customer"];
                    var oldClient = (from i in oldClientDT.AsEnumerable()
                                     where i.ItemArray[0].ToString() == id
                                     select i).FirstOrDefault();

                    NewIDList.Add(new NewIDData()
                    {
                        OldID = id,
                        NewID = string.Format("AM{0:0000}", NewIDList.Count + 1),
                        CompanyName = oldClient[1].ToString()
                    });
                }
            }

            if (NewIDList.Count > 0)
            {
                if (AMS.MessageBox_v2.Show("Enter the amount of clients you want to add.r\n\r\nFor all data press Cancel/No", AMS.MessageType.Question) == AMS.MessageOut.YesOk)
                {
                    int count = Convert.ToInt16(AMS.MessageBox_v2.MessageValue);
                    while (NewIDList.Count > count)
                        NewIDList.Remove(NewIDList[NewIDList.Count - 1]);
                }
            }

            // Save NewIDList
            AMS.IO.XML_v1.Writter<List<NewIDData>>(NewIDList, NewIDFileName, "Saving New Id list from the Access database", false);
            AMS.MessageBox_v2.EndProcess();
            id_Label.Text = NewIDList.Count + " / " + oldIDList.Count + " Ids were read/created";
            clientTotal = NewIDList.Count;


        }

        private void GetClientData()
        {
            AMS.Data.GobalManager.SuspendEvents();
            AMS.MessageBox_v2.ShowProcess("Importing Client and Main Person Data");

            foreach (var id in NewIDList)
            {
                string newAccount = id.NewID;

                var oldClient = (from i in access.Tables["Customer"].AsEnumerable()
                                 where i["CustomerID"].ToString() == id.OldID
                                 select i).FirstOrDefault();

                var oldClientLog = (from i in access.Tables["tblKlienteInteraksie"].AsEnumerable()
                                    where i["CustomerID"].ToString() == id.OldID
                                    select i).ToList();

                var oldClientCourier = (from i in access.Tables["tblCourier"].AsEnumerable()
                                        where i["CustomerID"].ToString() == id.OldID
                                        select i).ToList();

                if (oldClient != null && !oldClient["Company"].ToString().Contains("**"))
                {
                    AMS.MessageBox_v2.ShowProcess("Importing Client\r\n" + oldClient.ItemArray[1] + "\r\n\r\n" + id.OldID + " -> " + id.NewID); ;

                    var newCLient = new Data.People.Client();

                    newCLient.Name = oldClient["Company"].ToString().ToUpper();

                    StringBuilder sb = new StringBuilder();
                    if (oldClient["BusinessDeliveryStreet1"] != null) sb.Append(oldClient["BusinessDeliveryStreet1"] + "\r\n");
                    if (oldClient["BusinessDeliveryStreet2"] != null) sb.Append(oldClient["BusinessDeliveryStreet2"] + "\r\n");
                    if (oldClient["BusinessDeliveryCity"] != null) sb.Append(oldClient["BusinessDeliveryCity"] + "\r\n");
                    if (oldClient["BusinessCountry"] != null) sb.Append(oldClient["BusinessCountry"] + "\r\n");
                    if (oldClient["BusinessStreetCode"] != null) sb.Append(oldClient["BusinessStreetCode"] + "\r\n");

                    newCLient.PhysicalAddress = sb.ToString();

                    sb = new StringBuilder();

                    if (oldClient["BusinessStreet"] != null) sb.Append(oldClient["BusinessStreet"] + "\r\n");
                    if (oldClient["BusinessStreet2"] != null) sb.Append(oldClient["BusinessStreet2"] + "\r\n");
                    if (oldClient["BusinessCity"] != null) sb.Append(oldClient["BusinessCity"] + "\r\n");
                    if (oldClient["BusinessCountry"] != null) sb.Append(oldClient["BusinessCountry"] + "\r\n");
                    if (oldClient["BusinessPostalCode"] != null) sb.Append(oldClient["BusinessPostalCode"] + "\r\n");

                    newCLient.PostalAddress = sb.ToString();

                    newCLient.Telephone = oldClient["BusinessPhone"].ToString();
                    newCLient.Telephone += "; " + oldClient["MobilePhone"].ToString();
                    newCLient.Fax = oldClient["BusinessFax"].ToString();
                    newCLient.VatNr = oldClient["VatRef"].ToString();
                    newCLient.Catagory = oldClient["Categories"].ToString();
                    newCLient.Email = oldClient["Email"].ToString();
                    newCLient.CurrencyUsed = oldClient["Forex"].ToString();

                    try { if (oldClient["Maintenance"] != null) newCLient.Expirydate = (DateTime)oldClient["Maintenance"]; }
                    catch { newCLient.Expirydate = new DateTime(); }
                    try { if (oldClient["DateCreated"] != null)newCLient.Metadata.Created = (DateTime)oldClient["DateCreated"]; }
                    catch { newCLient.Metadata.Created = new DateTime(); }

                    if (Convert.ToBoolean(oldClient["skulddongle"].ToString()))
                    {
                        AMS.MessageBox_v2.Show("Skuld dongle " + oldClient["Company"] + " " + oldClient["skulddongleno"]);
                        newCLient.Notes += "Outstanding Dongle: " + oldClient["skulddongleno"].ToString() + "\r\n";
                    }

                    if (!string.IsNullOrEmpty("" + oldClient["Agent"])) newCLient.Notes = "Agent: " + oldClient["Agent"].ToString() + "\r\n";
                    if (!string.IsNullOrEmpty("" + oldClient["Notes"])) newCLient.Notes += oldClient["Notes"].ToString() + "\r\n";
                    if (!string.IsNullOrEmpty("" + oldClient["Keywords"])) newCLient.Notes += oldClient["Keywords"].ToString() + "\r\n";

                    newCLient.IsInternational = Convert.ToBoolean(oldClient["International"].ToString());
                    newCLient.VendorNr = oldClient["VendorNr"].ToString();
                    newCLient.Active = (bool)oldClient["ActiveStatus"];
                    newCLient.Account = newAccount;

                    // Get Log
                    if (oldClientLog != null)
                    {
                        foreach (var log in oldClientLog)
                        {
                            var newLog = "User: " + log["User"] + " - " + log["nota1"] + " - " + log["nota2"];
                            newCLient.AddDataLog("Log", newLog, AMS.Data.DataType.Client);
                        }
                    }

                    // Get courier info
                    if (oldClientCourier != null)
                    {
                        foreach (var cour in oldClientCourier)
                        {
                            var newLog = "User: " + cour["User"] + " - " + cour["Service Provider"] + " " + cour["Tracking Number"] + " - " + cour["Item"] + " - " + cour["Date"];
                            newCLient.AddDataLog("Courier", newLog, AMS.Data.DataType.Client);
                        }
                    }

                   newCLient.Name = tx.ToTitleCase(newCLient.Name.ToLower());
                   newCLient.Account = tx.ToUpper(newCLient.Account.ToLower());
                   newCLient.Catagory = tx.ToTitleCase(("" + newCLient.Catagory).ToLower());
                   newCLient.Country = tx.ToTitleCase(("" + newCLient.Country).ToLower());
                   newCLient.Email = tx.ToLower(("" + newCLient.Email).ToLower());
                   newCLient.PhysicalAddress = tx.ToTitleCase(("" + newCLient.PhysicalAddress).ToLower());
                   newCLient.PostalAddress = tx.ToTitleCase(("" + newCLient.PostalAddress).ToLower());

                    newCLient.Save("Client was Imported.", true, true);

                    clientNr++;
                }
            }

            AMS.MessageBox_v2.EndProcess();
            AMS.Data.GobalManager.ResumeEvents();

            client_Label.Text += "Clients: " + clientNr + "/" + NewIDList.Count + " read!";
            client_Label.Update();
        }

        private void GetPeopleData()
        {
            AMS.Data.GobalManager.SuspendEvents();
            AMS.MessageBox_v2.ShowProcess("Importing People Data");

            int nr = 0;
            int count = NewIDList.Count;

            foreach (var id in NewIDList)
            {
                nr++;
                HashSet<Data.People.Person> peopleList = new HashSet<Data.People.Person>();

                string newAccount = id.NewID;

                var oldPeopleList = (from i in access.Tables["tblMailList"].AsEnumerable()
                                     where i.ItemArray[1].ToString() == id.OldID
                                     select i).ToList();

                if (oldPeopleList != null && oldPeopleList.Count > 0)
                {
                    var oldClient = (from i in access.Tables["Customer"].AsEnumerable()
                                     where i["CustomerID"].ToString() == id.OldID
                                     select i).FirstOrDefault();

                    foreach (var oldPerson in oldPeopleList)
                    {
                        Data.People.Person p = new Data.People.Person();
                        p.FirstName = oldPerson["FirstName"].ToString();
                        p.LastName = oldPerson["LastName"].ToString();
                        p.Email = oldPerson["email"].ToString();
                        p.Account = id.NewID;
                        p.MailListExclude = (bool)oldPerson["ExcludeMe"];
                        p.Referee = (string)oldPerson["VERSKAFFER"];

                        if (oldClient["FirstName"].ToString() == p.FirstName && oldClient["LastName"].ToString() == p.LastName)
                        {
                            p.ContactNumber += " " + oldClient["MobilePhone"];
                            if (!string.IsNullOrEmpty(p.Email) && !string.IsNullOrEmpty(oldClient["Email"].ToString()) && p.Email.Trim().ToUpper() != oldClient["Email"].ToString().Trim().ToUpper()) p.Email += "; " + oldClient["Email"];
                            //p.MainContact = true;
                        }

                        peopleList.Add(p);
                    }

                    //// Get main contact too
                    //if (!string.IsNullOrEmpty(oldClient["FirstName"] + ""))
                    //{
                    //    Data.People.Person mainP = new Data.People.Person();
                    //    mainP.FirstName = oldClient["FirstName"].ToString();
                    //    mainP.LastName = oldClient["LastName"].ToString();
                    //    mainP.Email = oldClient["Email"].ToString();
                    //    mainP.Email = oldClient["BusinessPhone"].ToString();
                    //    mainP.Email = oldClient["MobilePhone"].ToString();
                    //    mainP.Account = id.NewID;
                    //    mainP.MainContact = true;
                    //    peopleList.Add(mainP);
                    //}

                    // Finally save contact list
                    var client = DMS.ClientManager.GetData(i => i.Account == id.NewID);
                    var idList = new HashSet<string>();

                    foreach (var person in peopleList)
                    {
                        person.Email = tx.ToTitleCase(("" + person.Email).ToLower());
                        person.FirstName = tx.ToTitleCase(("" + person.FirstName).ToLower());
                        person.Save(false);
                        AMS.MessageBox_v2.ShowProcess("Importing " + person.DisplayName);

                        //if (person.MainContact)
                        //{
                        //    if (client != null)
                        //    {
                        //        client.MainPersonID = person.ID;
                        //    }
                        //}

                        idList.Add(person.ID);
                    }
                    client.PeopleIDList = idList;
                    client.Save("Imported People List", true, false);
                }
            }

            AMS.Data.GobalManager.ResumeEvents();
            AMS.MessageBox_v2.EndProcess();
        }

        private void GetProducts(string catalogName)
        {
            //
            //
            //  ADD Supplier ID
            //
            //

            string oldTable = "";
            if (catalogName == "Model Maker") oldTable = "mmdong";
            if (catalogName == "Road Maker") oldTable = "rmdong";
            if (catalogName == "Pipe Maker") oldTable = "pmdong";
            if (catalogName == "Survey Maker") oldTable = "smdong";

            AMS.Data.GobalManager.SuspendEvents();
            AMS.MessageBox_v2.ShowProcess("Importing " + catalogName + " Dongle Data");
            int productNr = 0;
            int productCount = 0;

            var catalog = DMS.CatalogManager.GetData(qi => qi.Name == catalogName);

            int clientNr = 0;
            foreach (var id in NewIDList)
            {
                clientNr++;
                string headermessage = "Importing " + catalogName + " Dongle Data\r\n" + id.CompanyName + " [" + clientNr + "/" + NewIDList.Count + "]" + "\r\n\r\n";
                AMS.MessageBox_v2.ShowProcess(headermessage);

                var client = DMS.ClientManager.GetData(qi => qi.Account == id.NewID);
                string newAccount = id.NewID;

                DataTable dt = access.Tables[oldTable];

                var oldDongles = (from mm in dt.AsEnumerable()
                                  where mm.ItemArray[0].ToString() == id.OldID
                                  select mm).ToList();

                productCount += oldDongles.Count;
                AMS.MessageBox_v2.ShowProcess(headermessage + productCount + " data found\r\n");

                foreach (var i in oldDongles)
                {
                    AMS.MessageBox_v2.ShowProcess(headermessage + productCount + " data found\r\n" + i["Secrno"].ToString());

                    var newP = new Product(id.NewID);
                    newP.CatalogName = catalogName;
                    newP.Name = i["Secrno"].ToString();
                    string value = "0";
                    if (i["Value"] != null) value += i["Value"].ToString();
                    newP.PriceExVat = Convert.ToDecimal(value);
                    if (dt.Columns.Contains("Punte")) newP.Version = i["Punte"].ToString();
                    if ((bool)i["Maintenance"]) newP.ExpiryDate = client.Expirydate;

                    newP.Notes = "Imported from Access";
                    foreach (var line in i["notes"].ToString().Split('\n'))
                        if (!string.IsNullOrEmpty(line)) newP.AddDataLog("Import", line, AMS.Data.DataType.Product); // = ("" + i["notes"] + "\r\n\r\n" + i["Gen_notes"]).Trim();

                    int userCount = 1;
                    if (i["Netusers"] != null && Convert.ToInt32("0" + i["Netusers"]) > 1) userCount = (int)((double)i["Netusers"]);
                    newP.UserCount = userCount;
                    newP.Stolen = (bool)i["Stolen"];

                    var productItems = new List<Data.Products.Product>();
                    int modNr = 0;
                    foreach (var pi in catalog.GetItemList())
                    {
                        if (pi.Name != null && pi.Name.Length > 0)
                        {
                            bool selected = false;
                            modNr++;
                            selected = (i["Mod" + modNr] != null && i["Mod" + modNr].ToString() == "-1");
                            productItems.Add(new Data.Products.Product() { Selected = selected, Name = pi.Name, Code = pi.Code });
                        }
                    }

                    newP.ItemList = productItems;

                    // Get notes
                    var dongleNotes = (from qi in access.Tables["tblDongleNotes"].AsEnumerable()
                                       where qi["Secrno"].ToString() == newP.Name
                                       select qi).ToList();
                    if (dongleNotes != null)
                    {
                        foreach (var note in dongleNotes)
                        {
                            StringBuilder sb = new StringBuilder();

                            sb.Append(note["Notes"].ToString());
                            if (!string.IsNullOrEmpty("" + note["OldDongle1"])) sb.Append(" - " + note["OldDongle1"]);
                            if (!string.IsNullOrEmpty("" + note["OldDongle2"])) sb.Append(" - " + note["OldDongle2"]);
                            if (!string.IsNullOrEmpty("" + note["OldDongle3"])) sb.Append(" - " + note["OldDongle3"]);
                            if (!string.IsNullOrEmpty("" + note["OldDongle4"])) sb.Append(" - " + note["OldDongle4"]);
                            if (!string.IsNullOrEmpty("" + note["OldDongle5"])) sb.Append(" - " + note["OldDongle5"]);
                            if (!string.IsNullOrEmpty("" + note["OldDongle6"])) sb.Append(" - " + note["OldDongle6"]);

                            newP.AddDataLog("Import", sb.ToString(), AMS.Data.DataType.Product);
                        }
                    }
                    newP.SupplierID = "AS001";
                    newP.Save("Imported from Access", true, true);
                }
            }

            AMS.MessageBox_v2.EndProcess();
            AMS.Data.GobalManager.ResumeEvents();

            dongles_Label.Text = "Products: " + productNr + "/" + productCount + " read!\r\n";
            dongles_Label.Update();
        }

        private void GetTransactions()
        {
            AMS.Data.GobalManager.SuspendEvents();
            AMS.MessageBox_v2.ShowProcess("Importing Transaction Data");
            int transNr = 0;
            int transCount = 0;

            // get each id's data
            foreach (var id in NewIDList)
            {
                string headermessage = "Importing Transaction Data\r\n" + id.CompanyName + "\r\n\r\n";
                AMS.MessageBox_v2.ShowProcess(headermessage);

                // Get client info
                var client = DMS.ClientManager.GetData(qi => qi.Account == id.NewID);
                string newAccount = id.NewID;

                // Get list of data table info using the old ID
                DataTable dt = access.Tables["tblFakture"];
                var oldTransactions = (from qi in dt.AsEnumerable()
                                       where qi["CustomerID"].ToString() == id.OldID
                                       select qi).ToList();

                transCount += oldTransactions.Count;
                AMS.MessageBox_v2.ShowProcess(headermessage + transCount + " data found\r\n");

                // Run through data table list and get their transactions
                foreach (var i in oldTransactions)
                {
                    AMS.MessageBox_v2.ShowProcess(headermessage + transCount + " data found\r\n" + dt.TableName);

                    Data.Transactions.Transaction newT = new Data.Transactions.Transaction();
                    newT.Account = id.NewID;
                    newT.ID = i["FaktuurNo"].ToString();
                    newT.Metadata.Created = DateTime.Parse(i["FaktuurDatum"] + "");
                    newT.TransactionDate = DateTime.Parse(i["FaktuurDatum"] + "");
                    newT.Metadata.EmailDate = DateTime.Parse(i["FaktuurDatum"] + "");
                    newT.DueDate = DateTime.Parse(i["BetaalDatum"] + "");

                    newT.ClientRef = i["KlientVerwysing"].ToString();
                    newT.UseVat = (bool)i["HefBTW"];
                    newT.Currency = i["Currency"] + "";
                    newT.Forex = i["Wisselkoers"] + "";
                    newT.IsVoid = (bool)i["Void"];
                    newT.Notes = "Imported from Access: " + i["Note"].ToString();
                    // newT.IsCreditNote = (bool)i["CreditNote"];
                    newT.Type = Data.Transactions.TransactionType.Invoice;

                    var oldTransDetail = (from qi in access.Tables["tblFaktuurDetail"].AsEnumerable()
                                          where qi.ItemArray[5].ToString() == i.ItemArray[1].ToString()
                                          select qi).ToList();

                    foreach (var line in oldTransDetail)
                    {
                        var p = new Data.Products.Product();
                        decimal value = Convert.ToDecimal(line["Bedrag"].ToString());

                        p.Description = line["Item"].ToString() + " x" + line["Aantal"];
                        p.Name = line["DongleNo"].ToString();
                        p.PriceExVat = value;
                        if (!client.IsInternational) p.PriceExVat /= 1.14m;
                        p.PriceExVat *= Convert.ToDecimal(line["Aantal"] + "");
                        p.Discount = Convert.ToDecimal(line["Afslag"] + "");

                        newT.ItemList.Add(p);
                    }

                    bool isPaid = Convert.ToBoolean(i["BetalingOntvang"].ToString());
                    if (isPaid)
                    {
                        decimal amount = newT.ItemList.Sum(qi => qi.PriceExVat);
                        //newT.ReceiptAllocationList.Add(new Data.Accounts.ReceiptAllocation()
                        //{
                        //    //Amount = amount,
                        //    //DateFinalized = DateTime.Now,
                        //    //Description = "Imported",
                        //});
                    }

                    newT.Save("Added invoice " + newT.ID, true, false);
                }
            }

            AMS.MessageBox_v2.EndProcess();
            AMS.Data.GobalManager.ResumeEvents();

            invoice_Label.Text = "Transactions: " + transNr + "/" + transCount + " read!\r\n";
            invoice_Label.Update();
        }

        private void GetExtraKeywords()
        {

        }

        // Events

        private void GetClientData_Click(object sender, EventArgs e)
        {
            GetClientData();
        }

        private void close_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NewIDList_Click(object sender, EventArgs e)
        {
            CreateCheckNewID();
        }

        private void Connect_Click(object sender, EventArgs e)
        {
            //AMS.MessageBox_v2.ShowProcess("Getting Access Data");
            //using (MMS_Design_Import.Database db = new MMS_Design_Import.Database())
            //    access = db.DataSet;
            //AMS.MessageBox_v2.EndProcess();
        }

        private void GetProducts_Click(object sender, EventArgs e)
        {
            GetProducts("Model Maker");
            GetProducts("Road Maker");
            GetProducts("Survey Maker");
            GetProducts("Pipe Maker");
        }

        private void GetPeople_Click(object sender, EventArgs e)
        {
            GetPeopleData();
        }

        private void GetAllDate_Event(object sender, EventArgs e)
        {
            CreateCheckNewID();
            GetClientData();
            GetPeopleData();
            GetProducts("Model Maker");
            GetProducts("Road Maker");
            GetProducts("Survey Maker");
            GetProducts("Pipe Maker");
            GetTransactions();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GetTransactions();
        }
    }
}