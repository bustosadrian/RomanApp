using RomanApp.Client.ViewModel.Extensions;
using System.Globalization;
using System.Linq;
using System.Text;

namespace RomanApp.Client.ViewModel.Sheet.Text.Converters
{
    public abstract class BaseOutputTextGroupConverter
    {
        public BaseOutputTextGroupConverter(string and)
        {
            And = and;
        }

        protected string Convert(BaseViewModel viewModel, CultureInfo culture)
        {
            string retval = null;

            StringBuilder sb = new StringBuilder();

            if (viewModel is TotalGroupViewModel total)
            {
                 Convert(total, sb, culture);
            }
            else if (viewModel is ShareGroupViewModel share)
            {
                Convert(share, sb, culture);
            }
            else if (viewModel is DebtorsGroupViewModel debtors)
            {
                Convert(debtors, sb, culture);
            }
            else if(viewModel is CollectedGroupViewModel collected)
            {
                Convert(collected, sb, culture);
            }
            else if (viewModel is ExpensesGroupViewModel expenses)
            {
                Convert(expenses, sb, culture);
            }
            else if (viewModel is EvensGroupViewModel evens)
            {
                Convert(evens, sb, culture);
            }
            else
            {
                retval = "Group converted not defined";
            }

            retval = sb.ToString();

            return retval;
        }

        protected virtual void Convert(TotalGroupViewModel viewModel, StringBuilder sb, CultureInfo culture)
        {
            sb.Append(TotalCostEvent.
                Replace("{total}", viewModel.Total.ToMoney(culture)));
            if (viewModel.HasExpenses && viewModel.TotalGuests > 0)
            {
                sb.Append("<br />");
                
                string expenses = viewModel.Expenses.Select(
                    x => TotalExpense
                    .Replace("{value}", x.Value1.ToMoney(culture))
                    .Replace("{name}", x.Name))
                    .Enumerate(And);

                sb.Append(TotalComponsed.
                    Replace("{totalGuests}", viewModel.TotalGuests.ToMoney(culture)).
                    Replace("{expenses}", expenses));
            }
        }

        protected virtual void Convert(ShareGroupViewModel viewModel, StringBuilder sb, CultureInfo culture)
        {
            sb.Append(ShareDivided.
                Replace("{guestsCount}", viewModel.GuestsCount.ToString()).
                Replace("{share}", viewModel.Share.ToMoney(culture)));
            sb.Append("<br />");
            if (viewModel.NotEveryOneOwesFullShare)
            {
                sb.Append("<strong>");
                switch (viewModel.Situation)
                {
                    case GuestsSituation.CreditorsAndPartialDebtors:
                        sb.Append(ShareCreditorsAndPartialDebtors);
                        break;
                    case GuestsSituation.NoCreditors:
                        sb.Append(ShareNoCreditors);
                        break;
                    case GuestsSituation.PartialDebtors:
                        sb.Append(SharePartialDebtors);
                        break;
                }
            }
        }

        protected virtual void Convert(DebtorsGroupViewModel viewModel, StringBuilder sb, CultureInfo culture)
        {

            if (viewModel.HasFullDebtors)
            {
                string singleOrPluralFullDebtors = viewModel.IsSingleFullDebtor ? DebtorsFullDebtorsSingular : DebtorsFullDebtorsPlural;

                sb.Append(singleOrPluralFullDebtors
                    .Replace("{fullDebtors}", viewModel.FullDebtors.Select(x => $"<i>{x}</i>").Enumerate(And))
                    .Replace("{share}", viewModel.Share.ToMoney(culture)));
                sb.Append("<br />");
            }

            if (viewModel.HasPartialDebtors)
            {
                if (viewModel.IsSinglePartialDebtor)
                {
                    string insteadSinglePartialDebtor = viewModel.HasFullDebtors ? DebtorsInsteadPartialDebtorsSingular : DebtorsPartialDebtorsSingular;
                    sb.Append(insteadSinglePartialDebtor
                        .Replace("{name}", viewModel.SinglePartialDebtor.Name)
                        .Replace("{debt}", viewModel.SinglePartialDebtor.Value1.ToMoney(culture))
                        .Replace("{contribution}", viewModel.SinglePartialDebtor.Value2.ToMoney(culture)));
                }
                else
                {
                    string insteadManyPartialDebtors = viewModel.HasFullDebtors ? DebtorsInsteadPartialDebtorsPlural : DebtorsPartialDebtorsPlural;
                    sb.Append(insteadManyPartialDebtors
                        .Replace("{partialDebtors}", viewModel.PartialDebtors.Select(x => $"<i>{x.Name}</i>").Enumerate(And)));
                    sb.Append("<br />");
                    foreach (var o in viewModel.PartialDebtors)
                    {
                        sb.Append(DebtorsEachPartialDebtor
                            .Replace("{name}", o.Name)
                            .Replace("{debt}", o.Value1.ToMoney(culture))
                            .Replace("{contribution}", o.Value2.ToMoney(culture)));
                        sb.Append("<br />");
                    }
                }
            }
        }

        protected void Convert(CollectedGroupViewModel viewModel, StringBuilder sb, CultureInfo culture)
        {
            string creditors =
                viewModel.Creditors.Select(x => CollectedCreditor
                .Replace("{value}", x.Value1.ToMoney(culture))
                .Replace("{name}", x.Name))
                .Enumerate(And);

            if (viewModel.IsSingleDebtor)
            {
                sb.Append(CollectedSingleDebtor
                    .Replace("{singleDebtor}", viewModel.SingleDebtor)
                    .Replace("{creditors}", creditors));
            }
            else
            {
                sb.Append(CollectedTotalCollected
                    .Replace("{debtors}", viewModel.Debtors.Select(x => $"<i>{x}</i>").Enumerate(And)
                    .Replace("{totalCollected}", viewModel.TotalCopllected.ToMoney(culture))));
                sb.Append("<br />");
                if (viewModel.IsSingleCreditor && !viewModel.HasExpenses)
                {
                    sb.Append(CollectedOneSingleCreditor
                        .Replace("{singleCreditor}", viewModel.SingleCreditor.Name));
                }
                else
                {
                    sb.Append(CollectedManyDebtorsCreditors
                        .Replace("{creditors}", creditors));
                }
            }
        }

        protected void Convert(ExpensesGroupViewModel viewModel, StringBuilder sb, CultureInfo culture)
        {
            if (viewModel.HasCreditors)
            {
                sb.Append(ExpensesRemaining
                    .Replace("{remaining}", viewModel.Remaining.ToMoney(culture)));
                sb.Append("<br />");
            }
            string expenses = viewModel.Expenses.Select(x =>  ExpensesExpense
                .Replace("{value}", x.Value1.ToMoney(culture))
                .Replace("{name}", x.Name))
            .Enumerate(And);
            sb.Append(ExpensesExpenses.Replace("{expenses}", expenses));
        }

        protected void Convert(EvensGroupViewModel viewModel, StringBuilder sb, CultureInfo culture)
        {
            string evensSingularPlural = viewModel.Evens.Count() == 1 ? EvensSingular : EvensPlural;
            sb.Append(evensSingularPlural
                .Replace("{evens}", viewModel.Evens.Select(x => $"<i>{x}</i>").Enumerate(And)));
        }

        #region Lines

        protected string And
        {
            get;
            set;
        }

        //Total
        protected string TotalCostEvent
        {
            get;
            set;
        }
        
        protected string TotalComponsed
        {
            get;
            set;
        }

        protected string TotalExpense
        {
            get;
            set;
        }

        //Share
        protected string ShareDivided
        {
            get;
            set;
        }
        protected string ShareCreditorsAndPartialDebtors
        {
            get;
            set;
        }
        protected string ShareNoCreditors
        {
            get;
            set;
        }
        protected string SharePartialDebtors
        {
            get;
            set;
        }

        //Debtors
        protected string DebtorsFullDebtorsSingular
        {
            get;
            set;
        }
        protected string DebtorsFullDebtorsPlural
        {
            get;
            set;
        }

        protected string DebtorsPartialDebtorsSingular
        {
            get;
            set;
        }

        protected string DebtorsPartialDebtorsPlural
        {
            get;
            set;
        }

        protected string DebtorsInsteadPartialDebtorsSingular
        {
            get;
            set;
        }

        protected string DebtorsInsteadPartialDebtorsPlural
        {
            get;
            set;
        }

        protected string DebtorsEachPartialDebtor
        {
            get;
            set;
        }

        //Collected
        protected string CollectedSingleDebtor
        {
            get;
            set;
        }

        protected string CollectedCreditor
        {
            get;
            set;
        }

        protected string CollectedTotalCollected
        {
            get;
            set;
        }

        protected string CollectedManyDebtorsCreditors
        {
            get;
            set;
        }

        protected string CollectedOneSingleCreditor
        {
            get;
            set;
        }

        //Expenses
        protected string ExpensesRemaining
        {
            get;
            set;
        }

        protected string ExpensesExpenses
        {
            get;
            set;
        }

        protected string ExpensesExpense
        {
            get;
            set;
        }

        //Evens
        protected string EvensSingular
        {
            get;
            set;
        }

        protected string EvensPlural
        {
            get;
            set;
        }

        #endregion
    }
}
