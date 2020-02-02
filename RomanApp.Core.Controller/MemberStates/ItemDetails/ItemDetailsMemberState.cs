using RomanApp.Core.Controller.Entities;
using RomanApp.Core.Controller.MemberStates.Sheet;
using RomanApp.Messages.Event.Output.ItemDetails;
using System;

namespace RomanApp.Core.Controller.MemberStates.ItemDetails
{
    public abstract class ItemDetailsMemberState<T> 
        : EventMemberState where T : Item
    {
        protected T _item;

        public override void OnLoad(object parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            string itemId = (string)parameters;

            _item = GetItem(itemId);
        }

        public override void Brief()
        {
            QueueDetails();
        }

        protected override void OnBack()
        {
            ChangeState(typeof(SheetMemberState));
        }


        protected abstract T GetItem(string id);

        protected abstract ItemDetailsOutput CreateItemDetailsOutput();

        #region Queue

        protected void QueueDetails()
        {
            ItemDetailsOutput message = CreateItemDetailsOutput();
            message.EntityId = _item.Id;
            message.Label = _item.Label;
            message.Amount = _item.Share?.Amount;
            message.Description = _item.Share?.Description;
            Queue(message);
        }

        #endregion
    }
}
