using Reedoo.NET.XAML;
using RomanApp.Client.XAML.ViewModels.Budget;
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

namespace RomanApp.Client.UWP.Views.Budget
{
    [ClientView(KEY, typeof(BudgetViewModel))]
    public sealed partial class BudgetView : Page
    {
        private const string KEY = "RomanApp.Offline.Budget";

        public BudgetView()
        {
            this.InitializeComponent();
        }
    }
}
