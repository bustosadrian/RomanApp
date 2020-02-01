using Reedoo.NET.Messages;
using RomanApp.Messages.Event.Input.Sheet;
using RomanApp.Messages.Event.Output.Sheet;

namespace RomanApp.Client.UWP.ViewModels.Event.Sheet
{
    public class GuestViewModel : ItemViewModel
    {
        private bool _isSelf;
        public GuestViewModel(BaseViewModel parent, GuestOutput message, bool isAdmin)
            : base(parent, message, isAdmin)
        {

        }

        protected override void Map(ItemOutput message)
        {
            base.Map(message);
            GuestOutput guestOutput = (GuestOutput)message;
            _isSelf = guestOutput.IsSelf;
            IsHighlighted = _isSelf;
            if (_isSelf)
            {
                CanEdit = false;
                CanRemove = false;
            }
        }

        protected override RemoveItemInput CreateRemoveInput()
        {
            return new RemoveGuestInput();
        }

        protected override ChangeItemAmountInput CreateChangeContributionInput()
        {
            return new ChangeOthersContributionInput();
        }
        
    }
}
