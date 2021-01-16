
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
                typeof(ObservableCollection<OutcomeItemViewModel>), typeof(OutcomeItemsCard), null);

        public ObservableCollection<OutcomeItemViewModel> ItemsSource
        {
            get { return (ObservableCollection<OutcomeItemViewModel>)GetValue(ItemsSourceProperty); }
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

        public static readonly BindableProperty ShowAmountProperty = BindableProperty.Create(nameof(ShowAmount),
        typeof(bool), typeof(OutcomeItemsCard), true);

        public bool ShowAmount
        {
            get { return (bool)GetValue(ShowAmountProperty); }
            set { SetValue(ShowAmountProperty, value); }
        }

        public static readonly BindableProperty TotalProperty = BindableProperty.Create(nameof(Total),
                typeof(decimal), typeof(OutcomeItemsCard), (decimal)0);

        public decimal Total
        {
            get { return (decimal)GetValue(TotalProperty); }
            set { SetValue(TotalProperty, value); }
        }

        public static readonly BindableProperty ShowTotalProperty = BindableProperty.Create(nameof(ShowTotal),
                typeof(bool), typeof(OutcomeItemsCard), false);

        public bool ShowTotal
        {
            get { return (bool)GetValue(ShowTotalProperty); }
            set { SetValue(ShowTotalProperty, value); }
        }

        #endregion
    }
}