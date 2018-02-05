using AMS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Schedule
{
    [Serializable]
    public class Course : DataClass
    {
        public List<Attendee> AttendeeList { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDateTime { get; set; }
        public string GetStartDateTime { get { return string.Format("{0:dd MMMM yyyy}", StartDateTime); } }
        public DateTime EndDateTime { get; set; }
        public string GetEndDateTime { get { return string.Format("{0:dd MMMM yyyy}", EndDateTime); } }

        /// <summary>
        /// Used for location info
        /// </summary>
        public string Account { get; set; }
        public bool RequiresCertificates { get; set; }
        public decimal Cost { get; set; }

        public string CPDNumber { get; set; }
        public string PresenterID { get; set; }

        public Course()
        {
            AttendeeList = new List<Attendee>();
        }
    }
}
