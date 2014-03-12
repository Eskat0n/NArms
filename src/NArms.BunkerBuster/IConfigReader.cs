namespace NArms.Config
{
    public interface IConfigReader
    {
        void ReadTo(object configInstance);
    }
}