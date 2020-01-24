namespace RomanApp.Core.Controller.Entities
{
    public class Expense : BaseEntity
    {
        #region Properties

        public string Label
        {
            get;
            set;
        }

        public Share Share
        {
            get;
            set;
        }

        #endregion
    }
}
