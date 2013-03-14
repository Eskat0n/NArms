namespace NArms.BunkerBuster.Annotations
{
    using System;

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class ConfigOptionalAttribute : Attribute
    {
        public ConfigOptionalAttribute()
        {
        }
    }
}