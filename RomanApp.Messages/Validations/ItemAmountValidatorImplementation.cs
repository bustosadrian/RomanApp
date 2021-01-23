using Reedoo.NET.Messages.Output.Validation;
using Reedoo.NET.Messages.Validations;
using RomanApp.Commons.Utils;
using RomanApp.Messages.Output.Validation;
using System.Collections.Generic;
using System.Reflection;

namespace RomanApp.Messages.Validations
{
    public class ItemAmountValidatorImplementation : MessagePropertyValidatorImplementation<ItemAmountValidationAttribute>
    {
        public override void Check(PropertyInfo property)
        {
            if (!property.PropertyType.Equals(typeof(string)))
            {
                throw new ValidationCheckException($"{typeof(ItemAmountValidationAttribute)} should only be implemted on {typeof(string)} type properties.");
            }
        }

        public override IEnumerable<ValidationError> Validate(PropertyInfo property, object value)
        {
            IList<ValidationError> retval = null;

            retval = new List<ValidationError>();

            if(!string.IsNullOrEmpty((string)value))
            {
                try
                {
                    AmountConverter.Convert((string)value, GetAttribute().GreaterThanZero);
                }
                catch (AmountConvertionException e)
                {
                    retval.Add(new AmountValidationError(e.Reason));
                }
            }

            return retval;
        }
    }
}
