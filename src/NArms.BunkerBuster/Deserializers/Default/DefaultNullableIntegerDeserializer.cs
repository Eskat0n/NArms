namespace NArms.BunkerBuster.Deserializers.Default
{
    internal class DefaultNullableIntegerDeserializer : IDeserializer
    {
        public object Deserialize(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return null;

            long result;
            long.TryParse(value, out result);
            return result;
        }
    }
}