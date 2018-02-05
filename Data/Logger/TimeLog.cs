using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Logger
{
    [Serializable]
    public class TimeLog
    {
        public DateTime Start { get; set; }
        public DateTime Stop { get; set; }
    }
}
