using Reedoo.NET.Messages;
using RomanApp.Messages.Event.Input;
using RomanApp.Messages.Event.Input.Sheet;
using RomanApp.Messages.Event.Output.Sheet;

namespace RomanApp.Client.UWP.ViewModels.Event.Sheet
{
    public class ExpenseViewModel : ItemViewModel
    {
        public ExpenseViewModel(BaseViewModel parent, ExpenseOutput message, bool isAdmin)
            : base(parent, message, isAdmin)
        {

        }

        protected override RemoveItemInput CreateRemoveInput()
        {
            return new RemoveExpenseInput();
        }

        protected override ChangeItemAmountInput CreateChangeContributionInput()
        {
            return new ChangeExpenseAmountInput();
        }

        protected override ViewItemDetailsInput CreateViewItemDetailsInput()
        {
            return new ViewExpenseDetailsInput();
        }
    }
}
