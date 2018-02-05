using AMS.Data;
using AMS.Data.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace AMS.IO
{
    /// <summary>
    /// This version enforce a message box when overwriting the file. This is not thread safe and cannot work in WPF environment safely.
    /// <para>However, for MMS Design WinForms software, this is still Ok.</para>
    /// </summary>
    public static class XML_v1
    {
        // Creates an Object to load XML Data into for serialization
        //static Object xmlDataObject;
        
        /// <summary>
        /// Basic .xml File Write
        /// </summary>
        /// <param name="data">A PUBLIC class derived from DataClass</param>
        /// <param name="File">aFile</param>
        /// <param name="AlwaysOverwrite">Will not prompt for overwrite question</param>
        /// <returns></returns>
        public static bool Writter<T>(Object data, aFile File, string Message, bool AlwaysOverwrite)
        {
            return Writter<T>(data, File, Message, AlwaysOverwrite, AMS.Settings.Security.UseEncryption);
        }

        /// <summary>
        /// Basic .xml File Write
        /// </summary>
        /// <typeparam name="T">Object Type</typeparam>
        /// <param name="data">A PUBLIC class derived from DataClass</param>
        /// <param name="File">aFile</param>
        /// <param name="AlwaysOverwrite">Will not prompt for overwrite question</param>
        /// <param name="Encrypted">Override default Encryption</param>
        /// <returns></returns>
        public static bool Writter<T>(Object data, aFile File, string Message, bool AlwaysOverwrite, bool Encrypted)
        {
            bool wrote = false;

            if (Encrypted)
                wrote = IO.Serializer.EncryptWrite(File.FullName, data, Message, AlwaysOverwrite);
            else
                wrote = NormalWritter<T>(data, File, Message, AlwaysOverwrite);

            return wrote;
        }

        /// <summary>
        /// Read xml file into LoadXML object
        /// </summary>
        /// <param name="FileName">Location and File Name of xml</param>
        public static Object Reader<T>(string FileName)
        {
            return Reader<T>(FileName, AMS.Settings.Security.UseEncryption);
        }

        /// <summary>
        /// Read xml file into LoadXML object
        /// </summary>
        /// <typeparam name="T">Object Type</typeparam>
        /// <param name="FileName">Location and File Name of xml</param>
        /// <param name="Encrypted">Override default encryption</param>
        /// <returns></returns>
        public static Object Reader<T>(string FileName, bool Encrypted)
        {
            Object obj = null;

            if (Encrypted)
                obj = IO.Serializer.DecryptRead(FileName);
            else
                obj = NormalReader<T>(FileName);

            return obj;
        }

        // Private Methods

        private static bool NormalWritter<T>(Object data, aFile File, string Message, bool AlwaysOverwrite)
        {
            bool wroteFile = false;
            FileInfo f = new FileInfo(File.FullName);
            try
            {
                // Check FilePath
                if (!Directory.Exists(f.DirectoryName)) Directory.CreateDirectory(f.DirectoryName);

                if (f.Exists && !AlwaysOverwrite)
                {
                    if (MessageBox_v2.Show("File '" + f.Name + "' Already Exists.\r\nOverride Existing File?\r\n\r\n" + Message, MessageType.Question) == MessageOut.No)
                        return false;
                }

                // Write Data
                XmlSerializer writter = new XmlSerializer(typeof(T));

                using (System.IO.StreamWriter file = new System.IO.StreamWriter(File.FullName))
                {
                    writter.Serialize(file, data);
                    file.Close();
                }

                wroteFile = true;
            }
            catch (Exception ex) { throw ex; }

            return wroteFile;
        }

        private static Object NormalReader<T>(string File)
        {
            if (!System.IO.File.Exists(File))
                return null;
            Object obj = new object();
            XmlSerializer reader = new XmlSerializer(typeof(T));
            try
            {
                using (System.IO.FileStream fs = new System.IO.FileStream(File, System.IO.FileMode.Open))
                {
                    XmlReader xmlReader = new XmlTextReader(fs);
                    obj = (Object)reader.Deserialize(xmlReader);
                }
            }
            catch (Exception ex) { MessageBox_v2.Show("Error Reading Data\r\n" + File + "\r\n" + ex.Message, MessageType.Error); obj = null; }

            return obj;
        }
    }
}