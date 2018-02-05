using AMS.Data.Keys;
using AMS.Data.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Data.Users
{
    [Serializable]
    public class NetworkUser : Data.DataClass
    {
        public string Username { get; set; } // Acts are PK
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNr { get; set; }
        public string Email { get; set; }
        public string Prefix { get; set; }

        public AMS.Data.IO.aFile OnlineFle
        {
            get
            {
                AMS.Data.IO.aFile online = new IO.aFile("online", this.File.Location, DataType.Data);
                return online;
            }
        }

        public UserRoles UserRoles { get; set; }
        public UserPK UserPK { get; set; }

        public NetworkUser()
        {
            UserRoles = new UserRoles();
            if (AMS.Settings.Users.UserPk) UserPK = new UserPK();
        }
    }
}