using RomanApp.Messages.Output.Sheet.Outcome.Text;
using System.Collections.ObjectModel;

namespace RomanApp.Client.ViewModel.Sheet.Text
{
    public class EvensGroupViewModel : BaseViewModel
    {
        public EvensGroupViewModel(EvensGroupOutput message)
        {
            Evens = new ObservableCollection<string>(message.Evens);
        }


        #region Properties

        private ObservableCollection<string> _evens;
        public ObservableCollection<string> Evens
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
