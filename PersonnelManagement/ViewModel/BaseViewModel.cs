using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using PersonnelManagement.Model;

namespace PersonnelManagement.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged, IDisposable
    {
        protected DataModel _data;
        protected string _action;
        
        public Action Close { get; set; }

        public string Action
        {
            get => _action;
            set
            {
                _action = value;
                OnProperty("Action");
            }
        }

        public void Message(string message)
        {
            MessageBox.Show(message);
        }

        public virtual void Execute()
        {

        }

        #region Event
        public virtual event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnProperty([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
        #endregion

        // Метод установки свойст
        protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string PropertyName = null)
        {
            if (Equals(field, value)) return false;
            field = value;
            OnProperty(PropertyName);

            return true;

        }

        public void Dispose()
        {
            Dispose(true);
        }

        private bool _disposed;

        protected virtual void Dispose(bool Disposing)
        {
            if (!Disposing || _disposed) return;
            _disposed = true;
        }
    }
}
