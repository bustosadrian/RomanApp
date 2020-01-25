using RomanApp.Messages.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanApp.Client.UWP.ViewModels.Event
{
    public abstract class EventViewModel : BaseViewModel
    {
        protected void GoBack()
        {
            Send(new BackInput());
        }

        #region Commands

        private DelegateCommand _backCommand;
        public DelegateCommand BackCommand
        {
            get
            {
                if (_backCommand == null)
                {
                    _backCommand = new DelegateCommand(GoBack);
                }
                return _backCommand;
            }
        }

        #endregion

    }
}
