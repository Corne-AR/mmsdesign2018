using AMS.Data.Keys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Data.People
{
    [Serializable]
    public class aClient : Data.DataClass
    {
        public string Account { get; set; } // PK
        public string Name { get; set; }

        public string Catagory { get; set; }

        public HashSet<string> PeopleIDList { get; set; }

        public string VendorNr { get; set; }
        public string VatNr { get; set; }

        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Fax { get; set; }

        public string MainPersonID { get; set; }
        public aPerson GetMainContact
        {
            get
            {
                var person = aDMS.PeopleManager.GetData(i => i.ID == MainPersonID);
                if (person == null) person = new aPerson();
                return person;
            }
        }

        public string CurrencyUsed { get; set; }

        public string PhysicalAddress { get; set; }
        public string PostalAddress { get; set; }
        public string Country { get; set; }

        public bool IsInternational { get; set; }
        public bool Active { get; set; }

        public DateTime Expirydate { get; set; }
        public string Keywords { get; set; }

        public aClient()
        {
            PeopleIDList = new HashSet<string>();
        }
        
        public bool HasSupport
        {
            get
            {
                return (new DateTime(Expirydate.Year, Expirydate.Month, 1) >= new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(-2));
            }
        }
        
        public bool HasPerson(string Search)
        {
            bool hasPerson = false;

            foreach (var p in PeopleIDList)
            {
                var queryPeople = aDMS.PeopleManager.GetData(i => i.ID == p && i.DisplayName.ToLower().Contains(Search));
                if (queryPeople != null)
                {
                    hasPerson = true;
                    break;
                }
            }

            return hasPerson;
        }

        public bool Save(string Message, bool Overwrite, bool UseLog)
        {
            ID = Account;

            SetFile(Account, AMS.Settings.Program.Directories.Clients + Account, Data.DataType.Client);

            if (UseLog) AddDataLog(Account, Message, DataType.Client);
            bool saved = AMS.aDMS.ClientManager.Save(this, Message, Overwrite, true);

            UserPKManager.UpdatePk(KeyType.Account, Account);

            return saved;
        }
    }
}