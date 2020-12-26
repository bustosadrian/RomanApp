using System;

namespace RomanApp.Service.Exceptions
{
    public abstract class EventServiceException : Exception
    {
        public EventServiceException()
        {

        }

        public EventServiceException(string message) 
            : base(message)
        {
        }

        public EventServiceException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }
    }
}
