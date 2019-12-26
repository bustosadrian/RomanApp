using Reedoo.NET.XAML;
using RomanApp.Client.UWP.Controls;
using RomanApp.Client.XAML.ViewModels.Budget;
using Windows.UI.Xaml.Controls;

namespace RomanApp.Client.UWP.Views.Budget
{
    [ClientView(KEY, typeof(BudgetViewModel))]
    public sealed partial class BudgetView : Page
    {
        private const string KEY = "RomanApp.Offline.Budget";

        public BudgetView()
        {
            this.InitializeComponent();
        }
    }
}
