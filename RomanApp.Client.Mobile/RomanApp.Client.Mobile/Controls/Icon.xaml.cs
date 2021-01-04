
using RomanApp.Client.Mobile.Utils;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RomanApp.Client.Mobile.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Icon : Label
    {
        public Icon()
        {
            InitializeComponent();
        }

        #region Properties

        public static readonly BindableProperty ValueProperty = BindableProperty.Create(nameof(Value),
                typeof(Icons), typeof(Icon), null);

        public Icons Value
        {
            get { return (Icons)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        #endregion
    }
}