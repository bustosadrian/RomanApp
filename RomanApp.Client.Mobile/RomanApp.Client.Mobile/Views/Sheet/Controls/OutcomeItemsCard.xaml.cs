
using RomanApp.Client.ViewModel.Sheet.Embeddeds;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RomanApp.Client.Mobile.Views.Sheet.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OutcomeItemsCard : Frame
    {
        public OutcomeItemsCard()
        {
            InitializeComponent();
        }

        #region Properties

        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(nameof(ItemsSource),
                typeof(ObservableCollection<OutcomeGuestViewModel>), typeof(OutcomeItemsCard), null);

        public ObservableCollection<OutcomeGuestViewModel> ItemsSource
        {
            get { return (ObservableCollection<OutcomeGuestViewModel>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public static readonly BindableProperty GroupNameProperty = BindableProperty.Create(nameof(GroupName),
                typeof(string), typeof(ItemsCard), null);

        public string GroupName
        {
            get { return (string)GetValue(GroupNameProperty); }
            set { SetValue(GroupNameProperty, value); }
        }

        public static readonly BindableProperty CountProperty = BindableProperty.Create(nameof(Count),
                typeof(int), typeof(OutcomeItemsCard), 0);

        public int Count
        {
            get { return (int)GetValue(CountProperty); }
            set { SetValue(CountProperty, value); }
        }

        #endregion
    }
}