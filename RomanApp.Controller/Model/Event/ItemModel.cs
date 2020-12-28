namespace RomanApp.Controller.Model.Event
{
    public abstract class ItemModel : EntityModel
    {
        public ItemModel()
            : base ()
        {

        }

        public ItemModel(RomanApp.Service.Entities.Item entity)
            : this()
        {
            Map(entity);
        }

        public void Map(RomanApp.Service.Entities.Item entity)
        {
            base.Map(entity);
            Name = entity.Name;
            Amount = entity.Amount;
        }

        #region Properties

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private decimal _amount;
        public decimal Amount
        {
            get
            {
                return _amount;
            }
            set
            {
                _amount = value;
                OnPropertyChanged(nameof(Amount));
            }
        }

        #endregion
    }
}
