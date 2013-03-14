namespace NArms.BunkerBuster.Annotations
{
    using System;

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class ConfigKeyNameAttribute : Attribute
    {
        private readonly string _key;

        public ConfigKeyNameAttribute(string key)
        {
            _key = key;
        }
    }
}