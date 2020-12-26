using Reedoo.NET.Controller;
using RomanApp.Service;
using RomanApp.Service.Entities;

namespace RomanApp.Controller.MemberStates
{
    public abstract class BaseMemberState : MemberState
    {

        #region Locker

        protected RoomSettings RoomSettings
        {
            get
            {
                return RoomLocker.Get<RoomSettings>(LockerKeys.ROOM_SETTINGS);
            }
        }

        protected IEventService EventService
        {
            get
            {
                return RoomLocker.Get<IEventService>(LockerKeys.ROOM_EVENT_SERVICE);
            }
        }

        protected Event CurrentEvent
        {
            get
            {
                return RoomLocker.Get<Event>(LockerKeys.ROOM_CURRENT_EVENT);
            }
            set
            {
                RoomLocker.Add(LockerKeys.ROOM_CURRENT_EVENT, value);
            }
        }

        #endregion
    }
}
