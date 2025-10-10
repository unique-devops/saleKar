using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using SaleKar.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleKar.Services
{
    public class NavigationService : ObservableObject, INavigationService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly Dictionary<Type, object> _viewModels = new();

        private object? _currentViewModel;
        public object? CurrentViewModel
        {
            get => _currentViewModel;
            private set => SetProperty(ref _currentViewModel, value);
        }

        public NavigationService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void NavigateTo<TViewModel>() where TViewModel : class
        {
            if (!_viewModels.TryGetValue(typeof(TViewModel), out var vm))
            {
                vm = _serviceProvider.GetRequiredService<TViewModel>();
                _viewModels[typeof(TViewModel)] = vm;
            }

            CurrentViewModel = vm;
        }
    }
}
