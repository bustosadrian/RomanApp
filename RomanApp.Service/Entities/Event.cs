﻿using System;
using System.Collections.Generic;

namespace RomanApp.Service.Entities
{
    public class Event : BaseEntity
    {
        #region Properties

        public string Name
        {
            get;
            set;
        }

        public DateTime DateCreated
        {
            get;
            set;
        }

        public List<Guest> Guests
        {
            get;
            set;
        }

        public List<Expense> Expenses
        {
            get;
            set;
        }

        #endregion
    }
}
