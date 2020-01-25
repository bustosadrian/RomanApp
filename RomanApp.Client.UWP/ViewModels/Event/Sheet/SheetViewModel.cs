using Reedoo.NET.Messages;
using RomanApp.Messages.Event.Output;

namespace RomanApp.Client.UWP.ViewModels.Event.Sheet
{
    public class SheetViewModel : EventViewModel
    {
        #region Messages

        [Reader]
        public bool Read(SheetBriefingOutput message)
        {
            EventName = message.EventName;

            return true;
        }

        #endregion

        #region Properties

        private string _eventName;
        public string EventName
        {
            get
            {
                return _eventName;
            }
            set
            {
                _eventName = value;
                OnPropertyChanged("EventName");
            }
        }

        #endregion
    }
}
