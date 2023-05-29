using System;
using System.Globalization;
using System.Windows.Data;

namespace PersonnelManagement.ViewModel.Converters
{
    public class SalaryConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is decimal salary)
            {
                // Форматирование значения зарплаты в удобочитаемый формат строки
                return salary.ToString("C", culture).Replace("$", "₽"); // Используется формат "C" для форматирования в денежный формат
            }

            return value; // Возвращение исходного значения, если не удалось преобразовать
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException(); // Обратное преобразование не требуется для отображения
        }
    }
}
