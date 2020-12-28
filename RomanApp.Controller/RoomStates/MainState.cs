using Reedoo.NET.Controller;
using RomanApp.Controller.Model.Event;

namespace RomanApp.Controller.RoomStates
{
    public class MainState : BaseRoomState
    {
        public override void Brief(IMember member)
        {
            
        }

        public override void OnLoad()
        {
            CurrentEvent = new EventModel(EventService.Create());
        }

        public override void OnRestore()
        {
            base.OnRestore();

            EventService.Create();
            PopulateCurrentEvent();
        }

        private void PopulateCurrentEvent() 
        { 
            foreach(var o in CurrentEvent.Guests)
            {
                EventService.AddGuest(CurrentEvent.Id, o.Id, o.Name, o.Amount);
            }

            foreach (var o in CurrentEvent.Expenses)
            {
                EventService.AddExpense(CurrentEvent.Id, o.Id, o.Name, o.Amount);
            }
        }
    }
}
