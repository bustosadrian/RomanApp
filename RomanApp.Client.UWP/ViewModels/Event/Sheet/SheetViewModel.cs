using Reedoo.NET.Messages;
using Reedoo.NET.Utils.Reflect;
using RomanApp.Messages.Event.Output.Sheet;
using System.Collections.ObjectModel;
using System.Linq;

namespace RomanApp.Client.UWP.ViewModels.Event.Sheet
{
    public class SheetViewModel : EventViewModel
    {

        public SheetViewModel()
        {
            ItemFormViewModel = new ItemFormViewModel(this);
            OutcomeViewModel = new OutcomeViewModel(this);
        }

        #region Messages

        [Reader]
        public bool Read(SheetBriefingOutput message)
        {
            EventName = message.EventName;
            Guests = new ObservableCollection<GuestViewModel>(
                message.Guests.Select(x => new GuestViewModel(this, x)));

            Expenses = new ObservableCollection<ExpenseViewModel>(
                message.Expenses.Select(x => new ExpenseViewModel(this, x)));

            return true;
        }

        [Reader]
        public bool Read(GuestOutput message)
        {
            Guests.Add(new GuestViewModel(this, message));
            return true;
        }

        [Reader]
        public bool Read(ExpenseOutput message)
        {
            Expenses.Add(new ExpenseViewModel(this, message));
            return true;
        }

        [Reader]
        public bool Read(RemoveGuestOutput message)
        {
            GuestViewModel o = Guests.SingleOrDefault(x => x.Id == message.ItemId);
            if(o != null)
            {
                Guests.Remove(o);
            }

            return true;
        }

        [Reader]
        public bool Read(RemoveExpenseOutput message)
        {
            ExpenseViewModel o = Expenses.SingleOrDefault(x => x.Id == message.ItemId);
            if (o != null)
            {
                Expenses.Remove(o);
            }

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

        private ObservableCollection<ExpenseViewModel> _expenses;
        [Embedded]
        public ObservableCollection<ExpenseViewModel> Expenses
        {
            get
            {
                return _expenses;
            }
            set
            {
                _expenses = value;
                OnPropertyChanged("Expenses");
                OnPropertyChanged("ShowExpenses");
            }
        }

        private ObservableCollection<GuestViewModel> _guests;
        [Embedded]
        public ObservableCollection<GuestViewModel> Guests
        {
            get
            {
                return _guests;
            }
            set
            {
                _guests = value;
                OnPropertyChanged("Guests");
                OnPropertyChanged("ShowGuests");
            }
        }

        private ItemFormViewModel _itemFormViewModel;
        [Embedded]
        public ItemFormViewModel ItemFormViewModel
        {
            get
            {
                return _itemFormViewModel;
            }
            set
            {
                _itemFormViewModel = value;
                OnPropertyChanged("ItemFormViewModel");
            }
        }

        private OutcomeViewModel _outcomeViewModel;
        [Embedded]
        public OutcomeViewModel OutcomeViewModel
        {
            get
            {
                return _outcomeViewModel;
            }
            set
            {
                _outcomeViewModel = value;
                OnPropertyChanged("OutcomeViewModel");
            }
        }

        #endregion
    }
}
