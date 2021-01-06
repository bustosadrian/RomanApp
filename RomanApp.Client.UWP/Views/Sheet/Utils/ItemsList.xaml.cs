using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace RomanApp.Client.UWP.Views.Sheet.Utils
{
    public sealed partial class ItemsList : ItemsControl
    {
        public ItemsList()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            ((ICommand)ItemSelectedCommand).Execute(button.CommandParameter);
        }

        #region Commands

        public static readonly DependencyProperty ItemSelectedCommandProperty =
            DependencyProperty.Register(nameof(ItemSelectedCommand), typeof(XamlUICommand), typeof(ItemsList), null);
        public XamlUICommand ItemSelectedCommand
        {
            get { return (XamlUICommand)GetValue(ItemSelectedCommandProperty); }
            set { SetValue(ItemSelectedCommandProperty, value); }
        }

        #endregion

        #region Properties

        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(string),
        typeof(ItemsList), new PropertyMetadata(null));
        public string Icon
        {
            get { return (string)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }


        #endregion

        
    }
}
