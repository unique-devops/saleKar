using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleKar.Interface
{
    public interface INavigationService
    {
        void NavigateTo<TViewModel>() where TViewModel : class;
    }
}
