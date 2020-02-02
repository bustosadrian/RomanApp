using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace RomanApp.Client.UWP.Converters
{
    public class MoneyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string retval = null;
            if (value == null)
                return null;

            if (value is decimal myNumber)
            {
                retval = string.Format("{0:0.00}", myNumber);

                if (retval.EndsWith("00"))
                {
                    retval = ((int)myNumber).ToString();
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