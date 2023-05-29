//using System;
//using System.Windows.Media;

//namespace PersonnelManagement.Helpers
//{
//    public static class ProjectStatusHelper
//    {
//        public static string GetProjectStatus(DateTime startProject, DateTime finishProject)
//        {
//            DateTime currentDate = DateTime.Now;

//            if (currentDate < startProject)
//            {
//                return "Ожидание";
//            }
//            else if (currentDate >= startProject && currentDate <= finishProject)
//            {
//                return "Запущен";
//            }
//            else if (currentDate > finishProject)
//            {
//                return "Завершен";
//            }

//            return string.Empty;
//        }

//        public static SolidColorBrush GetProgressBarColor(DateTime startProject, DateTime finishProject)
//        {
//            DateTime currentDate = DateTime.Now;
//            TimeSpan remainingTime = finishProject - currentDate;

//            if (currentDate < startProject)
//            {
//                return Brushes.Transparent;
//            }
//            else if (remainingTime.TotalDays <= 2)
//            {
//                return Brushes.Red;
//            }
//            else
//            {
//                return Brushes.Green;
//            }
//        }
//    }

//}
