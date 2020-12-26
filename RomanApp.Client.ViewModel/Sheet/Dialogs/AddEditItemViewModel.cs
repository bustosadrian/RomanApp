using RomanApp.Messages;

namespace RomanApp.Client.ViewModel.Sheet.Dialogs
{
    public class AddEditItemViewModel : BaseViewModel
    {
        public AddEditItemViewModel(ItemType itemType, bool isDeleteEnabled)
        {
            ItemType = itemType;
            IsDeleteEnabled = isDeleteEnabled;
        }

        #region Properties

        private ItemType _itemType;
        public ItemType ItemType
        {
            get
            {
                return _itemType;
            }
            private set
            {
                _itemType = value;
                OnPropertyChanged(nameof(ItemType));
            }
        }

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
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
                OnPropertyChanged(nameof(Amount));
            }
        }

        private bool _isDeleteEnabled;
        public bool IsDeleteEnabled
        {
            get
            {
                return _isDeleteEnabled;
            }
            set
            {
                _isDeleteEnabled = value;
                OnPropertyChanged(nameof(IsDeleteEnabled));
            }
        }

        #endregion
    }
}
