using System;
using Reedoo.NET.Messages;
using Reedoo.NET.Messages.Output;
using RomanApp.Client.ViewModel;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace RomanApp.Client.UWP.ViewModels.Components
{
    public class ValidationsViewModel : EmbeddedViewModel
    {
        public ValidationsViewModel(BusViewModel parent) : base(parent)
        {

        }

        #region Messages

        [Reader]
        public async Task<bool> Read(ValidationErrors message)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var o in message.Errors)
            {
                sb.Append($"- {o.Message}");
                sb.AppendLine();
            }

            string verbiage = sb.ToString();

            var dialog = new MessageDialog(verbiage, "Wait!");

            await dialog.ShowAsync();

            return true;
        }

        #endregion
    }
}
