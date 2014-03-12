namespace NArms.Config
{
    using Readers;

    public abstract class ConfigBase
    {
        private static IConfigReader _configReader = new DefaultConfigReader();

        protected ConfigBase()
        {
            ConfigReader.ReadTo(this);
        }

        public static IConfigReader ConfigReader
        {
            get
            {
                return _configReader;
            }
            set
            {
                if (value == null)
                    return;

                _configReader = value;
            }
        }
    }
}
