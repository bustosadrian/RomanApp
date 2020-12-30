using Reedoo.NET.Controller;
using Reedoo.NET.Messages;
using RomanApp.Commons;
using RomanApp.Messages.Input;
using RomanApp.Messages.Input.Settings;
using RomanApp.Messages.Output.Settings;

namespace RomanApp.Controller.MemberStates
{
    [ApplicationState(StatesKeys.SETTINGS)]
    public class SettingsMemberState : BaseMemberState
    {
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
