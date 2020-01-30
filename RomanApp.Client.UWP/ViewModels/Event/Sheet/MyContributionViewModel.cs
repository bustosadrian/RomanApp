using RomanApp.Messages.Event.Input.Sheet;

namespace RomanApp.Client.UWP.ViewModels.Event.Sheet
{
    public class MyContributionViewModel : EmbeddedViewModel
    {

        public MyContributionViewModel(BaseViewModel parent)
            : base(parent)
        {

        }

        private void OnSubmit()
        {
            Send(new MyContributionInput()
            {
                Amount = Amount,
            });
        }

        #region Commands

        private DelegateCommand _submitCommand;
        public DelegateCommand SubmitCommand
        {
            get
            {
                if(_submitCommand == null)
                {
                    _submitCommand = new DelegateCommand(OnSubmit);
                }
                return _submitCommand;
            }
        }

        #endregion

        #region Properties

        private decimal _amount;
        public decimal Amount
        {
            get
            {
                return _amount;
            }
            zset
            {
                _amount = value;
                OnPropertyChanged("Amount");
            }
        }

        #endregion
    }
}
