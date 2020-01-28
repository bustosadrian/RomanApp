using Reedoo.NET.Messages.Output;
using System;
using System.Collections.Generic;
using System.Text;

namespace RomanApp.Messages.Event.Output
{
    public abstract class BaseEntityOutput : OutputMessage
    {
        #region Properties

        public string Id
        {
            get;
            set;
        }

        #endregion
    }
}
