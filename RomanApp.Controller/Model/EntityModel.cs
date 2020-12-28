namespace RomanApp.Controller.Model
{
    public abstract class EntityModel : BaseModel
    {
        public EntityModel()
        {

        }

        public EntityModel(RomanApp.Service.Entities.BaseEntity entity)
            : this ()
        {
            Map(entity);
        }

        public void Map(RomanApp.Service.Entities.BaseEntity entity)
        {
            Id = entity.Id;
        }

        #region Properties

        private string _id;
        public string Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        #endregion
    }
}
