using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Serialization;


namespace AMS.IO
{
    public static class Serializer
    {
        public static void Write(string filename, Object objectToSerialize)
        {
            Stream stream = System.IO.File.Open(filename, FileMode.Create);
            BinaryFormatter bFormatter = new BinaryFormatter();
            bFormatter.Serialize(stream, objectToSerialize);
            stream.Close();
        }

        public static Object Read(string filename)
        {
            Object objectToSerialize;
            Stream stream = System.IO.File.Open(filename, FileMode.Open);
            BinaryFormatter bFormatter = new BinaryFormatter();
            objectToSerialize = (Object)bFormatter.Deserialize(stream);
            stream.Close();
            return objectToSerialize;
        }

        public static bool EncryptWrite(string filename, Object obj)
        {
            bool wrote = false;
            try
            {
                var key = new DESCryptoServiceProvider().CreateEncryptor(Encoding.ASCII.GetBytes("64BitPas"), Encoding.ASCII.GetBytes(AMS.Settings.Security.SecurityKey));

                using (FileStream fs = System.IO.File.Open(filename, FileMode.Create))
                {
                    using (CryptoStream cs = new CryptoStream(fs, key, CryptoStreamMode.Write))
                    {
                        BinaryFormatter bFormatter = new BinaryFormatter();
                        bFormatter.Serialize(cs, obj);
                    }
                } wrote = true;
            }
            catch { throw new Exception(); }

            return wrote;
        }

        public static Object DecryptRead(string filename)
        {
            if (!System.IO.File.Exists(filename))
                return null;

            Object objectToSerialize = new object();
            try
            {
                var key = new DESCryptoServiceProvider().CreateDecryptor(Encoding.ASCII.GetBytes("64BitPas"), Encoding.ASCII.GetBytes(AMS.Settings.Security.SecurityKey));

                using (FileStream fs = System.IO.File.Open(filename, FileMode.Open))
                {
                    using (CryptoStream cs = new CryptoStream(fs, key, CryptoStreamMode.Read))
                    {
                        BinaryFormatter bFormatter = new BinaryFormatter();
                        objectToSerialize = (Object)bFormatter.Deserialize(cs);
                    }
                }
            }
            catch (Exception ex) 
            {
                objectToSerialize = null;
                AMS.MessageBox_v2.Show("Unable to Read File '" + filename + "'\r\n\r\n" + ex.Message, MessageType.Error); 
            }

            return objectToSerialize;
        }

        internal static bool EncryptWrite(string filename, object xmlDataClass, string Message, bool AlwaysOverwrite)
        {
            bool wrote = false;

            // Check FilePath
            FileInfo f = new FileInfo(filename);

            if (f.Exists && !AlwaysOverwrite)
            {
                if (MessageBox_v2.Show("File '" + f.Name + "' Already Exists.\r\nOverride Existing File?\r\n\r\n" + Message, MessageType.Question) == MessageOut.No)
                    return false;
            }

            try
            {
                if (!Directory.Exists(f.DirectoryName)) Directory.CreateDirectory(f.DirectoryName);
                var key = new DESCryptoServiceProvider().CreateEncryptor(Encoding.ASCII.GetBytes("64BitPas"), Encoding.ASCII.GetBytes(AMS.Settings.Security.SecurityKey));

                using (FileStream fs = System.IO.File.Open(filename, FileMode.Create))
                {
                    using (CryptoStream cs = new CryptoStream(fs, key, CryptoStreamMode.Write))
                    {
                        BinaryFormatter bFormatter = new BinaryFormatter();
                        bFormatter.Serialize(cs, xmlDataClass);
                    }
                }

                wrote = true;
            }
            catch { throw new Exception(); }

            return wrote;
        }
    }
}
