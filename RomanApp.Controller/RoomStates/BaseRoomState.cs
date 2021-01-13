using Reedoo.NET.Controller;
using Reedoo.NET.Messages.Output;
using RomanApp.Controller.MemberStates;
using RomanApp.Controller.Model;
using RomanApp.Controller.Model.Event;
using RomanApp.Service;
using System;

namespace RomanApp.Controller.RoomStates
{
    public abstract class BaseRoomState : RoomState
    {
        public override AlienTicket OnJoined(Passport passport)
        {
            MemberTicket retval = null;

            IMember member = CreateMember(passport);
            retval = new MemberTicket(passport, member);

            return retval;
        }

        public override Type OnJoined(IMember member)
        {
            return typeof(SheetMemberState);
        }

        #region Room Locker

        public RoomSettingsModel RoomSettings
        {
            get
            {
                return RoomLocker.Get<RoomSettingsModel>(LockerKeys.ROOM_SETTINGS);
            }
        }

        public IEventService EventService
        {
            get
            {
                return RoomLocker.Get<IEventService>(LockerKeys.ROOM_EVENT_SERVICE);
            }
        }

        public EventModel CurrentEvent
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
