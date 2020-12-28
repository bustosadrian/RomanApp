namespace RomanApp.Controller.Model.Event
{
    public class ExpenseModel : ItemModel
    {
        public ExpenseModel()
            : base()
        {

        }

        public ExpenseModel(RomanApp.Service.Entities.Expense entity)
            : this()
        {
            Map(entity);
        }

        public void Map(RomanApp.Service.Entities.Expense entity)
        {
            base.Map(entity);
        }

        #region Properties

        #endregion
    }
}
