using AMS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Schedule
{
    [Serializable]
    public class ScheduleList : AMS.Data.DataClass
    {
        public HashSet<Course> CoursetList { get; set; }
    }
}
