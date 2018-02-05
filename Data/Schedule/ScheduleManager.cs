using AMS.Data;
using Data.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Schedule
{
    public class ScheduleManager
    {
        private string name = "Schedule";
        public DataManager<ScheduleList> Manager = new DataManager<ScheduleList>(DataType.Data);

        private ScheduleList schedule;
        private HashSet<Course> courseList;
        public HashSet<Course> CourseList
        {
            get
            {
                if (courseList == null) courseList = GetSchedule().CoursetList;
                return courseList;
            }
        }

        //public event EventHandler CourseSelect_Event;
        //public event EventHandler OnSaved_Event;
        //public event EventHandler OnLoad_Event;
        //public event EventHandler OnSelect_Enter;

        //  Methods

        public ScheduleList GetSchedule()
        {
            schedule = Manager.GetData(i => i.ID == name);
            if (schedule == null) schedule = new ScheduleList()
            {
                ID = name,
                CoursetList = new HashSet<Course>()
            };

            return schedule;
        }

        public void ResetSchedule()
        {
            schedule.CoursetList = new HashSet<Course>();
        }

        public bool Save()
        {
            schedule.ID = name;
            schedule.SetFile(name, AMS.Settings.Program.Directories.Data, DataType.Data);

            foreach (var i in schedule.CoursetList)
            {
                if (i.ID == null)
                {
                    //i.ID = AMS.Data.Keys.UserPKManager.NewUserPK(AMS.Data.Keys.PrimaryKey.Data);
                    //AMS.Data.Keys.UserPKManager.UpdatePk(AMS.Data.Keys.PrimaryKey.Receipt, i.ID);
                }
            }

            return Manager.Save(schedule, "Saved Schedule", true, true);
        }

        public Course CurrentCourse { get; set; }

        public void SetCurrent(Course course)
        {
            throw new NotImplementedException();
        }
    }
}