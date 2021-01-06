using RomanApp.Client.Mobile.Utils;
using RomanApp.Messages;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace RomanApp.Client.Mobile.Converters
{
    public class ItemTypeToIconsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Icons? retval = null;

            if(value is ItemType type)
            {
                switch (type)
                {
                    case ItemType.Guest:
                        retval = Icons.User;
                        break;
                    case ItemType.Expense:
                        retval = Icons.MoneyBillAlt;
                        break;
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
