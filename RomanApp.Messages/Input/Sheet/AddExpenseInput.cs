using Reedoo.NET.Messages;
using Reedoo.NET.Messages.Validations;
using System;

namespace RomanApp.Messages.Input.Sheet
{
    [Serializable]
    [Message(KEY)]
    public class AddExpenseInput : AddItemInput
    {
        private const string KEY = "RomanApp.Sheet.Input.Add.Expense";

        #region Properties

        [Required(ValidationMessage = "sheet.add.edit.expense.name.required")]
        public override string Name
        {
            get;
            set;
        }

        [Required(ValidationMessage = "sheet.add.edit.expense.amount.required")]
        [Range(GreaterThan = 0, ValidationMessage = "sheet.add.edit.expense.amount.range")]
        public override decimal Amount
        {
            get;
            set;
        }

        #endregion
        
    }
}
