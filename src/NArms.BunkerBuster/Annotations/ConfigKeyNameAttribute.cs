namespace NArms.Config.Annotations
{
    using System;

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class ConfigKeyNameAttribute : Attribute
    {
        internal string Key { get; private set; }

        public ConfigKeyNameAttribute(string key)
        {
            Key = key;
        }
    }
}