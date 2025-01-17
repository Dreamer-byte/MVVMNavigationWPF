﻿using MVVMNavigationWPF.Core;
using MVVMNavigationWPF.MVVM.View;
using MVVMNavigationWPF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMNavigationWPF.MVVM.ViewModel
{
    public class MainViewModel:Core.ViewModel
    {
        private INavigationService _navigation;
        public INavigationService Navigation 
        {
            get => _navigation; 
            set => _navigation = value;
        }


        public RelayCommand NavigateToHomeCommand { get; set; }
        public RelayCommand NavigateToSettingCommand { get; set; }

        public MainViewModel(INavigationService navService)
        {

            Navigation = navService;
            NavigateToHomeCommand = new RelayCommand(execute:(o)  => { Navigation.NavigateTo<HomeViewModel>(); },canExecute:(o)=>true);
            NavigateToSettingCommand = new RelayCommand(execute: (o) => { Navigation.NavigateTo<SettingsViewModel>(); }, canExecute: (o) => true);

        }
        
    }
}
