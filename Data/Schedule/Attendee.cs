using AMS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Schedule
{
    [Serializable]
    public class Attendee : DataClass
    {
        public string PersonID { get; set; }
        public string Company { get; set; }
        public string BillingAddress { get; set; }
        public string Telephone { get; set; }
        public string Fax { get; set; }
        public string VAT { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string CPD { get; set; }
        public string DateOne { get; set; }
        public string DateTwo { get; set; }
        public string CourseDescription { get; set; }
        public MealType MealType { get; set; }
        public bool NeedPC { get; set; }
        public bool NeedDongle { get; set; }
    }
}
