
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RomanApp.Client.Mobile.Views.Help.Topics.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Note : Grid
    {
        public Note()
        {
            InitializeComponent();
        }

        #region Properties

        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text),
            typeof(string), typeof(Note), null);
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        #endregion
    }
}