using Reedoo.NET.Controller;
using RomanApp.Home.Controller.MemberStates.Menu;
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

        }

        protected override void OnBack()
        {
            ChangeState(typeof(MenuMemberState));
        }
    }
}
