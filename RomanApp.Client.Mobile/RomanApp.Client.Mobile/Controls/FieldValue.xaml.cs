
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RomanApp.Client.Mobile.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FieldValue : Grid
    {
        public FieldValue()
        {
            InitializeComponent();
        }


        #region Properties

        public static readonly BindableProperty ConceptProperty = BindableProperty.Create(nameof(Concept),
                typeof(string), typeof(FieldValue), null);
        public string Concept
        {
            get { return (string)GetValue(ConceptProperty); }
            set { SetValue(ConceptProperty, value); }
        }

        public static readonly BindableProperty ValueProperty = BindableProperty.Create(nameof(Value),
                typeof(string), typeof(FieldValue), null);
        public string Value
        {
            get { return (string)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public static readonly BindableProperty ConceptStyleProperty = BindableProperty.Create(nameof(ConceptStyle),
                typeof(Style), typeof(FieldValue), null);
        public Style ConceptStyle
        {
            get { return (Style)GetValue(ConceptStyleProperty); }
            set { SetValue(ConceptStyleProperty, value); }
        }

        public static readonly BindableProperty ValueStyleProperty = BindableProperty.Create(nameof(ValueStyle),
                typeof(Style), typeof(FieldValue), null);
        public Style ValueStyle
        {
            get { return (Style)GetValue(ValueStyleProperty); }
            set { SetValue(ValueStyleProperty, value); }
        }

        #endregion
    }
}