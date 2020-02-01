using Reedoo.NET.Messages;
using RomanApp.Client.UWP.Views.Event.Sheet.Controls;
using RomanApp.Messages.Event.Input.Sheet;
using RomanApp.Messages.Event.Output;
using RomanApp.Messages.Event.Output.Sheet;

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

        private void OnEdit()
        {
            Send(CreateChangeContributionInput());
        }

        protected abstract RemoveItemInput CreateRemoveInput();

        protected abstract ChangeContributionInput CreateChangeContributionInput();

        #region Messages

        #endregion

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

        private DelegateCommand _editCommand;
        public DelegateCommand EditCommand
        {
            get
            {
                if (_editCommand == null)
                {
                    _editCommand = new DelegateCommand(OnEdit);
                }

                return _editCommand;
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
