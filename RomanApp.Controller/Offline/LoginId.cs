using Reedoo.NET.Controller;

namespace RomanApp.Controller.Offline
{
    public class LoginId : TrespasserId
    {
        public LoginId(string name)
            : base()
        {
            Name = name;
        }

        #region Properties

        public string Name
        {
            get;
            private set;
        }

        public Share Share
        {
            get;
            set;
        }

        #endregion
    }
}
