using Reedoo.NET.Controller;
using RomanApp.Home.Controller.MemberStates.Menu;
using System;
using System.Collections.Generic;
using System.Text;

namespace RomanApp.Home.Controller.MemberStates.Help
{
    [ApplicationState(KEY)]
    public class HelpMemberState : HomeMemberState
    {
        private const string KEY = "RomanApp.Home.Help";

        public override void Brief()
        {

        }

        protected override void OnBack()
        {
            ChangeState(typeof(MenuMemberState));
        }
    }
}
