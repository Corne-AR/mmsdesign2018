using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Data.Common
{
    [Serializable]
    public class Date
    {
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public DateTime LastAccessed { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public DateTime Event { get; set; }
        public DateTime Completed { get; set; }
    }
}