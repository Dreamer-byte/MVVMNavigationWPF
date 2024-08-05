using MVVMNavigationWPF.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMNavigationWPF.Services
{
    public interface INavigationService
    {
        ViewModel CurrentView { get; }

        void NavigateTo<T> () where T : ViewModel;
    }
}
