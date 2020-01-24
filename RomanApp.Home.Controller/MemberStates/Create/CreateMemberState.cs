using Reedoo.NET.Controller;
using RomanApp.Home.Controller.MemberStates.Menu;
using RomanApp.Messages.Home.Output;
using System;
using System.Collections.Generic;
using System.Text;

namespace RomanApp.Home.Controller.MemberStates.Create
{

    [ApplicationState(KEY)]
    public class CreateMemberState : HomeMemberState
    {
        private const string KEY = "RomanApp.Home.Create";

        public override void Brief()
        {
            Queue(new CreateEventSetup() {
                IsAccessEnabled = true,
            });
        }

        protected override void OnBack()
        {
            ChangeState(typeof(MenuMemberState));
        }
    }
}
