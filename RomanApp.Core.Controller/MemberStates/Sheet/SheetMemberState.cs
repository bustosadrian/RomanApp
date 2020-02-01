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

        private string _othersGuestId = null;

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
        public void Read(ChangeMyContributionInput message)
        {
            YourContributionOutput output = new YourContributionOutput
            {
                Amount = MemberGuest?.Share?.Amount ?? 0
            };
            Queue(output);
        }

        [Reader]
        public void Read(ChangeOthersContributionInput message)
        {
            Guest guest = CurrentEvent.Guests.SingleOrDefault(x => x.Id == message.ItemId);
            //TODO cool for MethodValidation
            OthersContributionOutput output = new OthersContributionOutput
            {
                Amount = guest?.Share?.Amount ?? 0,
                GuestName = guest.Name,
                IsSelf = message.ItemId == MemberGuest?.Id,
            };
            _othersGuestId = message.ItemId;
            Queue(output);
        }

        [Reader]
        public void Read(MyContributionInput message)
        {
            Share share = new Share()
            {
                Amount = message.Amount,
                Description = message.Description,
            };
            EventService.UpdateGuestShare(CurrentEvent, MemberGuest, share);
            QueueGuest(MemberGuest);
            QueueOutcome();
        }

        [Reader]
        public void Read(OthersContributionInput message)
        {
            Share share = new Share()
            {
                Amount = message.Amount,
                Description = message.Description,
            };
            //TODO cool for MethodValidation
            Guest guest = CurrentEvent.Guests.SingleOrDefault(x => x.Id == _othersGuestId);
            EventService.UpdateGuestShare(CurrentEvent, guest, share);
            QueueGuest(guest);
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
                Outcome = Map(EventService.Calculate(CurrentEvent)),
                HasIdentity = MemberGuest != null,
            };
            Queue(briefing);
            QueueOutcome();
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
            QueueOutcome();
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
            QueueOutcome();
        }

        private void QueueOutcome()
        {
            Outcome outcome = EventService.Calculate(CurrentEvent);
            Queue(Map(outcome));
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
