using System;
using System.Collections.Generic;
using System.Text;

namespace RomanApp.Messages.Event.Input.Sheet
{
    [Serializable]
    public abstract class ChangeItemAmountInput : ChangeContributionInput
    {
        #region Properties

        public string ItemId
        {
            get;
            set;
        }

        #endregion
    }
}
