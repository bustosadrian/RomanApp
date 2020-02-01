using System;
using System.Collections.Generic;
using System.Text;

namespace RomanApp.Core.Controller.Entities
{
    public class Item : BaseEntity
    {
        public string Label
        {
            get;
            set;
        }

        public Share Share
        {
            get;
            set;
        }
    }
}
