using Reedoo.NET.Controller;
using Reedoo.NET.Messages;
using RomanApp.Commons;
using RomanApp.Commons.Utils;
using RomanApp.Controller.Model.Event;
using RomanApp.Messages;
using RomanApp.Messages.Input;
using RomanApp.Messages.Input.Sheet;
using RomanApp.Messages.Output.Sheet;
using RomanApp.Messages.Output.Sheet.Outcome;
using RomanApp.Messages.Output.Sheet.Outcome.Text;
using RomanApp.Service.Entities;
using System;
using System.Linq;

namespace RomanApp.Controller.MemberStates
{
    [ApplicationState(StatesKeys.SHEET)]
    public class SheetMemberState : BasicMemberState
    {
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
            QueueItemsAmount();
            QueueClearAll();
            QueueGuests();
            QueueExpenses();
            QueueOutcomeSummary();
            QueueOutcomeGuests();
            QueueEnableReset();
            QueueSettings();
        }

        private void CalculateOutcome()
        {
            _outcome = EventService.Calculate(null, RoomSettings.UseWholeNumbers);
        }

        private void CheckItemInput(AddItemInput message)
        {
            if(message.Name.Length > 30)
            {
                message.Name = message.Name.Substring(0, 30);
            }
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
                IsUseWholeNumbers = RoomSettings.UseWholeNumbers,
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

        private void QueueItemsAmount()
        {
            Queue(new ItemsAmountOutput()
            {
                GuestsAmount = CurrentEvent.Guests.Sum(x => x.Amount),
                ExpensesAmount = CurrentEvent.Expenses.Sum(x => x.Amount),
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
                TotalGuests = _outcome.TotalGuests,
                TotalExpenses = _outcome.TotalExpenses,
                TotalDebtors = _outcome.TotalDebtors,
                TotalCreditors = _outcome.TotalCreditors,
                Total = _outcome.Total,
                Share = _outcome.Share,
                UseWholeNumbers = RoomSettings.UseWholeNumbers,
                LeftOver = _outcome.LeftOver,
            }); ;
        }

        private void QueueItemSaved()
        {
            Queue(new ItemSavedOutput());
        }

        private void QueueOutcomeGuests()
        {
            OutcomeGuestsOutput list = new OutcomeGuestsOutput();
            list.Debtors = _outcome.Debtors.Select(x => ToOutcomeItemOutput(x)).ToList();
            list.Creditors = _outcome.Creditors.Select(x => ToOutcomeItemOutput(x)).ToList();
            list.Evens = _outcome.Evens.Select(x => ToOutcomeItemOutput(x)).ToList();
            list.Expenses = _outcome.Expenses.Select(x => ToOutcomeItemOutput(x)).ToList();
            Queue(list);
        }

        private void QueueEnableReset()
        {
            bool resetEnabled = false;
            if (CurrentEvent.Guests.Any())
            {
                resetEnabled = true;
            }

            if (CurrentEvent.Expenses.Any())
            {
                resetEnabled = true;
            }

            Queue(new EnableResetOutput()
            {
                ResetEnabled = resetEnabled,
            });
        }

        private void QueueSettings()
        {
            Queue(new UseNumericKeyboardOutput()
            {
                UseNumericKeyboard = RoomSettings.UseNumericKeyboard,
            });
        }

        private void QueueOutcomeAsText()
        {
            OutcomeTextOutput text = new OutcomeTextOutput();

            //Total
            text.Total = new TotalGroupOutput()
            {
                Total = _outcome.Total,
                TotalGuests = _outcome.TotalGuests,
                Expenses = _outcome.Expenses.Select(x => new NameAmountOutput()
                {
                    Name = x.Name,
                    Value1 = x.Amount,
                }).ToList()
            };

            var list = _outcome.Debtors.Where(x => x.Debt < _outcome.Share);

            //Share
            text.Share = new ShareGroupOutput()
            {
                GuestsCount = _outcome.GuestsCount,
                Share = _outcome.Share,
                RealShare = _outcome.RealShare,
                HasNoDebtors = (_outcome.GuestsCount - _outcome.Debtors.Count()) > 0,
                HasPartialDebtors = _outcome.Debtors.Any(x => x.Debt < _outcome.Share),
            };



            //Debtors
            text.Debtors = new DebtorsGroupOutput()
            {
                Share = _outcome.Share,
                FullDebtors = _outcome.Debtors.Where(x => x.DebtorStatus == GuestDebtorStatus.Full).Select(x => x.Name).ToList(),
                PartialDebtors = _outcome.Debtors.Where(x => x.DebtorStatus == GuestDebtorStatus.Partial).Select(x => new NameAmountOutput(x.Name, x.Debt, x.Amount)).ToList(),
            };

            //Collected
            if (_outcome.Creditors.Any())
            {
                text.Collected = new CollectedGroupOutput()
                {
                    HasExpenses = _outcome.Expenses.Any(),
                    Debtors = _outcome.Debtors.Select(x => x.Name).ToList(),
                    TotalCollected = _outcome.Debtors.Sum(x => x.Debt),
                    Creditors = _outcome.Creditors.Select(x => new NameAmountOutput(x.Name, x.Debt)).ToList(),
                };
            }

            //Expenses
            if (_outcome.Expenses.Any())
            {
                text.Expenses = new ExpensesGroupOutput()
                {
                    HasCreditors = _outcome.Creditors.Any(),
                    Remaining = _outcome.Total - _outcome.TotalGuests + _outcome.LeftOver,
                    Debtors = _outcome.Debtors.Select(x => x.Name).ToList(),
                    Expenses = _outcome.Expenses.Select(x => new NameAmountOutput(x.Name, x.Amount)).ToList(),
                };
            }

            //Expenses
            if (_outcome.LeftOver != 0)
            {
                text.LeftOver = new LeftOverGroupOutput()
                {
                    LeftOver = _outcome.LeftOver,
                };
            }

            //Evens
            if (_outcome.Evens.Any())
            {
                text.Evens = new EvensGroupOutput()
                {
                    Evens = _outcome.Evens.Select(x => x.Name).ToList(),
                };
            }
            text.UseWholeNumbers = RoomSettings.UseWholeNumbers;

            Queue(text);
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

        private OutcomeItemOutput ToOutcomeItemOutput(GuestOutcome entity)
        {
            OutcomeItemOutput retval = null;

            retval = new OutcomeItemOutput();
            retval.Name = entity.Name;
            retval.Amount = entity.Debt;

            return retval;
        }

        private OutcomeItemOutput ToOutcomeItemOutput(ExpenseOutcome entity)
        {
            OutcomeItemOutput retval = null;

            retval = new OutcomeItemOutput();
            retval.Name = entity.Name;
            retval.Amount = entity.Amount;

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
            CheckItemInput(message);
            ItemModel item = null;
            if(message is AddGuestInput)
            {
                decimal amount = AmountConverter.Convert(message.Amount, false);
                item = new GuestModel(EventService.AddGuest(CurrentEvent.Id, null, message.Name, amount));
                CurrentEvent.Guests.Add((GuestModel)item);
                Queue(ToItemOutput(item, ItemType.Guest));

            }
            else if (message is AddExpenseInput)
            {
                decimal amount = AmountConverter.Convert(message.Amount, true);
                item = new ExpenseModel(EventService.AddExpense(CurrentEvent.Id, null, message.Name, amount));
                CurrentEvent.Expenses.Add((ExpenseModel)item);
                Queue(ToItemOutput(item, ItemType.Expense));
            }
            else
            {
                throw new InvalidCastException($"{message.GetType().Name} is not handled");
            }
            CalculateOutcome();
            QueueItemsCount();
            QueueItemsAmount();
            QueueOutcomeAvailable();
            QueueOutcomeSummary();
            QueueOutcomeGuests();
            QueueItemSaved();
            QueueEnableReset();
        }


        [Reader]
        public void Action(EditItemInput message)
        {
            CheckItemInput(message);
            ItemModel modelItem = null;
            Item updatedItem = null;
            if (message is EditGuestInput)
            {
                decimal amount = AmountConverter.Convert(message.Amount, false);
                modelItem = CurrentEvent.Guests.Single(x => x.Id == message.ItemId);
                updatedItem = EventService.UpdateGuest(CurrentEvent.Id, modelItem.Id, message.Name, amount);
                modelItem.Map(updatedItem);
                Queue(ToItemOutput(modelItem, ItemType.Guest));
            }
            else if (message is EditExpenseInput)
            {
                decimal amount = AmountConverter.Convert(message.Amount, false);
                modelItem = CurrentEvent.Expenses.Single(x => x.Id == message.ItemId);
                updatedItem = EventService.UpdateExpense(CurrentEvent.Id, modelItem.Id, message.Name, amount);
                modelItem.Map(updatedItem);
                Queue(ToItemOutput(modelItem, ItemType.Expense));
            }
            else
            {
                throw new InvalidCastException($"{message.GetType().Name} is not handled");
            }

            if(modelItem != null)
            {
                CalculateOutcome();
                QueueItemsCount();
                QueueItemsAmount();
                QueueOutcomeAvailable();
                QueueOutcomeSummary();
                QueueOutcomeGuests();
                QueueItemSaved();
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
                QueueItemsAmount();
                QueueOutcomeAvailable();
                Queue(new RemoveItemOutput()
                {
                    Id = message.ItemId,
                    Type = message.Type,
                });
                QueueOutcomeSummary();
                QueueOutcomeGuests();
                QueueEnableReset();
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



        [Reader]
        public virtual void Action(GoToAboutInput message)
        {
            ChangeState(typeof(AboutMemberState));
        }

        [Reader]
        public virtual void Action(GetOutcomeAsTextInput message)
        {
            QueueOutcomeAsText();
        }
        

        #endregion
    }
}
