using System;
using System.Collections.Generic;
using System.Text;

namespace RomanApp.Core.Controller.Entities
{
    public class GuestOutcome
    {
        #region Properties

        public string Id
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public decimal Amount
        {
            get;
            set;
        }

        public decimal Debt
        {
            get;
            set;
        }

        #endregion
    }
}
