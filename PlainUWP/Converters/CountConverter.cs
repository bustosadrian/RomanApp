using System;
using Windows.UI.Xaml.Data;

namespace PlainUWP.Converters
{
    public class CountConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            int retval = 0;

            if(value is System.Collections.ICollection collection)
            {
                retval = collection.Count;
            }

            return retval;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
