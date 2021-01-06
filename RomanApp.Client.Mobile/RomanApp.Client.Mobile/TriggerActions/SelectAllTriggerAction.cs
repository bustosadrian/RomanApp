using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace RomanApp.Client.Mobile.TriggerActions
{
    public class SelectAllTriggerAction : TriggerAction<Entry>
    {
        protected override void Invoke(Entry sender)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                sender.CursorPosition = 0;
                sender.SelectionLength = sender.Text?.Length ?? 0;
            });
        }
    }
}
