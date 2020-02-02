using Reedoo.NET.Messages;
using RomanApp.Core.Controller.Entities;
using RomanApp.Core.Controller.MemberStates.ItemDetails;
using RomanApp.Messages.Event.Input;
using RomanApp.Messages.Event.Output;
using RomanApp.Messages.Input;

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

        [Reader]
        public void Read(ViewGuestDetailsInput message)
        {
            ChangeState(typeof(GuestDetailsMemberState), message.EntityId);
        }

        [Reader]
        public void Read(ViewExpenseDetailsInput message)
        {
            ChangeState(typeof(ExpenseDetailsMemberState), message.EntityId);
        }

        #endregion

        #region Mapping

        protected ShareOutput Map(Share entity)
        {
            ShareOutput retval = null;

            retval = new ShareOutput()
            {
                EntityId = entity.Id,
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

        public Guest MemberGuest
        {
            get
            {
                return Member.Locker.Get<Guest>(RomanAppRoomHandler.LOCKER_MEMBER_GUEST);
            }
        }

        public MemberProfile MemberProfile
        {
            get
            {
                return Member.Locker.Get<MemberProfile>(RomanAppRoomHandler.LOCKER_MEMBER_PROFILE);
            }
        }

        #endregion
    }
}
