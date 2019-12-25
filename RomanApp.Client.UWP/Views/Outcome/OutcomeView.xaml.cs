using Reedoo.NET.XAML;
using RomanApp.Client.XAML.ViewModels.Outcome;
using Windows.UI.Xaml.Controls;

namespace RomanApp.Client.UWP.Views.Outcome
{
    [ClientView(KEY, typeof(OutcomeViewModel))]
    public sealed partial class OutcomeView : Page
    {
        private const string KEY = "RomanApp.Offline.Outcome";

        public OutcomeView()
        {
            this.InitializeComponent();
        }
    }
}
