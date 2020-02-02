using Reedoo.NET.Messages;
using System;

namespace RomanApp.Messages.Event.Output.ItemDetails
{
    [Serializable]
    [Message(KEY)]
    public class ExpenseDetailsOutput : ItemDetailsOutput
    {
        private const string KEY = "RomanApp.Event.Expense.Details.Output";
        
    }
}
