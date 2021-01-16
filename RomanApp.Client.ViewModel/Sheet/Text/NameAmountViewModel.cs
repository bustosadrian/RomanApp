using RomanApp.Messages.Output.Sheet.Outcome.Text;

namespace RomanApp.Client.ViewModel.Sheet.Text
{
    public class NameAmountViewModel : BaseViewModel
    {
        public NameAmountViewModel(NameAmountOutput message)
        {
            Name = message.Name;
            Value1 = message.Value1;
            Value2 = message.Value2;
        }

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

        private decimal _value1;
        public decimal Value1
        {
            get
            {
                return _value1;
            }
            set
            {
                _value1 = value;
                OnPropertyChanged(nameof(Value1));
            }
        }

        private decimal _value2;
        public decimal Value2
        {
            get
            {
                return _value2;
            }
            set
            {
                _value2 = value;
                OnPropertyChanged(nameof(Value2));
            }
        }

        #endregion
    }
}
