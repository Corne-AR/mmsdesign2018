using AMS_Script.Script;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS_Script.Commands
{
    public class Variable
    {
        public string Name { get; set; }
        public object value { get; set; }
        public VariableType VariableType { get; set; }

        public object GetValue() { return value; }
        public object SetValue(string Value)
        {
            if (string.IsNullOrEmpty(Value)) Value = "0";

            switch (VariableType)
            {
                case VariableType.Decimal:
                    value = Convert.ToDecimal(Value);
                    break;
                case VariableType.IntFloor:
                    value = Convert.ToInt32(Math.Floor(Convert.ToDouble(Value)));
                    break;
                case VariableType.Int:
                    value = Convert.ToInt32(Convert.ToDouble(Value));
                    break;
                case VariableType.Money:
                    value = Math.Round(Convert.ToDecimal(Value), 2);
                    break;
            }

            return value;
        }

        #region HashSet Identifier

        public override bool Equals(object obj)
        {
            var other = obj as Variable;
            if (other == null)
            {
                return false;
            }
            if (Name == null) return false;
            return Name == other.Name;
        }

        public override int GetHashCode()
        {
            if (Name == null) return 0;
            return (Name).GetHashCode();
        }

        #endregion
    }
}