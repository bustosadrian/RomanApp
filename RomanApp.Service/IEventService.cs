using RomanApp.Service.Entities;

namespace RomanApp.Service
{
    public interface IEventService
    {
        Event Create();

        Guest AddGuest(Event e, string name, decimal amount);

        Expense AddExpense(Event e, string label, decimal amount);

        Guest UpdateGuest(Event e, string id, string name, decimal amount);

        Expense UpdateExpense(Event e, string id, string name, decimal amount);

        bool RemoveGuest(Event e, string id);

        bool RemoveExpense(Event e, string id);

        Outcome Calculate(Event e, bool useWholeNumbers);
    }
}
