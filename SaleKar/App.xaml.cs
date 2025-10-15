using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SaleKar.Core.Models;
using SaleKar.Infrastructure.DI;
using SaleKar.Interface;
using SaleKar.Services;
using SaleKar.ViewModels;
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
        public static IServiceProvider Services { get; private set; }
        public App()
        {
            AppHost = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    ServiceConfigurator.Configure(services);
                    services.AddSingleton<MainWindow>();
                    services.AddSingleton<INavigationService, NavigationService>();
                    services.AddSingleton<TabNavigationService>();
                    services.AddSingleton<MainViewModel>();
                    services.AddSingleton<HomeViewModel>();
                    services.AddSingleton<ItemViewModel>();
                    services.AddSingleton<SettingsViewModel>();
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
