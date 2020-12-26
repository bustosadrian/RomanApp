using Reedoo.NET.Client.Messages;
using Reedoo.NET.Messages;
using RomanApp.Messages.Output.Sheet.Outcome;
using System.Collections.ObjectModel;
using System.Linq;

namespace RomanApp.Client.ViewModel.Sheet.Embeddeds
{
    public class OutcomeViewModel : EmbeddedViewModel
    {

        public OutcomeViewModel(BusViewModel parent)
            : base(parent)
        {

        }

        #region Messages

        [Reader]
        public bool Read(OutcomeSummaryOutput message)
        {
            Total = message.Total;
            TotalExpenses = message.TotalExpenses;
            Share = message.Share;
            return true;
        }

        [Reader]
        public bool Read(OutcomeGuestsOutput message)
        {
            Debtors = new ObservableCollection<OutcomeGuestViewModel>(message.Debtors.Select(x => new OutcomeGuestViewModel(x)));
            Creditors = new ObservableCollection<OutcomeGuestViewModel>(message.Creditors.Select(x => new OutcomeGuestViewModel(x)));
            Evens = new ObservableCollection<OutcomeGuestViewModel>(message.Evens.Select(x => new OutcomeGuestViewModel(x)));

            return true;
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
                OnPropertyChanged(nameof(Total));
            }
        }


        private decimal _totalExpesnes;
        public decimal TotalExpenses
        {
            get
            {
                return _totalExpesnes;
            }
            set
            {
                _totalExpesnes = value;
                OnPropertyChanged(nameof(TotalExpenses));
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
                OnPropertyChanged(nameof(Share));
            }
        }

        private ObservableCollection<OutcomeGuestViewModel> _debtors;
        [Embedded]
        public ObservableCollection<OutcomeGuestViewModel> Debtors
        {
            get
            {
                return _debtors;
            }
            set
            {
                _debtors = value;
                OnPropertyChanged(nameof(Debtors));
            }
        }

        private ObservableCollection<OutcomeGuestViewModel> _creditors;
        [Embedded]
        public ObservableCollection<OutcomeGuestViewModel> Creditors
        {
            get
            {
                return _creditors;
            }
            set
            {
                _creditors = value;
                OnPropertyChanged(nameof(Creditors));
            }
        }

        private ObservableCollection<OutcomeGuestViewModel> _evens;
        [Embedded]
        public ObservableCollection<OutcomeGuestViewModel> Evens
        {
            get
            {
                return _evens;
            }
            set
            {
                _evens = value;
                OnPropertyChanged(nameof(Evens));
            }
        }

        #endregion
    }
}
