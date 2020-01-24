using Reedoo.NET.XAML;
using RomanApp.Client.UWP.ViewModels.Home.Create;
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


namespace RomanApp.Client.UWP.Views.Home.Create
{
    [ClientView(KEY, typeof(CreateViewModel))]
    public sealed partial class CreateView : Page
    {
        private const string KEY = "RomanApp.Home.Create";

        public CreateView()
        {
            this.InitializeComponent();
        }
    }
}
