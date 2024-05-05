using Data;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace UserInterface.IO.Forms
{
    /// <summary>
    /// Interaction logic for Export.xaml
    /// </summary>
    public partial class Export : Window
    {
        public Export()
        {
            InitializeComponent();

            Loaded += Export_Loaded;
        }

        void Export_Loaded(object sender, RoutedEventArgs e)
        {
            HashSet<string> productCategories = new HashSet<string>();

            foreach (var i in DMS.ProductManager.GetDataList())
                productCategories.Add(i.CatalogName);

            product_ListBox.ItemsSource = productCategories;
        }

        // Methods

        private DataTable OLDExportTable()
        {
            DataTable dt = new DataTable("Export");


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

            AMS.MessageBox_v2.EndProcess();
            return dt;
        }

        private DataTable ExportTable()
        {
            HashSet<IO.Export> resultList = new HashSet<IO.Export>();
            List<IO.Export> queryList = new List<IO.Export>();
            List<IO.Export> removeList = new List<IO.Export>();
            List<IO.Export> addList = new List<IO.Export>();
            HashSet<string> productCategories = new HashSet<string>();

            foreach (var i in product_ListBox.SelectedItems)
                productCategories.Add(i.ToString());

            int count = DMS.ClientManager.GetDataList().Count;
            int nr = 0;

            foreach (var client in DMS.ClientManager.GetDataList())
            {
                nr++;
                AMS.MessageBox_v2.ShowProcess("Reading " + count + " Client Data\r\n" + client.Name, nr, count);
                HashSet<Products> products = new HashSet<Products>();
                var queryProducts = DMS.ProductManager.GetDataList(qi => qi.Account == client.Account);
                foreach (var item in queryProducts)
                    products.Add(new Products(item.CatalogName, item.Name));

                queryList.Add(new IO.Export(client, products));

                if (includePeople_CheckBox.IsChecked.Value)
                {
                    foreach (var person in client.GetPeopleList())
                        queryList.Add(new IO.Export(client.Name, person));
                }
            }

            AMS.MessageBox_v2.ShowProcess("Filtering Data");

            #region Split Contact Numbers

            if (splitContactNumbers_CheckBox.IsChecked.Value)
            {
                foreach (var i in queryList)
                {
                    var contactList = ContactList(i.ContactNumber);
                    if (i.ContactNumber != null && contactList.Count > 1)
                    {
                        removeList.Add(i);

                        foreach (var contact in contactList)
                        {
                            i.ContactNumber = contact;
                            addList.Add(i);
                        }
                    }
                }
            }

            #endregion

            #region Split Emails

            if (splitEmails_CheckBox.IsChecked.Value)
            {
                foreach (var i in queryList)
                {
                    if (i.Email != null && i.Email.Contains(";"))
                    {
                        removeList.Add(i);

                        var emailSplit = i.Email.ToString().Split(';');

                        foreach (var split in emailSplit)
                        {
                            i.Email = split;
                            addList.Add(i);
                        }
                    }
                }
            }

            #endregion

            #region Finally Remove and Add the differences

            foreach (var item in removeList)
            {
                var queryItem = (from i in queryList
                                 where i.ID == item.ID
                                 select i).FirstOrDefault();

                queryList.Remove(queryItem);
            }

            foreach (var item in addList)
            {
                queryList.Add(item);
            }

            foreach (var i in queryList)
                resultList.Add(i);

            #endregion

            AMS.MessageBox_v2.ShowProcess("Creating Export Data");

            DataTable dt = new DataTable("Export");

            dt.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("Client Name"),
                new DataColumn("Person"),
                new DataColumn("Contact Number"),
                new DataColumn("Email"),
                new DataColumn("Expiry Date"),
                new DataColumn("Catagory"), //CA0323
            });

            foreach (var i in productCategories) dt.Columns.Add(new DataColumn("Product " + i));

            foreach (var client in resultList)
            {
                var newObject = new object[dt.Columns.Count];
                newObject[0] = client.ClientName;
                newObject[1] = client.Person;
                newObject[2] = client.ContactNumber;
                newObject[3] = client.Email;
                newObject[4] = client.ExpiryDate;
                newObject[5] = client.Catagory; //CA0323
                int next = 6; //CA0323 waarde was 5 nou is dit 6. weet nie regtig waarvoor die is nie
                foreach (var cat in productCategories)
                {
                    if (client.Products != null)
                    {
                        var products = client.Products.Where(qi => qi.Category == cat);

                        string productstring = "";

                        foreach (var item in products)
                        {
                            productstring += item.Name + "\r\n";
                        }

                        newObject[next] = productstring.Trim();
                        next++;
                    }
                }
                dt.Rows.Add(newObject);
            }

            AMS.MessageBox_v2.EndProcess();

            return dt;
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

        // Events

        private void Export_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog savedialog = new SaveFileDialog();
            savedialog.DefaultExt = "xml";
            savedialog.FileName = string.Format("Export {0:dd MM yy}.xml", DateTime.Now);

            savedialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var resutls = savedialog.ShowDialog();

            if (resutls == true)
            {
                if (string.IsNullOrEmpty(savedialog.FileName)) { AMS.MessageBox_v2.Show("No file name was specified"); return; }


                AMS.MessageBox_v2.ShowProcess("Saving Export Data\r\n" + savedialog.FileName);
                ExportTable().WriteXml(savedialog.FileName);
                AMS.MessageBox_v2.EndProcess();
                System.Diagnostics.Process.Start(savedialog.InitialDirectory);
            }

        }
    }
}
