using Reedoo.NET.Messages;
using RomanApp.Messages.Input;
using RomanApp.Messages.Output;
using System.Collections.ObjectModel;
using System.Linq;

namespace RomanApp.Client.XAML.ViewModels.Outcome
{
    public class OutcomeViewModel : BaseViewModel
    {

        private void Reset()
        {
            Send(new ResetMessage());
        }

        private void Back()
        {
            Send(new BackMessage());
        }

        #region Messages

        [Reader]
        public bool Read(OutcomeMessage message)
        {
            Total = message.Total;
            Share = message.Share;
            ExpensesTotal = message.ExpnesesTotal;

            Debtors = new ObservableCollection<GuestOutcomeViewModel>(
                message.Debtors.Select(x => Map(x)));

            Creditors = new ObservableCollection<GuestOutcomeViewModel>(
                message.Creditors.Select(x => Map(x)));

            Evens = new ObservableCollection<GuestOutcomeViewModel>(
                message.Evens.Select(x => Map(x)));

            return true;
        }

        private GuestOutcomeViewModel Map(GuestOutcomeMessage message)
        {
            GuestOutcomeViewModel retval = null;

            retval = new GuestOutcomeViewModel()
            {
                Name = message.Name,
                Amount = message.Amount,
            };

            return retval;
        }

        #endregion

        #region Commands

        private DelegateCommand _resetCommand;
        public DelegateCommand ResetCommand
        {
            get
            {
                if (_resetCommand == null)
                {
                    _resetCommand = new DelegateCommand(Reset);
                }
                return _resetCommand;
            }
        }

        private DelegateCommand _backCommand;
        public DelegateCommand BackCommand
        {
            get
            {
                if (_backCommand == null)
                {
                    _backCommand = new DelegateCommand(Back);
                }
                return _backCommand;
            }
        }


        #endregion

        #region Properties

        private decimal _total;
        public decimal Total
        {
            get
            {
                return _total;
            }
            set
            {
                _total = value;
                OnPropertyChanged("Total");
            }
        }

        private decimal _share;
        public decimal Share
        {
            get
            {
                return _share;
            }
            set
            {
                _share = value;
                OnPropertyChanged("Share");
            }
        }

        private decimal _expensesTotal;
        public decimal ExpensesTotal
        {
            get
            {
                return _expensesTotal;
            }
            set
            {
                _expensesTotal = value;
                OnPropertyChanged("ExpensesTotal");
            }
        }

        private ObservableCollection<GuestOutcomeViewModel> _debtors;
        public ObservableCollection<GuestOutcomeViewModel> Debtors
        {
            get
            {
                return _debtors;
            }
            set
            {
                _debtors = value;
                OnPropertyChanged("Debtors");
            }
        }

        private ObservableCollection<GuestOutcomeViewModel> _creditors;
        public ObservableCollection<GuestOutcomeViewModel> Creditors
        {
            get
            {
                return _creditors;
            }
            set
            {
                _creditors = value;
                OnPropertyChanged("Creditors");
            }
        }

        private ObservableCollection<GuestOutcomeViewModel> _evens;
        public ObservableCollection<GuestOutcomeViewModel> Evens
        {
            get
            {
                return _evens;
            }
            set
            {
                _evens = value;
                OnPropertyChanged("Evens");
            }
        }

        #endregion
    }
}
