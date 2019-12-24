using Reedoo.NET.XAML;
using RomanApp.Client.XAML.ViewModels.CreateItem;
using Windows.UI.Xaml.Controls;

namespace RomanApp.Client.UWP.Views.CreateItem
{
    [ClientView(KEY, typeof(CreateItemViewModel))]
    public sealed partial class CreateItemView : Page
    {
        private const string KEY = "RomanApp.Offline.Create.Item";

        public CreateItemView()
        {
            this.InitializeComponent();
        }


    }
}
