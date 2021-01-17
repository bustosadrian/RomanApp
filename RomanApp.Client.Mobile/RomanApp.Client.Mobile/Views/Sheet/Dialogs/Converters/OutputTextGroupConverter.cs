using RomanApp.Client.ViewModel;
using RomanApp.Client.ViewModel.Sheet.Text.Converters;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace RomanApp.Client.Mobile.Views.Sheet.Dialogs.Converters
{
    public class OutputTextGroupConverter : BaseOutputTextGroupConverter, IValueConverter
    {
        public OutputTextGroupConverter()
            : base(Resx.Native.And)
        {
            TotalCostEvent = Resx.Views.Sheet_Outcome_Text_TotalCostEvent;
            TotalComponsed = Resx.Views.Sheet_Outcome_Text_TotalComponsed;
            TotalExpense = Resx.Views.Sheet_Outcome_Text_TotalExpense;

            ShareDivided = Resx.Views.Sheet_Outcome_Text_ShareDivided;
            ShareCreditorsAndPartialDebtors = Resx.Views.Sheet_Outcome_Text_ShareCreditorsAndPartialDebtors;
            ShareNoCreditors = Resx.Views.Sheet_Outcome_Text_ShareNoCreditors;
            SharePartialDebtors = Resx.Views.Sheet_Outcome_Text_SharePartialDebtors;

            DebtorsFullDebtorsSingular = Resx.Views.Sheet_Outcome_Text_DebtorsFullDebtorsSingular;
            DebtorsFullDebtorsPlural = Resx.Views.Sheet_Outcome_Text_DebtorsFullDebtorsPlural;
            DebtorsPartialDebtorsSingular = Resx.Views.Sheet_Outcome_Text_DebtorsPartialDebtorsSingular;
            DebtorsPartialDebtorsPlural = Resx.Views.Sheet_Outcome_Text_DebtorsPartialDebtorsPlural;
            DebtorsInsteadPartialDebtorsSingular = Resx.Views.Sheet_Outcome_Text_DebtorsInsteadPartialDebtorsSingular;
            DebtorsInsteadPartialDebtorsPlural = Resx.Views.Sheet_Outcome_Text_DebtorsInsteadPartialDebtorsPlural;
            DebtorsEachPartialDebtor = Resx.Views.Sheet_Outcome_Text_DebtorsEachPartialDebtor;

            CollectedSingleDebtor = Resx.Views.Sheet_Outcome_Text_CollectedSingleDebtor;
            CollectedCreditor = Resx.Views.Sheet_Outcome_Text_CollectedCreditor;
            CollectedTotalCollected = Resx.Views.Sheet_Outcome_Text_CollectedTotalCollected;
            CollectedManyDebtorsCreditors = Resx.Views.Sheet_Outcome_Text_CollectedManyDebtorsCreditors;
            CollectedOneSingleCreditor = Resx.Views.Sheet_Outcome_Text_CollectedOneSingleCreditor;

            ExpensesRemaining = Resx.Views.Sheet_Outcome_Text_ExpensesRemaining;
            ExpensesExpenses = Resx.Views.Sheet_Outcome_Text_ExpensesExpenses;
            ExpensesExpense = Resx.Views.Sheet_Outcome_Text_ExpensesExpense;

            EvensSingular = Resx.Views.Sheet_Outcome_Text_EvensSingular;
            EvensPlural = Resx.Views.Sheet_Outcome_Text_EvensPlural;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string retval = null;

            if (value is BaseViewModel viewModel)
            {
                retval = Convert(viewModel, culture);
            }
            else
            {
                retval = "Invalid value type";
            }

            return retval;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
