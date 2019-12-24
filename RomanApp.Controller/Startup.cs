using Microsoft.Extensions.DependencyInjection;
using Reedoo.NET.Controller.Builder;
using Reedoo.NET.Controller.Extensions.Binding.Local;
using RomanApp.Controller.Offline;
using RomanApp.Messages.Output;

namespace RomanApp.Controller
{
    public class Startup
    {
        public IHandlerBuilder GetBuilder(ServiceProvider serviceProvider)
        {
            IHandlerBuilder retval = null;

            retval = serviceProvider.GetService<IHandlerBuilder>();
            retval.EnableLocalBinding(true)
                //.JsonSerializer().Add()
                .Set();
            //retval.EnableTCPBinding()
            //    .Listen(8980)
            //    .JsonSerializer().Add()
            //    .Set();

            retval.NewApp("RomanApp")
                .AddAssembly(GetType().Assembly)
                .AddAssembly(typeof(GuestMessage).Assembly)
                .NewRoomDefinition(EventType.Offline).SetHandlerType(typeof(RoomHandler)).Add()
                .NewRoom().SetId("Room1").SetRoomType(EventType.Offline).SetName("Room 1").Add()

                .Add();

            return retval;
        }
    }
}
