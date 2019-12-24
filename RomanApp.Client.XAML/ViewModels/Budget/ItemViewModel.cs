using RomanApp.Client.XAML.ViewModels;

namespace RomanApp.Client.XAML.ViewModels.Budget
{
    public abstract class ItemViewModel : BaseViewModel
    {
        #region Properties

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

        #endregion
    }
}
