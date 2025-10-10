using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SaleKar.Interface;
using SaleKar.Services;
using SaleKar.ViewModel;
using System.Configuration;
using System.Data;
using System.Windows;

namespace SaleKar
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IHost AppHost { get; private set; } = null!;

        public App()
        {
            AppHost = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddSingleton<INavigationService, NavigationService>();
                    services.AddSingleton<TabNavigationService>();
                    services.AddSingleton<MainViewModel>();
                    services.AddSingleton<HomeViewModel>();
                    services.AddSingleton<SettingsViewModel>();
                    services.AddSingleton<MainWindow>();
                })
                .Build();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            AppHost.Start();

            var mainWindow = AppHost.Services.GetRequiredService<MainWindow>();
            mainWindow.DataContext = AppHost.Services.GetRequiredService<MainViewModel>();
            mainWindow.Show();

            base.OnStartup(e);
        }
    }

}
