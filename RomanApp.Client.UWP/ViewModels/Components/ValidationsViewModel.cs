using System;
using Reedoo.NET.Messages;
using Reedoo.NET.Messages.Output;
using RomanApp.Client.ViewModel;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using System.Linq;

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
                if (o.Tags != null && o.Tags.Length > 0)
                {
                    sb.Append(TagsToString(o.Tags));
                    sb.Append(" ");
                }
                sb.Append($"- {o.Message}");
                sb.AppendLine();
            }

            string verbiage = sb.ToString();

            var dialog = new MessageDialog(verbiage, "Wait!");

            await dialog.ShowAsync();

            return true;
        }

        private string TagsToString(string[] tags)
        {
            string retval = null;

            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < tags.Length; i++)
            {
                var o = tags[i];
                sb.Append(o);
                if((i + 1) < tags.Length)
                {
                    sb.Append(", ");
                }
            }
            if(sb.Length > 0)
            {
                retval = $"({sb})";
            }

            return retval;
        }

        #endregion
    }
}
