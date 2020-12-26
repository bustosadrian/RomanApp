using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace RomanApp.Client.UWP.Views.Sheet.Utils
{
    public sealed partial class OutcomeGuestsList : ItemsControl
    {
        public OutcomeGuestsList()
        {
            this.InitializeComponent();
        }

        #region Properties

        //public static readonly DependencyProperty ForegroundProperty =
        //    DependencyProperty.Register("Foreground", typeof(Brush),
        //typeof(OutcomeGuestsList), new PropertyMetadata(new SolidColorBrush(Colors.Black)));
        //public Brush Foreground
        //{
        //    get { return (Brush)GetValue(ForegroundProperty); }
        //    set { SetValue(ForegroundProperty, value); }
        //}


        #endregion
    }
}
