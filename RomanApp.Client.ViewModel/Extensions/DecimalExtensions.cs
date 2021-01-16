using System.Globalization;

namespace RomanApp.Client.ViewModel.Extensions
{
    public static class DecimalExtensions
    {
        public static string ToMoney(this decimal value, CultureInfo culture)
        {
            string retval = null;

            if (value % 1 == 0)
            {
                retval = value.ToString("n0", culture);
            }
            else
            {
                retval = value.ToString("n2", culture);
            }

            return retval;
        }
    }
}
