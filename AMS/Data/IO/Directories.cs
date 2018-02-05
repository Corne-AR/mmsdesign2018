using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Data.IO
{
    public class Directories
    {
        public Directories(string Data)
        {
            data = Data;
        }

        public string LocalData
        {
            get { return Environment.ExpandEnvironmentVariables(@"%USERPROFILE%\." + Settings.Program.Name + @"\"); }
        }

        public string AppData
        {
            get { return Environment.ExpandEnvironmentVariables(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"AMS\"); }
        }

        public string RootData = @"C:\AMS\";

        private string data = @"Data\";
        public string Data
        {
            get {return RootData + data;}
        }

        public string Tasks
        {
            get { return Data + @"Tasks\"; }
        }

        public string People
        {
            get { return Data + @"People\"; }
        }

        public string Users
        {
            get { return Data + @"Users\"; }
        }

        public string Certificates
        {
            get { return Data + @"Certificates\"; }
        }

        public string Clients
        {
            get { return Data + @"Clients\"; }
        }

        public string Commerce
        {
            get { return Data + @"Commerce\"; }
        }

        public string Templates
        {
            get { return RootData + @"Templates\"; }
        }

        public string Headers
        {
            get { return Templates + @"Headers\"; }
        }

        public string Footers
        {
            get { return Templates + @"Footers\"; }
        }

        public string Terms
        {
            get { return Templates + @"Terms\"; }
        }

        public string SplashScreens
        {
            get { return Templates + @"SplashScreens\"; }
        }
    }
}