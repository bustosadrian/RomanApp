using RomanApp.Core.Controller.Entities;

namespace RomanApp.Core.Controller.Service
{
    public interface IEventService
    {
        Event Create(string name);

        Guest AddGuest(Event e, string name, decimal amount, string description);

        Expense AddExpense(Event e, string label, decimal amount, string description);

        bool RemoveGuest(Event e, string id);

        bool RemoveExpense(Event e, string id);

    }
}
