using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AMS_Script.Script
{
    public class aScript
    {
        public string Name { get; set; }
        public string InValue { get; set; }
        private string outValue;
        public string OutValue { get { Decode(ScriptContent); return outValue; } }
        public string ScriptContent { get; set; }
        public string Summary
        {
            get
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendLine("Script: " + Name);
                sb.AppendLine();
                sb.AppendLine(ScriptContent);

                sb.AppendLine();
                sb.AppendLine("----------");
                sb.AppendLine();
                sb.AppendLine("Factor List");
                sb.AppendLine();

                foreach (var i in VariableList.ToList())
                    sb.AppendLine(i.Name + " - " + i.value);

                return sb.ToString();
            }
        }


        public HashSet<Commands.Variable> VariableList
        {
            get
            {
                if (Data.VariableList == null) Decode(ScriptContent);
                return Data.VariableList;
            }
        }

        public string Stats
        {
            get
            {

                if (GetCommandList().Count == 0) return "N/A";

                StringBuilder sb = new StringBuilder();

                sb.AppendLine("SCRIPT STATS");
                sb.AppendLine();
                sb.AppendLine("Command Count: " + GetCommandList().Count);
                sb.AppendLine();
                sb.AppendLine("Variable List:");

                foreach (var i in Data.VariableList)
                {
                    sb.AppendLine("     " + i.VariableType.ToString() + " " + i.Name + " = " + i.GetValue());
                }

                return sb.ToString();
            }
        }

        private string message;
        public string Message
        {
            get { return message; }
        }

        /// <summary>
        /// Script will auto decode. if answer is possible, then OutValue will Return a string
        /// </summary>
        /// <param name="Script">Script Text</param>
        public aScript(string InitialValue)
        {
            // Return, if script is not valid
            this.InValue = InitialValue;
        }

        public aScript()
        {
            // TODO: Complete member initialization
        }

        public void Decode(string ScriptContent)
        {
            if (ScriptContent == null || ScriptContent.Length < 2) { message = null; return; }
            this.ScriptContent = ScriptContent;

            Data.CommandList = new List<ScriptCommand>();
            Data.VariableList = new HashSet<Commands.Variable>();

            var inVar = new Commands.Variable();
            inVar.Name = "InValue";
            inVar.VariableType = VariableType.Decimal;
            inVar.SetValue(this.InValue);

            var outVar = new Commands.Variable();
            outVar.Name = "OutValue";
            outVar.VariableType = VariableType.Decimal;
            outVar.SetValue(this.outValue);

            Data.VariableList.Add(inVar);
            Data.VariableList.Add(outVar);

            foreach (var i in ScriptManager.FactorList)
                Data.VariableList.Add(i);

            Decode();
        }

        // Take script and try decode every element
        private void Decode()
        {
            string currentCmd = "";
            try
            {
                foreach (string cmd in GetCommandList())
                {
                    currentCmd = cmd;
                    // Decipher each command
                    Data.CommandList.Add(new ScriptCommand(cmd));
                }

                currentCmd = "";
                message = "OutValue = " + (from i in Data.VariableList where i.Name == "OutValue" select i).FirstOrDefault().GetValue();

                outValue = (from i in Data.VariableList
                            where i.Name == "OutValue"
                            select i).FirstOrDefault().GetValue().ToString();
            }
            catch { message = "ERROR\r\n" + currentCmd + "\r\n\r\n"; }
        }

        // Separate each command into listOfCommands
        private List<string> GetCommandList()
        {
            if (ScriptContent == null || ScriptContent.Length < 2) { message = null; return new List<string>(); }

            List<string> commandList = new List<string>();
            var commands = ScriptContent.Trim().Split(';');

            foreach (string cmdLine in commands)
            {
                // Remove the Comments
                string cmd = "";
                if (cmdLine.Contains("//"))
                {
                    var comments = Regex.Split(cmdLine, @"//");
                    if (comments.Count() > 1) cmd = comments[0].Trim();
                }
                else
                {
                    cmd = cmdLine.Trim();
                }

                if (cmd != null && cmd.Count() > 0) commandList.Add(cmd);
            }

            return commandList;
        }

        #region HashSet Identifier

        public override bool Equals(object obj)
        {
            var other = obj as aScript;
            if (other == null)
            {
                return false;
            }
            if (Name == null) return false;
            return Name == other.Name;
        }

        public override int GetHashCode()
        {
            return (Name).GetHashCode();
        }

        #endregion

    }
}