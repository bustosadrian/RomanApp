using Reedoo.NET.XAML;
using RomanApp.Client.Mobile.Platform;
using RomanApp.Client.Mobile.ViewModels.About;
using RomanApp.Commons;
using Xamarin.Forms.Xaml;

namespace RomanApp.Client.Mobile.Views.About
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [ClientView(StatesKeys.ABOUT, typeof(AboutViewModel))]
    public partial class AboutView : NavigablePage
    {
        public AboutView()
        {
            InitializeComponent();
        }
    }
}