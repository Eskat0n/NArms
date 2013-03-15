namespace NArms.BunkerBuster.Extensions
{
    using System;
    using System.Linq;
    using System.Reflection;

    internal static class PropertyInfoExtensions
    {
        internal static TAttribute GetCustomAttribute<TAttribute>(this PropertyInfo propertyInfo)
            where TAttribute : Attribute
        {
            return propertyInfo.GetCustomAttributes(true)
                .OfType<TAttribute>()
                .SingleOrDefault();
        }

        internal static void SetValue(this PropertyInfo propertyInfo, object instance, string value,
                                      IDeserializersRegistry deserializers)
        {
            var deserializedValue = deserializers.Deserialize(value, propertyInfo.PropertyType);

            propertyInfo.SetValue(instance, deserializedValue, null);
        }
    }
}