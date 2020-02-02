using Reedoo.NET.Messages;
using RomanApp.Client.UWP.ViewModels.Event;
using RomanApp.Messages.Event.Output.ItemDetails;

namespace RomanApp.Client.UWP.ViewModels.Event.ItemDetails
{
    public class GuestDetailsViewModel : ItemDetailsViewModel
    {

        #region Messages

        [Reader]
        public bool Read(GuestDetailsOutput message)
        {
            base.ReadDetails(message);
            IsSelf = message.IsSelf;

            return true;
        }

        #endregion

        #region Properties

        private bool _isSelf;
        public bool IsSelf
        {
            get
            {
                return _isSelf;
            }
            set
            {
                _isSelf = value;
                OnPropertyChanged("IsSelf");
            }
        }
        
        #endregion
    }
}
