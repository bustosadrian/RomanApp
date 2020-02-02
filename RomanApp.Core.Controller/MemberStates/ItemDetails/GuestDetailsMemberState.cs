using Reedoo.NET.Controller;
using RomanApp.Core.Controller.Entities;
using RomanApp.Core.Controller.MemberStates.Sheet;
using RomanApp.Messages.Event.Output.ItemDetails;
using System;
using System.Linq;

namespace RomanApp.Core.Controller.MemberStates.ItemDetails
{
    [ApplicationState(KEY)]
    public class GuestDetailsMemberState : ItemDetailsMemberState<Guest>
    {
        private const string KEY = "RomanApp.Event.Guest.Details";

        protected override ItemDetailsOutput CreateItemDetailsOutput()
        {
            GuestDetailsOutput retval = null;

            retval = new GuestDetailsOutput();
            retval.IsSelf = _item.Id == MemberGuest.Id;

            return retval;
        }

        protected override Guest GetItem(string id)
        {
            return CurrentEvent.Guests.Single(x => x.Id == id);
        }
    }
}
