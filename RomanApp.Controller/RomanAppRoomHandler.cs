using Reedoo.NET.Controller;
using RomanApp.Controller.Model;
using RomanApp.Controller.RoomStates;
using RomanApp.Service;
using System;

namespace RomanApp.Controller
{
    public class RomanAppRoomHandler : RoomHandler
    {
        public RomanAppRoomHandler(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {

        }

        public override ActionResult Init()
        {
            ActionResult retval = null;

            retval = new ActionResult()
            {
                StateType = typeof(MainState),
            };

            return retval;
        }

        public override void OnStart()
        {
            Locker.Add(LockerKeys.ROOM_SETTINGS, new RoomSettingsModel()
            {
                UseWholeNumbers = true,
                UseNumericKeyboard = true,
            });

            Locker.Add(LockerKeys.ROOM_EVENT_SERVICE, new EventService());
        }

        #region Room Locker

        public RoomSettingsModel RoomSettings
        {
            get
            {
                return Locker.Get<RoomSettingsModel>(LockerKeys.ROOM_SETTINGS);
            }
        }

        public IEventService EventService
        {
            get
            {
                return Locker.Get<IEventService>(LockerKeys.ROOM_EVENT_SERVICE);
            }
        }

        #endregion
    }
}
