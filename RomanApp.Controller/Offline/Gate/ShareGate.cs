using Reedoo.NET.Controller;
using Reedoo.NET.Messages;
using RomanApp.Messages.Input;

namespace RomanApp.Controller.Offline.Gate
{
    [ApplicationState(KEY)]
    public class ShareGate : TrespasserState
    {
        private const string KEY = "RomanApp.Offline.Gate.Share";

        private LoginId _loginId;

        public override void OnLoad(object parameters)
        {
            _loginId = (LoginId)parameters;
        }

        public override void Brief()
        {

        }

        #region Messages

        [Reader]
        public void Read(MyShareMessage message)
        {
            _loginId.Share = new Share()
            {
                Amount = message.Amount,
                Description = message.Description,
            };
            GrantAccess(_loginId);
        }

        #endregion

    }
}
