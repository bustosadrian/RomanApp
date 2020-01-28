using System;
using Windows.UI.Xaml.Data;

namespace RomanApp.Client.UWP.Converters
{
    public class AbsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            object retval = null;

            if(value is decimal _value)
            {
                retval = Math.Abs(_value);
            }

            return retval;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
