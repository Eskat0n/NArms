namespace NArms.BunkerBuster
{
    using System.Configuration;
    using System.Reflection;

    public abstract class ConfigBase
    {
        protected ConfigBase()
        {
            var properties = GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var property in properties)
            {
                var value = ConfigurationManager.AppSettings[property.Name];

                property.SetValue(this, value, null);
            }
        }
    }
}
