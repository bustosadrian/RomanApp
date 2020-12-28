using RomanApp.Service.Entities;

namespace RomanApp.Service
{
    public interface IEventService
    {
        Event Create();

        Guest AddGuest(string eventId, string id, string name, decimal amount);

        Expense AddExpense(string eventId, string id, string label, decimal amount);

        Guest UpdateGuest(string eventId, string id, string name, decimal amount);

        Expense UpdateExpense(string eventId, string id, string name, decimal amount);

        bool RemoveGuest(string eventId, string id);

        bool RemoveExpense(string eventId, string id);

        Outcome Calculate(string eventId, bool useWholeNumbers);
    }
}
