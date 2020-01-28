using Reedoo.NET.Messages;
using RomanApp.Core.Controller.Entities;
using RomanApp.Messages.Event.Output;
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

        #region Mapping

        protected ShareOutput Map(Share entity)
        {
            ShareOutput retval = null;

            retval = new ShareOutput()
            {
                Id = entity.Id,
                Description = entity.Description,
                Amount = entity.Amount,
            };

            return retval;
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
