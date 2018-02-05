using AMS_Script.Script;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AMS_Script
{
    public static class Data
    {
        public static List<ScriptCommand> CommandList { get; set; }
        public static HashSet<Commands.Variable> VariableList;
    }
}
