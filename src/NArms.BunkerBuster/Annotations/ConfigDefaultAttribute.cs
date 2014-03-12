namespace NArms.Config.Annotations
{
    using System;

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class ConfigDefaultAttribute : Attribute
    {
        internal object DefaultValue { get; private set; }

        public ConfigDefaultAttribute(object defaultValue)
        {
            DefaultValue = defaultValue;
        }
    }
}