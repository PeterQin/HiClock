using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Data;

namespace Common.Presentation.Converters
{
    public class StrToIntConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int result;
            if (value != null && Int32.TryParse(value.ToString(), out result))
            {
                return result;
            }
            else
            {
                return new ValidationResult(false, "Invaild input");
            }
        }
    }
}
