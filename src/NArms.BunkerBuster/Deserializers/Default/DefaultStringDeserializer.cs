namespace NArms.BunkerBuster.Deserializers.Default
{
    internal class DefaultStringDeserializer : IDeserializer
    {
        public object Deserialize(string value)
        {
            return value;
        }
    }
}