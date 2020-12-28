using Reedoo.NET.Controller;
using Reedoo.NET.Messages;
using RomanApp.Controller.MemberStates.Parameters;
using RomanApp.Controller.Model.Event;
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

        public override void OnRestore()
        {
            base.OnRestore();

            CalculateOutcome();
        }

        public override void Brief()
        {
            QueueOutcomeAvailable();
            QueueItemsCount();
            QueueClearAll();
            QueueGuests();
            QueueExpenses();
            QueueOutcomeSummary();
            QueueOutcomeGuests();
        }

        private void CalculateOutcome()
        {
            _outcome = EventService.Calculate(null, RoomSettings.UseWholeNumbers);
        }

        #region Queues

        private void QueueClearAll()
        {
            QueueClearGuests();
            QueueClearExpenses();
        }

        private void QueueOutcomeAvailable()
        {
            Queue(new OutcomeResultOutput()
            {
                Value = (RomanApp.Messages.Output.Sheet.Outcome.OutcomeResult)
                Enum.Parse(typeof(RomanApp.Messages.Output.Sheet.Outcome.OutcomeResult), _outcome.Result.ToString()),
            });
        }

        private void QueueClearGuests()
        {
            Queue(new ClearGuestsOutput());
        }

        private void QueueClearExpenses()
        {
            Queue(new ClearExpensesOutput());
        }

        private void QueueItemsCount()
        {
            Queue(new ItemsCountOutput()
            {
                GuestsCounts = CurrentEvent.Guests.Count(),
                ExpensesCount = CurrentEvent.Expenses.Count(),
            });
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

        private ItemOutput ToItemOutput(ItemModel entity, ItemType type)
        {
            ItemOutput retval = null;

            retval = new ItemOutput()
            {
                Id = entity.Id,
                Type = type,
                Name = entity.Name,
                Amount = entity.Amount,
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
        public void Action(GoToHelpInput message)
        {
            ChangeState(typeof(HelpMemberState), new HelpParameters()
            {
                Topic = HelpTopic.Overview,
            });
        }

        [Reader]
        public void Action(AddItemInput message)
        {
            ItemModel item = null;
            switch (message.Type)
            {
                case ItemType.Guest:
                    item = new GuestModel(EventService.AddGuest(CurrentEvent.Id, null, message.Name, message.Amount));
                    CurrentEvent.Guests.Add((GuestModel)item);
                    break;
                case ItemType.Expense:
                    item = new ExpenseModel(EventService.AddExpense(CurrentEvent.Id, null, message.Name, message.Amount));
                    CurrentEvent.Expenses.Add((ExpenseModel)item);
                    break;
            }
            CalculateOutcome();
            QueueItemsCount();
            QueueOutcomeAvailable();
            Queue(ToItemOutput(item, message.Type));
            QueueOutcomeSummary();
            QueueOutcomeGuests();
        }


        [Reader]
        public void Action(EditItemInput message)
        {
            ItemModel modelItem = null;
            Item updatedItem = null;
            switch (message.Type)
            {
                case ItemType.Guest:
                    modelItem = CurrentEvent.Guests.Single(x => x.Id == message.ItemId);
                    updatedItem = EventService.UpdateGuest(CurrentEvent.Id, modelItem.Id, message.Name, message.Amount);
                    modelItem.Map(updatedItem);
                    break;
                case ItemType.Expense:
                    modelItem = CurrentEvent.Expenses.Single(x => x.Id == message.ItemId);
                    updatedItem = EventService.UpdateExpense(CurrentEvent.Id, modelItem.Id, message.Name, message.Amount);
                    modelItem.Map(updatedItem);
                    break;
            }
            if(modelItem != null)
            {
                CalculateOutcome();
                QueueItemsCount();
                QueueOutcomeAvailable();
                Queue(ToItemOutput(modelItem, message.Type));
                QueueOutcomeSummary();
                QueueOutcomeGuests();
            }
        }

        [Reader]
        public void Action(RemoveItemInput message)
        {
            ItemModel modelItem = null;
            bool removed = false;
            switch (message.Type)
            {   
                case ItemType.Guest:
                    modelItem = CurrentEvent.Guests.Single(x => x.Id == message.ItemId);
                    if (removed = EventService.RemoveGuest(CurrentEvent.Id, modelItem.Id))
                    {
                        CurrentEvent.Guests.Remove((GuestModel)modelItem);
                    }

                    break;
                case ItemType.Expense:
                    modelItem = CurrentEvent.Expenses.Single(x => x.Id == message.ItemId);
                    if(removed = EventService.RemoveExpense(CurrentEvent.Id, modelItem.Id))
                    {
                        CurrentEvent.Expenses.Remove((ExpenseModel)modelItem);
                    }
                    break;
            }
            if (removed)
            {
                CalculateOutcome();
                QueueItemsCount();
                QueueOutcomeAvailable();
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
            var newEvent = EventService.Create();
            CurrentEvent.Map(newEvent);
            CalculateOutcome();
            Brief();
        }

        #endregion
    }
}
