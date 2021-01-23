using RomanApp.Client.ViewModel.Extensions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RomanApp.Client.Mobile.Views.Sheet.Tabs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OutcomeTab : ContentPage
    {
        public OutcomeTab()
        {
            InitializeComponent();
        }
    }

    public class LeftOverConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string retval = null;

            if(value is decimal leftOver)
            {
                if(leftOver > 0)
                {
                    retval = Resx.Views.Sheet_Outcome_LeftOver_Surplus
                        .Replace("{leftOver}", Math.Abs(leftOver).ToMoney(culture));
                }
                else
                {
                    retval = Resx.Views.Sheet_Outcome_LeftOver_Shortcoming
                        .Replace("{leftOver}", Math.Abs(leftOver).ToMoney(culture));
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