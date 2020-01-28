using RomanApp.Messages.Event.Input.Sheet;
using RomanApp.Messages.Event.Output;

namespace RomanApp.Client.UWP.ViewModels.Event.Sheet
{
    public abstract class ItemViewModel : EmbeddedViewModel
    {
        public ItemViewModel(BaseViewModel parent)
            : base(parent)
        {

        }

        protected void Map(ShareOutput message)
        {
            Amount = message.Amount;
        }

        private void OnRemove()
        {
            RemoveItemInput message = CreateRemoveInput();
            message.ItemId = Id;
            Send(message);
        }

        protected abstract RemoveItemInput CreateRemoveInput();

        #region Commands

        private DelegateCommand _removeCommand;
        public DelegateCommand RemoveCommand
        {
            get
            {
                if(_removeCommand == null)
                {
                    _removeCommand = new DelegateCommand(OnRemove);
                }

                return _removeCommand;
            }
        }

        #endregion

        #region Properties

        private string _id;
        public string Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }

        }

        private string _label;
        public string Label
        {
            get
            {
                return _label;
            }
            set
            {
                _label = value;
                OnPropertyChanged("Label");
            }
        }

        private decimal _amount;
        public decimal Amount
        {
            get
            {
                return _amount;
            }
            set
            {
                _amount = value;
                OnPropertyChanged("Amount");
            }
        }

        #endregion
    }
}
