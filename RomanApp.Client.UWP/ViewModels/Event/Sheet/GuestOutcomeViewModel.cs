using Reedoo.NET.Messages;
using RomanApp.Messages.Event.Output.Sheet;

namespace RomanApp.Client.UWP.ViewModels.Event.Sheet
{
    public class GuestOutcomeViewModel : EmbeddedViewModel
    {
        public GuestOutcomeViewModel(BaseViewModel parent, 
            GuestOutcomeOutput message) 
            : base(parent)
        {
            Map(message);
        }

        private void Map(GuestOutcomeOutput message)
        {
            Name = message.Name;
            Amount = message.Amount;
            Debt = message.Debt;
        }

        #region Properties

        [Reader]
        public bool Read(GuestOutcomeOutput message)
        {
            bool retval = false;

            if (Id.Equals(message.Id))
            {
                Map(message);
                retval = true;
            }

            return retval;
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
                OnPropertyChanged("Id");
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
                OnPropertyChanged("Name");
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
                OnPropertyChanged("Amount");
            }
        }

        private decimal _debt;
        public decimal Debt
        {
            get
            {
                return _debt;
            }
            set
            {
                _debt = value;
                OnPropertyChanged("Debt");
            }
        }

        #endregion
    }
}
