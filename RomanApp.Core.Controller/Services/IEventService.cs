using RomanApp.Core.Controller.Entities;

namespace RomanApp.Core.Controller.Services
{
    public interface IEventService
    {
        Event Create(string name);

        Guest AddGuest(Event e, string name, decimal amount, string description);

        Expense AddExpense(Event e, string label, decimal amount, string description);

        Share UpdateGuestShare(Event e, Guest guest, Share share);

        bool RemoveGuest(Event e, string id);

        bool RemoveExpense(Event e, string id);

        Outcome Calculate(Event e);
    }
}
