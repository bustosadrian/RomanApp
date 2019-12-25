using Reedoo.NET.Controller;
using RomanApp.Controller.Entities;
using RomanApp.Controller.Offline.States;
using System;

namespace RomanApp.Controller.Offline
{
    public class RoomHandler : Reedoo.NET.Controller.RoomHandler
    {
        public const string LOCKER_BUDGET = "budget";

        public const string LOCKER_BUDGET_OUTCOME = "budget_outcome";

        public RoomHandler(IServiceProvider serviceProvider) 
            : base(serviceProvider)
        {

        }

        #region Overriden

        public override void OnBuild()
        {
            Locker.Add(LOCKER_BUDGET, new Budget());
        }

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
