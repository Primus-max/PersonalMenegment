using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace PersonnelManagement.ViewModel.Converters
{
    public class IsActiveToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int isActive)
            {
                return isActive == 1 ? Visibility.Visible : Visibility.Collapsed;
            }
            return Visibility.Collapsed; // Скрывать кнопку, если значение не является целым числом
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
