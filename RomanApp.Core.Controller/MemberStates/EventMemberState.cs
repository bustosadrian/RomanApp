using Reedoo.NET.Messages;
using RomanApp.Messages.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace RomanApp.Core.Controller.MemberStates
{
    public abstract class EventMemberState : RomanAppMemberState
    {
        protected virtual void OnBack()
        {

        }

        #region Messages

        [Reader]
        public void Read(BackInput message)
        {
            OnBack();
        }

        #endregion

        #region Properties

        protected IRomanAppRoomState RomanAppRoomState
        {
            get
            {
                return (IRomanAppRoomState)GetRoomState();
            }
        }

        #endregion
    }
}
