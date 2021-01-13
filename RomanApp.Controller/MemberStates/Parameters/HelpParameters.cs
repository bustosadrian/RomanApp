﻿using RomanApp.Messages;
using System;

namespace RomanApp.Controller.MemberStates.Parameters
{
    public class HelpParameters
    {
        #region Properties

        public HelpTopic Topic
        {
            get;
            set;
        }

        public Type PreviousState
        {
            get;
            set;
        }

        #endregion
    }
}
