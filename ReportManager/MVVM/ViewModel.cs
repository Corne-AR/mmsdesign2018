using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ReportManager.MVVM
{
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected Dictionary<string, object> ObjectValues { get; } = new Dictionary<string, object>();

        protected T GetValue<T>([CallerMemberName] string Name = null)
        {
            if (!ObjectValues.ContainsKey(Name)) return default(T);

            return (T)ObjectValues[Name];
        }
    
        protected void SetValue<T>(T Value, [CallerMemberName] string Name = null)
        {
            ObjectValues[Name] = Value;
        }

        public void RaisePropertiesChanged() => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
    }
}
