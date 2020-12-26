using Reedoo.NET.Messages;
using RomanApp.Messages.Input;
using RomanApp.Messages.Input.Settings;
using RomanApp.Messages.Output.Settings;
using System.Windows.Input;

namespace RomanApp.Client.ViewModel.Settings
{
    public abstract class BaseSettingsViewModel : BusViewModel
    {

        protected void OnBack()
        {
            Send(new BackInput());
        }

        protected void OnSave()
        {
            Send(new SaveSettingsInput()
            {
                UseWholeNumbers = IsUseWholeNumbers,
            });
        }

        #region Command

        public ICommand BackCommand
        {
            get;
            protected set;
        }

        public ICommand SaveCommand
        {
            get;
            protected set;
        }

        #endregion


        #region Messages

        [Reader]
        public bool Read(SettingsOutput message)
        {
            IsUseWholeNumbers = message.UseWholeNumbers;

            return true;
        }

        #endregion

        #region Properties

        private bool _isUseWholeNumbers;
        public bool IsUseWholeNumbers
        {
            get
            {
                return _isUseWholeNumbers;
            }
            set
            {
                _isUseWholeNumbers = value;
                OnPropertyChanged(nameof(IsUseWholeNumbers));
            }
        }

        #endregion
    }
}
