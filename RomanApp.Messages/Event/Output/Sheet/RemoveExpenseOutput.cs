using Reedoo.NET.Messages;
using System;

namespace RomanApp.Messages.Event.Output.Sheet
{
    [Serializable]
    [Message(KEY)]
    public class RemoveExpenseOutput : RemoveItemOutput
    {

        private const string KEY = "RomanApp.Event.Sheet.Remove.Expense.Output";

    }
}
