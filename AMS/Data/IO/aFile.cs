using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Data.IO
{
    [Serializable]
    public class aFile
    {
        private string name = "";
        public string Name { get { return name; } }
        private DataType extension = new DataType();
        public DataType Extension { get { return extension; } }
        private string location = "";
        public string Location { get { return location; } }

        public aFile()
        {

        }

        public aFile(string Name, string Location, DataType Extension)
        {
            SetFile(Name, Location, Extension);
        }

        public void SetFile(string Name, string Location, DataType Extension)
        {
            this.name = Name;
            this.location = Location;
            this.extension = Extension;
        }

        public void SetLocation(string Location)
        {
            this.location = Location;
        }

        //public string FullName
        //{
        //    get { return (Location + "\\" + Name + "." + Extension).Replace("\r","").Replace("\n", ""); }
        //}

        public string FullName  //CA8Des2023 replace "//" with "/"
        {
            get { return (Location + "\\" + Name + "." + Extension).Replace("\r", "").Replace("\n", "").Replace("\\\\", "\\"); }
        }

    }
}
