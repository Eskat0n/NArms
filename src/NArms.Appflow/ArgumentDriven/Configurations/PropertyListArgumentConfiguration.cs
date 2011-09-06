using System;

namespace NArms.Appflow.ArgumentDriven.Configurations
{
    public class PropertyListArgumentConfiguration : ArgumentConfiguration
    {
        public PropertyListArgumentConfiguration(string name)
            : base(ArgumentType.PropertyList, name)
        {
        }

        public override object GetValue(string value)
        {
            throw new NotImplementedException();
        }
    }
}