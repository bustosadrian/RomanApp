using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlainUWP
{
    public interface INavigationService
    {
        void NavigateTo(Type page, object parameter = null);
    }
}
