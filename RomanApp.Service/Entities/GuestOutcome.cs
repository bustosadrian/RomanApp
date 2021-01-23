namespace RomanApp.Service.Entities
{
    public class GuestOutcome : ItemOutcome
    {

        #region Properties

        public decimal Debt
        {
            get;
            set;
        }

        public GuestDebtorStatus DebtorStatus
        {
            get;
            set;
        }

        #endregion
    }
}
