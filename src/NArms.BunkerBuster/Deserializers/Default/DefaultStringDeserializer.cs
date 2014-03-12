namespace NArms.Config.Deserializers.Default
{
    internal class DefaultStringDeserializer : IDeserializer
    {
        public object Deserialize(string value)
        {
            return value;
        }
    }
}