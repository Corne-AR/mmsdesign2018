using AMS;
using AMS.Data;
using AMS.Data.Keys;
using AMS.Data.People;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AMS.Data.Tasks
{
    public static class OLDTaskManager
    {
        public static bool HasStarted = false;

        #region ---------- Task ----------

        // Variables
        public static string DirectoryTasks = AMS.Settings.Program.Directories.Tasks;

        // Current Task

        private static aTask currentTask;
        public static aTask CurrentTask
        {
            get { return currentTask; }
        }
        public static aTask SetCurrentTask(aTask Task)
        {
            currentTask = Task;
            AMS.StatusUpdate.UpdateSelectionOne("Task", currentTask.ID);
            return currentTask;
        }

        public static void RemoveCurrentTask()
        {
            RemoveTask(currentTask.ID);

            if (taskList.Count > 0) currentTask = taskList[0];
            else currentTask = null;
        }

        public static List<aTask> CurretTask_HistoryList
        {
            get
            {
                List<aTask> taskHistoryList = new List<aTask>();

                string[] archives = AMS.IO.File.GetAllFiles(AMS.Settings.Program.Archives.Tasks, DataType.Task);

                foreach (var i in archives)
                {
                    var task = (aTask)AMS.IO.XML_v1.Reader<aTask>(i.ToString());

                    if (task.ID == currentTask.ID)
                        taskHistoryList.Add(task);
                }

                return taskHistoryList;
            }
        }

        // Get Task

        public static int LoadTaskList()
        {
            taskList = new List<aTask>();

            // Making a local taskFiles list, for optimizing to only onetime read of files
            string[] taskFiles = TaskFiles();

            // Final count of files when loading
            int filecount = taskFiles.Count();

            // Reading each file into memory
            int fileNr = 0;
            foreach (var file in taskFiles)
            {
                aTask t = (aTask)AMS.IO.XML_v1.Reader<aTask>(file.ToString());

                if (t != null) taskList.Add(t);

                fileNr++;
                StatusUpdate.UpdateArea("Tasks Loaded: " + fileNr + "/" + filecount);

                if (AMS.Settings.Program.WorkMode == WorkMode.Demo && fileNr >= AMS.Settings.Program.DemoLimit)
                    break;
            }

            // Add TaskItemList to this load method too
            LoadTaskItemList();

            return filecount;
        }

        public static aTask GetTask(string Code)
        {
            return (from i in taskList
                    where i.ID == Code
                    select i).FirstOrDefault();
        }

        private static List<aTask> taskList;
        public static List<aTask> TaskList()
        {
            if (taskList == null) taskList = new List<aTask>();
            return taskList;
        }

        public static string[] TaskFiles()
        {
            return AMS.IO.File.GetAllFiles(AMS.Settings.Program.Directories.Tasks, Data.DataType.Task);
        }

        // Save Task

        public static bool Save(aTask Task)
        {
            bool saved = false;

            AMS.StatusUpdate.UpdateArea("Saving Task: " + Task.ID + "...");

            // Generate Id if null
            if (Task.ID == null || Task.ID.ToString().Trim() == "")
                Task.ID = UserPKManager.NewUserPK(KeyType.Task);

            try
            {
                // Saving File to HardDrive
                Task.SetFile(Task.ID,  AMS.Settings.Program.Directories.Tasks + Task.ID, DataType.Task);
                saved = AMS.IO.XML_v1.Writter<aTask>(Task, Task.File, "", false);
                UserPKManager.UpdatePk(KeyType.Task, Task.ID);
            }
            catch (Exception ex) { MessageBox_v2.Show("Unable to Save: " + Task.ID + "\r\n\r\n" + ex.Message + "\r\n" + ex.InnerException, MessageType.Error); }

            if (saved)
            {
                currentTask = Task;
                MessageBox_v2.Show("Saved Task: " + Task.ID,  1200);
                AMS.StatusUpdate.UpdateArea("Saved Task: " + Task.ID);

                // Add to List if data does not exist
                var queryList = (from i in taskList
                                 where i.ID == Task.ID
                                 select i).FirstOrDefault();

                if (queryList == null) taskList.Add(Task);
            }
            else
            {
                AMS.StatusUpdate.UpdateArea("Unable to Save Task: " + Task.ID + "!");
            }

            return saved;
        }

        /// <summary>
        /// Looks at Recurrence data and move the next start date onwards
        /// </summary>
        /// <param name="Task">Task Data</param>
        public static void UpdateRecurrance(aTask Task)
        {
            // Update only happens after the start date has passed
            if (Task.StartDate < DateTime.Now)
            {
                AMS.MessageBox_v2.Show("Older than Today");
            }
        }

        // Remove Task

        public static void RemoveTask(string TaskCode)
        {
            try
            {
                if (AMS.MessageBox_v2.Show("Remove Task '" + GetTask(TaskCode) + "' from Database?", MessageType.Question) == MessageOut.YesOk)
                {
                    aTask task = GetTask(TaskCode);
                    string file = AMS.Settings.Program.Directories.Tasks + task.ID;
                    Directory.Delete(file, true);
                }
            }
            catch (Exception ex) { MessageBox_v2.Show("Cannot Remove Task: " + GetTask(TaskCode).ID + "\r\n" + ex.Message, MessageType.Error); }

            LoadTaskList();
        }

        #endregion

        #region --------- Task Archives ----------

        public static bool SaveToArchive(aTask Task, List<string> TaskFiles, List<string> TaskDirectories)
        {
            bool saved = false;

            AMS.StatusUpdate.UpdateArea("Archiving Task: " + Task.ID + "...");

            Task.CompleteDate = DateTime.Now;
            string path = "";
            try
            {
                // Saving File to HardDrive
                Task.SetFile(Task.ID, AMS.Settings.Program.Archives.Tasks + Task.ID + "\\" + string.Format("{0:dd MMMM yyyy - hh-mm-ss}" + "\\", DateTime.Now), DataType.Task);
 
                saved = AMS.IO.XML_v1.Writter<aTask>(Task, Task.File, "", true);

                var queryItems = (from i in taskItemList
                                  where i.TaskID == Task.ID
                                  select i).ToList();
                path = Task.File.Location;
                string  itemPath = path + "Items\\";
                foreach (aTaskItem i in queryItems)
                {
                    i.SetFile(i.ID, itemPath, DataType.TaskItem);
                    i.CompleteDate = Task.CompleteDate;
                    saved = AMS.IO.XML_v1.Writter<aTaskItem>(i, i.File, "", true);
                }
            }
            catch (Exception ex) { MessageBox_v2.Show("Unable to Save: " + Task.ID + "\r\n\r\n" + ex.Message + "\r\n" + ex.InnerException, MessageType.Error); }

            if (saved)
            {
                MessageBox_v2.Show("Archived Task: " + Task.ID, 1500);
                AMS.StatusUpdate.UpdateArea("Archived Task: " + Task.ID);
            }
            else
            {
                AMS.StatusUpdate.UpdateArea("Unable to Archive Task: " + Task.ID + "!");
            }

            // Saving Archive Files
            if (TaskFiles != null && TaskFiles.Count > 0)
            {
                AMS.MessageBox_v2.ShowProcess("Coping Files...", 0, TaskFiles.Count);
                string documentsPath = path + "Documents\\";

                if (!Directory.Exists(documentsPath)) Directory.CreateDirectory(documentsPath);

                int nr = 0;
                foreach (var file in TaskFiles)
                {
                    nr++;

                    FileInfo fileInfo = new FileInfo(file);
                    AMS.MessageBox_v2.ShowProcess("Coping Files...\r\n" + fileInfo.Name, nr, TaskFiles.Count);
                    try { File.Copy(file, documentsPath + fileInfo.Name); }
                    catch (Exception ex) { AMS.MessageBox_v2.Show("Cannot copy: " + file + "\r\n" + ex.Message, MessageType.Error); }
                }
            }

            // Saving Archive Directories
            if (TaskDirectories != null && TaskDirectories.Count > 0)
            {
                AMS.MessageBox_v2.ShowProcess("Coping Directories...", 0, TaskDirectories.Count);
                string documentsPath = path + "Documents\\";

                if (!Directory.Exists(documentsPath)) Directory.CreateDirectory(documentsPath);

                foreach (var dir in TaskDirectories)
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(dir);

                    try
                    {
                        //Now Create all of the directories
                        int nr = 0;
                        foreach (string dirPath in Directory.GetDirectories(dir, "*", SearchOption.AllDirectories))
                        {
                            nr++; 

                            Directory.CreateDirectory(dirPath.Replace(dir, documentsPath + "\\" + dirInfo.Name));
                            AMS.MessageBox_v2.ShowProcess("Coping Directories...\r\n" + dirInfo.Name, nr, TaskDirectories.Count);
                        }
                    }
                    catch (Exception ex) { AMS.MessageBox_v2.Show(ex.Message, MessageType.Error); }

                    //Copy all the files
                    try
                    {
                        int nr = 0;
                        var files = Directory.GetFiles(dir, "*.*", SearchOption.AllDirectories);
                        foreach (string newPath in files)
                        {
                            nr++;
                            FileInfo fileInfo = new FileInfo(newPath);

                            File.Copy(newPath, newPath.Replace(dir, documentsPath + "\\" + dirInfo.Name));

                            AMS.MessageBox_v2.ShowProcess("Coping Directories...\r\n" + dirInfo.Name + "\\" + fileInfo.Name, nr, files.Count());
                        }
                    }
                    catch (Exception ex) { AMS.MessageBox_v2.Show(ex.Message, MessageType.Error); }
                }
            }

            if (TaskFiles.Count > 0 || TaskDirectories.Count > 0)
            {
                AMS.MessageBox_v2.EndProcess();

                System.Diagnostics.Process.Start(path);
            }

            return saved;
        }

        public static string GetArchiveFolder(aTask Task)
        {
            string path = AMS.Settings.Program.Archives.Tasks + Task.ID;

            return path;
        }

        private static List<aTask> taskArchiveList;
        public static List<aTask> TaskArchiveList()
        {
            taskArchiveList = new List<aTask>();

            foreach (var i in TaskArchiveFiles())
            {
                var t = (aTask)AMS.IO.XML_v1.Reader<aTask>(i);

                if(t != null) taskArchiveList.Add(t);
            }
            
            return taskArchiveList;
        }

        public static string[] TaskArchiveFiles()
        {
            return AMS.IO.File.GetAllFiles(AMS.Settings.Program.Archives.Tasks, Data.DataType.Task);
        }

        private static List<aTaskItem> taskItemArchiveList;
        public static List<aTaskItem> TaskItemArchiveList(aTask Task)
        {
            taskItemArchiveList = new List<aTaskItem>();

            foreach (var i in TaskItemArchiveFiles)
            {
                var t = (aTaskItem)AMS.IO.XML_v1.Reader<aTaskItem>(i);

                if (t != null && Task.CompleteDate == t.CompleteDate) taskItemArchiveList.Add(t);
            }

            return taskItemArchiveList;
        }

        public static string[] TaskItemArchiveFiles
        {
            get
            {
                return AMS.IO.File.GetAllFiles(AMS.Settings.Program.Archives.Tasks, Data.DataType.TaskItem);
            }
        }

        #endregion

        #region ---------- Task Items ----------

        // Get TaskItem
        public static aTaskItem GetTaskItem(string TaskItemID)
        {
            return (from i in taskItemList
                    where i.ID == TaskItemID
                    select i).FirstOrDefault();
        }

        private static List<aTaskItem> taskItemList = new List<aTaskItem>();

        public static int LoadTaskItemList()
        {
            taskItemList = new List<aTaskItem>();

            // Making a local Files list, for optimizing to only onetime read of files
            string[] taskItemFiles = TaskItemFiles();

            // Final count of files when loading
            int filecount = taskItemFiles.Count();

            // Reading each file into memory
            int fileNr = 0;
            foreach (var file in taskItemFiles)
            {
                aTaskItem t = (aTaskItem)AMS.IO.XML_v1.Reader<aTaskItem>(file.ToString());

                taskItemList.Add(t);

                fileNr++;

                if (AMS.Settings.Program.WorkMode == WorkMode.Demo && fileNr >= AMS.Settings.Program.DemoLimit)
                    break;
            }

            return filecount;
        }

        public static string[] TaskItemFiles()
        {
            return AMS.IO.File.GetAllFiles(AMS.Settings.Program.Directories.Tasks, Data.DataType.TaskItem);
        }

        public static List<aTaskItem> TaskItemList()
        {
            return taskItemList;
        }

        public static List<aTaskItem> TaskItemList(aTask Task)
        {
            return (from i in taskItemList
                    where i.TaskID == Task.ID
                    orderby i.Metadata.Created
                    select i).ToList();
        }

        public static string GetTaskItemFileName(string TaskID)
        {
            return (from i in taskItemList
                    where i.ID == TaskID
                    select i).FirstOrDefault().ID;
        }

        // Save TaskItem

        public static bool Save(aTaskItem TaskItem)
        {
            bool saved = false;

            // Generate Id if null
            if (TaskItem.ID == null || TaskItem.ID.ToString().Trim() == "")
            {
                TaskItem.ID = UniqueKey.NewShortCode();
                TaskItem.Metadata.Created = DateTime.Now;
            }

            try
            {
                TaskItem.SetFile(TaskItem.ID, AMS.Settings.Program.Directories.Tasks + GetTask(TaskItem.TaskID).ID + "\\Items\\", DataType.TaskItem);
                saved = AMS.IO.XML_v1.Writter<aTaskItem>(TaskItem, TaskItem.File, "", true);


                // Add to List if data does not exist
                var queryList = (from i in taskItemList
                                 where i.ID == TaskItem.ID
                                 select i).FirstOrDefault();

                if (queryList == null) taskItemList.Add(TaskItem);
            }
            catch (Exception ex) { MessageBox_v2.Show("Unable to Save TaskItem: " + TaskItem.Description + "\r\n\r\n" + ex.Message + "\r\n" + ex.InnerException, MessageType.Error); }

            return saved;
        }

        // Remove TaskItem
        public static void Remove(string TaskItemCode)
        {
            string message = "Remove Task Item '" + GetTaskItem(TaskItemCode).Description + "' from Task '" + GetTask(GetTaskItem(TaskItemCode).TaskID).ID + "'?";
            string itemFile = DirectoryTasks + GetTask(GetTaskItem(TaskItemCode).TaskID) + "\\Items\\" + GetTaskItemFileName(TaskItemCode) + DataType.TaskItem;

            if (MessageBox_v2.Show(message, MessageType.Question) == MessageOut.YesOk)
            {
                File.Delete(itemFile);
            }

            LoadTaskItemList();
        }

        #endregion
    }
}