using RomanApp.Messages.Output.Sheet.Outcome;

namespace RomanApp.Client.ViewModel.Sheet.Embeddeds
{
    public class OutcomeGuestViewModel : BaseViewModel
    {
        public OutcomeGuestViewModel(OutcomeGuestOutput message)
        {
            Load(message);
        }

        public void Load(OutcomeGuestOutput outcomeGuestOutput)
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
