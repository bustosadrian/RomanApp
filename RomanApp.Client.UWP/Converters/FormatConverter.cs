using System;
using System.Collections;
using Windows.UI.Xaml.Data;

namespace RomanApp.Client.UWP.Converters
{
    public class FormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string retval = null;

            if(value is string text)
            {
                retval = text;

                if(parameter is ICollection values)
                {
                    object[] ar = new object[values.Count];
                    values.CopyTo(ar, 0);
                    retval = string.Format(text, ar);
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
