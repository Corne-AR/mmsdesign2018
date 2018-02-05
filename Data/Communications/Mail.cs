using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Communications
{
    public class Mail : AMS.Data.Communications.Mail
    {
        public string Account { get; set; }
        public Data.People.Client Client { get { return DMS.ClientManager.GetData(i => i.Account == Account); } }
    }
}


