using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace TECHIS.Configuration.DependencyInjection
{
    public static class AppSettingsObjectBinder
    {
        public static IServiceCollection Bind(this IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }

        public static IServiceCollection AddConfig<T>(this IServiceCollection services, IConfiguration configuration) where T : class, new()
        {
            return AddConfig<T>(services, configuration, typeof(T).Name);
        }
        public static IServiceCollection AddConfig<T>(this IServiceCollection services, IConfiguration configuration, string sectionName) where T : class, new()
        {
            T configObject = configuration.GetSection(sectionName)?.Get<T>() ?? new T();
            
            services.AddSingleton(configObject);

            return services;
        }
    }
}
