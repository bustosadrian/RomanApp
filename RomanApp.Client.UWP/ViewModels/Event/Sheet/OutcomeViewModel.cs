using Reedoo.NET.Messages;
using RomanApp.Messages.Event.Output.Sheet;

namespace RomanApp.Client.UWP.ViewModels.Event.Sheet
{
    public class OutcomeViewModel : EmbeddedViewModel
    {
        public OutcomeViewModel(BaseViewModel parent)
            : base(parent)
        {

        }

        private void Map(OutcomeOutput message)
        {
            Total = message.Total;
            ExpensesTotal = message.ExpensesTotal;
            Share = message.Share;
        }

        #region Messages

        [Reader]
        public bool Read(OutcomeOutput message)
        {
            Map(message);
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
                OnPropertyChanged("Total");
            }
        }

        private decimal _expensesTotal;
        public decimal ExpensesTotal
        {
            get
            {
                return _expensesTotal;
            }
            set
            {
                _expensesTotal = value;
                OnPropertyChanged("ExpensesTotal");
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
                OnPropertyChanged("Share");
            }
        }

        #endregion
    }
}
