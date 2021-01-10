using Reedoo.NET.Messages;
using RomanApp.Messages.Input;
using RomanApp.Messages.Input.Settings;
using RomanApp.Messages.Output.Settings;
using System;
using System.Windows.Input;

namespace RomanApp.Client.ViewModel.Settings
{
    public abstract class BaseSettingsViewModel : BusViewModel
    {

        protected void OnBack()
        {
            Send(new BackInput());
        }

        private void SaveWholeNumbers()
        {
            try
            {
                Send(new SaveSettingsInput()
                {
                    UseWholeNumberSet = true,
                    UseWholeNumbers = IsUseWholeNumbers,
                });
            }
            catch (Exception e)
            {
                HandleError(e);
            }
        }

        #region Command

        public ICommand BackCommand
        {
            get;
            protected set;
        }

        #endregion


        #region Messages

        [Reader]
        public bool Read(SettingsOutput message)
        {
            _isUseWholeNumbers = message.UseWholeNumbers;
            OnPropertyChanged(nameof(IsUseWholeNumbers));

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
                bool changed = _isUseWholeNumbers != value;
                _isUseWholeNumbers = value;
                OnPropertyChanged(nameof(IsUseWholeNumbers));
                if (changed)
                {
                    SaveWholeNumbers();
                }
            }
        }

        #endregion
    }
}
