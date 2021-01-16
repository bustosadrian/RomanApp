using RomanApp.Messages.Output.Sheet.Outcome.Text;
using System.Collections.ObjectModel;
using System.Linq;

namespace RomanApp.Client.ViewModel.Sheet.Text
{
    public class DebtorsGroupViewModel : BaseViewModel
    {
        public DebtorsGroupViewModel(DebtorsGroupOutput message) 
        {
            Share = message.Share;

            FullDebtors = new ObservableCollection<string>(message.FullDebtors);

            PartialDebtors = new ObservableCollection<NameAmountViewModel>(
                message.PartialDebtors.Select(x => new NameAmountViewModel(x)));

            if(FullDebtors.Any())
            {
                HasFullDebtors = true;
                if (FullDebtors.Count() == 1)
                {
                    IsSingleFullDebtor = true;
                    SingleFullDebtor = FullDebtors.Single();
                }
            }

            if (PartialDebtors.Any())
            {
                HasPartialDebtors = true;
                if (PartialDebtors.Count() == 1)
                {
                    IsSinglePartialDebtor = true;
                    SinglePartialDebtor = PartialDebtors.Single();
                }
            }
        }

        #region Properties

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

        private bool _hasFullDebtors;
        public bool HasFullDebtors
        {
            get
            {
                return _hasFullDebtors;
            }
            set
            {
                _hasFullDebtors = value;
                OnPropertyChanged(nameof(HasFullDebtors));
            }
        }

        private bool _hasPartialDebtors;
        public bool HasPartialDebtors
        {
            get
            {
                return _hasPartialDebtors;
            }
            set
            {
                _hasPartialDebtors = value;
                OnPropertyChanged(nameof(HasPartialDebtors));
            }
        }

        private ObservableCollection<string> _fullDebtors;
        public ObservableCollection<string> FullDebtors
        {
            get
            {
                return _fullDebtors;
            }
            set
            {
                _fullDebtors = value;
                OnPropertyChanged(nameof(FullDebtors));
            }
        }

        private ObservableCollection<NameAmountViewModel> _partialDebtors;
        public ObservableCollection<NameAmountViewModel> PartialDebtors
        {
            get
            {
                return _partialDebtors;
            }
            set
            {
                _partialDebtors = value;
                OnPropertyChanged(nameof(PartialDebtors));
            }
        }

        private bool _isSingleFullDebtor;
        public bool IsSingleFullDebtor
        {
            get
            {
                return _isSingleFullDebtor;
            }
            set
            {
                _isSingleFullDebtor = value;
                OnPropertyChanged(nameof(IsSingleFullDebtor));
            }
        }

        private bool _isSinglePartialDebtor;
        public bool IsSinglePartialDebtor
        {
            get
            {
                return _isSinglePartialDebtor;
            }
            set
            {
                _isSinglePartialDebtor = value;
                OnPropertyChanged(nameof(IsSinglePartialDebtor));
            }
        }

        private string _singleFullDebtor;
        public string SingleFullDebtor
        {
            get
            {
                return _singleFullDebtor;
            }
            set
            {
                _singleFullDebtor = value;
                OnPropertyChanged(nameof(SingleFullDebtor));
            }
        }


        private NameAmountViewModel _singlePartialDebtor;
        public NameAmountViewModel SinglePartialDebtor
        {
            get
            {
                return _singlePartialDebtor;
            }
            set
            {
                _singlePartialDebtor = value;
                OnPropertyChanged(nameof(SinglePartialDebtor));
            }
        }

        #endregion
    }
}
