using Reedoo.NET.Messages;
using Reedoo.NET.Messages.Output;
using System;
using System.Collections.Generic;
using System.Text;

namespace RomanApp.Messages.Event.Output.ItemDetails
{
    [Serializable]
    [Message(KEY)]
    public class GuestDetailsOutput : ItemDetailsOutput
    {
        private const string KEY = "RomanApp.Event.Guest.Details.Output";

        #region Properties

        public bool IsSelf
        {
            get;
            set;
        }

        #endregion
    }
}
