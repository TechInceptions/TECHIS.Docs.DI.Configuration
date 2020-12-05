using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using TECHIS.Core;

namespace TECHIS.Configuration
{
    public class AppSettingsProvider : IApplicationSettings
    {
        private readonly IConfiguration _Configuration;

        public AppSettingsProvider(IConfiguration configuration)
        {
            InputValidator.ArgumentNullCheck(configuration, nameof(configuration));
            _Configuration = configuration;
        }

        public TValue Get<TValue>(string key, TValue value)
        {
            return _Configuration.GetValue(key,value);
        }
        public TConfig Get<TConfig>(string sectionName)
        {
            var section = _Configuration.GetSection(sectionName);
            return section == null ? default : section.Get<TConfig>();
            
        }
        public string Get(string key)
        {
            return _Configuration[key];
        }

        public IEnumerable<KeyValuePair<string, string>> GetAll()
        {
            return _Configuration.AsEnumerable();
        }

        public Task<IEnumerable<KeyValuePair<string, string>>> GetAllAsync()
        {
            return Task.FromResult(GetAll());
        }

        public Task<string> GetAsync(string key)
        {
            return Task.FromResult(_Configuration.GetValue<string>(key));
        }

        public Task<TConfig> GetAsync<TConfig>(string sectionName)
        {
            return Task.FromResult(Get<TConfig>(sectionName));
        }
    }
}
