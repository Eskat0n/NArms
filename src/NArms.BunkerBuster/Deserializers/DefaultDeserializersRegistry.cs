namespace NArms.Config.Deserializers
{
    using Default;

    internal class DefaultDeserializersRegistry : DeserializersRegistryBase
    {
        internal DefaultDeserializersRegistry()
        {
            RegisterDeserializer<string>(new DefaultStringDeserializer());

            RegisterDeserializer<short>(new DefaultIntegerDeserializer(typeof(short)));
            RegisterDeserializer<ushort>(new DefaultIntegerDeserializer(typeof(ushort)));
            RegisterDeserializer<int>(new DefaultIntegerDeserializer(typeof(int)));
            RegisterDeserializer<uint>(new DefaultIntegerDeserializer(typeof(uint)));
            RegisterDeserializer<long>(new DefaultIntegerDeserializer(typeof(long)));
            RegisterDeserializer<ulong>(new DefaultIntegerDeserializer(typeof(ulong)));

            RegisterDeserializer<short?>(new DefaultNullableIntegerDeserializer(typeof(short?)));
            RegisterDeserializer<ushort?>(new DefaultNullableIntegerDeserializer(typeof(ushort?)));
            RegisterDeserializer<int?>(new DefaultNullableIntegerDeserializer(typeof(int?)));
            RegisterDeserializer<uint?>(new DefaultNullableIntegerDeserializer(typeof(uint?)));
            RegisterDeserializer<long?>(new DefaultNullableIntegerDeserializer(typeof(long?)));
            RegisterDeserializer<ulong?>(new DefaultNullableIntegerDeserializer(typeof(ulong?)));
        }
    }
}