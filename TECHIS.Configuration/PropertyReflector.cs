using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace TECHIS.Configuration
{
    public static class PropertyReflector
    {
        public static IEnumerable<(string Name, string TypeName, object Value)> GetPropertyValues(this ServiceConfigurationBase obj)
        {
            return GetPropertyValues(obj);
        }

        private static IEnumerable<(string Name, string TypeName, object Value)> GetPropertyValues(Object obj)
        {
            Type t = obj?.GetType();
            return t == null ? Array.Empty<(string Name, string TypeName, object Value)>() :
                                t.GetProperties().Select(prop => (prop.Name, TypeName: prop.PropertyType.Name, Value: prop.GetValue(obj)));
        }
    }
}
