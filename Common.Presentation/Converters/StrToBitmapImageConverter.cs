using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Common.Presentation.Converters
{
    public class StrToBitmapImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null && string.IsNullOrWhiteSpace(value.ToString()) == false)
            {
                BitmapImage source = new BitmapImage();
                source.BeginInit();
                try
                {
                    source.UriSource = new Uri(value.ToString(), UriKind.Relative);
                    source.CacheOption = BitmapCacheOption.OnLoad;
                }
                finally
                {
                    source.EndInit();
                }
                return source;
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
