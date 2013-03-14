namespace NArms.BunkerBuster
{
    using System.Configuration;
    using System.Reflection;
    using Annotations;
    using Extensions;

    public abstract class ConfigBase
    {
        protected ConfigBase()
        {
            var properties = GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var property in properties)
            {
                var ignoreAttribute = property.GetCustomAttribute<ConfigIgnoreAttribute>();
                if (ignoreAttribute != null)
                    continue;

                var keyNameAttribute = property.GetCustomAttribute<ConfigKeyNameAttribute>();

                var key = keyNameAttribute == null
                              ? property.Name
                              : keyNameAttribute.Key;
                var value = ConfigurationManager.AppSettings[key];

                property.SetValue(this, value, null);
            }
        }
    }
}
