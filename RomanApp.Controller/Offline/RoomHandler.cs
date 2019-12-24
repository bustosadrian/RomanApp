using Reedoo.NET.Controller;
using RomanApp.Controller.Offline.States;
using System;

namespace RomanApp.Controller.Offline
{
    public class RoomHandler : Reedoo.NET.Controller.RoomHandler
    {
        public RoomHandler(IServiceProvider serviceProvider) 
            : base(serviceProvider)
        {

        }

        #region Overriden

        public override ActionResult Init()
        {
            ActionResult retval = null;

            retval = new ActionResult()
            {
                StateType = typeof(EventState),
            };

            return retval;
        }
    
        #endregion
    }
}
