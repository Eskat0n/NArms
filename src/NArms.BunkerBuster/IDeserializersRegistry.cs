namespace NArms.Config
{
    using System;

    public interface IDeserializersRegistry
    {
        object Deserialize(string value, Type propertyType);
    }
}