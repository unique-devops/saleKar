using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleKar.ViewModel
{
    public partial class HomeViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string title = "🏠 Home Page";

        [RelayCommand]
        void Refresh()
        {
            Title = $"🏠 Home Page - Refreshed at {DateTime.Now:T}";
        }
    }
}
