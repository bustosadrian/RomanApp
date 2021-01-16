using RomanApp.Messages.Output.Sheet.Outcome.Text;
using System;
using System.Collections.Generic;
using System.Text;

namespace RomanApp.Client.ViewModel.Sheet.Text
{
    public class ShareGroupViewModel : BaseViewModel
    {
        public ShareGroupViewModel(ShareGroupOutput message)
        {
            GuestsCount = message.GuestsCount;
            Share = message.Share;

            NotEveryOneOwesFullShare = true;
            if (message.HasNoDebtors && message.HasPartialDebtors)
            {
                Situation = GuestsSituation.CreditorsAndPartialDebtors;
            } 
            else if (message.HasPartialDebtors)
            {
                Situation = GuestsSituation.PartialDebtors;
            }
            else if (message.HasNoDebtors)
            {
                Situation = GuestsSituation.NoCreditors;
            }
            else
            {
                NotEveryOneOwesFullShare = false;
            }
        }

        #region Properties

        private int _guestsCount;
        public int GuestsCount
        {
            get
            {
                return _guestsCount;
            }
            set
            {
                _guestsCount = value;
                OnPropertyChanged(nameof(GuestsCount));
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
                OnPropertyChanged(nameof(Share));
            }
        }

        private GuestsSituation _situation;
        public GuestsSituation Situation
        {
            get
            {
                return _situation;
            }
            set
            {
                _situation = value;
                OnPropertyChanged(nameof(Situation));
            }
        }

        private bool _notEveryOneOwesFullShare;
        public bool NotEveryOneOwesFullShare
        {
            get
            {
                return _notEveryOneOwesFullShare;
            }
            set
            {
                _notEveryOneOwesFullShare = value;
                OnPropertyChanged(nameof(NotEveryOneOwesFullShare));
            }
        }

        #endregion
    }

    public enum GuestsSituation
    {
        CreditorsAndPartialDebtors,
        PartialDebtors,
        NoCreditors,
    }
}
