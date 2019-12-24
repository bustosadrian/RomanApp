using Reedoo.NET.Messages;
using System;

namespace RomanApp.Messages.Output
{
    [Serializable]
    [Message(Key = KEY)]
    public class ExpenseMessage : ItemMessage
    {
        private const string KEY = "RomanApp.Expense";
    }
}
