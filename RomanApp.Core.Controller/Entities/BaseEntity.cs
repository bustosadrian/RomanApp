namespace RomanApp.Core.Controller.Entities
{
    public abstract class BaseEntity
    {
        public override bool Equals(object obj)
        {
            if(obj != null && GetType().Equals(obj.GetType()))
            {
                return Id == ((BaseEntity)obj).Id;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return Id != null ? Id.GetHashCode() : base.GetHashCode();
        }

        #region Properties

        public string Id
        {
            get;
            set;
        }

        #endregion
    }
}
