using System.Collections;
using System.Collections.Specialized;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RomanApp.Client.Mobile.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Repeat : StackLayout
    {
        public Repeat()
        {
            InitializeComponent();
        }

        private void CreateRows(IEnumerable items)
        {
            Children.Clear();
            if(items != null)
            {
                foreach (var o in items)
                {
                    var tapped = new TapGestureRecognizer();
                    tapped.Tapped += Tgr_Tapped;

                    var itemContent = (View)ItemTemplate.CreateContent();
                    itemContent.GestureRecognizers.Add(tapped);
                    itemContent.BindingContext = o;
                    Children.Add(itemContent);
                }
            }
        }

        private void Tgr_Tapped(object sender, System.EventArgs e)
        {
            Execute(SelectedCommand, ((BindableObject)sender).BindingContext);
        }

        #region Commands

        public void Execute(ICommand command, object parameter)
        {
            if (command == null) return;
            if (command.CanExecute(null))
            {
                command.Execute(parameter);
            }
        }

        public static readonly BindableProperty SelectedCommandProperty =
            BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(Repeat), null);
        public ICommand SelectedCommand
        {
            get { return (ICommand)GetValue(SelectedCommandProperty); }
            set { SetValue(SelectedCommandProperty, value); }
        }

        #endregion

        #region Properties

        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(nameof(ItemsSource),
                typeof(IEnumerable),typeof(Repeat),
                propertyChanged: OnItemsSourceChanged);

        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        private static void OnItemsSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            Repeat me = (Repeat)bindable;

            if (oldValue is INotifyCollectionChanged oldNotifyCollection)
            {
                oldNotifyCollection.CollectionChanged -= me.ItemsSource_CollectionChanged;
            }

            if (newValue is INotifyCollectionChanged newNotifyCollection)
            {
                newNotifyCollection.CollectionChanged += me.ItemsSource_CollectionChanged;
            }
            me.CreateRows((IEnumerable)newValue);
        }

        private void ItemsSource_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            CreateRows(ItemsSource);
        }

        public static readonly BindableProperty ItemTemplateProperty = BindableProperty.Create(nameof(ItemTemplate),
                typeof(DataTemplate), typeof(Repeat), null);

        public DataTemplate ItemTemplate
        {
            get { return (DataTemplate)GetValue(ItemTemplateProperty); }
            set { SetValue(ItemTemplateProperty, value); }
        }

        #endregion
    }
}