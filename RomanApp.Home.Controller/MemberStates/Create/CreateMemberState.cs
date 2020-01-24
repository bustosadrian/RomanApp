﻿using Reedoo.NET.Controller;
using Reedoo.NET.Messages;
using RomanApp.Core.Controller.Entities;
using RomanApp.Home.Controller.MemberStates.Menu;
using RomanApp.Messages.Home.Input;
using RomanApp.Messages.Home.Output;

namespace RomanApp.Home.Controller.MemberStates.Create
{

    [ApplicationState(KEY)]
    public class CreateMemberState : HomeMemberState
    {
        private const string KEY = "RomanApp.Home.Create";

        public override void Brief()
        {
            Queue(new CreateEventBriefingOutput() {
                IsAccessEnabled = false,
            });
        }

        protected override void OnBack()
        {
            ChangeState(typeof(MenuMemberState));
        }

        private void CreateEvent(CreateEventFormInput form)
        {
            Event e = EventService.Create(form.Name);
            CurrentEvent = e;
        }

        #region Messages

        [Reader]
        public void Read(CreateEventFormInput message)
        {
            CreateEvent(message);
        }

        #endregion
    }
}
