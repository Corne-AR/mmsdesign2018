using AMS.Data;
using AMS.Data.People;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Data.Tasks
{
    [Serializable]
    public class aTaskItem : DataClass
    {
        public string TaskID { get; set; }
        public int ItemNr { get; set; }
        public string Description { get; set; }
        public string ItemCode { get; set; }
        public int Quantity { get; set; }
        public string Color { get; set; }
        public bool Completed { get; set; }
        public DateTime CompleteDate { get; set; }

        public aTaskItem()
        {
        }

        public bool Save(aTask aTask)
        {
            TaskID = aTask.ID;

            string name = OriginalFile.Name;
            if (string.IsNullOrEmpty(name)) name = "Item - " + AMS.Data.Keys.UniqueKey.NewShortCode();

            SetFile(name, AMS.Settings.Program.Directories.Tasks + TaskID + "\\Items\\", DataType.TaskItem);

            return aDMS.TaskItemManager.Save(this, "Saving task item.", true, true);
        }
    }
}