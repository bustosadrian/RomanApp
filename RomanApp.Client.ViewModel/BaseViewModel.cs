using System.ComponentModel;
using System.Windows.Input;

namespace RomanApp.Client.ViewModel
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
     
        protected virtual void ChangeCanExecute(ICommand command)
        {

        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
