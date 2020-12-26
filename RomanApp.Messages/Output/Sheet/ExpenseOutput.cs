using Reedoo.NET.Messages;
using System;

namespace RomanApp.Messages.Output.Sheet
{
    [Serializable]
    [Message(KEY)]
    public class ExpenseOutput : ItemOutput
    {
        private const string KEY = "RomanApp.Sheet.Output.Expense";
    }
}
