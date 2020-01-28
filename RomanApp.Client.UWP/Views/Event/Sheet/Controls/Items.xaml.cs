using RomanApp.Client.UWP.ViewModels.Event.Sheet;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace RomanApp.Client.UWP.Views.Event.Sheet.Controls
{
    public sealed partial class Items : UserControl
    {
        public Items()
        {
            this.InitializeComponent();
        }

        #region Properties

        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", typeof(ObservableCollection<ItemViewModel>),
                typeof(Items), new PropertyMetadata(null));
        public ObservableCollection<ItemViewModel> ItemsSource
        {
            get { return (ObservableCollection<ItemViewModel>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        #endregion  
    }
}
