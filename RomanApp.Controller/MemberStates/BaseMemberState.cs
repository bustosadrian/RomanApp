using Reedoo.NET.Controller;
using RomanApp.Controller.Model;
using RomanApp.Controller.Model.Event;
using RomanApp.Service;

namespace RomanApp.Controller.MemberStates
{
    public abstract class BaseMemberState : MemberState
    {

        #region Locker

        protected RoomSettingsModel RoomSettings
        {
            get
            {
                return RoomLocker.Get<RoomSettingsModel>(LockerKeys.ROOM_SETTINGS);
            }
        }

        protected IEventService EventService
        {
            get
            {
                return RoomLocker.Get<IEventService>(LockerKeys.ROOM_EVENT_SERVICE);
            }
        }

        protected EventModel CurrentEvent
        {
            get
            {
                return RoomLocker.Get<EventModel>(LockerKeys.ROOM_CURRENT_EVENT);
            }
            set
            {
                RoomLocker.Add(LockerKeys.ROOM_CURRENT_EVENT, value);
            }
        }

        #endregion
    }
}
