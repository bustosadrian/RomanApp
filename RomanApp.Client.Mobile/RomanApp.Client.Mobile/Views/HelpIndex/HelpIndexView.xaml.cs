using Reedoo.NET.XAML;
using RomanApp.Client.Mobile.Platform;
using RomanApp.Client.Mobile.ViewModels.HelpIndex;
using RomanApp.Commons;
using Xamarin.Forms.Xaml;

namespace RomanApp.Client.Mobile.Views.HelpIndex
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [ClientView(StatesKeys.HELP_INDEX, typeof(HelpIndexViewModel))]
    public partial class HelpIndexView : NavigablePage
    {
        public HelpIndexView()
        {
            InitializeComponent();
        }
    }
}