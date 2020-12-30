using Reedoo.NET.XAML;
using RomanApp.Client.Mobile.ViewModels.Help;
using RomanApp.Commons;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RomanApp.Client.Mobile.Views.Help
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [ClientView(StatesKeys.HELP, typeof(HelpViewModel))]
    public partial class HelpView : ContentPage
    {
        public HelpView()
        {
            InitializeComponent();
        }
    }
}