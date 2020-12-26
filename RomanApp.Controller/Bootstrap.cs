using Microsoft.Extensions.DependencyInjection;
using Reedoo.NET.Controller.Builder;
using Reedoo.NET.Controller.Extensions.Binding.Local;
using RomanApp.Messages.Input;

namespace RomanApp.Controller
{
    public class Bootstrap
    {
        public const string ROOM_ID = "Local";

        public IHandlerBuilder GetBuilder(ServiceProvider serviceProvider)
        {
            IHandlerBuilder retval = null;

            retval = serviceProvider.GetService<IHandlerBuilder>();
            retval.EnableLocalBinding(true)
                .Set();

            retval.NewApp("RomanApp")
                .AddAssembly(GetType().Assembly)
                .AddAssembly(typeof(BackInput).Assembly)
                .NewRoomDefinition(EventType.Offline).SetHandlerType(typeof(RomanAppRoomHandler)).Add()
                .NewRoom().SetId(ROOM_ID).SetRoomType(EventType.Offline).SetName(ROOM_ID).Add()

                .Add();

            return retval;
        }
    }
}
