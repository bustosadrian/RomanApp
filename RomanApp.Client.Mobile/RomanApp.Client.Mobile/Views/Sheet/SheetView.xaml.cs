
using Reedoo.NET.XAML;
using RomanApp.Client.Mobile.Services;
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
        private IAppService _appService;

        public SheetView()
        {
            InitializeComponent();
            
            NavigationPage.SetBackButtonTitle(this, "");
            NavigationPage.SetHasBackButton(this, false);

            _appService = DependencyService.Get<IAppService>();
        }

        protected override bool OnBackButtonPressed()
        {
            _appService?.Quit();

            return true;
        }
    }
}