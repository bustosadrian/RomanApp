using Reedoo.NET.Messages.Input;
using Reedoo.NET.XAML;
using RomanApp.Messages.Input;
using System;

namespace RomanApp.Client.ViewModel
{
    public abstract class BusViewModel : BaseViewModel, IViewModelBus
    {
        public virtual void Send(InputMessage message)
        {
            Bus.Send(message);
        }

        public void GoBack()
        {
            Send(new BackInput());
        }

        protected void HandleError(Exception e)
        {
            Bus.HandleError(e);
        }

        #region Bus
        public Bus Bus
        {
            get;
            set;
        }

        #endregion
    }
}
