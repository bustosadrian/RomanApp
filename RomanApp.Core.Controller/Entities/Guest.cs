using Reedoo.NET.Controller;

namespace RomanApp.Core.Controller.Entities
{
    public class Guest : BaseEntity
    {
        #region Properties

        public string Name
        {
            get;
            set;
        }

        public Share Share
        {
            get;
            set;
        }

        public IMember Member
        {
            get;
            set;
        }

        #endregion
    }
}
