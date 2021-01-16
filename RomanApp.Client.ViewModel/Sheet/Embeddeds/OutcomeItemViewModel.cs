using RomanApp.Messages.Output.Sheet.Outcome;

namespace RomanApp.Client.ViewModel.Sheet.Embeddeds
{
    public class OutcomeItemViewModel : BaseViewModel
    {
        public OutcomeItemViewModel(OutcomeItemOutput message)
        {
            Load(message);
        }

        public void Load(OutcomeItemOutput outcomeGuestOutput)
        {
            Name = outcomeGuestOutput.Name;
            Amount = outcomeGuestOutput.Amount;
        }

        #region Messages


        #endregion

        #region Properties

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
