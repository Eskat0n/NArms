namespace NArms.BunkerBuster.Readers
{
    using System.Configuration;
    using System.Reflection;
    using Annotations;
    using Extensions;

    public class DefaultConfigReader : IConfigReader
    {
        public void ReadTo(object configInstance)
        {
            var properties = GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var property in properties)
            {
                var ignoreAttribute = property.GetCustomAttribute<ConfigIgnoreAttribute>();
                if (ignoreAttribute != null)
                    continue;

                var keyNameAttribute = property.GetCustomAttribute<ConfigKeyNameAttribute>();
                var optionalAttribute = property.GetCustomAttribute<ConfigOptionalAttribute>();
                var defaultAttribute = property.GetCustomAttribute<ConfigDefaultAttribute>();

                var key = keyNameAttribute == null
                              ? property.Name
                              : keyNameAttribute.Key;
                
                if (ConfigurationManager.AppSettings.ContainsKey(key))
                {
                    var value = ConfigurationManager.AppSettings[key];
                    property.SetValue(configInstance, value, null);
                }
                else if (defaultAttribute != null)
                {
                    property.SetValue(configInstance, defaultAttribute.DefaultValue, null);
                }
                else if (optionalAttribute == null)
                {

                }
            }
        }
    }
}