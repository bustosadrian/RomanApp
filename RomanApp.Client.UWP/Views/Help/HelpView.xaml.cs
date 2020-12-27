using Reedoo.NET.XAML;
using RomanApp.Client.UWP.ViewModels.Help;
using Windows.UI.Xaml.Controls;


namespace RomanApp.Client.UWP.Views.Help
{
    [ClientView(KEY, typeof(HelpViewModel))]
    public sealed partial class HelpView : Page
    {
        private const string KEY = "RomanApp.Help";

        public HelpView()
        {
            this.InitializeComponent();
        }
    }
}
