using Reedoo.NET.Controller;
using RomanApp.Core.Controller.Services;
using System;

namespace RomanApp.Core.Controller
{
    public abstract class RomanAppRoomHandler : RoomHandler
    {
        public const string LOCKER_ROOM_EVENT_SERVICE = "event_service";

        public const string LOCKER_ROOM_CURRENT_EVENT = "current_event";

        public const string LOCKER_MEMBER_GUEST = "member_guest";

        public const string LOCKER_MEMBER_PROFILE = "member_profile";

        public RomanAppRoomHandler(IServiceProvider serviceProvider) 
            : base(serviceProvider)
        {
        }

        public override void OnStart()
        {
            Locker.Add(LOCKER_ROOM_EVENT_SERVICE, new EventService());
        }

        #region Room Locker

        public IEventService EventService
        {
            get
            {
                return Locker.Get<IEventService>(LOCKER_ROOM_EVENT_SERVICE);
            }
        }

        #endregion
    }
}
