using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleKar.Infrastructure.Configuration
{
    public static class AppConfigManager
    {
        public static IConfigurationRoot Configuration { get; }

        static AppConfigManager()
        {
            //Configuration = new ConfigurationBuilder()
            //    .SetBasePath(AppContext.BaseDirectory)
            //    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            //    .Build();

        }
        public static string DataMode;
        public static string DatabaseProvider;
        public static string ApiBaseUrl;
        public static string GetConnectionString(string name) =>
            Configuration.GetConnectionString(name)!;
        //public static string DataMode => Configuration["DataMode"]!;
        //public static string DatabaseProvider => Configuration["DatabaseProvider"]!;
        //public static string ApiBaseUrl => Configuration["ApiBaseUrl"]!;
        //public static string GetConnectionString(string name) =>
        //    Configuration.GetConnectionString(name)!;
    }
}
