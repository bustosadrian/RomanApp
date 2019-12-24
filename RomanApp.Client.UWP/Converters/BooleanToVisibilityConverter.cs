using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace RomanApp.Client.UWP.Converters
{
    public class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var flag = false;
            if (value is bool)
            {
                flag = (bool)value;
            }
            else if (value is bool?)
            {
                var nullable = (bool?)value;
                flag = nullable.HasValue ? nullable.Value : false;
            }

            if (IsInverse)
            {
                flag = !flag;
            }

            return (flag ? Visibility.Visible : Visibility.Collapsed);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return ((value is Visibility) && (((Visibility)value) == Visibility.Visible));
        }

        public bool IsInverse { get; set; }
    }
}