using Reedoo.NET.Messages;
using Reedoo.NET.Messages.Input;
using System;

namespace RomanApp.Messages.Input.Settings
{
    [Serializable]
    [Message(KEY)]
    public class SaveSettingsInput : InputMessage
    {
        private const string KEY = "RomanApp.Settings.Input.Save.Settings";

        #region Properties

        public bool UseWholeNumberSet
        {
            get;
            set;
        }

        public bool UseWholeNumbers
        {
            get;
            set;
        }

        public bool UseNumericKeyboardSet
        {
            get;
            set;
        }

        public bool UseNumericKeyboard
        {
            get;
            set;
        }

        #endregion

    }
}
