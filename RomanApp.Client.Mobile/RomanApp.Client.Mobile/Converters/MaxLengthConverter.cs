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
                int maxLength = MaxLength;
                if(parameter != null)
                {
                    int.TryParse(parameter.ToString(), out maxLength);
                }

                retval = value.ToString();

                if(retval.Length > maxLength)
                {
                    retval = retval.Substring(0, maxLength);
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
