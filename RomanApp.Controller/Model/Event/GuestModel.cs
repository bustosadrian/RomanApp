namespace RomanApp.Controller.Model.Event
{
    public class GuestModel : ItemModel
    {
        public GuestModel() 
            : base()
        { 

        }

        public GuestModel(RomanApp.Service.Entities.Guest entity)
            : this()
        {
            Map(entity);
        }

        public void Map(RomanApp.Service.Entities.Guest entity)
        {
            base.Map(entity);
        }

        #region Properties

        #endregion
    }
}
