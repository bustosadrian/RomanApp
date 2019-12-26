using Reedoo.NET.Messages.Output;
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

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace RomanApp.Client.UWP.Controls
{
    public sealed partial class ValidationMessages : ContentDialog
    {
        public ValidationMessages()
        {
            this.InitializeComponent();
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {

        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {

        }

        #region Properties

        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register("Message", typeof(ValidationErrors),
                typeof(ValidationMessages), new PropertyMetadata(null, OnMessageChanged));
        public ValidationErrors Message
        {
            get { return (ValidationErrors)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        private async static void OnMessageChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if(e.NewValue is ValidationErrors validationErrors)
            {
                ValidationMessages c = (ValidationMessages)d;
                await c.ShowAsync();
            }
        }

        #endregion
    }
}
