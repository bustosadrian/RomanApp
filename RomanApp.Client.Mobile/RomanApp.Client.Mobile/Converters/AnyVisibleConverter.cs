using System;
using System.Collections;
using System.Globalization;
using Xamarin.Forms;

namespace RomanApp.Client.Mobile.Converters
{
    public class AnyVisibleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool retval = false;

            if(value is IEnumerable en)
            {
                retval = en.GetEnumerator().MoveNext();

                if (IsInverse)
                {
                    retval = !retval;
                }
            }

            return retval;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #region Properties

        public bool IsInverse
        {
            get;
            set;
        }

        #endregion
    }
}
