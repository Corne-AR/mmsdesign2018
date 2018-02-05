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
    public static class Help
    {
        public static string Instructions
        {
            get
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendLine("Instructions");
                sb.AppendLine("   " + "Variables need to have a Type and an unique Name");
                sb.AppendLine("   " + "Variables can be added to via the 'Variable List' or in the script dynamically");
                sb.AppendLine("   " + "Note: the Variable 'Value' is a internal variable");
                sb.AppendLine("   " + "   Int x;");
                sb.AppendLine("   " + "   Int y = 7;");
                sb.AppendLine("   " + "Each command line requires neatly spaced scripts and ends with a ';'");
                sb.AppendLine("   " + "   x = y / 5 * 0.1;");
                sb.AppendLine("   " + "Comments are allowed, but requires a ';' to make sure the scrip knows when it ends");
                sb.AppendLine();

                sb.AppendLine("List of available variables");
                foreach (var i in Enum.GetValues(typeof(VariableType)))
                {
                    FieldInfo fi = i.GetType().GetField(i.ToString());

                    DescriptionAttribute[] attributes =
                        (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

                    if (attributes.Count() > 0) sb.AppendLine("   " + i.ToString() + " - " + attributes[0].Description);
                    else sb.AppendLine("   " + i.ToString());
                }
                sb.AppendLine();

                sb.AppendLine("List of commands");
                foreach (var i in Enum.GetValues(typeof(CommandType)))
                {
                    FieldInfo fi = i.GetType().GetField(i.ToString());

                    DescriptionAttribute[] attributes =
                        (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

                    if (attributes.Count() > 0) sb.AppendLine("   " + i.ToString() + " - " + attributes[0].Description);
                    else sb.AppendLine("   " + i.ToString());
                }

                return sb.ToString();
            }
        }
    }
}
