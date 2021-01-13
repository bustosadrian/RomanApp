using RomanApp.Messages.Input;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace RomanApp.Client.ViewModel
{
    public abstract class BasicViewModel : BusViewModel
    {

        #region Command Methods

        protected void OnGetHelp()
        {
            try
            {
                Send(new GetHelpInput());
            }
            catch (Exception e)
            {
                HandleError(e);
            }
        }

        #endregion

        #region Commands

        public ICommand GetHelpCommand
        {
            get;
            protected set;
        }

        #endregion

    }
}
