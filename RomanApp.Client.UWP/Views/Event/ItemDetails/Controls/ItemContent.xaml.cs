using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace RomanApp.Client.UWP.Views.Event.ItemDetails.Controls
{
    public sealed partial class ItemContent : UserControl
    {
        public ItemContent()
        {
            this.InitializeComponent();
        }

        #region Properties

        public static readonly DependencyProperty SymbolProperty =
            DependencyProperty.Register("Symbol", typeof(Symbol),
                typeof(ItemContent), new PropertyMetadata(null));
        public Symbol Symbol
        {
            get { return (Symbol)GetValue(SymbolProperty); }
            set { SetValue(SymbolProperty, value); }
        }

        public static readonly DependencyProperty ShowYouProperty =
            DependencyProperty.Register("ShowYou", typeof(bool),
                typeof(ItemContent), new PropertyMetadata(null));
        public bool ShowYou
        {
            get { return (bool)GetValue(ShowYouProperty); }
            set { SetValue(ShowYouProperty, value); }
        }

        public static readonly DependencyProperty AmountLabelProperty =
            DependencyProperty.Register("AmountLabel", typeof(string),
        typeof(ItemContent), new PropertyMetadata(null));
        public string AmountLabel
        {
            get { return (string)GetValue(AmountLabelProperty); }
            set { SetValue(AmountLabelProperty, value); }
        }


        #endregion
    }
}
