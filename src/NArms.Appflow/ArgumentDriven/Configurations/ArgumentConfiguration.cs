namespace NArms.Appflow.ArgumentDriven.Configurations
{
    public abstract class ArgumentConfiguration
    {
        public ArgumentType ArgumentType { get; private set; }
        public string Name { get; private set; }

        protected ArgumentConfiguration(ArgumentType argumentType, string name)
        {
            ArgumentType = argumentType;
            Name = name;
        }

        public abstract object GetValue(string value);
    }
}