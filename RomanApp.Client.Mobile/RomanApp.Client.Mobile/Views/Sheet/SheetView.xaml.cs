
using Reedoo.NET.XAML;
using RomanApp.Client.Mobile.ViewModels.Sheet;
using RomanApp.Commons;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RomanApp.Client.Mobile.Views.Sheet
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [ClientView(StatesKeys.SHEET, typeof(SheetViewModel))]
    public partial class SheetView : TabbedPage
    {
        public SheetView()
        {
            InitializeComponent();
        }
    }
}