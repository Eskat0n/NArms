namespace NArms.BunkerBuster.Annotations
{
    using System;

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class ConfigIgnoreAttribute : Attribute
    {        
    }
}