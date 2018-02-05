using AMS.Data.Communications;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Data
{
    public class DataManager<T> : DataClass
    {
        // Variables
        private bool loaded;
        private bool loading;

        DataType fileExtenion;
        List<T> dataList;
        public List<T> DataList { get { return dataList; } }

        private T currentData = default(T);
        public T CurrentData
        {
            get
            {
                if (currentData == null) currentData = (T)Activator.CreateInstance<T>();
                return currentData;
            }
        }

        private List<FileInfo> fileList;
        public List<FileInfo> FileList
        {
            get { return fileList; }
            set { fileList = value; }
        }

        public event EventHandler OnLoad_Event;
        public event EventHandler OnSaved_Event;
        public event EventHandler OnSaveCanceled_Event;
        public event EventHandler OnSelect_Enter;

        //public AMS.BackgroundService.IO.Indexing Indexing { get; }
        //public int ChangedCount { get; private set; }

        // Constructors

        public DataManager(DataType FileExtenion)
        {
            this.fileExtenion = FileExtenion;

            //Indexing = BackgroundService.IO.Indexing.Create(Settings.Program.Directories.Data, $"*.{FileExtenion}", 10 * 1000 * 60, SearchOption.AllDirectories);
            //Indexing.ExecuteCompleted += (s, e) =>
            //{
            //    ChangedCount = Indexing.CountChanged();
            //};
            //GobalManager.UpdateIndexer += () =>
            //BackgroundService.Services.Default.Start(Indexing);
        }

        // Load

        /// <summary>
        /// Load a fresh set of Data
        /// </summary>
        /// <returns>List of type T</returns>
        public bool LoadData()
        {
            loading = true;

            dataList = new List<T>();
            fileList = new List<FileInfo>();
            StringBuilder errorlist = new StringBuilder();

            // Making a local taskFiles list, for optimizing to only onetime read of files
            string[] objFiles = GetFiles(AMS.Settings.Program.Directories.Data, fileExtenion);

            // Final count of files when loading
            int filecount = objFiles.Count();

            // Reading each file into memory
            int fileNr = 0;
            foreach (var file in objFiles)
            {
                try
                {
                    FileInfo fileInfo = new FileInfo(file);
                    //char firstExtensionChar = fileInfo.Extension[1];

                    //if (char.IsLower(firstExtensionChar))
                    //{
                    //    System.Diagnostics.Process.Start(fileInfo.DirectoryName);
                    //}

                    var readObject = AMS.IO.XML_v1.Reader<T>(fileInfo.FullName);

                    if (readObject != null)
                    {
                        dataList.Add((T)readObject);
                        fileList.Add(new FileInfo(fileInfo.FullName));

                        string fileName = fileInfo.Name.Substring(0, fileInfo.Name.Length - fileInfo.Extension.Length);
                        string location = fileInfo.Directory.FullName;
                        string extension = fileInfo.Extension.Substring(1);
                        extension = extension.ToLower();
                        extension = char.ToUpper(extension[0]) + extension.Substring(1);

                        DataType datatype = (DataType)Enum.Parse(typeof(DataType), extension);

                        ((DataClass)readObject).SetFile(fileName, location, datatype);
                        ((DataClass)readObject).SetOrignalFile(fileName, location, datatype);

                        try
                        {
                            DataClass test = (DataClass)readObject;

                            if (test.ID == null)
                            {
                                AMS.MessageBox_v2.Show("Missing ID in " + fileInfo.FullName, MessageType.Warning);
                            }
                        }
                        catch { }
                    }

                    fileNr++;
                    StatusUpdate.UpdateDataCount(typeof(T).Name.ToString() + " Data Loaded: " + fileNr + "/" + filecount);

                    if (AMS.Settings.Program.WorkMode == WorkMode.Demo && fileNr >= AMS.Settings.Program.DemoLimit)
                        break;
                }
                catch (Exception ex) { errorlist.AppendLine(file + "\r\n" + ex.Message); }
            }

            loaded = true;
            loading = false;

            if (errorlist.Length > 0)
                AMS.MessageBox_v2.Show("The following files had problems loading\r\n\r\n" + errorlist.ToString(), MessageType.Error);

            if (OnLoad_Event != null && objFiles.Count() > 0 && !Data.GobalManager.ControlsSuspended) OnLoad_Event(this, EventArgs.Empty);

            return loaded;
        }

        // GetData

        public T GetData(Func<T, bool> expression)
        {
            if (loading) return default(T);

            if (!loaded) LoadData();
            var data = dataList.Where(expression);
            return data.FirstOrDefault();
        }

        public List<T> GetDataList()
        {
            if (loading) return null;

            if (!loaded || dataList == null || dataList.Count == 0)
                LoadData();

            var releaseList = new List<T>();
            int nr = 0;
            foreach (var i in dataList)
            {
                nr++;
                releaseList.Add(i);
                dataList = releaseList;
            }

            return dataList;
        }

        public List<T> GetDataList(Func<T, bool> expression)
        {
            if (loading) return null;

            List<T> newDataList = new List<T>();

            if (!loaded || dataList == null || dataList.Count == 0)
                LoadData();

            newDataList = dataList.Where(expression).ToList();

            return newDataList;
        }

        public List<T> GetDataList(string Location, DataType DataType)
        {
            if (loading) return null;

            List<T> datalist = new List<T>();

            var files = AMS.IO.File.GetAllFiles(Location, DataType);

            foreach (var file in files)
            {
                var readObject = AMS.IO.XML_v1.Reader<T>(file.ToString());

                if (readObject != null)
                {
                    datalist.Add((T)readObject);
                    ((DataClass)readObject).File.SetLocation(file.ToString());
                }
            }

            return datalist;
        }

        public string[] GetFiles(string Location, DataType FileExtension)
        {
            return AMS.IO.File.GetAllFiles(Location, FileExtension);
        }

        // SetData

        public T SetCurrent(T Data)
        {
            currentData = Data;

            if (OnSelect_Enter != null && !AMS.Data.GobalManager.ControlsSuspended) OnSelect_Enter(this, EventArgs.Empty);
            return currentData;
        }

        public T SetCurrent(Func<T, bool> expression)
        {
            currentData = GetData(expression);

            if (OnSelect_Enter != null && !Data.GobalManager.ControlsSuspended) OnSelect_Enter(this, EventArgs.Empty);
            return currentData;
        }

        // SaveData

        public bool Save(DataClass Data, string Message, bool OverWrite, bool SaveMetadata)
        {
            if (loading) return false;

            System.Windows.Forms.Application.DoEvents();

            bool saved = false;
            string originalFile = Data.OriginalFile.FullName;
            string tempFile = "";

            // Make sure the original file exists
            if (!System.IO.File.Exists(originalFile)) originalFile = null;

            // Prompt Overwrite, else cancel
            if ((!string.IsNullOrEmpty(originalFile) && !OverWrite) && MessageBox_v2.Show("File '" + Data.File.Name + "' Already Exists.\r\nOverride Existing File?\r\n\r\n" + Message, MessageType.Question) == MessageOut.No)
                return false;

            // Make a backup for the original file
            if (!string.IsNullOrEmpty(originalFile))
            {
                FileInfo oldFileInfo = new FileInfo(originalFile);
                string tempFolder = Settings.Program.Directories.RootData + "\\Temp\\" + Data.ID + "\\";
                tempFile = tempFolder + oldFileInfo.Name;
                if (System.IO.File.Exists(tempFile)) System.IO.File.Delete(tempFile);
                if (!Directory.Exists(tempFolder)) Directory.CreateDirectory(tempFolder);
                System.IO.File.Move(originalFile, tempFile);
            }

            if (Data.File != null && Data.File.Name != null && Data.File.Extension.ToString() != "" && Data.File.Location != null)
            {
                AMS.StatusUpdate.UpdateArea("Saving '" + Data.File.Name + "' to Database...");

                try
                {
                    // New PK if needed
                    if (string.IsNullOrEmpty(Data.ID)) Data.ID = Guid.NewGuid().ToString();

                    // Saving Metadata
                    if (SaveMetadata) Data.Metadata.Save(Data);

                    // Save Physical File
                    if (AMS.IO.XML_v1.Writter<T>(Data, Data.File, Message, OverWrite))
                        saved = true;

                }
                catch (Exception ex)
                {
                    AMS.StatusUpdate.UpdateArea("Error saving '" + Data.File.Name + "' to Database.");
                    MessageBox_v2.Show("Cannot Save '" + Data.File.Name + "'\r\n\r\n" + ex.Message + "\r\n" + ex.InnerException, MessageType.Error);
                }

                // Restore Backup if needed
                if (!string.IsNullOrEmpty(originalFile))
                {
                    // if Saved, delete the tempFile, else restore it.
                    if (saved) System.IO.File.Delete(tempFile);
                    else
                    {
                        if (System.IO.File.Exists(originalFile) && System.IO.File.Exists(tempFile)) System.IO.File.Delete(originalFile);

                        System.IO.File.Move(tempFile, originalFile);
                    }

                    // Remove empty folder if needed
                    if (Directory.Exists(Data.OriginalFile.Location) && Directory.GetFiles(Data.OriginalFile.Location, "*.*", SearchOption.AllDirectories).Count() == 0) Directory.Delete(Data.OriginalFile.Location);
                }

                if (saved)
                {
                    AMS.StatusUpdate.UpdateArea("Saved '" + Data.File.Name + "' to Database.");

                    // Add/Save to current Data
                    if (!AMS.Data.GobalManager.EventsSuspended) LoadData();
                }
            }
            else
            {
                AMS.MessageBox_v2.Show("No Data Location was Specified", MessageType.Error);
                return false;
            }

            System.Windows.Forms.Application.DoEvents();

            // Finally fire all events in external forms or user controls.
            if (saved)
            {
                if (OnSaved_Event != null && !AMS.Data.GobalManager.ControlsSuspended) OnSaved_Event(this, EventArgs.Empty);
                //Data.OnSaved();
            }

            return saved;
        }

        public void SaveCancel()
        {
            if (OnSaveCanceled_Event != null && !Data.GobalManager.ControlsSuspended) OnSaveCanceled_Event(this, EventArgs.Empty);
        }

        // Methods

        public bool Delete(string Message, T dataClass)
        {
            return Delete(Message, dataClass, false);
        }

        public bool Delete(string Message, T dataClass, bool AutoDelete)
        {
            if (loading) return false;

            bool removed = false;

            if (AutoDelete || AMS.MessageBox_v2.Show(Message, MessageType.Question) == MessageOut.YesOk)
            {
                try
                {
                    int nr = dataList.IndexOf(dataClass);
                    try
                    {
                        FileInfo file = new FileInfo(fileList[nr].FullName);
                        System.IO.File.Delete(file.FullName);
                        removed = true;

                        if (Directory.Exists(file.Directory.FullName) && Directory.GetFiles(file.Directory.FullName, "*.*", SearchOption.AllDirectories).Count() == 0) Directory.Delete(file.Directory.FullName);
                    }
                    catch (Exception ex) { MessageBox_v2.Show("Cannot remove '" + fileList[nr].FullName + "'\r\n\r\n" + ex.Message, MessageType.Error); }

                }
                catch (Exception ex) { MessageBox_v2.Show(ex.Message + "\r\n" + ex.InnerException, MessageType.Error); }
            }

            if (!AutoDelete)
            {
                System.Windows.Forms.Application.DoEvents();
                LoadData();
                if (OnLoad_Event != null && !Data.GobalManager.EventsSuspended) OnLoad_Event(this, EventArgs.Empty);
                if (dataList != null && dataList.Count > 0 && dataList[0] != null) SetCurrent(dataList[0]);
                else SetCurrent(default(T));
            }

            return removed;
        }

        // Dispose

        public new void Dispose()
        {
            dataList = null;
            currentData = default(T);
        }

        // Archives

        public List<T> GetArchiveList()
        {
            if (loading) return null;

            List<T> datalist = new List<T>();

            string[] files = GetFiles(AMS.Settings.Program.Archives.Data, fileExtenion);

            foreach (var file in files)
            {
                var readObject = AMS.IO.XML_v1.Reader<T>(file.ToString());

                if (readObject != null) datalist.Add((T)readObject);
            }

            return datalist.ToList();
        }

        public List<T> GetArchiveList(Func<T, bool> expression)
        {
            if (loading) return null;

            List<T> datalist = new List<T>();

            string[] files = GetFiles(AMS.Settings.Program.Archives.Data, fileExtenion);

            foreach (var file in files)
            {
                var readObject = AMS.IO.XML_v1.Reader<T>(file.ToString());

                if (readObject != null) datalist.Add((T)readObject);
            }

            return datalist.Where(expression).ToList();
        }

        public bool SaveToArchive(DataClass Data, string Location)
        {
            if (loading) return false;

            return SaveToArchive(Data, Location, null, null);
        }

        public bool SaveToArchive(DataClass Data, string Location, List<string> FileList, List<string> DirectoryList)
        {
            if (loading) return false;

            bool saved = false;

            AMS.StatusUpdate.UpdateArea("Archiving " + Data.GetType().Name + " data: " + Data.ID + "...");
            Data.File.SetLocation(Location);
            Data.Metadata.Save(Data);

            try
            {
                // Saving File to HardDrive
                saved = AMS.IO.XML_v1.Writter<T>(Data, Data.File, "Saving Archive.", true);
            }
            catch (Exception ex) { MessageBox_v2.Show("Unable to Save: " + Data.ID + "\r\n\r\n" + ex.Message + "\r\n" + ex.InnerException, MessageType.Error); }

            if (saved)
            {
                // if (!MessageBox_v2.Processing)
                MessageBox_v2.Show("Data '" + Data.ID + "' Archived.", 1200);
                AMS.StatusUpdate.UpdateArea("Data '" + Data.ID + "' Archived.");
            }
            else
            {
                AMS.StatusUpdate.UpdateArea("Unable to Archive " + Data.GetType().Name + " data " + Data.ID + "!");
            }

            if (FileList != null || DirectoryList != null)
            {
                // Saving Archive Files
                int nr = 0;
                if (FileList != null && FileList.Count > 0)
                {
                    nr++;

                    AMS.MessageBox_v2.ShowProcess("Coping Files to Archive...", nr, FileList.Count);
                    string documentsPath = Location + "\\Documents\\";

                    if (!Directory.Exists(documentsPath)) Directory.CreateDirectory(documentsPath);

                    foreach (var file in FileList)
                    {
                        FileInfo fileInfo = new FileInfo(file);
                        AMS.MessageBox_v2.ShowProcess("Coping Files...\r\n" + fileInfo.Name);
                        try { System.IO.File.Copy(file, documentsPath + fileInfo.Name); }
                        catch (Exception ex) { MessageBox_v2.Show("Cannot copy: " + file + "\r\n" + ex.Message, MessageType.Error); }
                    }
                }

                // Saving Archive Directories
                nr = 0;
                if (DirectoryList != null && DirectoryList.Count > 0)
                {
                    nr++;

                    AMS.MessageBox_v2.ShowProcess("Coping Directories...", nr, DirectoryList.Count);
                    string documentsPath = Location + "\\Documents\\";

                    if (!Directory.Exists(documentsPath)) Directory.CreateDirectory(documentsPath);

                    foreach (var dir in DirectoryList)
                    {
                        DirectoryInfo dirInfo = new DirectoryInfo(dir);

                        try
                        {
                            //Now Create all of the directories
                            foreach (string dirPath in Directory.GetDirectories(dir, "*", SearchOption.AllDirectories))
                            {
                                Directory.CreateDirectory(dirPath.Replace(dir, documentsPath + "\\" + dirInfo.Name));
                                AMS.MessageBox_v2.ShowProcess("Coping Directories...\r\n" + dirInfo.Name);
                            }
                        }
                        catch (Exception ex) { AMS.MessageBox_v2.Show(ex.Message, MessageType.Error); }

                        //Copy all the files
                        try
                        {
                            nr = 0;
                            var allfiles = Directory.GetFiles(dir, "*.*", SearchOption.AllDirectories);
                            foreach (string newPath in allfiles)
                            {
                                nr++;

                                FileInfo fileInfo = new FileInfo(newPath);

                                System.IO.File.Copy(newPath, newPath.Replace(dir, documentsPath + "\\" + dirInfo.Name));

                                AMS.MessageBox_v2.ShowProcess("Coping Directories...\r\n" + dirInfo.Name + "\\" + fileInfo.Name, nr, allfiles.Count());
                            }
                        }
                        catch (Exception ex) { AMS.MessageBox_v2.Show(ex.Message, MessageType.Error); }
                    }
                }

                if (FileList.Count > 0 || DirectoryList.Count > 0)
                {
                    AMS.MessageBox_v2.EndProcess();

                    System.Diagnostics.Process.Start(Location);
                }
            }

            return saved;
        }
    }
}