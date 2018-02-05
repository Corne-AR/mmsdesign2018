using AMS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Logger
{
    [Serializable]
    public class WorkLogger : DataClass
    {
        public string Account { get; set; }
        public string ClientName { get; set; }
        public string Description { get; set; }
        public List<TimeLog> TimeLog { get; set; }

        public WorkLogger()
        {
            TimeLog = new List<TimeLog>();
        }
    }
}
