using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TECHIS.Configuration;
using TECHIS.Configuration.Windows;
using TECHIS.Core;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using TECHIS.Docs.Services;
using TECHIS.Configuration.DependencyInjection;

[assembly: FunctionsStartup(typeof(TECHIS.Docs.AzureApp.Startup))]
namespace TECHIS.Docs.AzureApp
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var configuration = builder.GetContext().Configuration;

            //Reg Config
            builder.Services.AddConfig<Services.Config.CustomerRepository>(configuration)
                            .AddConfig<Services.Config.CustomerService>(configuration)

            //Reg services
                            .AddScoped<ICustomerService, CustomerService>()
                            .AddScoped<IRepository<long>, CustomerRepository>();

        }
    }
}