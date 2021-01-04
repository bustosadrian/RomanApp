using System;
using System.Globalization;
using Xamarin.Forms;

namespace RomanApp.Client.Mobile.Converters
{
    public class AddConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            object retval = null;

            retval = value;

            parameter = parameter ?? 0;

            if (value != null)
            {
                if (value is int)
                {
                    retval = (int)value + int.Parse(parameter.ToString());
                }
                else if (value is double)
                {
                    retval = (double)value + double.Parse(parameter.ToString());
                }
            }

            return retval;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
