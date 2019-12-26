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

namespace RomanApp.Client.UWP.Controls
{
    public sealed partial class Header : UserControl
    {
        public Header()
        {
            this.InitializeComponent();
        }

        #region Properties

        public static readonly DependencyProperty UsernameProperty =
            DependencyProperty.Register("Username", typeof(string),
                typeof(Header), new PropertyMetadata(null));
        public string Username
        {
            get { return (string)GetValue(UsernameProperty); }
            set { SetValue(UsernameProperty, value); }
        }

        #endregion
    }
}
