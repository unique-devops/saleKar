using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleKar.ViewModel
{
    public class BaseViewModel : ObservableObject
    {
        private string? _displayTitle;
        public string? DisplayTitle
        {
            get => _displayTitle;
            set => SetProperty(ref _displayTitle, value);
        }
    }
}
