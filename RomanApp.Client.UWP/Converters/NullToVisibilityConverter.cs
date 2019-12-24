using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace RomanApp.Client.UWP.Converters
{
    public class NullToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var flag = false;

            flag = value != null;

            if (IsInverse)
            {
                flag = !flag;
            }

            return (flag ? Visibility.Visible : Visibility.Collapsed);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }

        public bool IsInverse { get; set; }
    }
}
