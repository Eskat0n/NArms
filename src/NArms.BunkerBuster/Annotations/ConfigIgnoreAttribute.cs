namespace NArms.BunkerBuster.Annotations
{
    using System;

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class ConfigIgnoreAttribute : Attribute
    {        
    }
}