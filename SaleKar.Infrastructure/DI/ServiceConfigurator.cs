using Microsoft.Extensions.DependencyInjection;
using SaleKar.ApiServices.Services;
using SaleKar.Core.Interfaces;
using SaleKar.Core.Models;
using SaleKar.Data.Db;
using SaleKar.Data.Services;
using SaleKar.Infrastructure.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleKar.Infrastructure.DI
{
    public static class ServiceConfigurator
    {
        public static void Configure(IServiceCollection services)
        {
            //services.AddSingleton(AppConfigManager.Configuration);

            // Decide mode
            if (AppConfigManager.DataMode == "API")
            {
                services.AddHttpClient<ICustomerService, ApiCustomerService>(client =>
                {
                    client.BaseAddress = new Uri(AppConfigManager.ApiBaseUrl);
                });
            }
            else // DB mode
            {
                services.AddSingleton<IDbConnectionFactory, DbConnectionFactory>();
                services.AddScoped<ICustomerService, CustomerService>();
            }
        }
    }
}
