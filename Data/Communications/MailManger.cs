using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Communications
{
    public partial class MailManger
    {
        private AMS.Data.IO.aFile MailTemplateFile = new AMS.Data.IO.aFile("MailTemplates", AMS.Settings.Program.Directories.Data, AMS.Data.DataType.Data);

        private HashSet<MailTemplate> templateList;
        public List<MailTemplate> TemplateList
        {
            get
            {
                if (templateList == null) GetTemplateList();
                return templateList.ToList();
            }
        }

        public bool SaveTemplates()
        {
            AMS.Data.GobalManager.SuspendEvents();

            bool saved = AMS.IO.XML_v1.Writter<List<MailTemplate>>(templateList.ToList(), MailTemplateFile, "Saving Mail Template List", true);
            AMS.Data.GobalManager.ResumeEvents();

            return saved;
        }

        public HashSet<MailTemplate> GetTemplateList()
        {
            if (templateList == null) templateList = new HashSet<MailTemplate>();

            var list = (List<MailTemplate>)AMS.IO.XML_v1.Reader<List<MailTemplate>>(MailTemplateFile.FullName);

            if (list != null)
                foreach (var i in list)
                    templateList.Add(i);

            foreach (var i in Enum.GetNames(typeof(TemplateTypes)))
            {
                if (GetTemplate(i) == null)
                {
                    templateList.Add(new MailTemplate()
                    {
                        Name = i
                    });
                }
            }

            return templateList;
        }

        public MailTemplate GetTemplate(string Name)
        {
            return (from i in TemplateList
                    where i.Name == Name
                    select i).FirstOrDefault();
        }
    }
}