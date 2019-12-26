using Reedoo.NET.Messages;
using Reedoo.NET.Messages.Input;
using Reedoo.NET.Messages.Output;
using Reedoo.NET.Messages.Output.Validation;
using Reedoo.NET.XAML;
using RomanApp.Messages.Output;
using System.ComponentModel;
using System.Text;

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

        #region Messages

        [Reader]
        public bool Read(ValidationErrors message)
        {
            ValidationErrors = message;
            return true;
        }

        [Reader]
        public bool Read(ProfileMessage message)
        {
            UserProfile = new UserProfileViewModel()
            {
                Name = message.Name,
            };
            return true;
        }

        #endregion

        #region Properties

        private ValidationErrors _validationErrors;
        public ValidationErrors ValidationErrors
        {
            get
            {
                return _validationErrors;
            }
            set
            {
                _validationErrors = value;
                OnPropertyChanged("ValidationErrors");
            }
        }

        private UserProfileViewModel _userProfile;
        public UserProfileViewModel UserProfile
        {
            get
            {
                return _userProfile;
            }
            set
            {
                _userProfile = value;
                OnPropertyChanged("UserProfile");
            }
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
