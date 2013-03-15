namespace NArms.BunkerBuster
{
    using System;

    public interface IDeserializersRegistry
    {
        object Deserialize(string value, Type propertyType);
    }
}