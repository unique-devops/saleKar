using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SaleKar.Interface;
using SaleKar.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace SaleKar.ViewModel
{
    public partial class MainViewModel : BaseViewModel
    {
        private readonly TabNavigationService _tabs;
        private readonly DispatcherTimer _timer;
        public ObservableCollection<BaseViewModel> OpenTabs => _tabs.OpenTabs;

        [ObservableProperty]
        private BaseViewModel? selectedTab;


        [ObservableProperty] private string statusMessage = "Ready";
        [ObservableProperty] private string currentUser = "User: Admin";
        [ObservableProperty] private string licenseStatus = "License: Demo";
        [ObservableProperty] private string currentTime = DateTime.Now.ToString("hh:mm:ss tt");
        public MainViewModel(TabNavigationService tabs)
        {
            _tabs = tabs;
            // open default tab
            //_tabs.OpenTab<HomeViewModel>("Home");

            // Update time every second
            _timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            _timer.Tick += (_, __) => CurrentTime = DateTime.Now.ToString("hh:mm:ss tt");
            _timer.Start();
        }

        [RelayCommand] void OpenHome() => OpenTab<HomeViewModel>("Home");
        [RelayCommand] void OpenSettings() => OpenTab<SettingsViewModel>("Settings");        

        [RelayCommand]
        void RefreshCurrentTab()
        {
            if (SelectedTab is HomeViewModel home)
            {
                home.RefreshCommand.Execute(null);
                StatusMessage = "Home tab refreshed";
            }
            else
            {
                StatusMessage = "No refreshable tab selected";
            }
        }
        [RelayCommand]
        void About()
        {
            MessageBox.Show("WPF ERP Navigation System\nVersion 1.0", "About", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        [RelayCommand]
        void Exit()
        {
            Application.Current.Shutdown();
        }

        private void OpenTab<TViewModel>(string tabMenuName) where TViewModel : BaseViewModel
        {
            _tabs.OpenTab<TViewModel>(tabMenuName);
            SelectedTab = _tabs.SelectedTab;
        }
        [RelayCommand]
        private void CloseTab(BaseViewModel vm)
        {
            _tabs.CloseTab(vm);
            SelectedTab = _tabs.SelectedTab;
        }
    }
}
