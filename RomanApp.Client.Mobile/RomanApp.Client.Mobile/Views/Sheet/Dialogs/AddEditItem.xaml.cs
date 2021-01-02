using RomanApp.Messages;
using System;
using System.Globalization;
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


    public class HeaderLabelConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string retval = null;

            if(value is ItemType type)
            {
            
                if(IsEditing)
                {
                    switch (type)
                    {
                        case ItemType.Guest:
                            retval = RomanApp.Client.Mobile.Resx.Views.Sheet_Input_Dialog_Edit_Header_Guest;
                            break;
                        case ItemType.Expense:
                            retval = RomanApp.Client.Mobile.Resx.Views.Sheet_Input_Dialog_Edit_Header_Expense;
                            break;
                    }
                }
                else
                {
                    switch (type)
                    {
                        case ItemType.Guest:
                            retval = RomanApp.Client.Mobile.Resx.Views.Sheet_Input_Dialog_Add_Header_Guest;
                            break;
                        case ItemType.Expense:
                            retval = RomanApp.Client.Mobile.Resx.Views.Sheet_Input_Dialog_Add_Header_Expense;
                            break;
                    }
                }
            }

            return retval;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #region Properties

        public bool IsEditing
        {
            get;
            set;
        }

        #endregion
    }

    public class AmountLabelConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string retval = null;

            if (value is ItemType type)
            {
                switch (type)
                {
                    case ItemType.Guest:
                        retval = RomanApp.Client.Mobile.Resx.Views.Sheet_Input_Dialog_Add_Edit_Guest_Amount;
                        break;
                    case ItemType.Expense:
                        retval = RomanApp.Client.Mobile.Resx.Views.Sheet_Input_Dialog_Add_Edit_Expense_Amount;
                        break;
                }
            }

            return retval;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}