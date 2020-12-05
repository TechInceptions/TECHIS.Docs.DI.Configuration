using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TECHIS.Configuration
{
    public abstract class ServiceConfigurationBase
    {

        private static string _stringTypeName = typeof(string).Name;
        /// <summary>
        /// The prevalidate method is called right after the configuration is read into the class - this usually means at startup
        /// </summary>
        /// <param name="throwOnFailure"></param>
        /// <returns></returns>
        public virtual bool PreValidate(bool throwOnFailure = false)
        {
            return true;
        }
        /// <summary>
        /// The validate method is called during the construction of the service object
        /// </summary>
        /// <param name="throwOnFailure"></param>
        /// <returns></returns>
        public virtual bool Validate(bool throwOnFailure = false)
        {
            var properties = this.GetPropertyValues();

            var results = properties.Select(prop => 
            {
                //In the current context, makes sense to validate only string types
                if (prop.TypeName == _stringTypeName && string.IsNullOrWhiteSpace(prop.Value.ToString()))
                {
                    return (prop.Name, IsValid: false);
                }

                return (prop.Name, IsValid: true);
            });

            var isValid = results.Any(result => !result.IsValid);

            if (throwOnFailure && !isValid)
            {
                throw new Exception($"For the config section:{GetType().Name}, The following config fields are invalid: { string.Join(", ", results.Where(r=> !r.IsValid).Select(r => r.Name)) }");
            }

            return isValid;
        }

    }
}
