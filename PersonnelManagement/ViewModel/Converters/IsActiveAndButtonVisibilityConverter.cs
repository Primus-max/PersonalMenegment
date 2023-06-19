//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Windows.Data;
//using System.Threading.Tasks;

//namespace PersonnelManagement.Helpers
//{
//    public class IsActiveAndButtonVisibilityConverter : IMultiValueConverter
//    {
//        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
//        {
//            if (values.Length >= 2 && values[0] is bool isActive && values[1] is Visibility buttonVisibility)
//            {
//                if (isActive && buttonVisibility == Visibility.Visible)
//                {
//                    return Visibility.Visible;
//                }
//            }

//            return Visibility.Collapsed;
//        }

//        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
//        {
//            throw new NotImplementedException();
//        }
//    }

//}
