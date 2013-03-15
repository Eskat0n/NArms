namespace NArms.BunkerBuster.Deserializers.Default
{
    internal class DefaultIntegerDeserializer : IDeserializer
    {
        public object Deserialize(string value)
        {
            long result;
            long.TryParse(value, out result);
            return result;
        }
    }
}