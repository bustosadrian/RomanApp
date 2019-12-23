using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlainUWP.ViewModels
{
    public abstract class NavigationViewModel : BaseViewModel
    {
        protected INavigationService _navigationService;

        public NavigationViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
