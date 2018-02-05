using AMS.Data;
using AMS.Data.Keys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Data.People
{
    [Serializable]
    public class aPerson : DataClass
    {
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public string IDNr { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string ContactNumberAlternative { get; set; }
        public string PhysicalAddress { get; set; }
        public string PostalAddress { get; set; }
        public string Status { get; set; }
        public string Branch { get; set; }
        public string EmployeeNumber { get; set; }
        public string Gender { get; set; }
        public string JobTitle { get; set; }
        public string Role { get; set; }
        public string NOKName { get; set; }
        public string NOKContactNr { get; set; }
        public int SupervisorID { get; set; }
        public string AccessLevel { get; set; }
        public aCompany CurrentCompany { get; set; }
        public aCompany PreviousCompany { get; set; }
        public DateTime DateJoined { get; set; }
        public DateTime DateLeft { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool DisplayNickName { get; set; }
        public string CertificateNr { get; set; }
        
        public aPerson()
        {
            CurrentCompany = new aCompany();
            PreviousCompany = new aCompany();

            if (Role == null) Role = "";
        }

        public string DisplayName
        {
            get
            {
                string displayName = "";
                if (DisplayNickName) displayName = NickName;
                else displayName = FirstName + " " + LastName;

                return displayName;
            }
        }

        public bool Save()
        {
            if (ID == null || ID.Trim() == "") ID = AMS.Data.Keys.UserPKManager.NewUserPK(Keys.KeyType.Person);

            FirstName = FirstName.Trim();
            LastName = LastName.Trim();
            SetFile(ID + " - " + FirstName + " " + LastName, AMS.Settings.Program.Directories.People + FirstName + " " + LastName, Data.DataType.Person);

            UserPKManager.UpdatePk(KeyType.Person, ID);

            bool saved = aDMS.PeopleManager.Save(this, "", false, true);

            return saved;
        }
    }
}