using System;
using System.Collections.Generic;
using System.Text;

namespace RomanApp.Service.Entities
{
    public class Item : BaseEntity
    {
        public string Name
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
