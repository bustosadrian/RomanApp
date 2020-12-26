using Reedoo.NET.Messages;
using Reedoo.NET.Messages.Output;
using System;

namespace RomanApp.Messages.Output.Settings
{
    [Serializable]
    [Message(KEY)]
    public class SettingsOutput : OutputMessage
    {
        private const string KEY = "RomanApp.Settings.Output.Settings";

        #region Properties

        public bool UseWholeNumbers
        {
            get;
            set;
        }

        #endregion
    }
}

