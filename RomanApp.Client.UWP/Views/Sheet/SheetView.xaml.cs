using Reedoo.NET.XAML;
using RomanApp.Client.UWP.ViewModels.Sheet;
using Windows.UI.Xaml.Controls;

namespace RomanApp.Client.UWP.Views.Sheet
{
    [ClientView(KEY, typeof(SheetViewModel))]
    public sealed partial class SheetView : Page
    {
        private const string KEY = "RomanApp.Sheet";

        public SheetView()
        {
            this.InitializeComponent();
        }
    }
}
