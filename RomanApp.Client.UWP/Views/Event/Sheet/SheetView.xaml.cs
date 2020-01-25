using Reedoo.NET.XAML;
using RomanApp.Client.UWP.ViewModels.Event.Sheet;
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

namespace RomanApp.Client.UWP.Views.Event.Sheet
{
    [ClientView(KEY, typeof(SheetViewModel))]
    public sealed partial class SheetView : Page
    {
        private const string KEY = "RomanApp.Event.Sheet";

        public SheetView()
        {
            this.InitializeComponent();
        }
    }
}
