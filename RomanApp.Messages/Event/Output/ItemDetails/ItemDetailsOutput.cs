using Reedoo.NET.Messages.Output;
using System;
using System.Collections.Generic;
using System.Text;

namespace RomanApp.Messages.Event.Output.ItemDetails
{
    [Serializable]
    public abstract class ItemDetailsOutput : OutputMessage
    {
        #region Properties

        public string EntityId
        {
            get;
            set;
        }

        public string Label
        {
            get;
            set;
        }

        public decimal? Amount
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        #endregion

    }
}
