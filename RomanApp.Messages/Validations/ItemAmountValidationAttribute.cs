using Reedoo.NET.Messages.Validations;
using System;

namespace RomanApp.Messages.Validations
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class ItemAmountValidationAttribute :  MessagePropertyValidatorAttribute
    {
        public ItemAmountValidationAttribute()
            : base( new ItemAmountValidatorImplementation())
        {

        }

        #region Properties

        public bool GreaterThanZero
        {
            get;
            set;
        }

        #endregion
    }
}
