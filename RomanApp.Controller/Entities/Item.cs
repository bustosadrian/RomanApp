using System;
using System.Collections.Generic;
using System.Text;

namespace RomanApp.Controller.Entities
{
    public abstract class Item
    {
        #region Properties

        public string Label
        {
            get;
            set;
        }

        public decimal Amount
        {
            get;
            set;
        }

        #endregion
    }
}
