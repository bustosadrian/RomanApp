using RomanApp.Client.Mobile.Services;
using RomanApp.Client.Mobile.Styles;
using System.Collections;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RomanApp.Client.Mobile.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Repeat : StackLayout
    {

        //private ISoundService _soundService;

        public Repeat()
        {
            InitializeComponent();
            
            Resources.Add(new Pallete());
        }

        private void PlayTapSound()
        {
            try
            {
                DependencyService.Get<ISoundService>()?.Tap();
            }
            catch
            {

            }
        }

        private void ResetRows()
        {
            ResetRows(ItemsSource);
        }
        
        private void ResetRows(IEnumerable rows)
        {
            if(rows != null)
            {
                Children.Clear();
                AddRows(rows);
            }
        }

        private void AddRows(IEnumerable rows)
        {
            if (ItemTemplate != null)
            {
                foreach (var o in rows)
                {
                    AddRow(o);
                }
            }
        }

        private void AddRow(object row)
        {
            

            var itemContent = (View)ItemTemplate.CreateContent();
            if (itemContent != null)
            {
                Children.Add(WrapContent(itemContent, row));
            }
        }

        private Grid WrapContent(View content, object row)
        {
            Grid retval = null;

            retval = new Grid();
            retval.BindingContext = row;
            BoxView selectionBox = new BoxView();
            selectionBox.BackgroundColor = (Color)Resources["main-color-bright"];
            selectionBox.Opacity = 0;

            retval.Children.Add(selectionBox, 0, 0);
            retval.Children.Add(content, 0, 0);

            var tapped = new TapGestureRecognizer();
            tapped.Tapped += Tgr_Tapped;
            retval.GestureRecognizers.Add(tapped);


            return retval;
        }

        private void RemoveRows(IEnumerable rows)
        {
            foreach(var o in rows)
            {
                RemoveRow(o);
            }
        }

        private void RemoveRow(object row)
        {
            var toRemove = Children.SingleOrDefault(x => x.BindingContext == row);
            if(toRemove != null)
            {
                Children.Remove(toRemove);
            }
        }

        private async void Tgr_Tapped(object sender, System.EventArgs e)
        {
            if(SelectedCommand != null)
            {
                Grid contentWrapper = (Grid)sender;
                var selectionBox = contentWrapper.Children.First();
                selectionBox.Opacity = 1;
                await selectionBox.FadeTo(0, 250);

                PlayTapSound();

                Execute(SelectedCommand, contentWrapper.BindingContext);
            }
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
            me.ResetRows((IEnumerable)newValue);
        }

        private void ItemsSource_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Reset:
                    ResetRows();
                    break;
                case NotifyCollectionChangedAction.Add:
                    AddRows(e.NewItems);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    RemoveRows(e.OldItems);
                    break;
                default:
                    break;
            }
        }

        public static readonly BindableProperty ItemTemplateProperty = BindableProperty.Create(nameof(ItemTemplate),
                typeof(DataTemplate), typeof(Repeat), 
                propertyChanged: ItemTemplate_OnChanged);

        public DataTemplate ItemTemplate
        {
            get { return (DataTemplate)GetValue(ItemTemplateProperty); }
            set { SetValue(ItemTemplateProperty, value); }
        }

        private static void ItemTemplate_OnChanged(BindableObject bindable, object oldValue, object newValue)
        {
            Repeat me = (Repeat)bindable;
            me.ResetRows();
        }

        #endregion
    }
}