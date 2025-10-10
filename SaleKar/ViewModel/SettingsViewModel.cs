using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleKar.ViewModel
{
    public partial class SettingsViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string message = "⚙️ Settings Page";
    }
}
