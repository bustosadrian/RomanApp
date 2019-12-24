using Reedoo.NET.Messages;

namespace RomanApp.Messages.Input
{
    [Message(Key = KEY)]
    public class AddExpenseMessage : AddItemMessage
    {
        private const string KEY = "RomanApp.Add.Expense";

    }
}
