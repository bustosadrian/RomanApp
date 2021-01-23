using RomanApp.Client.ViewModel;
using RomanApp.Client.ViewModel.Sheet.Text.Converters;
using System;
using System.Globalization;
using Windows.UI.Xaml.Data;

namespace RomanApp.Client.UWP.Views.Sheet.Dialogs.OutcomeText.Converters
{
    public class TextGroupConverter : BaseOutputTextGroupConverter, IValueConverter
    {
        public TextGroupConverter()
            : base("and")
        {
            TotalCostEvent = "The total cost of the event is <strong>{total}</strong>.";
            TotalComponsed = "This is composed by the guests' contributions (<strong>{totalGuests}</strong> in total) plus {expenses}.";
            TotalExpense = "<strong>{value}</strong> for <u>{name}</u>";

            ShareDivided = "This will be divided by the {guestsCount} guests giving us a share (what each guest is supposed to pay) of <strong>{share}</strong>.";
            ShareRealShare = "<i>This is a rounded number from <strong>{realShare}</strong>. So you might end up with a small difference at the end.</i>";
            ShareRealShareCreditorsAndPartialDebtors = "Anyway, but not all guests should pay and not all guests should pay their full share.";
            ShareRealShareNoCreditors = "Anyway, but not all guests should pay their full share.";
            ShareRealSharePartialDebtors = "Anyway, but not all guests should pay";
            ShareCreditorsAndPartialDebtors = "But not all guests should pay and not all guests should pay their full share.";
            ShareNoCreditors = "But not all guests should pay their full share.";
            SharePartialDebtors = "But not all guests should pay";

            DebtorsFullDebtorsSingular = "{fullDebtors} should put <strong>{share}</strong> (the full share) on the table.";
            DebtorsFullDebtorsPlural = DebtorsFullDebtorsSingular;
            DebtorsPartialDebtorsSingular = "<i>{name}</i> should put <strong>{debt}</strong> on the table since they already contributed for the event with <strong>{contribution}</strong>.";
            DebtorsPartialDebtorsPlural = "{partialDebtors} should pay less than their full share, since they already contributed for this event.";
            DebtorsInsteadPartialDebtorsSingular = "Instead " + DebtorsPartialDebtorsSingular;
            DebtorsInsteadPartialDebtorsPlural = "Instead "+ DebtorsPartialDebtorsPlural;
            DebtorsEachPartialDebtor = "- <i>{name}</i>'s share is <strong>{debt}</strong> since they already contributed with <strong>{contribution}</strong>.";

            CollectedSingleDebtor = "From <i>{singleDebtor}</i>'s share, {creditors}";
            CollectedCreditor = "<strong>{value}</strong> should go to <i>{name}</i>";
            CollectedTotalCollected = "After {debtors} pay their share, there should be <strong>{totalCollected}</strong> on the table.";
            CollectedManyDebtorsCreditors = "From that {creditors}.";
            CollectedOneSingleCreditor = "That money should go to <i>{singleCreditor}</i>.";

            ExpensesRemaining = "Leaving still <strong>{remaining}</strong> on the table.";
            ExpensesExpenses = "This money is to pay {expenses}.";
            ExpensesExpense = "<strong>{value}</strong> for <u>{name}</u>";

            LeftOverSurplus = "You'll notice there are <strong>{leftOver}</strong> left over. You can divide this between the guests as you see fit.";
            LeftOverShortcoming = "You'll notice there are <strong>{leftOver}</strong> missing. You'll have to decide who should cover this difference.";

            EvensSingular = "And finally {evens} should not pay anything since their contributions matches their share.";
            EvensPlural = EvensSingular;
        }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string retval = null;

            if (value is BaseViewModel viewModel)
            {
                retval = Convert(viewModel, CultureInfo.CurrentCulture);
            }
            else
            {
                retval = "Invalid value type";
            }

            return retval;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
