using PlainUWP.ViewModels.Outcome;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace PlainUWP.Pages.Outcome
{
    public sealed partial class OutcomePage : Page
    {
        public OutcomePage()
        {
            this.InitializeComponent();
            DataContext = new OutcomeViewModel(new NavigationService());
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ViewModel.Load((Entities.Budget)e.Parameter);
        }

        #region Properties

        private OutcomeViewModel ViewModel
        {
            get
            {
                return (OutcomeViewModel)DataContext;
            }
        }

        #endregion
    }
}
