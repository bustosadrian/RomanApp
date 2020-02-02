using Reedoo.NET.Messages.Input;
using System;

namespace RomanApp.Messages.Event.Input
{
    [Serializable]
    public abstract class ViewItemDetailsInput : InputMessage
    {
        #region Properties

        public string EntityId
        {
            get;
            set;
        }

        #endregion

    }
}
