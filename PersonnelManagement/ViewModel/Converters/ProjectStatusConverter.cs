using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace PersonnelManagement.ViewModel.Converters
{
    public class ProjectStatusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime startProject && parameter is DateTime finishProject)
            {
                DateTime currentDate = DateTime.Now;
                TimeSpan remainingTime = finishProject - currentDate;

                string status;
                SolidColorBrush progressBarColor;

                if (currentDate < startProject)
                {
                    status = "Ожидание";
                    progressBarColor = Brushes.Transparent;
                }
                else if (remainingTime.TotalDays <= 2)
                {
                    status = "Завершение";
                    progressBarColor = Brushes.Red;
                }
                else
                {
                    status = "Запущен";
                    progressBarColor = Brushes.Green;
                }

                return new Tuple<string, SolidColorBrush>(status, progressBarColor);
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
