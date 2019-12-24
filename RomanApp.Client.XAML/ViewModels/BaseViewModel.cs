using Reedoo.NET.Messages.Input;
using Reedoo.NET.XAML;
using System.ComponentModel;

namespace RomanApp.Client.XAML.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged, IViewModelBus
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

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
