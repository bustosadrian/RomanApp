using Reedoo.NET.Messages;
using RomanApp.Messages.Input.Settings;
using RomanApp.Messages.Output.Settings;
using System;

namespace RomanApp.Client.ViewModel.Settings
{
    public abstract class BaseSettingsViewModel : BasicViewModel
    {
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

        private void SaveNumericKeyboard()
        {
            try
            {
                Send(new SaveSettingsInput()
                {
                    UseNumericKeyboardSet = true,
                    UseNumericKeyboard = IsUseNumericKeyboard,
                });
            }
            catch (Exception e)
            {
                HandleError(e);
            }
        }

        #region Command

        #endregion


        #region Messages

        [Reader]
        public bool Read(SettingsOutput message)
        {
            _isUseWholeNumbers = message.UseWholeNumbers;
            OnPropertyChanged(nameof(IsUseWholeNumbers));

            _isUseNumericKeyboard = message.UseNumericKeyboard;
            OnPropertyChanged(nameof(IsUseNumericKeyboard));

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


        private bool _isUseNumericKeyboard;
        public bool IsUseNumericKeyboard
        {
            get
            {
                return _isUseNumericKeyboard;
            }
            set
            {
                bool changed = _isUseNumericKeyboard != value;
                _isUseNumericKeyboard = value;
                OnPropertyChanged(nameof(IsUseNumericKeyboard));
                if (changed)
                {
                    SaveNumericKeyboard();
                }
            }
        }

        #endregion
    }
}
