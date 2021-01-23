using Reedoo.NET.Controller;
using Reedoo.NET.Messages;
using RomanApp.Commons;
using RomanApp.Messages.Input.Settings;
using RomanApp.Messages.Output.Settings;

namespace RomanApp.Controller.MemberStates
{
    [ApplicationState(StatesKeys.SETTINGS)]
    public class SettingsMemberState : BasicMemberState
    {

        public override void Brief()
        {
            QueueSettings();
        }

        protected override void OnBack()
        {
            ChangeState(typeof(SheetMemberState));
        }


        #region Queues

        private void QueueSettings()
        {
            Queue(new SettingsOutput()
            {
                UseWholeNumbers = RoomSettings.UseWholeNumbers,
                UseNumericKeyboard = RoomSettings.UseNumericKeyboard,
            });        
        }

        #endregion

        #region Messages

        [Reader]
        public void Action(SaveSettingsInput message)
        {
            if (message.UseWholeNumberSet)
            {
                RoomSettings.UseWholeNumbers = message.UseWholeNumbers;
            }

            if (message.UseNumericKeyboardSet)
            {
                RoomSettings.UseNumericKeyboard = message.UseNumericKeyboard;
            }
        }

        #endregion
    }
}
