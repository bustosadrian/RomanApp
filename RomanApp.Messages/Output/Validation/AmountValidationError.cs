using Reedoo.NET.Messages.Output.Validation;
using RomanApp.Commons.Utils;

namespace RomanApp.Messages.Output.Validation
{
    public class AmountValidationError : ValidationError
    {
        public AmountValidationError(FailuireReason reason)
            : base($"Invalid amount: {reason}")
        {
            Reason = reason;
        }

        #region Properties

        public FailuireReason Reason
        {
            get;
            set;
        }

        #endregion
    }
}
