using System;
using System.Globalization;
using Xamarin.Forms;

namespace RomanApp.Client.Mobile.Converters
{
    public class MaxLengthConverter : IValueConverter
    {

        public MaxLengthConverter()
        {
            MaxLength = 20;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string retval = null;

            if(value is string)
            {
                retval = value.ToString();

                if(retval.Length > MaxLength)
                {
                    retval = retval.Substring(0, MaxLength);
                    retval += "...";
                }
            }

            return retval;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #region Properties

        public int MaxLength
        {
            get;
            set;
        }

        #endregion
    }
}
