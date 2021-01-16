namespace RomanApp.Service.Entities
{
    public abstract class ItemOutcome
    {
        #region Properties

        public string Id
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public decimal Amount
        {
            get;
            set;
        }

        #endregion
    }
}
