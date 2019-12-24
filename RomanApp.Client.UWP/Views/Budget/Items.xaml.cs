using RomanApp.Client.XAML.ViewModels.Budget;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace RomanApp.Client.UWP.Views.Budget
{
    public sealed partial class Items : UserControl
    {
        public Items()
        {
            this.InitializeComponent();
        }

        #region Properties

        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", typeof(ObservableCollection<GuestViewModel>),
                typeof(Items), new PropertyMetadata(null));
        public ObservableCollection<ItemViewModel> ItemsSource
        {
            get { return (ObservableCollection<ItemViewModel>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        #endregion
    }
}
