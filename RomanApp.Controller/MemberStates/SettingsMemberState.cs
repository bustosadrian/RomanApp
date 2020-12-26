using Reedoo.NET.Controller;
using Reedoo.NET.Messages;
using RomanApp.Messages.Input;
using RomanApp.Messages.Input.Settings;
using RomanApp.Messages.Output.Settings;

namespace RomanApp.Controller.MemberStates
{
    [ApplicationState(KEY)]
    public class SettingsMemberState : BaseMemberState
    {
        private const string KEY = "RomanApp.Settings";

        public override void Brief()
        {
            QueueSettings();
        }

        private void Back()
        {
            ChangeState(typeof(SheetMemberState));
        }

        #region Queues

        private void QueueSettings()
        {
            Queue(new SettingsOutput()
            {
                UseWholeNumbers = RoomSettings.UseWholeNumbers,
            });        
        }

        #endregion

        #region Messages

        [Reader]
        public void Action(BackInput message)
        {
            Back();
        }

        [Reader]
        public void Action(SaveSettingsInput message)
        {
            RoomSettings.UseWholeNumbers = message.UseWholeNumbers;
            Back();
        }

        #endregion
    }
}
