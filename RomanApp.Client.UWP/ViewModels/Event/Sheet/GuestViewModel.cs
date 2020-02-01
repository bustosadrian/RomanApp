using Reedoo.NET.Messages;
using RomanApp.Messages.Event.Input.Sheet;
using RomanApp.Messages.Event.Output.Sheet;

namespace RomanApp.Client.UWP.ViewModels.Event.Sheet
{
    public class GuestViewModel : ItemViewModel
    {
        public GuestViewModel(BaseViewModel parent, GuestOutput guest)
            : base(parent)
        {
            Map(guest);
        }

        protected void Map(GuestOutput message)
        {
            base.Map(message.Share);
            Id = message.Id;
            Label = message.Name;
        }

        protected override RemoveItemInput CreateRemoveInput()
        {
            return new RemoveGuestInput();
        }

        protected override ChangeItemAmountInput CreateChangeContributionInput()
        {
            return new ChangeOthersContributionInput();
        }
        
        #region Messages

        [Reader]
        //TODO GuestOutput and ExpenseOutput should inherit
        public bool Read(GuestOutput message)
        {
            bool retval = false;

            if (message.Id.Equals(Id))
            {
                Map(message);
                retval = true;
            }

            return retval;
        }

        #endregion
    }
}
