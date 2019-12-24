using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace RomanApp.Client.UWP.Converters
{
    public class AnyToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            Visibility retval = Visibility.Collapsed;

            if (value is System.Collections.ICollection collection)
            {
                if (collection.Count > 0)
                {
                    retval = Visibility.Visible;
                }
            }

            return retval;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
