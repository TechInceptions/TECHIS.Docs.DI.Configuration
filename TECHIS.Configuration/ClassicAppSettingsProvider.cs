using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TECHIS.Configuration.Windows
{
    public class ClassicAppSettingsProvider : TECHIS.Core.IApplicationSettings
    {
        public string Get(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        public TConfig Get<TConfig>(string sectionName)
        {
            return (TConfig)ConfigurationManager.GetSection(sectionName);
        }

        public TValue Get<TValue>(string key, TValue value)
        {
            var tmp = Get(key);
            if (tmp == null)
            {
                return value;
            }
            else
            {
                return (TValue)(TECHIS.Core.IO.ObjectReaderWriter.ParseObject(Get(key), typeof(TValue)));
            }
        }

        public IEnumerable<KeyValuePair<string, string>> GetAll()
        {
            var appSettings = ConfigurationManager.AppSettings;
            int count = appSettings.Count;
            var results = new KeyValuePair<string, string>[count];
            for (int i = 0; i < count; i++)
            {
                results[i] = new KeyValuePair<string, string>(appSettings.GetKey(i), appSettings.Get(i));
            }

            return results;
        }

        public Task<IEnumerable<KeyValuePair<string, string>>> GetAllAsync()
        {
            return Task.FromResult( GetAll());
        }

        public Task<string> GetAsync(string key)
        {
            return Task.FromResult(Get(key));
        }

        public Task<TConfig> GetAsync<TConfig>(string sectionName)
        {
            return Task.FromResult(Get<TConfig>(sectionName));
        }
    }
}
