namespace NArms.Config.Deserializers
{
    using System;
    using System.Collections.Generic;

    public class DeserializersRegistryBase : IDeserializersRegistry
    {
        protected readonly IDictionary<Type, IDeserializer> Deserializers
            = new Dictionary<Type, IDeserializer>();

        protected void RegisterDeserializer<T>(IDeserializer deserializer)
        {
            Deserializers.Add(typeof(T), deserializer);
        }

        public virtual object Deserialize(string value, Type propertyType)
        {
            if (Deserializers.ContainsKey(propertyType))
                return Deserializers[propertyType].Deserialize(value);

            throw new NotImplementedException();
        }
    }
}