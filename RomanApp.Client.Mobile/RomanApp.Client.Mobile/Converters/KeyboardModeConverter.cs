using RomanApp.Client.ViewModel.Sheet;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace RomanApp.Client.Mobile.Converters
{
    public class KeyboardModeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Keyboard retval = null;

            retval = Keyboard.Default;
            if(value is KeyboardMode mode)
            {
                if(mode == KeyboardMode.Numeric)
                {
                    retval = Keyboard.Numeric;
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
