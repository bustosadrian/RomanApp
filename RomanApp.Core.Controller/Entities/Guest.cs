﻿using Reedoo.NET.Controller;

namespace RomanApp.Core.Controller.Entities
{
    public class Guest : Item
    {
        #region Properties

        public IMember Member
        {
            get;
            set;
        }

        #endregion
    }
}
