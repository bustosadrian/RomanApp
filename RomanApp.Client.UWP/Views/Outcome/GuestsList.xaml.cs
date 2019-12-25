using RomanApp.Client.XAML.ViewModels.Outcome;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace RomanApp.Client.UWP.Views.Outcome
{
    public sealed partial class GuestsList : UserControl
    {
        public GuestsList()
        {
            this.InitializeComponent();
        }

        #region Properties

        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", typeof(ObservableCollection<GuestOutcomeViewModel>),
                typeof(GuestsList), new PropertyMetadata(null));
        public ObservableCollection<GuestOutcomeViewModel> ItemsSource
        {
            get { return (ObservableCollection<GuestOutcomeViewModel>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        #endregion
    }
}
