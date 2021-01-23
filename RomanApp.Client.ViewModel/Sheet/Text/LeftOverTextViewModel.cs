using RomanApp.Messages.Output.Sheet.Outcome.Text;
using System;

namespace RomanApp.Client.ViewModel.Sheet.Text
{
    public class LeftOverTextViewModel : BaseViewModel
    {
        public LeftOverTextViewModel(LeftOverGroupOutput message)
        {
            LeftOver = message.LeftOver;
            AbsLeftOver = Math.Abs(LeftOver);
        }

        #region Properties

        private decimal _leftOver;
        public decimal LeftOver
        {
            get
            {
                return _leftOver;
            }
            set
            {
                _leftOver = value;
                OnPropertyChanged(nameof(LeftOver));
            }
        }

        private decimal _absLeftOver;
        public decimal AbsLeftOver
        {
            get
            {
                return _absLeftOver;
            }
            set
            {
                _absLeftOver = value;
                OnPropertyChanged(nameof(AbsLeftOver));
            }
        }

        #endregion
    }
}
