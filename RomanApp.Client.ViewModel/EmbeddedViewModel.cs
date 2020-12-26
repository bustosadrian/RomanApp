using Reedoo.NET.Messages.Input;

namespace RomanApp.Client.ViewModel
{
    public abstract class EmbeddedViewModel : BaseViewModel
    {
        public EmbeddedViewModel(BusViewModel parent)
        {
            Parent = parent;
        }

        public EmbeddedViewModel(EmbeddedViewModel parent) 
            : this(parent.Parent)
        {

        }


        #region Overriden

        public void Send(InputMessage message)
        {
            Parent.Send(message);
        }

        #endregion

        #region Properties

        protected BusViewModel Parent
        {
            get;
            private set;
        }


        #endregion
    }
}
