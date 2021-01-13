
using RomanApp.Messages;
using System.Collections;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RomanApp.Client.Mobile.Controls.Help
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SeeAlso : StackLayout
    {
        public SeeAlso()
        {
            InitializeComponent();
        }

        #region Commands

        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(SeeAlso), null);
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }


        #endregion

        #region Properties

        public static readonly BindableProperty RelatedTopicsProperty = BindableProperty.Create(nameof(RelatedTopics),
                typeof(IEnumerable), typeof(SeeAlso));

        public IEnumerable RelatedTopics
        {
            get { return (IEnumerable)GetValue(RelatedTopicsProperty); }
            set { SetValue(RelatedTopicsProperty, value); }
        }

        #endregion
    }
}