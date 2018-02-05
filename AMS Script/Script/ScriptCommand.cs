using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS_Script.Script
{
    public class ScriptCommand
    {
        //  Value    Input Value
        //  ;        End Line 
        //  //       Comment Line out
        //  int      integer
        //  decimal  decimal
        //  =        equals
        //  /        divide
        //  *        multiply
        //  +        add
        //  -        minus
        //  ()       do bracket as a unit answer
        //  1-9 etc  numbers
        //  .        decimal separator

        // example command =  fnCurrencyConvert = Int(pPrys / factor * 0.9 / 5) * 5 + 5

        public ScriptCommand(string Command)
        {
            // Check to which command it belongs, a variable or a maths
            var checkCommand = Command.Trim().Split('=');
            var checkVariable = checkCommand[0].Trim().Split(' ');

            // Variable ex: Int X;
            if (checkCommand.Count() == 1)
            {
                SetVariable(checkCommand[0], "0");
                return;
            }

            // Variable with Value ex: Int X = 100;
            if (checkCommand.Count() == 2 && checkCommand[1].Trim().Split(' ').Count() == 1 && checkVariable.Count() < 3)
            {
                SetVariable(checkCommand[0], checkCommand[1]);
                return; // No need to father check the command
            }
         
            // Maths ex: X = X * 5;
            DoMaths(checkVariable[0], checkCommand[1].Trim());
            return;
        }

        /// <summary>
        /// Add a value to a variable
        /// </summary>
        /// <param name="Name">Name of variable</param>
        /// <param name="Value">Value to be set</param>
        private void SetVariable(string Name, string Value)
        {
            Name = Name.Trim();
            if (Value != null) Value = Value.Trim();

            //var variable = new Commands.Variable();

            // Query for existing variables
            var queryVarName = (from i in Data.VariableList
                             where i.Name == Name
                             select i).FirstOrDefault();
            // Query if the Value is from another variable 
            var queryVarValue = (from i in Data.VariableList
                              where i.Name == Value
                              select i).FirstOrDefault();

            // if the Value is from another variable, then get it's value
            if (queryVarValue != null) Value = queryVarValue.GetValue().ToString();

            // Finally set the Variable's value
            if (queryVarName != null)
            {
                // Set value to an existing variable
                if (Value != null) queryVarName.SetValue(Value);
                return;
            }
            else
            {
                // Else set a new Variable

                var type = Name.Split(' ')[0];
                var name = Name.Split(' ')[1];

                var newVar = new Commands.Variable();
                newVar.Name = name;
                newVar.VariableType = (VariableType)Enum.Parse(typeof(VariableType), type);
                
                if (Value != null) newVar.SetValue(Value);
                Data.VariableList.Add(newVar);
            }
        }

        private decimal DoMaths(string command)
        {
            decimal value = 0m;

            //if (command.Contains("("))
            //{
            //    var commandBetweenBrackets = command.Split('(')[1].Split(')')[0];
            //    value = DoMaths(commandBetweenBrackets);

            //    command = command.Split('(')[0] + value + command.Split(')')[1];
            //}

            List<string> itemList = new List<string>();
            foreach (var i in command.Split(' '))
                itemList.Add(i);

            while (itemList.Count() != 1)
            {
                Commands.Maths math = new Commands.Maths();

                var firstValue = (from i in Data.VariableList
                                  where i.Name == itemList[0]
                                  select i).FirstOrDefault();


                var secondValue = (from i in Data.VariableList
                                   where i.Name == itemList[2]
                                   select i).FirstOrDefault();

                if (firstValue != null) math.FirstValue = Convert.ToDecimal(firstValue.GetValue());
                else math.FirstValue = Convert.ToDecimal(itemList[0]);
                if (secondValue != null) math.SecondValue = Convert.ToDecimal(secondValue.GetValue());
                else math.SecondValue = Convert.ToDecimal(itemList[2]);

                math.Type = math.GetCommandType(itemList[1]);

                itemList.RemoveRange(0, 2); // Removing the first 3 items in the command
                itemList[0] = math.Value.ToString();
                value = Convert.ToDecimal(itemList[0]);
            }

            return value;
        }

        private void DoMaths(string name, string command)
        {
            SetVariable(name, DoMaths(command).ToString());
        }
    }
}