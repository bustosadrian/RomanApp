using Reedoo.NET.Messages.Input;
using Reedoo.NET.XAML;

namespace RomanApp.Client.ViewModel
{
    public abstract class BusViewModel : BaseViewModel, IViewModelBus
    {
        public virtual void Send(InputMessage message)
        {
            Bus.Send(message);
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
