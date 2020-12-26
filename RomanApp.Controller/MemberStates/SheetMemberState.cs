using Reedoo.NET.Controller;
using Reedoo.NET.Messages;
using RomanApp.Messages;
using RomanApp.Messages.Input;
using RomanApp.Messages.Input.Sheet;
using RomanApp.Messages.Output.Sheet;
using RomanApp.Messages.Output.Sheet.Outcome;
using RomanApp.Service.Entities;
using System;
using System.Linq;

namespace RomanApp.Controller.MemberStates
{
    [ApplicationState(KEY)]
    public class SheetMemberState : BaseMemberState
    {
        private const string KEY = "RomanApp.Sheet";

        private Outcome _outcome;

        public override void OnLoad()
        {
            base.OnLoad();

            CalculateOutcome();
        }

        public override void Brief()
        {
            QueueClearAll();
            QueueGuests();
            QueueExpenses();
            QueueOutcomeSummary();
            QueueOutcomeGuests();
        }

        private void CalculateOutcome()
        {
            _outcome = EventService.Calculate(CurrentEvent, RoomSettings.UseWholeNumbers);
        }

        #region Queues

        private void QueueClearAll()
        {
            QueueClearGuests();
            QueueClearExpenses();
        }

        private void QueueClearGuests()
        {
            Queue(new ClearGuestsOutput());
        }

        private void QueueClearExpenses()
        {
            Queue(new ClearExpensesOutput());
        }



        private void QueueGuests()
        {
            foreach (var o in CurrentEvent.Guests)
            {
                Queue(ToItemOutput(o, ItemType.Guest));
            }
        }
        private void QueueExpenses()
        {
            foreach (var o in CurrentEvent.Expenses)
            {
                Queue(ToItemOutput(o, ItemType.Expense));
            }
        }

        private void QueueOutcomeSummary()
        {
            Queue(new OutcomeSummaryOutput()
            {
                Total = _outcome.Total,
                TotalExpenses = _outcome.TotalExpenses,
                Share = _outcome.Share,
            });
        }

        private void QueueOutcomeGuests()
        {
            OutcomeGuestsOutput list = new OutcomeGuestsOutput();
            list.Debtors = _outcome.Debtors.Select(x => ToOutcomeGuestOutput(x)).ToList();
            list.Creditors = _outcome.Creditors.Select(x => ToOutcomeGuestOutput(x)).ToList();
            list.Evens = _outcome.Evens.Select(x => ToOutcomeGuestOutput(x)).ToList();
            Queue(list);
        }

        #endregion
               
        #region Mappers

        private ItemOutput ToItemOutput(Item entity, ItemType type)
        {
            ItemOutput retval = null;

            retval = new ItemOutput()
            {
                Id = entity.Id,
                Type = type,
                Name = entity.Name,
                Amount = entity.Share.Amount,
            };

            return retval;
        }

        private OutcomeGuestOutput ToOutcomeGuestOutput(GuestOutcome entity)
        {
            OutcomeGuestOutput retval = null;

            retval = new OutcomeGuestOutput()
            {
                Name = entity.Name,
                Amount = Math.Abs(entity.Debt),
            };

            return retval;
        }


        #endregion

        #region Messages

        [Reader]
        public void Action(GoToSettingsInput message)
        {
            ChangeState(typeof(SettingsMemberState));
        }

        [Reader]
        public void Action(AddItemInput message)
        {
            Item item = null;
            switch (message.Type)
            {
                case ItemType.Guest:
                    item = EventService.AddGuest(CurrentEvent, message.Name, message.Amount);
                    break;
                case ItemType.Expense:
                    item = EventService.AddExpense(CurrentEvent, message.Name, message.Amount);
                    break;
            }
            CalculateOutcome();
            Queue(ToItemOutput(item, message.Type));
            QueueOutcomeSummary();
            QueueOutcomeGuests();
        }


        [Reader]
        public void Action(EditItemInput message)
        {
            Item item = null;
            switch (message.Type)
            {
                case ItemType.Guest:
                    item = EventService.UpdateGuest(CurrentEvent, message.ItemId, message.Name, message.Amount);
                    break;
                case ItemType.Expense:
                    item = EventService.UpdateExpense(CurrentEvent, message.ItemId, message.Name, message.Amount);
                    break;
            }
            if(item != null)
            {
                CalculateOutcome();
                Queue(ToItemOutput(item, message.Type));
                QueueOutcomeSummary();
                QueueOutcomeGuests();
            }
        }

        [Reader]
        public void Action(RemoveItemInput message)
        {
            bool removed = false;
            switch (message.Type)
            {   
                case ItemType.Guest:
                    removed = EventService.RemoveGuest(CurrentEvent, message.ItemId);
                    break;
                case ItemType.Expense:
                    removed = EventService.RemoveExpense(CurrentEvent, message.ItemId);
                    break;
            }
            if (removed)
            {
                CalculateOutcome();
                Queue(new RemoveItemOutput()
                {
                    Id = message.ItemId,
                    Type = message.Type,
                });
                QueueOutcomeSummary();
                QueueOutcomeGuests();
            }
        }

        [Reader]
        public void Action(ResetSheetInput message)
        {
            CurrentEvent = EventService.Create();
            CalculateOutcome();
            Brief();
        }

        #endregion
    }
}
