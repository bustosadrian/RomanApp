﻿using Reedoo.NET.Controller;
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

        private string _editingItemId = null;

        public override void Brief()
        {
            QueueBriefing();
        }

        protected override void OnBack()
        {
            RomanAppRoomState.OnExit(Member);
        }

        private Outcome CalculateOutcome()
        {
            return EventService.Calculate(CurrentEvent);
        }

        #region Messages

        [Reader]
        public void Read(AddGuestInput message)
        {
            Guest entity = EventService.AddGuest(
                CurrentEvent, message.Label, 
                message.Amount, 
                message.Name);

            QueueGuest(entity);
        }

        [Reader]
        public void Read(AddExpenseInput message)
        {
            Expense entity = EventService.AddExpense(
                CurrentEvent, message.Label,
                message.Amount,
                message.Name);

            QueueExpense(entity);
        }

        [Reader]
        public void Read(RemoveGuestInput message)
        {
            if (EventService.RemoveGuest(CurrentEvent, message.ItemId))
            {
                Queue(new RemoveGuestOutput()
                {
                    ItemId = message.ItemId,
                });
                QueueOutcome();
            }
        }

        [Reader]
        public void Read(RemoveExpenseInput message)
        {
            if (EventService.RemoveExpense(CurrentEvent, message.ItemId))
            {
                Queue(new RemoveExpenseOutput()
                {
                    ItemId = message.ItemId,
                });
                QueueOutcome();
            }
        }

        [Reader]
        public void Read(ChangeSelfContributionInput message)
        {
            SelfContributionOutput output = new SelfContributionOutput
            {
                Amount = MemberGuest?.Share?.Amount ?? 0
            };
            Queue(output);
        }

        [Reader]
        public void Read(ChangeOthersContributionInput message)
        {
            Guest entity = CurrentEvent.Guests.SingleOrDefault(x => x.Id == message.ItemId);
            //TODO cool for MethodValidation
            OthersContributionOutput output = new OthersContributionOutput
            {
                Amount = entity?.Share?.Amount ?? 0,
                GuestName = entity.Label,
                IsSelf = message.ItemId == MemberGuest?.Id,
            };
            _editingItemId = message.ItemId;
            Queue(output);
        }

        [Reader]
        public void Read(ChangeExpenseAmountInput message)
        {
            Expense entity = CurrentEvent.Expenses.SingleOrDefault(x => x.Id == message.ItemId);
            //TODO cool for MethodValidation
            ExpenseAmountOutput output = new ExpenseAmountOutput
            {
                Amount = entity?.Share?.Amount ?? 0,
                ExpenseLabel = entity.Label,
            };
            _editingItemId = message.ItemId;
            Queue(output);
        }

        [Reader]
        public void Read(UpdateSelfContributionInput message)
        {
            Share share = new Share()
            {
                Amount = message.Amount,
                Description = message.Description,
            };
            EventService.UpdateGuestContribution(CurrentEvent, MemberGuest, share);
            QueueGuest(MemberGuest);
            QueueOutcome();
        }

        [Reader]
        public void Read(UpdateOthersContributionInput message)
        {
            Share share = new Share()
            {
                Amount = message.Amount,
                Description = message.Description,
            };
            //TODO cool for MethodValidation
            Guest guest = CurrentEvent.Guests.SingleOrDefault(x => x.Id == _editingItemId);
            EventService.UpdateGuestContribution(CurrentEvent, guest, share);
            QueueGuest(guest);
            QueueOutcome();
        }

        [Reader]
        public void Read(UpdateExpenseAmountInput message)
        {
            Share share = new Share()
            {
                Amount = message.Amount,
                Description = message.Description,
            };
            //TODO cool for MethodValidation
            Expense expense = CurrentEvent.Expenses.SingleOrDefault(x => x.Id == _editingItemId);
            EventService.UpdateExpenseAmount(CurrentEvent, expense, share);
            QueueExpense(expense);
            QueueOutcome();
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
                Outcome = Map(CalculateOutcome()),
                HasIdentity = MemberGuest != null,
                IsAdmin = MemberProfile.IsAdmin,
            };
            Queue(briefing);
            QueueOutcome();
        }

        private void QueueGuest(Guest entity)
        {
            Queue(Map(entity));
            QueueOutcome();
        }

        private void QueueExpense(Expense entity)
        {
            Queue(Map(entity));
            QueueOutcome();
        }

        private void QueueOutcome()
        {
            Queue(Map(CalculateOutcome()));
        }

        #endregion

        #region Mapping

        private void Map(Item entity, ItemOutput message)
        {
            message.EntityId = entity.Id;
            message.Label = entity.Label;
            message.Share = new ShareOutput()
            {
                EntityId = entity.Share.Id,
                Amount = entity.Share.Amount,
                Description = entity.Share.Description,
            };
        }


        private GuestOutput Map(Guest entity)
        {
            GuestOutput retval = null;

            retval = new GuestOutput()
            {
                IsSelf = entity.Id == MemberGuest?.Id,
            };
            Map(entity, retval);

            return retval;
        }

        private ExpenseOutput Map(Expense entity)
        {
            ExpenseOutput retval = null;

            retval = new ExpenseOutput();
            Map(entity, retval);

            return retval;
        }

        private OutcomeOutput Map(Outcome entity)
        {
            OutcomeOutput retval = null;

            retval = new OutcomeOutput
            {
                IsEmpty = entity.IsEmpty,
                Total = entity.Total,
                ExpensesTotal = entity.ExpensesTotal,
                Share = entity.Share,
            };
            retval.Creditors = entity.Creditors.Select(x => Map(x)).ToList();
            retval.Debtors = entity.Debtors.Select(x => Map(x)).ToList();
            retval.Evens = entity.Evens.Select(x => Map(x)).ToList();

            return retval;
        }

        private GuestOutcomeOutput Map(GuestOutcome entity)
        {
            GuestOutcomeOutput retval = null;

            retval = new GuestOutcomeOutput()
            {
                Id = entity.Id,
                Name = entity.Name,
                Amount = entity.Amount,
                Debt = entity.Debt,
            };

            return retval;
        }

        #endregion
    }
}
