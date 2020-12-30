using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RomanApp.Client.Mobile.Views.Sheet.Dialogs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddEditItem : ContentView
    {
        public AddEditItem()
        {
            InitializeComponent();
        }
    }

    public enum AddEditItemResult 
    { 
        Delete = 0,
        Cancel = 1,
        Ok = 2,
    }

}