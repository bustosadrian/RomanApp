using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace RomanApp.Client.Mobile.Converters
{
    public class ValidationMessageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string retval = null;

            if(value is string key)
            {
                retval = RomanApp.Client.Mobile.Resx.ValidationMessages.ResourceManager.GetString(key);
            }

            return retval;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
