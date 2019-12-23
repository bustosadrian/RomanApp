using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace PlainUWP
{
    public sealed class NavigationService : INavigationService
    {
        public void NavigateTo(Type page, object parameter = null)
        {
            Page retval = null;

            var rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(page, parameter);
            retval = (Page)rootFrame.Content;
        }
    }
}
