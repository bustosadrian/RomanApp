using Reedoo.NET.Controller;
using Reedoo.NET.Messages;
using RomanApp.Messages.Input;

namespace RomanApp.Controller.Offline.Gate
{
    [ControllerState(Key = KEY)]
    public class LoginGate : TrespasserState
    {
        private const string KEY = "RomanApp.Offline.Gate.Login";

        public override void Brief()
        {
            
        }

        #region Messages

        [Reader]
        public void Read(LoginMessage message)
        {
            GrantAccess(new LoginId(message.Name)
            {

            });
        }

        #endregion
    }
}
