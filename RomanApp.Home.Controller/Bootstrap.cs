using Microsoft.Extensions.DependencyInjection;
using Reedoo.NET.Controller.Builder;
using Reedoo.NET.Controller.Extensions.Binding.Local;
using RomanApp.Core.Controller;
using RomanApp.Messages.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace RomanApp.Home.Controller
{
    public class Bootstrap
    {
        public IHandlerBuilder GetBuilder(ServiceProvider serviceProvider)
        {
            IHandlerBuilder retval = null;

            retval = serviceProvider.GetService<IHandlerBuilder>();
            retval.EnableLocalBinding(true).Set();

            retval.NewApp("RomanApp")
                .AddAssembly(GetType().Assembly)
                .AddAssembly(typeof(BackInput).Assembly)
                .NewRoomDefinition(RoomType.Home).SetHandlerType(typeof(HomeRoomHandler)).Add()
                .NewRoom().SetId("Home").SetRoomType(RoomType.Home).SetName("Home").Add()
                .Add();

            return retval;
        }

    }
}
