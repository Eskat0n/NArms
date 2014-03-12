namespace NArms.Config.Extensions
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
    }
}