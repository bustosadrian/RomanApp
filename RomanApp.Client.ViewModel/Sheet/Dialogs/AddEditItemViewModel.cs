using Reedoo.NET.Messages.Output.Validation;
using RomanApp.Messages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace RomanApp.Client.ViewModel.Sheet.Dialogs
{
    public class AddEditItemViewModel : BaseViewModel
    {
        public AddEditItemViewModel(ItemType itemType, bool isEditing)
        {
            NameValidationErrors = new ObservableCollection<string>();
            AmountValidationErrors = new ObservableCollection<string>();

            ItemType = itemType;
            IsEditing = isEditing;
        }

        public AddEditItemViewModel(string id, ItemType itemType, bool isDeleteEnabled)
        {
            NameValidationErrors = new ObservableCollection<string>();
            AmountValidationErrors = new ObservableCollection<string>();

            Id = id;
            ItemType = itemType;
            IsEditing = isDeleteEnabled;
        }

        public bool ProcessValidationErrors(IEnumerable<ValidationError> errors)
        {
            bool retval = false;

            NameValidationErrors.Clear();
            AmountValidationErrors.Clear();
            foreach(var o in errors)
            {
                if(o.Data.ContainsKey("propertyName") && o.Data["propertyName"].ToString().Equals("name", StringComparison.InvariantCultureIgnoreCase))
                {
                    NameValidationErrors.Add(o.Message);
                    retval = true;
                } 
                else if (o.Data.ContainsKey("propertyName") && o.Data["propertyName"].ToString().Equals("amount", StringComparison.InvariantCultureIgnoreCase))
                {
                    AmountValidationErrors.Add(o.Message);
                    retval = true;
                }
            }

            return retval;
        }

        #region Properties

        private ObservableCollection<string> _nameValidationErrors;
        public ObservableCollection<string> NameValidationErrors
        {
            get
            {
                return _nameValidationErrors;
            }
            set 
            {
                _nameValidationErrors = value;
                OnPropertyChanged(nameof(NameValidationErrors));
            }
        }

        private ObservableCollection<string> _amountValidationErrors;
        public ObservableCollection<string> AmountValidationErrors
        {
            get
            {
                return _amountValidationErrors;
            }
            set
            {
                _amountValidationErrors = value;
                OnPropertyChanged(nameof(AmountValidationErrors));
            }
        }

        private string _id;
        public string Id
        {
            get
            {
                return _id;
            }
            private set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

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

        private bool _isEditing;
        public bool IsEditing
        {
            get
            {
                return _isEditing;
            }
            set
            {
                _isEditing = value;
                OnPropertyChanged(nameof(IsEditing));
            }
        }

        #endregion
    }
}
