using Reedoo.NET.XAML;
using RomanApp.Client.UWP.ViewModels.Event.ItemDetails;
using Windows.UI.Xaml.Controls;

namespace RomanApp.Client.UWP.Views.Event.ItemDetails
{
    [ClientView(KEY, typeof(GuestDetailsViewModel))]
    public sealed partial class GuestDetailsView : Page
    {
        private const string KEY = "RomanApp.Event.Guest.Details";

        public GuestDetailsView()
        {
            this.InitializeComponent();
        }
    }
}
