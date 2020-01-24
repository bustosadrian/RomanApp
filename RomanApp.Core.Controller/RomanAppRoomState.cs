using Reedoo.NET.Controller;
using RomanApp.Core.Controller.Entities;
using RomanApp.Core.Controller.Service;

namespace RomanApp.Core.Controller
{
    public abstract class RomanAppRoomState : RoomState
    {

        #region Room Locker

        public IEventService EventService
        {
            get
            {
                return RoomLocker.Get<IEventService>(RomanAppRoomHandler.LOCKER_ROOM_EVENT_SERVICE);
            }
        }

        public Event CurrentEvent
        {
            get
            {
                return RoomLocker.Get<Event>(RomanAppRoomHandler.LOCKER_ROOM_CURRENT_EVENT);
            }
            set
            {
                RoomLocker.Add(RomanAppRoomHandler.LOCKER_ROOM_CURRENT_EVENT, value);
            }
        }

        #endregion

    }
}
