using System;
using System.Globalization;
using Xamarin.Forms;

namespace RomanApp.Client.Mobile.Converters
{
    public class NullBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool retval = false;

            retval = value != null;

            if (IsInverse)
            {
                retval = !retval;
            }

            return retval;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public bool IsInverse { get; set; }
    }
}
