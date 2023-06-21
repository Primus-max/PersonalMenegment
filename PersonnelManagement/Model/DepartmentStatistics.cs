using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;


namespace PersonnelManagement.Model
{
    public class DepartmentStatistics: INotifyPropertyChanged
    {
        public string DepartmentName { get; set; }
        public int EmployeeCount { get; set; }
      
        public decimal TotalProfit { get; set; }
        public decimal Budget { get; set; }
        public decimal Efficiency { get; set; }

        private ObservableCollection<Worker> _allWorkers;

        public ObservableCollection<Worker> AllWorkers
        {
            get { return _allWorkers; }
            set
            {
                if (_allWorkers != value)
                {
                    _allWorkers = value;
                    OnPropertyChanged(nameof(AllWorkers));
                }
            }
        }

        // Реализация интерфейса INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
