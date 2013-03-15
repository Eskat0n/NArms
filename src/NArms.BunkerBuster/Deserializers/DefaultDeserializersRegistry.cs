namespace NArms.BunkerBuster.Deserializers
{
    using Default;

    internal class DefaultDeserializersRegistry : DeserializersRegistryBase
    {
        internal DefaultDeserializersRegistry()
        {
            RegisterDeserializer<string>(new DefaultStringDeserializer());

            var integerDeserializer = new DefaultIntegerDeserializer();
            RegisterDeserializer<short>(integerDeserializer);
            RegisterDeserializer<ushort>(integerDeserializer);
            RegisterDeserializer<int>(integerDeserializer);
            RegisterDeserializer<uint>(integerDeserializer);
            RegisterDeserializer<long>(integerDeserializer);
            RegisterDeserializer<ulong>(integerDeserializer);

            var nullableIntegerDeserializer = new DefaultNullableIntegerDeserializer();
            RegisterDeserializer<short?>(nullableIntegerDeserializer);
            RegisterDeserializer<ushort?>(nullableIntegerDeserializer);
            RegisterDeserializer<int?>(nullableIntegerDeserializer);
            RegisterDeserializer<uint?>(nullableIntegerDeserializer);
            RegisterDeserializer<long?>(nullableIntegerDeserializer);
            RegisterDeserializer<ulong?>(nullableIntegerDeserializer);
        }
    }
}