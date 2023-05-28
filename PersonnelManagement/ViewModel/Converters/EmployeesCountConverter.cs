using PersonnelManagement.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Data;

namespace PersonnelManagement.ViewModel.Converters
{
    public class EmployeesCountConverter : IMultiValueConverter

    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ICollection collection)
            {
                return collection.Count;
            }

            return 0;
        }

     
            public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
            {
            if (values != null && values.Length > 0)
            {
                if (values[0] is ObservableCollection<Worker> collection)
                {
                    return collection.Count;
                }
            }

            return 0;
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
