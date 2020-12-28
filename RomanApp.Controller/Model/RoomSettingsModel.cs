namespace RomanApp.Controller.Model
{
    public class RoomSettingsModel : BaseModel
    {

        #region Properties

        private bool _useWholeNumbers;
        public bool UseWholeNumbers
        {
            get
            {
                return _useWholeNumbers;
            }
            set
            {
                _useWholeNumbers = value;
                OnPropertyChanged(nameof(UseWholeNumbers));
            }
        }

        #endregion
    }
}
