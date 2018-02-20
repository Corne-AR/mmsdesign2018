using AMS.Data;
using AMS.Data.People;
using AMS.Data.Tasks;
using Data.Catalogs;
using Data.Accounts;
using Data.Products;
using Data.Quotes;
using Data.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.People;

namespace Data
{
    public static class DMS
    {
        public static DataManager<Client> ClientManager = new DataManager<Client>(DataType.Client);
        public static DataManager<Person> PeopleManager = new DataManager<Person>(DataType.Person);
        public static DataManager<aTask> TaskManager = AMS.aDMS.TaskManager;
        public static DataManager<Quote> QuoteManager = new DataManager<Quote>(DataType.Quote);
        public static DataManager<Product> ProductManager = new DataManager<Product>(DataType.Product);
        public static DataManager<Catalog> CatalogManager = new DataManager<Catalog>(DataType.Catalog);
        public static DataManager<Transaction> TransactionManager = new DataManager<Transaction>(DataType.Transaction);
        public static Data.Accounts.AccountsManager AccountsManager = new AccountsManager();
        public static Data.Catalogs.CatalogGroupManager CatalogGroupManager = new Data.Catalogs.CatalogGroupManager();
        public static Data.Schedule.ScheduleManager ScheduleManager = new Schedule.ScheduleManager();
        public static ProcessPreferencesManager ProcessPreferencesManager = new ProcessPreferencesManager();
        public static Communications.MailManger MailManager = new Communications.MailManger();

        public static Search.SearchManager SearchManager = new Search.SearchManager();
        public static Search.SearchLinkManager SearchLinkManager = new Search.SearchLinkManager();
        public static OldSearch OLDSearch = new OldSearch();

        //public static AMS.Reporting.Manager ReportManager = new AMS.Reporting.Manager(new UnitOfWork(), AMS.Settings.Program.Directories.Templates);

        // Keywords
        private static List<ClientKeyword> keywordList;
        public static List<ClientKeyword> KeywordList
        {
            get
            {
                //if (keywordList == null || keywordList.Count == 0)
                {
                    keywordList = new List<ClientKeyword>();

                    foreach (var client in ClientManager.GetDataList())
                    {
                        var key = new ClientKeyword();
                        key.Keywords = client.Keywords;
                        key.Account = client.Account;

                        if (key.Keywords != null && key.Keywords.Length > 2)
                            keywordList.Add(key);
                    }
                }
                return keywordList;
            }
        }

        /// <summary>
        /// 0.08
        /// </summary>
        public static decimal MaintenanceFactor = 0.08m;
        public static decimal CODFactor = 0.875m;

        /// <summary>
        /// 370.5
        /// </summary>
        public static decimal MinMaintenanceValue { get { return AMS.Suite.SuiteManager.Profile.MinMaint; } }

        // Suppliers
        private static HashSet<Client> supplierList = new HashSet<Client>();
        private static StringBuilder supplierListInfo;
        public static HashSet<Client> GetSupplierList
        {
            get
            {
                if (supplierList == null || supplierList.Count == 0)
                    GetSupplierInfo();

                return supplierList;
            }
        }
        public static string GetSupplierListInfo
        {
            get
            {
                if (supplierListInfo == null || supplierListInfo.Length == 0) GetSupplierInfo();
                if (supplierListInfo != null) return supplierListInfo.ToString();
                else return "No Suppliers Loaded";
            }
        }

        private static void GetSupplierInfo()
        {
            supplierList = new HashSet<Client>();
            supplierListInfo = new StringBuilder();

            foreach (var i in DMS.ClientManager.GetDataList(i => i.Catagory == "Supplier"))
            {
                supplierList.Add(i);
                supplierListInfo.AppendLine(i.Name + " - " + i.ID);
            }
        }

        public static void MaintenanceMail(Data.People.Client Client)
        {
            var mail = MailManager.NewMail(Client.Account, Client.GetMainContact?.DisplayName, Client.GetMainContact?.Email, "Software Support Agreement", Communications.TemplateTypes.MaintenanceReminder);
            AMS.Communications.MailManager.SendMail(mail);
        }
    }

    public class ClientKeyword
    {
        public string Keywords { get; set; }
        public string Account { get; set; }
    }
}