using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.IO
{
    /// <summary>
    /// IO of text strings
    /// </summary>
    public static class Text
    {
        /// <summary>
        /// Writes the specified text lines to a file.
        /// </summary>
        /// <param name="TextLines">The text lines.</param>
        /// <param name="FileName">Name of the file.</param>
        /// <returns>true if saved</returns>
        /// <exception cref="System.Exception">Unable to save</exception>
        public static bool Write(List<string> TextLines, string FileName)
        {
            bool saved = false;
            if (TextLines == null) TextLines = new List<string>();

            try
            {
                System.IO.File.WriteAllLines(FileName, TextLines);
                saved = true;
            }
            catch (Exception ex) { throw new Exception(ex.Message + "+\r\n\r\nUnable to Save: " + FileName); }

            return saved;
        }

        /// <summary>
        /// Writes the specified text to a file
        /// </summary>
        /// <param name="Text">The text.</param>
        /// <param name="FileName">Name of the file.</param>
        /// <returns>true if saved</returns>
        /// <exception cref="System.Exception">Unable to save</exception>
        public static bool Write(string Text, string FileName)
        {
            bool saved = false;

            try
            {
                System.IO.File.WriteAllText(FileName, Text);
                saved = true;
            }
            catch (Exception ex) { throw new Exception(ex.Message + "+\r\n\r\nUnable to Save: " + FileName); }

            return saved;
        }

        /// <summary>
        /// Reads the specified file name into a string
        /// </summary>
        /// <param name="FileName">Name of the file.</param>
        /// <returns>string of read file</returns>
        /// <exception cref="System.Exception">Unable to read file</exception>
        public static string Read(string FileName)
        {
            StringBuilder read = new StringBuilder();
            try
            {
                foreach (var line in System.IO.File.ReadAllLines(FileName, Encoding.Default))
                {
                    read.Append(line);
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message + "+\r\n\r\nUnable to Read: " + FileName); }

            return read.ToString();
        }
    }
}
