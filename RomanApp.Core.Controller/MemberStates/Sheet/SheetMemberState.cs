using Reedoo.NET.Controller;
using Reedoo.NET.Messages;
using RomanApp.Core.Controller.Entities;
using RomanApp.Messages.Event.Input.Sheet;
using RomanApp.Messages.Event.Output;
using RomanApp.Messages.Event.Output.Sheet;
using System.Linq;

namespace RomanApp.Core.Controller.MemberStates.Sheet
{

    [ApplicationState(KEY)]
    public class SheetMemberState : EventMemberState
    {
        private const string KEY = "RomanApp.Event.Sheet";

        public override void Brief()
        {
            QueueBriefing();
        }

        protected override void OnBack()
        {
            RomanAppRoomState.OnExit(Member);
        }

        #region Messages

        [Reader]
        public void Read(AddGuestInput message)
        {
            Guest entity = EventService.AddGuest(
                CurrentEvent, message.Label, 
                message.Amount, 
                message.Description);

            QueueGuest(entity);
        }

        [Reader]
        public void Read(AddExpenseInput message)
        {
            Expense entity = EventService.AddExpense(
                CurrentEvent, message.Label,
                message.Amount,
                message.Description);

            QueueExpense(entity);
        }

        #endregion

        #region Queue

        private void QueueBriefing()
        {
            SheetBriefingOutput briefing = new SheetBriefingOutput()
            {
                EventName = CurrentEvent.Name,
                Guests = CurrentEvent.Guests.Select(x => Map(x)).ToList(),
                Expenses = CurrentEvent.Expenses.Select(x => Map(x)).ToList(),
            };
            Queue(briefing);
        }

        private void QueueGuest(Guest entity)
        {
            GuestOutput output = new GuestOutput()
            {
                Id = entity.Id,
                Name = entity.Name,
                Share = new ShareOutput()
                {
                    Id = entity.Share.Id,
                    Amount = entity.Share.Amount,
                    Description = entity.Share.Description,
                },
            };
            Queue(output);
        }

        private void QueueExpense(Expense entity)
        {
            ExpenseOutput output = new ExpenseOutput()
            {
                Id = entity.Id,
                Label = entity.Label,
                Share = new ShareOutput()
                {
                    Id = entity.Share.Id,
                    Amount = entity.Share.Amount,
                    Description = entity.Share.Description,
                },
            };
            Queue(output);
        }


        #endregion

        #region Mapping

        private GuestOutput Map(Guest entity)
        {
            GuestOutput retval = null;

            retval = new GuestOutput()
            {
                Id = entity.Id,
                Name = entity.Name,
                Share = Map(entity.Share),
            };

            return retval;
        }

        private ExpenseOutput Map(Expense entity)
        {
            ExpenseOutput retval = null;

            retval = new ExpenseOutput()
            {
                Id = entity.Id,
                Label = entity.Label,
                Share = Map(entity.Share),
            };

            return retval;
        }

        #endregion
    }
}
