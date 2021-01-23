using Reedoo.NET.Messages;
using Reedoo.NET.Messages.Input;
using Reedoo.NET.Messages.Validations;
using System;

namespace RomanApp.Messages.Input.Sheet
{
    [Serializable]
    public abstract class AddItemInput : InputMessage
    {

        #region Properties

        [Tags("name")]
        public virtual string Name
        {
            get;
            set;
        }

        [Tags("amount")]
        public virtual string Amount
        {
            get;
            set;
        }


        #endregion
    }
}
