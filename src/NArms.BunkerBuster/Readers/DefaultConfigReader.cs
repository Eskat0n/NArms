namespace NArms.Config.Readers
{
    using System.Configuration;
    using System.Reflection;
    using Annotations;
    using Deserializers;
    using Extensions;

    public class DefaultConfigReader : IConfigReader
    {
        private readonly IDeserializersRegistry _deserializers;

        public DefaultConfigReader()
            : this(new DefaultDeserializersRegistry())
        {
        }

        public DefaultConfigReader(IDeserializersRegistry deserializers)
        {
            _deserializers = deserializers;
        }

        public void ReadTo(object configInstance)
        {
            var properties = configInstance.GetType()
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
                    var deserializedValue = _deserializers.Deserialize(value, property.PropertyType);

                    property.SetValue(configInstance, deserializedValue, null);
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