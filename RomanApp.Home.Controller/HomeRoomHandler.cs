using System;
using Reedoo.NET.Controller;
using RomanApp.Core.Controller;
using RomanApp.Home.Controller.RoomStates;

namespace RomanApp.Home.Controller
{
    public class HomeRoomHandler : RomanAppRoomHandler
    {
        public HomeRoomHandler(IServiceProvider serviceProvider) 
            : base(serviceProvider)
        {

        }

        public override ActionResult Init()
        {
            ActionResult retval = null;

            retval = new ActionResult()
            {
                StateType = typeof(HomeState),
            };

            return retval;
        }
    }
}
