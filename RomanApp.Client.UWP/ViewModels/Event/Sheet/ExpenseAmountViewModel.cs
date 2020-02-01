using RomanApp.Messages.Event.Input.Sheet;

namespace RomanApp.Client.UWP.ViewModels.Event.Sheet
{
    public class ExpenseAmountViewModel : ItemAmountViewModel
    {
        public ExpenseAmountViewModel(BaseViewModel parent, string expenseLabel)
            : base(parent, new ExpenseAmountDialogTitle(expenseLabel))
        {
        }

        protected override UpdateContributionInput CreateUpdateContributionInput()
        {
            return new UpdateExpenseAmountInput();
        }
    }
}
