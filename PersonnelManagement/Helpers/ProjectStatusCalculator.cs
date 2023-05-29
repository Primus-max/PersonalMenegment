//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.ComponentModel;

//namespace PersonnelManagement.Helpers
//{
//    public class ProjectStatusCalculator : INotifyPropertyChanged
//    {
//        private DateTime startDate;
//        private DateTime endDate;
//        private double status;

//        public DateTime StartDate
//        {
//            get { return startDate; }
//            set
//            {
//                startDate = value;
//                CalculateStatus();
//                OnPropertyChanged(nameof(StartDate));
//            }
//        }

//        public DateTime EndDate
//        {
//            get { return endDate; }
//            set
//            {
//                endDate = value;
//                CalculateStatus();
//                OnPropertyChanged(nameof(EndDate));
//            }
//        }

//        public double Status
//        {
//            get { return status; }
//            private set
//            {
//                status = value;
//                OnPropertyChanged(nameof(Status));
//            }
//        }

//        public event PropertyChangedEventHandler PropertyChanged;

//        protected virtual void OnPropertyChanged(string propertyName)
//        {
//            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
//        }

//        private void CalculateStatus()
//        {
//            if (EndDate <= StartDate)
//            {
//                Status = 0;
//            }
//            else
//            {
//                TimeSpan totalDuration = EndDate - StartDate;
//                TimeSpan elapsedDuration = DateTime.Now - StartDate;
//                double progressPercentage = elapsedDuration.TotalMilliseconds / totalDuration.TotalMilliseconds * 100;
//                Status = Math.Clamp(progressPercentage, 0, 100);
//            }
//        }
//    }
//}
