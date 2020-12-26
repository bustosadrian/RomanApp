using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


namespace RomanApp.Client.UWP.Views.Sheet.Utils
{
    public sealed partial class ItemsList : ItemsControl
    {
        public ItemsList()
        {
            this.InitializeComponent();
        }

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
