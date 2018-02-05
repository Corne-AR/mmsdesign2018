using AMS.Data.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Data
{
    [Serializable]
    public class Metadata
    {
        public string UserName { get; set; }

        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public DateTime EmailDate { get; set; }
        public string MailTo { get; set; }

        public Metadata Save(DataClass Data)
        {
            Metadata meta = new Metadata();

            if (Created < new DateTime(1900, 1, 1)) Created = DateTime.Now;
            Modified = DateTime.Now;

            if (AMS.Users.UserManager.CurrentUser != null && AMS.Users.UserManager.CurrentUser.Username != null) UserName = AMS.Users.UserManager.CurrentUser.Username;
            if (Data.GetType() == typeof(Mail)) MailTo = ((Mail)Data).MailTo;

            return meta;
        }
    }
}