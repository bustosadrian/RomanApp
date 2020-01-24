using Reedoo.NET.XAML;
using RomanApp.Client.UWP.ViewModels.Home.Menu;
using Windows.UI.Xaml.Controls;

namespace RomanApp.Client.UWP.Views.Home.Menu
{
    [ClientView(KEY, typeof(MenuViewModel))]
    public sealed partial class MenuView : Page
    {
        private const string KEY = "RomanApp.Home.Menu";

        public MenuView()
        {
            this.InitializeComponent();
        }
    }
}
