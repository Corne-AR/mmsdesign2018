using AMS;
using AMS.Data;
using AMS.Data.People;
using AMS.Data.Scheduling;
using AMS.Scheduling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Data.Tasks
{
    [Serializable]
    public class aTask : DataClass
    {
        public int RevisionNr { get; set; }
        public string Description { get; set; }
        public string Instruction { get; set; }
        public string Category { get; set; }
        public string RDLCReport { get; set; }
        public string Type { get; set; }
        public int PriorityLevel { get; set; }
        public Recur Recur { get; set; }
        public string Status { get; set; }
        public string Report { get; set; }
        public DateTime CompleteDate { get; set; }
        public DateTime StartDate { get; set; }
        public bool Completed { get; set; }
        public TaskCompletedType TaskCompletedType
        {
            get
            {
                TaskCompletedType t = new TaskCompletedType();
                t = Tasks.TaskCompletedType.Pending;

                if (Recur.RecurDate < DateTime.Now.AddDays(7)) t = Tasks.TaskCompletedType.Overdue;
                if (Completed) t = Tasks.TaskCompletedType.Completed;

                return t;
            }
        }

        public aTask()
        {
            Recur = new Recur();
        }

        public virtual bool Save()
        {
            return Save(true);
        }

        public virtual bool Save(bool OverWrite)
        {
            SetFile(ID, AMS.Settings.Program.Directories.Tasks + ID, DataType.Task);

            // return base.Save(OverWrite);
            return aDMS.TaskManager.Save(this, "", OverWrite, true);
        }
    }
}