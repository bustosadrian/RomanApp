using Reedoo.NET.Messages;
using RomanApp.Messages.Event.Output.ItemDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanApp.Client.UWP.ViewModels.Event.ItemDetails
{
    public class ExpenseDetailsViewModel : ItemDetailsViewModel
    {
        #region Messages

        [Reader]
        public bool Read(ExpenseDetailsOutput message)
        {
            base.ReadDetails(message);

            return true;
        }

        #endregion
    }
}
