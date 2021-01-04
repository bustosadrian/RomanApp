using RomanApp.Client.Mobile.Fonts;
using RomanApp.Client.Mobile.Utils;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace RomanApp.Client.Mobile.Converters
{
    public class IconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            object retval = null;

            if(value is Icons icon)
            {
                switch (Result)
                {
                    case IconConverterResult.Font:
                        switch (icon)
                        {
                            case Icons.ChevronLeft:
                                retval = FontAwesomeIcons.ChevronLeft;
                                break;
                            case Icons.Exclamation:
                                retval = FontAwesomeIcons.Exclamation;
                                break;
                            case Icons.MoneyBillAlt:
                                retval = FontAwesomeIcons.MoneyBillAlt;
                                break;
                            case Icons.Plus:
                                retval = FontAwesomeIcons.Plus;
                                break;
                            case Icons.User:
                                retval = FontAwesomeIcons.User;
                                break;
                        }
                        break;
                    case IconConverterResult.FontFamily:
                        switch (icon)
                        {
                            case Icons.Plus:
                            case Icons.ChevronLeft:
                            case Icons.Exclamation:
                                retval = Application.Current.Resources["FontAwesomeSolid"];
                                break;
                            case Icons.MoneyBillAlt:
                            case Icons.User:
                                retval = Application.Current.Resources["FontAwesomeRegular"];
                                break;
                        }
                        break;
                }
            }

            return retval;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #region Properties

        public IconConverterResult Result
        {
            get;
            set;
        }

        #endregion
    }

    public enum IconConverterResult
    {
        Font,
        FontFamily
    }
}
