using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS_Script.Script
{
    public enum CommandType
    {
        [Description("1 + 2 = 3")]
        Add,
        [Description("1 - 2 = -1")]
        Minus,
        [Description("1 / 2 = 0.5")]
        Divide,
        [Description("1 * 2 = 2")]
        Multiply
    }
}
