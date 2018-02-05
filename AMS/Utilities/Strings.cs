using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace System
{
    /// <summary>
    /// String Utilities
    /// </summary>
    public static class Strings
    {
        /// <summary>
        /// Gets the bytes.
        /// </summary>
        /// <param name="String">The string.</param>
        /// <returns></returns>
        public static byte[] GetBytes(this string String)
        {
            byte[] bytes = new byte[String.Length * sizeof(char)];
            System.Buffer.BlockCopy(String.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        /// <summary>
        /// Gets the string.
        /// </summary>
        /// <param name="Bytes">The bytes.</param>
        /// <returns></returns>
        public static string GetString(this byte[] Bytes)
        {
            char[] chars = new char[Bytes.Length / sizeof(char)];
            System.Buffer.BlockCopy(Bytes, 0, chars, 0, Bytes.Length);
            return new string(chars);
        }

        /// <summary>
        /// Removes the whitespace.
        /// </summary>
        /// <param name="Value">The input.</param>
        /// <returns></returns>
        public static string ToRemoveWhiteSpace(this string Value)
        {
            if (string.IsNullOrEmpty(Value)) return null;
            return new string(Value.Where(c => !Char.IsWhiteSpace(c)).ToArray());
        }

        /// <summary>
        /// Spaces the after capital.
        /// </summary>
        /// <param name="Value">The input.</param>
        /// <returns></returns>
        public static string ToSpaceAfterCapital(this string Value)
        {
            return string.Join(
                string.Empty,
                Value.Select((x, i) => (
                    char.IsUpper(x) && i > 0 &&
                    (char.IsLower(Value[i - 1]) || (i < Value.Count() - 1 && char.IsLower(Value[i + 1])))
                    ) ? " " + x : x.ToString()));
        }

        /// <summary>
        /// Removes white spaces and then add single white space after capital.
        /// </summary>
        /// <param name="Value">The value.</param>
        /// <returns></returns>
        public static string Neat(this string Value)
        => Value.ToRemoveWhiteSpace().ToSpaceAfterCapital();

        /// <summary>
        /// Uppercases the first.
        /// </summary>
        /// <param name="Value">The string value.</param>
        /// <returns></returns>
        public static string ToUpperFirst(this string Value)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(Value)) return string.Empty;

            // Return char and concat substring.
            Value = char.ToUpper(Value[0]) + Value.Substring(1);
            return Value;
        }

        /// <summary>
        /// Converts a string with a separator character into a list of strings
        /// </summary>
        /// <param name="String">String containing data to be separated</param>
        /// <param name="Delimitater">Char to use as delimitation</param>
        /// <param name="RemoveEmpty">By default, remove any empty value</param>
        /// <returns></returns>
        public static List<string> StringToList(this string String, char Delimitater, bool RemoveEmpty = true)
        {
            return RemoveEmpty ?
                String.Split(new[] { Delimitater }, StringSplitOptions.RemoveEmptyEntries).ToList() :
                String.Split(new[] { Delimitater }).ToList();
        }

        /// <summary>
        /// Converts a string with a separator character into a unique list of strings
        /// </summary>
        /// <param name="String">String containing data to be separated</param>
        /// <param name="Delimitater">Char to use as delimitation</param>
        /// <param name="RemoveEmpty">By default, remove any empty value</param>
        /// <returns></returns>
        public static HashSet<string> StringToHashSet(this string String, char Delimitater, bool RemoveEmpty = true)
            => new HashSet<string>(StringToList(String, Delimitater, RemoveEmpty));

        /// <summary>
        /// Determines whether if string is numbers only.
        /// </summary>
        /// <param name="Value">The string.</param>
        public static bool IsNumbersOnly(this string Value)
        {
            foreach (char c in Value)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        /// <summary>
        /// To letters only.
        /// </summary>
        /// <param name="Value">The value.</param>
        /// <returns></returns>
        public static string ToLettersOnly(this string Value)
            => new String(Value.Where(Char.IsLetter).ToArray());

        public static int ToNumbersOnly(this string Value)
            => Convert.ToInt32(new String(Value.Where(Char.IsNumber).ToArray()));


    }
}