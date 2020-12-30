using Reedoo.NET.XAML;
using RomanApp.Client.UWP.ViewModels.Sheet;
using RomanApp.Commons;
using Windows.UI.Xaml.Controls;

namespace RomanApp.Client.UWP.Views.Sheet
{
    [ClientView(StatesKeys.SHEET, typeof(SheetViewModel))]
    public sealed partial class SheetView : Page
    {
        public SheetView()
        {
            this.InitializeComponent();
        }
    }
}
