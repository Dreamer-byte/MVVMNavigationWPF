using MVVMNavigationWPF.Core;
using MVVMNavigationWPF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MVVMNavigationWPF.MVVM.ViewModel
{
    public class HomeViewModel : Core.ViewModel
    {

        private INavigationService _navigation;

        public INavigationService Navigation
        {
            get => _navigation;
            set 
            {
                _navigation = value;
                OnPropertyChanged();
            }
        }


        public RelayCommand NavigateToSettingCommand { get; set; }

        public HomeViewModel(INavigationService navService) 
        {
            Navigation = navService;
            NavigateToSettingCommand = new RelayCommand(execute: (o) => { Navigation.NavigateTo<SettingsViewModel>(); }, canExecute: (o) => true);
        }
    }
}
