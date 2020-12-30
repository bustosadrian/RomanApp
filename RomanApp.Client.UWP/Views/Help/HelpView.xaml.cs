using Reedoo.NET.XAML;
using RomanApp.Client.UWP.ViewModels.Help;
using RomanApp.Commons;
using Windows.UI.Xaml.Controls;


namespace RomanApp.Client.UWP.Views.Help
{
    [ClientView(StatesKeys.HELP, typeof(HelpViewModel))]
    public sealed partial class HelpView : Page
    {
        public HelpView()
        {
            this.InitializeComponent();
        }
    }
}
