using Reedoo.NET.XAML;
using RomanApp.Client.Mobile.Platform;
using RomanApp.Client.Mobile.ViewModels.Help;
using RomanApp.Client.ViewModel;
using RomanApp.Commons;
using Xamarin.Forms.Xaml;

namespace RomanApp.Client.Mobile.Views.Help
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [ClientView(StatesKeys.HELP, typeof(HelpViewModel))]
    public partial class HelpView : NavigablePage
    {
        public HelpView()
        {
            InitializeComponent();
        }

        protected override bool OnBackButtonPressed()
        {
            ((BusViewModel)BindingContext).GoBack();

            return true;
        }
    }
}