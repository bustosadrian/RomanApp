using Reedoo.NET.Controller;
using RomanApp.Core.Controller.Entities;

namespace RomanApp.Core.Controller
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
