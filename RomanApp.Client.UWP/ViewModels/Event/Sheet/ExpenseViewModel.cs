using Reedoo.NET.Messages;
using RomanApp.Messages.Event.Input.Sheet;
using RomanApp.Messages.Event.Output.Sheet;

namespace RomanApp.Client.UWP.ViewModels.Event.Sheet
{
    public class ExpenseViewModel : ItemViewModel
    {
        public ExpenseViewModel(BaseViewModel parent, ExpenseOutput expense)
            : base(parent)
        {
            Map(expense);
        }

        protected void Map(ExpenseOutput message)
        {
            base.Map(message.Share);
            Id = message.Id;
            Label = message.Label;
        }

        protected override RemoveItemInput CreateRemoveInput()
        {
            return new RemoveExpenseInput();
        }

        #region Messages

        [Reader]
        public bool Read(ExpenseOutput message)
        {
            bool retval = false;

            if (message.Id.Equals(Id))
            {
                Map(message);
                retval = true;
            }

            return retval;

        }

        #endregion
    }
}
