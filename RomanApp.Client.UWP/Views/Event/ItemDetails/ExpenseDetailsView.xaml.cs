using Reedoo.NET.XAML;
using RomanApp.Client.UWP.ViewModels.Event.ItemDetails;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace RomanApp.Client.UWP.Views.Event.ItemDetails
{
    [ClientView(KEY, typeof(ExpenseDetailsViewModel))]
    public sealed partial class ExpenseDetailsView : Page
    {
        private const string KEY = "RomanApp.Event.Expense.Details";

        public ExpenseDetailsView()
        {
            this.InitializeComponent();
        }
    }
}
