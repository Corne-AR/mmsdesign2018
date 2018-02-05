using AMS.Data.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Data.Keys
{
    public static class UniqueKey
    {
        // 1. Create new Id Class if none exsits
        // 2. Make sure all exsisting Task Id numbers are accounted for
        // 3. Generate new number
        // 4. Save Id Class

        // 1. Get NewKey(DataType DataType, string Name) for current New key
        // 2. Finaly SaveKey(DataType DataType, string Name) to update key index

        static public string NewShortCode()
        {
            string characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#";
            System.Threading.Thread.Sleep(2);
            string ticks = DateTime.UtcNow.Ticks.ToString();
            var code = "";
            for (var i = 0; i < characters.Length; i += 2)
            {
                if ((i + 2) <= ticks.Length)
                {
                    var number = int.Parse(ticks.Substring(i, 2));
                    if (number > characters.Length - 1)
                    {
                        var one = double.Parse(number.ToString().Substring(0, 1));
                        var two = double.Parse(number.ToString().Substring(1, 1));
                        code += characters[Convert.ToInt32(one)];
                        code += characters[Convert.ToInt32(two)];
                    }
                    else
                        code += characters[number];
                }
            }
            return code;
        }

        public static string NewKey(DataType DataType, string Name)
        {
            string dir = "";
            string fileName = "";

            #region Create and Read existing Key Data
            switch(DataType)
            {
                case DataType.Task:
                    dir = Settings.Program.Directories.Tasks;
                    fileName = "Tasks";
                    break;

                case DataType.Person:
                    dir = Settings.Program.Directories.People;
                    fileName = "People";
                    break;
            }

            // Create New Data Keys
            aFile file = new aFile(fileName, dir, DataType);

            if (!File.Exists(dir + fileName)) AMS.IO.XML_v1.Writter<KeyIndex>(new KeyIndex(), file, "Creating Key Index.",true);
            #endregion

            KeyIndex keyIndex = (KeyIndex)AMS.IO.XML_v1.Reader<KeyIndex>(dir + fileName);

            return (keyIndex.KeyInfoList.Count + 1).ToString();
        }

        public static void SaveKey(DataType DataType, string Name)
        {
            MessageBox_v2.Show("TODO Save updated Key info");
        }

        public static void CheckUnqiueKeyList(DataType DataType)
        {
            // 1. Check for rules to apply to keep integrity for Keys
            // 2. If check fails, create new KeyList
        }

        [Serializable]
        public class KeyIndex
        {
            // Holds a list of Data Names to their Ids
            public string DataClass { get; set; }
            public List<KeyInfo> KeyInfoList = new List<KeyInfo>();

            [Serializable]
            public class KeyInfo
            {
                public string ID { get; set; }
                public string DataName { get; set; }
                public DateTime Created { get; set; }
                public DateTime Modified { get; set; }
            }
        }
    }
}
