using Reedoo.NET.Messages;
using System;

namespace RomanApp.Messages.Event.Input.Sheet
{
    [Serializable]
    [Message(KEY)]
    public class RemoveExpenseInput : RemoveItemInput
    {
        private const string KEY = "RomanApp.Event.Sheet.Remove.Expense..Output";
    }
}
