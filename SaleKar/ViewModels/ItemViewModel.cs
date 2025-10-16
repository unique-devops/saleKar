using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SaleKar.Core.Interfaces;
using SaleKar.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SaleKar.ViewModels
{
    public partial class ItemViewModel : BaseViewModel
    {
        private readonly IItemService _itemService;

        [ObservableProperty]
        private ObservableCollection<Item> items = new();

        public IAsyncRelayCommand LoadCustomersCommand { get; }
        public ItemViewModel(IItemService itemService)
        {
            _itemService = itemService;
            LoadCustomersCommand = new AsyncRelayCommand(LoadCustomersAsync);
            _ = LoadCustomersAsync(); // auto-load
        }

        private async Task LoadCustomersAsync()
        {
            try
            {
                var data = await _itemService.GetAllAsync();
                Items = new ObservableCollection<Item>(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }


    }
}
