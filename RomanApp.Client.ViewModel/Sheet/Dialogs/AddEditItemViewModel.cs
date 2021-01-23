using Reedoo.NET.Messages.Output.Validation;
using RomanApp.Messages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace RomanApp.Client.ViewModel.Sheet.Dialogs
{
    public class AddEditItemViewModel : BaseViewModel
    {
        public AddEditItemViewModel(KeyboardMode keyboardMode, ItemType itemType, bool isEditing)
            : this(keyboardMode, null, itemType, isEditing)
        {

        }

        public AddEditItemViewModel(KeyboardMode keyboardMode, string id, ItemType itemType, bool isEditing)
        {
            NameValidationErrors = new ObservableCollection<ValidationError>();
            AmountValidationErrors = new ObservableCollection<ValidationError>();

            KeyboardMode = keyboardMode;
            Id = id;
            ItemType = itemType;
            IsEditing = isEditing;
        }

        public bool ProcessValidationErrors(IEnumerable<ValidationError> errors)
        {
            bool retval = false;

            NameValidationErrors.Clear();
            AmountValidationErrors.Clear();
            foreach(var o in errors)
            {
                if (o.Tags.Contains("name"))
                {
                    NameValidationErrors.Add(o);
                    retval = true;
                }

                if (o.Tags.Contains("amount"))
                {
                    AmountValidationErrors.Add(o);
                    retval = true;
                }
            }

            return retval;
        }

        #region Properties

        private ObservableCollection<ValidationError> _nameValidationErrors;
        public ObservableCollection<ValidationError> NameValidationErrors
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

        private ObservableCollection<ValidationError> _amountValidationErrors;
        public ObservableCollection<ValidationError> AmountValidationErrors
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

        private string _amount;
        public string Amount
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

        private KeyboardMode _keyboardMode;
        public KeyboardMode KeyboardMode
        {
            get
            {
                return _keyboardMode;
            }
            set
            {
                _keyboardMode = value;
                OnPropertyChanged(nameof(KeyboardMode));
            }
        }

        #endregion
    }
}
