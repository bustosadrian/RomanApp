using System;

namespace RomanApp.Messages.Event.Input.Sheet
{
    [Serializable]
    public class AddExpenseInput : AddItemInput
    {
        private const string KEY = "RomanApp.Event.Sheet.Add.Expense";

    }
}
