using Reedoo.NET.Controller;
using Reedoo.NET.Messages;
using RomanApp.Messages.Event.Input.Login;

namespace RomanApp.Core.Controller.Gates.Login
{
    [ApplicationState(KEY)]
    public class LoginGate : TrespasserState
    {
        private const string KEY = "RomanApp.Event.Gate.Login";

        public override void Brief()
        {

        }

        #region Messages

        [Reader]
        public void Read(LoginInput message)
        {
            LoginId loginId = new LoginId(message.Name);
            GrantAccess(loginId);
        }

        #endregion
    }
}
