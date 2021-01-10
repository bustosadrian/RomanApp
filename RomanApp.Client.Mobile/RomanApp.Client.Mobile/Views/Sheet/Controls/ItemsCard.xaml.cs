using RomanApp.Client.Mobile.Utils;
using RomanApp.Client.ViewModel.Sheet.Embeddeds;
using RomanApp.Messages;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RomanApp.Client.Mobile.Views.Sheet.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemsCard : Grid
    {
        public ItemsCard()
        {
            InitializeComponent();
        }

        private void EvaluateIsEmpty()
        {
            IsEmpty = !ItemsSource?.Any() ?? true;
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
                typeof(ObservableCollection<ItemRowViewModel>), typeof(ItemsCard),
                propertyChanged: OnItemsSourceChanged);

        public ObservableCollection<ItemRowViewModel> ItemsSource
        {
            get { return (ObservableCollection<ItemRowViewModel>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        private static void OnItemsSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ItemsCard me = (ItemsCard)bindable;

            if (oldValue is INotifyCollectionChanged oldNotifyCollection)
            {
                oldNotifyCollection.CollectionChanged -= me.ItemsSource_CollectionChanged;
            }

            if (newValue is INotifyCollectionChanged newNotifyCollection)
            {
                newNotifyCollection.CollectionChanged += me.ItemsSource_CollectionChanged;
            }
            me.EvaluateIsEmpty();
        }

        private void ItemsSource_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            EvaluateIsEmpty();
        }


        public static readonly BindableProperty IconProperty = BindableProperty.Create(nameof(Icon),
               typeof(Icons), typeof(ItemsCard), null);

        public Icons Icon
        {
            get { return (Icons)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        public static readonly BindableProperty ItemTypeProperty = BindableProperty.Create(nameof(ItemType),
                typeof(ItemType), typeof(ItemsCard), null);

        public ItemType ItemType
        {
            get { return (ItemType)GetValue(ItemTypeProperty); }
            set { SetValue(ItemTypeProperty, value); }
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


        public static readonly BindableProperty IsEmptyProperty = BindableProperty.Create(nameof(IsEmpty),
               typeof(bool), typeof(ItemsCard), true);

        public bool IsEmpty
        {
            get { return (bool)GetValue(IsEmptyProperty); }
            set { SetValue(IsEmptyProperty, value); }
        }

        #endregion
    }

    public class TypeNameToEmptyMessageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string retval = null;

            if (value is ItemType type)
            {
                switch (type)
                {
                    case ItemType.Guest:
                        retval = RomanApp.Client.Mobile.Resx.Views.Sheet_Card_Empty_Guests;
                        break;
                    case ItemType.Expense:
                        retval = RomanApp.Client.Mobile.Resx.Views.Sheet_Card_Empty_Expenses;
                        break;
                }
            }

            return retval;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class TypeNameToItemNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string retval = null;

            if (value is ItemType type)
            {
                switch (type)
                {
                    case ItemType.Guest:
                        retval = RomanApp.Client.Mobile.Resx.Views.Sheet_Card_Header_Guests;
                        break;
                    case ItemType.Expense:
                        retval = RomanApp.Client.Mobile.Resx.Views.Sheet_Card_Header_Expenses;
                        break;
                }
            }

            return retval;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}