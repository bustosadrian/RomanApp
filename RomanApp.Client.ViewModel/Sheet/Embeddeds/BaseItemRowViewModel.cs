using Reedoo.NET.Messages;
using Reedoo.NET.Messages.Output;
using RomanApp.Client.ViewModel.Sheet.Dialogs;
using RomanApp.Messages;
using RomanApp.Messages.Input.Sheet;
using RomanApp.Messages.Output.Sheet;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RomanApp.Client.ViewModel.Sheet.Embeddeds
{
    public abstract class BaseItemRowViewModel : EmbeddedViewModel
    {

        public BaseItemRowViewModel(BusViewModel parent)
            : base(parent)
        {

        }

        public void Map(ItemOutput item)
        {
            Id = item.Id;
            Type = item.Type;
            Name = item.Name;
            Amount = item.Amount;
        }

        protected bool Load(ItemOutput item)
        {
            bool retval = false;

            if (item.Type == Type && item.Id.Equals(Id))
            {
                Map(item);
                retval = true;
            }

            return retval;
        }

        protected void Edit(AddEditItemViewModel viewModel)
        {
            EditItemInput message = new EditItemInput()
            {
                ItemId = Id,
                Type = Type,
                Name = viewModel.Name,
                Amount = viewModel.Amount,
            };
            Send(message);
        }

        protected void Delete()
        {
            Send(new RemoveItemInput()
            {
                ItemId = Id,
                Type = Type,
            });
        }

        #region Commands

        public ICommand EditCommand
        {
            get;
            protected set;
        }

        #endregion

        #region Messages

        [Reader]
        public virtual bool Read(ValidationErrors message)
        {
            return false;
        }

        [Reader]
        public virtual bool Read(ItemSavedOutput message)
        {
            return false;
        }

        [Reader]
        public bool Read(ItemOutput message)
        {
            return Load(message);
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
                OnPropertyChanged(nameof(Id));
            }
        }

        private ItemType _type;
        public ItemType Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
                OnPropertyChanged(nameof(Type));
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

        #endregion

    }
}
