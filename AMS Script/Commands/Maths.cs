using AMS_Script.Script;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS_Script.Commands
{
    public class Maths
    {
        public CommandType Type { get; set; }
        public decimal FirstValue { get; set; }
        public decimal SecondValue { get; set; }
        private decimal value { get; set; }
        public decimal Value { get { GetValue(); return value; } }

        private void GetValue()
        {
            try
            {
                switch (Type)
                {
                    case CommandType.Add:
                        value = FirstValue + SecondValue;
                        break;

                    case CommandType.Divide:
                        value = (decimal)FirstValue / SecondValue;
                        break;

                    case CommandType.Minus:
                        value = FirstValue - SecondValue;
                        break;
                    case CommandType.Multiply:
                        value = FirstValue * SecondValue;
                        break;
                }
            }
            catch { throw new Exception("Cannot calculate '" + FirstValue + "' " + Type.ToString() + " '" + SecondValue + "'"); }
        }

        public CommandType GetCommandType(string type)
        {
            CommandType commandType = new CommandType();
            if (type.ToString().Trim() == "+") commandType = CommandType.Add;
            if (type.ToString().Trim() == "-") commandType = CommandType.Minus;
            if (type.ToString().Trim() == "/") commandType = CommandType.Divide;
            if (type.ToString().Trim() == "*") commandType = CommandType.Multiply;


            return commandType;
        }
    }
}
