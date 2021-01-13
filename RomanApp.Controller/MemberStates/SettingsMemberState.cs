using Reedoo.NET.Controller;
using Reedoo.NET.Messages;
using RomanApp.Commons;
using RomanApp.Messages;
using RomanApp.Messages.Input.Settings;
using RomanApp.Messages.Output.Settings;

namespace RomanApp.Controller.MemberStates
{
    [ApplicationState(StatesKeys.SETTINGS)]
    public class SettingsMemberState : BasicMemberState
    {
        public SettingsMemberState()
            : base(HelpTopic.Settings)
        {

        }

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
        }

        #endregion
    }
}
