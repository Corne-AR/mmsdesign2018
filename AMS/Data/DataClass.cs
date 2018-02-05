using AMS.Data.Common;
using AMS.Data.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AMS.Data
{
    /// <summary>
    /// AMS Data base type
    /// </summary>
    [Serializable]
    public class DataClass : IDisposable, INotifyPropertyChanged
    {
        //[field: NonSerialized]
        //public event EventHandler OnSaved_Event;
        //[field: NonSerialized]
        //public event EventHandler Save_Event;

        /// <summary>
        /// Use for Primary Key
        /// </summary>
        public string ID { get; set; }

        public string Notes { get; set; }
        //public List<string> DatalogIDList { get; set; }
        public Metadata Metadata { get; set; }
        public HashSet<Datalog> DatalogList { get; set; }
        public string OLDGetArchiveFolder
        {
            get
            {
                return ""; // AMS.Settings.Program.Archives + File.Extension.ToString() + ID;
            }
        }

        [field: NonSerialized]
        private aFile file;
        [XmlIgnore]
        public aFile File { get { return file; } }
        [XmlIgnore]
        internal aFile OriginalFile { get; private set; }          // Used to save the old file name before changing the new file

        [field: NonSerialized]
        private Dictionary<string, object> _values;
        protected Dictionary<string, object> Values
        {
            get
            {
                if (_values == null) _values = new Dictionary<string, object>();
                return _values;
            }
        }

        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        public DataClass()
        {
            Metadata = new Metadata();
            DatalogList = new HashSet<Datalog>();
            //DatalogIDList = new List<string>();
            OriginalFile = new aFile();
        }

        // Methods

        //public T Clone<T>()
        //{
        //    System.Runtime.Serialization.IFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
        //    System.IO.Stream stream = new System.IO.MemoryStream();
        //    using (stream)
        //    {
        //        formatter.Serialize(stream, this);
        //        stream.Seek(0, System.IO.SeekOrigin.Begin);
        //        var obj = (T)formatter.Deserialize(stream);

        //        return obj;
        //    }
        //}

        public void SetFile(string Name, string Location, DataType Extension)
        {
            file = new aFile();
            file.SetFile(Name, Location, Extension);
        }

        public void SetFile(AMS.Data.IO.aFile aFile)
        {
            file = aFile;
        }

        internal void SetOrignalFile(string Name, string Location, DataType Extension)
        {
            OriginalFile = new aFile();
            OriginalFile.SetFile(Name, Location, Extension);
        }

        public object Clone()
        {
            System.Runtime.Serialization.IFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            System.IO.Stream stream = new System.IO.MemoryStream();
            using (stream)
            {
                formatter.Serialize(stream, this);
                stream.Seek(0, System.IO.SeekOrigin.Begin);
                var obj = (DataClass)formatter.Deserialize(stream);
                if (OriginalFile != null) obj.OriginalFile.SetLocation("");
                return obj;
            }
        }

        public void Copy(object Source)
        {
            var destProperties = this.GetType().GetProperties();
            var sourceProperties = Source.GetType().GetProperties();

            foreach (var sourceProperty in sourceProperties)
            {
                foreach (var destProperty in destProperties)
                {
                    if (destProperty.CanWrite && destProperty.Name == sourceProperty.Name && destProperty.PropertyType.IsAssignableFrom(sourceProperty.PropertyType))
                    {
                        destProperty.SetValue(this, sourceProperty.GetValue(Source, new object[] { }), new object[] { });

                        break;
                    }
                }
            }
        }

        public void AddNote(string Note)
        {
            Notes += Note + "\r\n";
        }

        /// <summary>
        /// Adds notes to this data class
        /// </summary>
        /// <param name="Referece">From where does the note come in the program</param>
        /// <param name="Message">What is needed to be saved?</param>
        /// <param name="DataType"></param>
        public void AddDataLog(string Referece, string Message, DataType DataType)
        {
            //if (DatalogIDList == null) DatalogList = new HashSet<Datalog>();
            if (DatalogList == null) DatalogList = new HashSet<Datalog>();
            Datalog dataLog = new Datalog();

            dataLog.Message = Message;
            dataLog.Created = DateTime.Now;
            dataLog.UserName = AMS.Users.UserManager.CurrentUser.Username;
            dataLog.Reference = Referece;
            dataLog.DataType = DataType;

            DatalogList.Add(dataLog);
        }

        public void ViewDatalogOnly()
        {
            using (Forms.Log.DatalogViewer f = new Forms.Log.DatalogViewer(this))
                f.ShowDialog();
        }

        // Dispose
        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Do manual clearing of items here, if needed
                }
                // Release unmanaged resources.
                disposed = true;
            }

        }

        //internal void OnSaved()
        //{
        //    if (OnSaved_Event != null && !AMS.Data.GobalManager.ControlsSuspended) OnSaved_Event(this, EventArgs.Empty);
        //}

        #region HashSet Identifier

        /// <summary>
        /// Hash identifier.
        /// </summary>
        protected string HashID { get { return $"{ID}"; } }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            var other = obj as DataClass;
            if (other == null || string.IsNullOrEmpty(HashID)) return false;
            return HashID == other.HashID;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        public override int GetHashCode() => (HashID).GetHashCode();

        #endregion

        protected T GetValue<T>([CallerMemberName] string Name = null)
            => (T)Values[Name];

        protected void SetValue<T>(T Value, [CallerMemberName] string Name = null)
        {
            Values[Name] = Value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Name));
        }

    }
}