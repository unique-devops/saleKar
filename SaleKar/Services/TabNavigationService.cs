using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using SaleKar.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleKar.Services
{
    public class TabNavigationService : ObservableObject
    {
        private readonly IServiceProvider _serviceProvider;
        public ObservableCollection<BaseViewModel> OpenTabs { get; } = new();

        private BaseViewModel? _selectedTab;
        public BaseViewModel? SelectedTab
        {
            get => _selectedTab;
            set => SetProperty(ref _selectedTab, value);
        }

        public TabNavigationService(IServiceProvider sp)
        {
            _serviceProvider = sp;
        }

        public void OpenTab<TViewModel>(string? title = null) where TViewModel : BaseViewModel
        {
            var vm = _serviceProvider.GetRequiredService<TViewModel>();

            // Prevent duplicate tabs of same type
            if (!OpenTabs.Any(t => t.GetType() == typeof(TViewModel)))
            {
                vm.DisplayTitle = title ?? typeof(TViewModel).Name.Replace("ViewModel", "");
                OpenTabs.Add(vm);
            }

            SelectedTab = OpenTabs.FirstOrDefault(t => t.GetType() == typeof(TViewModel));
        }

        public void CloseTab(BaseViewModel vm)
        {
            if (OpenTabs.Contains(vm))
                OpenTabs.Remove(vm);

            if (SelectedTab == vm)
                SelectedTab = OpenTabs.LastOrDefault();
        }
    }
}
