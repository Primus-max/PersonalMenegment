using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using PersonnelManagement.Model;

namespace PersonnelManagement.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
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
        protected virtual void OnProperty(params string[] propertyNames)
        {
            if (PropertyChanged != null)
            {
                foreach (string propertyName in propertyNames) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                PropertyChanged(this, new PropertyChangedEventArgs("HasError"));
            }
        }
        #endregion
    }
}
