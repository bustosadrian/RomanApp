using System;
using System.Globalization;
using Xamarin.Forms;

namespace RomanApp.Client.Mobile.Converters
{
    public class MoneyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string retval = null;

            if (value is decimal myNumber)
            {
                if (myNumber % 1 == 0)
                {
                    retval = myNumber.ToString("n0", culture);
                }
                else
                {
                    retval = myNumber.ToString("n2", culture);
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
