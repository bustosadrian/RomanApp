using Reedoo.NET.Messages;
using System;

namespace RomanApp.Messages.Event.Input
{
    [Serializable]
    [Message(KEY)]
    public class ViewExpenseDetailsInput : ViewItemDetailsInput
    {
        private const string KEY = "RomanApp.Event.View.Expense.Details.Input";

    }
}
