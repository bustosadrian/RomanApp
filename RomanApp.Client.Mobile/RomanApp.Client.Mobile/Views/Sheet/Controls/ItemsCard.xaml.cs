using RomanApp.Client.ViewModel.Sheet.Embeddeds;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RomanApp.Client.Mobile.Views.Sheet.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemsCard : Frame
    {
        public ItemsCard()
        {
            InitializeComponent();
        }

        #region Commands

        public static readonly BindableProperty ItemSelectedCommandProperty =
            BindableProperty.Create(
                propertyName: nameof(ItemSelectedCommand),
                returnType: typeof(ICommand),
                declaringType: typeof(ItemsCard),
                defaultValue: null);
        public ICommand ItemSelectedCommand
        {
            get { return (ICommand)GetValue(ItemSelectedCommandProperty); }
            set { SetValue(ItemSelectedCommandProperty, value); }
        }

        public static readonly BindableProperty AddItemCommandProperty =
            BindableProperty.Create(
                propertyName: nameof(AddItemCommand),
                returnType: typeof(ICommand),
                declaringType: typeof(ItemsCard),
                defaultValue: null);
        public ICommand AddItemCommand
        {
            get { return (ICommand)GetValue(AddItemCommandProperty); }
            set { SetValue(AddItemCommandProperty, value); }
        }

        #endregion

        #region Properties

        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(nameof(ItemsSource),
                typeof(ObservableCollection<BaseItemRowViewModel>), typeof(ItemsCard), null);

        public ObservableCollection<BaseItemRowViewModel> ItemsSource
        {
            get { return (ObservableCollection<BaseItemRowViewModel>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }


        public static readonly BindableProperty TypeNameProperty = BindableProperty.Create(nameof(TypeName),
                typeof(string), typeof(ItemsCard), null);

        public string TypeName
        {
            get { return (string)GetValue(TypeNameProperty); }
            set { SetValue(TypeNameProperty, value); }
        }

        public static readonly BindableProperty TotalCountProperty = BindableProperty.Create(nameof(TotalCount),
                typeof(string), typeof(ItemsCard), null);

        public string TotalCount
        {
            get { return (string)GetValue(TotalCountProperty); }
            set { SetValue(TotalCountProperty, value); }
        }

        public static readonly BindableProperty TotalAmountProperty = BindableProperty.Create(nameof(TotalAmount),
               typeof(decimal), typeof(ItemsCard), (decimal)0);

        public decimal TotalAmount
        {
            get { return (decimal)GetValue(TotalAmountProperty); }
            set { SetValue(TotalAmountProperty, value); }
        }

        #endregion
    }
}