using Reedoo.NET.Messages;
using RomanApp.Messages.Event.Input;
using RomanApp.Messages.Event.Input.Sheet;
using RomanApp.Messages.Event.Output.Sheet;

namespace RomanApp.Client.UWP.ViewModels.Event.Sheet
{
    public abstract class ItemViewModel : EmbeddedViewModel
    {
        private bool _isAdmin;

        public ItemViewModel(BaseViewModel parent, ItemOutput message, 
            bool isAdmin)
            : base(parent)
        {
            _isAdmin = isAdmin;
            CanEdit = _isAdmin;
            CanRemove = _isAdmin;

            Map(message);
        }

        protected virtual void Map(ItemOutput message)
        {
            Id = message.EntityId;
            Label = message.Label;
            Amount = message.Share?.Amount ?? 0;
        }

        private void OnRemove()
        {
            RemoveItemInput message = CreateRemoveInput();
            message.ItemId = Id;
            Send(message);
        }

        private void OnEdit()
        {
            ChangeItemAmountInput message = CreateChangeContributionInput();
            message.ItemId = Id;
            Send(message);
        }

        private void OnViewDetails()
        {
            ViewItemDetailsInput message = CreateViewItemDetailsInput();
            message.EntityId = Id;
            Send(message);
        }

        protected abstract RemoveItemInput CreateRemoveInput();

        protected abstract ChangeItemAmountInput CreateChangeContributionInput();

        protected abstract ViewItemDetailsInput CreateViewItemDetailsInput();

        #region Messages

        [Reader]
        public bool Read(ItemOutput message)
        {
            bool retval = false;

            if (message.EntityId.Equals(Id))
            {
                Map(message);
                retval = true;
            }

            return retval;
        }

        #endregion

        #region Commands

        private DelegateCommand _removeCommand;
        public DelegateCommand RemoveCommand
        {
            get
            {
                if(_removeCommand == null)
                {
                    _removeCommand = new DelegateCommand(OnRemove, () => CanRemove);
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
                    _editCommand = new DelegateCommand(OnEdit, () => CanEdit);
                }

                return _editCommand;
            }
        }

        private DelegateCommand _viewDetailsCommand;
        public DelegateCommand ViewDetailsCommand
        {
            get
            {
                if(_viewDetailsCommand == null)
                {
                    _viewDetailsCommand = new DelegateCommand(OnViewDetails);
                }
                return _viewDetailsCommand;
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

        public bool _canEdit;
        public bool CanEdit
        {
            get
            {
                return _canEdit;
            }
            set
            {
                _canEdit = value;
                OnPropertyChanged("CanEdit");
                EditCommand.RaiseCanExecuteChanged();
            }
        }

        public bool _canRemove;
        public bool CanRemove
        {
            get
            {
                return _canRemove;
            }
            set
            {
                _canRemove = value;
                OnPropertyChanged("CanRemove");
                RemoveCommand.RaiseCanExecuteChanged();
            }
        }

        private bool _isHighlighted;
        public bool IsHighlighted
        {
            get
            {
                return _isHighlighted;
            }
            set
            {
                _isHighlighted = value;
                OnPropertyChanged("IsHighlighted");
            }
        }

        #endregion
    }
}
