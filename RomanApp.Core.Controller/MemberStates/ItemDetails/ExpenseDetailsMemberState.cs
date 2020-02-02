using Reedoo.NET.Controller;
using RomanApp.Core.Controller.Entities;
using RomanApp.Messages.Event.Output.ItemDetails;
using System.Linq;

namespace RomanApp.Core.Controller.MemberStates.ItemDetails
{
    [ApplicationState(KEY)]
    public class ExpenseDetailsMemberState : ItemDetailsMemberState<Expense>
    {
        private const string KEY = "RomanApp.Event.Expense.Details";

        protected override ItemDetailsOutput CreateItemDetailsOutput()
        {
            ExpenseDetailsOutput retval = null;

            retval = new ExpenseDetailsOutput();

            return retval;
        }

        protected override Expense GetItem(string id)
        {
            return CurrentEvent.Expenses.Single(x => x.Id == id);
        }
    }
}
