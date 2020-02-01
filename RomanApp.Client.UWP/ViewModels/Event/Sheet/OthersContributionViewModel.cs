using RomanApp.Messages.Event.Input.Sheet;

namespace RomanApp.Client.UWP.ViewModels.Event.Sheet
{
    public class OthersContributionViewModel : ItemAmountViewModel
    {
        public OthersContributionViewModel(BaseViewModel parent, string guestName)
            : base(parent, new OtherGuestAmountDialogTitle(guestName))
        {
        }

        protected override UpdateContributionInput CreateUpdateContributionInput()
        {
            return new OthersContributionInput();
        }
    }
}
