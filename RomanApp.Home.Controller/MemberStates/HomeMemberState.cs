using Reedoo.NET.Controller;
using Reedoo.NET.Messages;
using RomanApp.Core.Controller;
using RomanApp.Messages.Input;

namespace RomanApp.Home.Controller.MemberStates
{
    public abstract class HomeMemberState : RomanAppMemberState
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
    }
}
