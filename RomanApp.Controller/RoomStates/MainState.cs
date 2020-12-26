using Reedoo.NET.Controller;

namespace RomanApp.Controller.RoomStates
{
    public class MainState : BaseRoomState
    {
        public override void Brief(IMember member)
        {
            
        }

        public override void OnLoad()
        {
            CurrentEvent = EventService.Create();
            
            MockItems();
        }

        private void MockItems()
        {
            EventService.AddGuest(CurrentEvent, "Juan", 0);
            EventService.AddGuest(CurrentEvent, "Daniel", 0);
            EventService.AddGuest(CurrentEvent, "Mike", 1500);

            EventService.AddExpense(CurrentEvent, "Parrilla", 100);
            //EventService.AddExpense(CurrentEvent, "Cancha", 1500, null);
        }
    }
}
