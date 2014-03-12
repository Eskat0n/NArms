namespace NArms.Config
{
    public interface IDeserializer
    {
        object Deserialize(string value);
    }
}