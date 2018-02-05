using AMS.Data.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Accounts
{
    public class ProcessPreferencesManager
    {
        private aFile FileName = new aFile("Keyword Ignore List", AMS.Settings.Program.Directories.Data, AMS.Data.DataType.Data);

        public HashSet<string> WordList { get; set; }

        public ProcessPreferencesManager()
        {
            Load();
        }

        public void Load()
        {
            try
            {
                List<string> list = (List<string>)AMS.IO.XML_v1.Reader<List<string>>(FileName.FullName);
                if (list == null) list = new List<string>();
                list = list.OrderBy(i => i).ToList();
                WordList = new HashSet<string>(list);
            }
            catch { WordList = new HashSet<string>(); }
        }

        public bool Save()
        {
            return AMS.IO.XML_v1.Writter<HashSet<string>>(WordList, FileName, "", true);
        }

        public void Clear()
        {
            WordList.Clear();
        }

        public void AddWord(string Word)
        {
            WordList.Add(Word);
        }
    }
}