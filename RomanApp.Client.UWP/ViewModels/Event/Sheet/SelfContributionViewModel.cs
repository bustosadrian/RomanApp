using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RomanApp.Messages.Event.Input.Sheet;

namespace RomanApp.Client.UWP.ViewModels.Event.Sheet
{
    public class SelfContributionViewModel : ItemAmountViewModel
    {
        public SelfContributionViewModel(BaseViewModel parent) 
            : base(parent, new SelfAmountDialogTitle())
        {

        }

        protected override UpdateContributionInput CreateUpdateContributionInput()
        {
            return new MyContributionInput();
        }
    }
}
