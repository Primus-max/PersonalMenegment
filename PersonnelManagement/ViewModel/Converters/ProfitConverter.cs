using System;
using System.Globalization;
using System.Windows.Data;

namespace PersonnelManagement.ViewModel.Converters
{
    public class ProfitConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            decimal profit = (decimal)value;

            if (profit == 0)
            {
                return "Нет прибыли";
            }

            return profit.ToString("C", culture).Replace("$", "₽");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
