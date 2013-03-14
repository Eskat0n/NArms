namespace NArms.BunkerBuster
{
    using System.Configuration;
    using System.Linq;
    using System.Reflection;
    using Annotations;

    public abstract class ConfigBase
    {
        protected ConfigBase()
        {
            var properties = GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var property in properties)
            {
                var configKeyNameAttribute = property.GetCustomAttributes(true)
                    .OfType<ConfigKeyNameAttribute>()
                    .SingleOrDefault();

                var key = configKeyNameAttribute == null
                              ? property.Name
                              : configKeyNameAttribute.Key;
                var value = ConfigurationManager.AppSettings[key];

                property.SetValue(this, value, null);
            }
        }
    }
}
