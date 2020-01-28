using Reedoo.NET.Messages.Input;

namespace RomanApp.Client.UWP.ViewModels
{
    public abstract class EmbeddedViewModel : BaseViewModel
    {
        private BaseViewModel _parent;

        public EmbeddedViewModel(BaseViewModel parent)
        {
            _parent = parent;
        }

        #region Overriden

        public override void Send(InputMessage message)
        {
            _parent.Send(message);
        }

        #endregion
    }
}
