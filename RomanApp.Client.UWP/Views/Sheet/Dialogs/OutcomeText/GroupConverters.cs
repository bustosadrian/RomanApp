using RomanApp.Client.UWP.Utils;
using RomanApp.Client.ViewModel.Sheet.Text;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Windows.UI.Xaml.Data;

namespace RomanApp.Client.UWP.Views.Sheet.Dialogs.OutcomeText
{
    public class TotalExpensesConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string retval = null;

            if(value is ObservableCollection<NameAmountViewModel> vm)
            {
                retval = StringUtils.Enumerate(vm.Select(x => string.Format("{0} ({1})", x.Name, x.Value1)));
            }

            return retval;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

    public class ShareGuestSituationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string retval = null;

            if(value is GuestsSituation situation)
            {
                switch (situation) 
                {
                    case GuestsSituation.CreditorsAndPartialDebtors:
                        retval = "But not all guests should pay and not all guests should pay their full share";
                        break;
                    case GuestsSituation.PartialDebtors:
                        retval = "But not all guests should pay their full share";
                        break;
                    case GuestsSituation.NoCreditors:
                        retval = "But not all guests should pay";
                        break;
                }
            }

            return retval;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }



    public class DebtorsFullConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string retval = null;

            if (value is DebtorsGroupViewModel viewModel)
            {
                if (viewModel.IsSingleFullDebtor)
                {
                    retval = $"{viewModel.SingleFullDebtor} should put {viewModel.Share}  (the full share) on the table.";
                }
                else
                {
                    string fullDebtors = StringUtils.Enumerate(viewModel.FullDebtors);
                    retval = $"{fullDebtors} should each put {viewModel.Share} (the full share) on the table.";
                }
            }

            return retval;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

    public class DebtorsPartialConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string retval = null;

            if (value is DebtorsGroupViewModel viewModel)
            {
                StringBuilder sb = new StringBuilder();
                if (viewModel.HasFullDebtors)
                {
                    sb.Append("Instead ");
                    if (viewModel.IsSinglePartialDebtor)
                    {
                        sb.Append($"{viewModel.SinglePartialDebtor.Name} should pay {viewModel.SinglePartialDebtor.Value1} since they already contributed for the event with {viewModel.SinglePartialDebtor.Value2}.");
                    }
                    else
                    {
                        string partialDebtors = StringUtils.Enumerate(viewModel.PartialDebtors.Select(x => x.Name));
                        sb.Append($"{partialDebtors} should pay less than their full share, since they already contributed for the event.");
                    }
                }
                
                retval = sb.ToString();
            }

            return retval;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
