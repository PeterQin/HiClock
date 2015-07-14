using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace Common.Presentation.Converters
{
    public class BooleanToVisibilityConverter : IValueConverter
    {

        private bool FReversal = false;

        public bool Reversal
        {
            get { return FReversal; }
            set { FReversal = value; }
        }
        
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool visible = false;
            Visibility result = Visibility.Collapsed;
            if (value != null && Boolean.TryParse(value.ToString(), out visible))
            {
            }

            if (Reversal)
            {
                result = visible ? Visibility.Collapsed : Visibility.Visible;
            }
            else
            {
                result = visible ? Visibility.Visible : Visibility.Collapsed;
            }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
