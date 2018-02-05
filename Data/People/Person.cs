using AMS.Data;
using AMS.Data.Keys;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.People
{
    [Serializable]
    public class Person : DataClass
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
        public int SupervisorID { get; set; }
        public string AccessLevel { get; set; }
        public Company CurrentCompany { get; set; }
        public Company PreviousCompany { get; set; }
        public DateTime DateJoined { get; set; }
        public DateTime DateLeft { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool DisplayNickName { get; set; }
        public string CertificateNr { get; set; }
        public string Account { get; set; }       // Used at import, to reference the main contact for a client

        public string TempExportAccount { get; set; }

        public Person()
        {
            CurrentCompany = new Company();
            PreviousCompany = new Company();

            if (Role == null) Role = "";
        }

        #region HashSet Identifier

        string HashIdentifier { get { return FirstName + LastName + ContactNumber + Email; } }


        public override bool Equals(object obj)
        {
            var other = obj as Person;
            if (other == null)
            {
                return false;
            }
            if (HashIdentifier == null) return false;
            return HashIdentifier == other.HashIdentifier;
        }

        public override int GetHashCode()
        {
            return (HashIdentifier).GetHashCode();
        }

        #endregion

        public string DisplayName
        {
            get
            {
                string displayName = "";
                if (DisplayNickName) displayName = NickName;
                else displayName = FirstName + " " + LastName;

                return displayName.Trim();
            }
        }

        public bool Save()
        {
            return Save(false);
        }

        public bool Save(bool Overwrite)
        {
            if (ID == null || ID.Trim() == "") ID = AMS.Data.Keys.UserPKManager.NewUserPK(AMS.Data.Keys.KeyType.Person);

            FirstName = FirstName.Trim();
            LastName = LastName.Trim();

            SetFile(ID + " - " + (FirstName + " " + LastName).Trim(), AMS.Settings.Program.Directories.People + (FirstName + " " + LastName).Trim(), DataType.Person);

            UserPKManager.UpdatePk(KeyType.Person, ID);

            bool saved = DMS.PeopleManager.Save(this, "", Overwrite, true);

            return saved;
        }

        public bool MailListExclude { get; set; }

        public string Referee { get; set; }
    }
}