namespace RomanApp.Core.Controller.Entities
{
    public class Share : BaseEntity
    {
        #region Properties

        public decimal Amount
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        #endregion
    }
}
