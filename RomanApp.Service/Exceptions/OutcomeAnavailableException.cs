using RomanApp.Service.Entities;

namespace RomanApp.Service.Exceptions
{
    public class OutcomeAnavailableException : EventServiceException
    {
        public OutcomeAnavailableException(OutcomeResult result)
        {
            Result = result;
        }

        #region Properties

        public OutcomeResult Result
        {
            get;
            set;
        }

        #endregion
    }
}
