using Reedoo.NET.Controller;
using System;
using System.Collections.Generic;
using System.Text;

namespace RomanApp.Core.Controller
{
    public abstract class RomanAppRoomHandler : RoomHandler
    {
        public RomanAppRoomHandler(IServiceProvider serviceProvider) 
            : base(serviceProvider)
        {
        }
    }
}
