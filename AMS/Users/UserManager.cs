using AMS.Data;
using AMS.Data.IO;
using AMS.Data.Users;
using AMS.Suite.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Users
{
    public static class UserManager
    {
        public static bool HasLoaded = false;

        public static LocalData LocalData;
        internal static aFile localDataFileName = new aFile("LocalData", AMS.Settings.Program.Directories.LocalData, DataType.Data);

        // For making the file "inaccessible"
        public static System.IO.FileStream OnlineFile;

        // Current User
        private static NetworkUser currentUser = new NetworkUser();
        public static NetworkUser CurrentUser { get { return currentUser; } }

        internal static void SetCurrentUser(NetworkUser user)
        {
            currentUser = (from i in NetworkUsers
                           where i.Username == user.Username
                           select i).FirstOrDefault();
        }

        // New Methods

        internal static bool StartUp()
        {
            HasLoaded = ReadLocalDataFile();

            // 1. Get Network/Data Location, to be able to read from "Users" folder
            // 2. Ability to add users (Add limitation here for AMS Versions, so that people can buy higher versions with more user rights) (Add later a standalone user manager, to be able to delete modify users for companies. Where indivituals are not allowed to edit their user login data)
            // 3. If in network mode, LocalData can save username and password info for fast logging
            // 4. Login, making their logging file "read-only" giving the ability to read who is "online"

            // If in Network Mode, get user login details
            if (AMS.Settings.Program.WorkMode == WorkMode.Network)
            {
                // Loads Network Adman Form if no users found
                if (NetworkUsers.Count == 0) AMS.MessageBox_v2.Show("There was no users found.\r\nPlease user administration login details to add some users with the User Manager.");

                // Login
                HasLoaded = CheckNetworkUserLogin();
            }
            else // Using default User for data and counters
            {
               HasLoaded = UseLocalUser();
            }

            return HasLoaded;
        }

        /// <summary>
        /// Use if Network Edition is not in use, but still want PK Numbers
        /// </summary>
        /// <returns></returns>
        private static bool UseLocalUser()
        {
            bool loaded = false;
            aFile localUserFile = new aFile("Default", AMS.Settings.Program.Directories.Users + "\\Default", DataType.User);
            currentUser = LoadUser(localUserFile);

            if (currentUser == null)
            {
                try
                {
                    MessageBox_v2.ShowProcess("Creating New Local User Data");
                    
                    currentUser = new NetworkUser()
                    {
                        Username = "Default"
                    };

                    IO.XML_v1.Writter<NetworkUser>(currentUser, localUserFile, "Saving default user data.", true);
                    MessageBox_v2.EndProcess();
                }
                catch { MessageBox_v2.Show("Unable to Save and Process the Local User Data file.\r\nPlease Contact the System Administrator for Assistance", MessageType.Error); }

                currentUser = (NetworkUser)IO.XML_v1.Reader<NetworkUser>(localUserFile.FullName);
            }

            if (currentUser != null) loaded = true;

            return loaded;
        }

        internal static void SaveCurrentUser()
        {
            try
            {
                currentUser.SetFile(currentUser.Username, AMS.Settings.Program.Directories.Users + currentUser.Username, DataType.User);
                AMS.IO.XML_v1.Writter<NetworkUser>(currentUser, currentUser.File, "", true);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }

            currentUser = GetNetworkUser(currentUser.Username);
        }

        private static NetworkUser LoadUser(aFile UserFile)
        {
            if (!File.Exists(UserFile.FullName)) return null;
            // Used to hold the user network file, so no-one can delete/modify it... does not work with dropbox of cause
            NetworkUser User = new NetworkUser();
            try
            {
                User = (NetworkUser)IO.XML_v1.Reader<NetworkUser>(UserFile.FullName);
                User.SetFile(UserFile);
                if (!File.Exists(User.OnlineFle.FullName)) File.Create(User.OnlineFle.FullName);
                else OnlineFile = new FileStream(User.OnlineFle.FullName, System.IO.FileMode.Open, FileAccess.Read, FileShare.None);
            }
            catch (Exception ex)
            {
                AMS.MessageBox_v2.Show(ex.Message, MessageType.Error);
                throw new Exception(ex.Message);
            }

            return User;
        }


        #region ---------- Local Data ----------

        /// <summary>
        /// Read/Create the Local Data File and Check if in Network Mode to adjust Root Data Folder
        /// </summary>
        /// <returns>returns true, if successful</returns>
        private static bool ReadLocalDataFile()
        {
            // 1. Reads local Data
            // 2. Creates new Local Data if null and re-read
            // 3. note: Read different for network or local

            AMS.StatusUpdate.UpdateArea("Reading Data File...");

            // Read or Create LocalData
            LocalData = new LocalData();
            LocalData = (LocalData)AMS.IO.XML_v1.Reader<LocalData>(localDataFileName.FullName);
            
            // Read Again if first time failed
            if (LocalData == null || LocalData.DirectoryRootData == "")
            {
                AMS.StatusUpdate.UpdateArea("Creating Local Data File...");

                CreateLocalData();
                LocalData = (LocalData)AMS.IO.XML_v1.Reader<LocalData>(localDataFileName.FullName);

                if (LocalData == null)
                {
                    AMS.StatusUpdate.UpdateArea("Unable to Read the Data File!");
                    AMS.MessageBox_v2.Show("Unable to create a data file, please contact System Administrator", MessageType.Error);
                    return false;
                }
                else
                {
                    AMS.StatusUpdate.UpdateArea("Local Data File Read.");
                    HasLoaded = true;
                }
            }
            else
            {
                AMS.StatusUpdate.UpdateArea("Local Data File Read.");
                HasLoaded = true;
            }

            AMS.Settings.Program.Directories.RootData = LocalData.DirectoryRootData;
            AMS.Settings.Program.Archives.RootData = LocalData.DirectoryRootData;

            return HasLoaded;
        }

        private static void CreateLocalData()
        {
            LocalData = new LocalData();
            AMS.Settings.Program.SetDataRootDirectory();
        }

        public static void SaveLocalData()
        {
            try
            {
                IO.XML_v1.Writter<LocalData>(LocalData, localDataFileName, "", true);
            }
            catch (Exception ex) { AMS.MessageBox_v2.Show("Unable to create " + localDataFileName + " \r\n\r\n" + ex.Message, MessageType.Error); }
        }

        #endregion

        #region ---------- Network Data ----------

        private static bool CheckNetworkUserLogin()
        {
            // 1. if login info = Username: Admin, Password: Gr33nb1rd, load Network Administrator form
            bool logged = false;

            if (LocalData.FastLogin)
            {
                NetworkUser user = new NetworkUser()
                {
                    Username = LocalData.UserName,
                    Password = LocalData.Password
                };

                logged = CheckUserNamePassword(user, true);
            }

            if (logged == false)
            {
                using (Forms.Login f = new Forms.Login())
                {
                    f.ShowDialog();
                    logged = f.Logged;
                }
            }

            return logged;
        }

        public static List<NetworkUser> NetworkUsers
        {
            get
            {
                List<NetworkUser> networkUsers = new List<NetworkUser>();
                foreach (var userFile in NetworkUserFiles)
                {
                    NetworkUser user = new NetworkUser();
                    user = (NetworkUser)AMS.IO.XML_v1.Reader<NetworkUser>(userFile);

                    if (user != null) networkUsers.Add(user);
                }
                return networkUsers;
            }
        }

        public static string[] NetworkUserFiles
        {
            get
            {
                return (IO.File.GetAllFiles(AMS.Settings.Program.Directories.Users, Data.DataType.User));
            }
        }

        private static void NetworkAdministation()
        {
            using (Forms.Network_Administration f = new Forms.Network_Administration())
                f.ShowDialog();
        }

        internal static bool SaveNetworkUser(NetworkUser user)
        {
            bool saved = false;

            try
            {
                user.SetFile(user.Username, AMS.Settings.Program.Directories.Users + user.Username, DataType.User);

                if (AMS.IO.XML_v1.Writter<NetworkUser>(user, user.File, "", true))
                    saved = true;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }

            if (saved) MessageBox_v2.Show(user.Username + " Saved", 800);

            return saved;
        }
       
        public static List<string> OnlineNetworkUsers
        {
            get
            {
                List<string> networkUsers = new List<string>();

                foreach (string userFile in NetworkUserFiles)
                {
                    System.IO.FileInfo file = new System.IO.FileInfo(userFile);
                    try
                    {
                        if (!file.Open(System.IO.FileMode.Open).CanWrite)
                        {

                        }
                    }
                    catch 
                    {
                        networkUsers.Add(file.Name);
                        // GetNetworkUser("eafreak"); // Testing accesablily
                    }
                }

                return networkUsers;
            }
        }
        
        #endregion

        #region --------- Network User ----------

        internal static bool CheckUserNamePassword(NetworkUser NetworkUser, bool FirstCheck)
        {
            // Network Admin Login
            if (NetworkUser.Username == Settings.Security.Admin.Username && NetworkUser.Password == Settings.Security.Admin.Password)
            {
                NetworkAdministation();
                return false;
            }

            bool canLog = false;
            var user = UserManager.GetNetworkUser(NetworkUser.Username);

            // Get user name, and check related password
            if (user != null && user.Password == NetworkUser.Password)
            {
                // Check if this user has a person associated to him/her with correct data
                if (user == null || user.FirstName == null || user.LastName == null || user.Email == null)
                {
                    if (AMS.MessageBox_v2.Show("You do not have valid personal data associated to your username\r\n\r\nPlease use the network manager to fix this problem", MessageType.Question) == MessageOut.YesOk)
                    {
                        using (AMS.Users.Forms.Network_Administration f = new Forms.Network_Administration(user))
                            f.ShowDialog();
                    }
                }
                else
                {
                    UserManager.SetCurrentUser(user);
                    canLog = true;
                }
            }

            if (FirstCheck && canLog) canLog = CheckUserNamePassword(user, false);

            return canLog;
        }

        internal static NetworkUser GetNetworkUser(string UserName)
        {
            return (from i in NetworkUsers
                    where i.Username == UserName
                    select i).FirstOrDefault();
        }
      
        #endregion

        internal static void RemoveNetworkUser(NetworkUser user)
        {
            try
            {
                System.IO.Directory.Delete(AMS.Settings.Program.Directories.Users + user.Username, true);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }
}
