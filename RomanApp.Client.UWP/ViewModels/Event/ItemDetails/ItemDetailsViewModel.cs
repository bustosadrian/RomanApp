using RomanApp.Messages.Event.Output.ItemDetails;

namespace RomanApp.Client.UWP.ViewModels.Event.ItemDetails
{
    public class ItemDetailsViewModel : EventViewModel
    {
        public void ReadDetails(ItemDetailsOutput message)
        {
            Id = message.EntityId;
            Label = message.Label;
            Amount = message.Amount;
            Description = message.Description;
        }

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

        private string _label;
        public string Label
        {
            get
            {
                return _label;
            }
            set
            {
                _label = value;
                OnPropertyChanged("Label");
            }
        }

        private decimal? _amount;
        public decimal? Amount
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

        private string _description;
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                OnPropertyChanged("Description");
            }
        }

        #endregion
    }
}
