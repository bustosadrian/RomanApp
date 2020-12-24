using Reedoo.NET.Client.Messages;
using Reedoo.NET.Messages;
using RomanApp.Messages.Event.Output.Sheet;
using System.Collections.ObjectModel;
using System.Linq;

namespace RomanApp.Client.UWP.ViewModels.Event.Sheet
{
    public class OutcomeViewModel : EmbeddedViewModel
    {
        public OutcomeViewModel(BaseViewModel parent)
            : base(parent)
        {

        }

        private void Map(OutcomeOutput message)
        {
            IsEmpty = message.IsEmpty;
            Total = message.Total;
            ExpensesTotal = message.ExpensesTotal;
            Share = message.Share;

            Creditors = new ObservableCollection<GuestOutcomeViewModel>( 
                message.Creditors.Select(x => new  GuestOutcomeViewModel(this, x)).ToList());

            Debtors = new ObservableCollection<GuestOutcomeViewModel>(
                message.Debtors.Select(x => new GuestOutcomeViewModel(this, x)).ToList());

            Evens = new ObservableCollection<GuestOutcomeViewModel>(
                message.Evens.Select(x => new GuestOutcomeViewModel(this, x)).ToList());
        }

        #region Messages

        [Reader]
        public bool Read(OutcomeOutput message)
        {
            Map(message);
            return true;
        }

        #endregion

        #region Properties

        private bool _isEmpty;
        public bool IsEmpty
        {
            get
            {
                return _isEmpty;
            }
            set
            {
                _isEmpty = value;
                OnPropertyChanged("IsEmpty");
            }
        }

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

        private ObservableCollection<GuestOutcomeViewModel> _creditors;
        [Embedded]
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

        private ObservableCollection<GuestOutcomeViewModel> _debtors;
        [Embedded]
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

        private ObservableCollection<GuestOutcomeViewModel> _evens;
        [Embedded]
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
