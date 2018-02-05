using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Data.Communications
{
    public class Mail : DataClass
    {
        public string MailFrom { get; set; }
        public string MailTo { get; set; }
        public string Subject { get; set; }
        public string Attachment { get; set; }
        public string Server { get; set; }
        public int ServerPort { get; set; }
        public string Login { get; set; }
        public System.Security.SecureString Password { get; set; }

        public string Body { get; set; }

        public Mail()
        {
        }

        public string Contact { get; set; }
    }
}