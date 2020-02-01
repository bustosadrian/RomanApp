using Reedoo.NET.Messages.Output;
using System;
using System.Collections.Generic;
using System.Text;

namespace RomanApp.Messages.Event.Output.Sheet
{
    [Serializable]
    public abstract class ItemOutput : BaseEntityOutput
    {
        #region Properties

        public string Label
        {
            get;
            set;
        }

        public ShareOutput Share
        {
            get;
            set;
        }

        #endregion
    }
}
