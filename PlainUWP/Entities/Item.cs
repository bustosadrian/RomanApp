using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlainUWP.Entities
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
