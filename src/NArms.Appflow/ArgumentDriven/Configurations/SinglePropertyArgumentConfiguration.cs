using System;

namespace NArms.Appflow.ArgumentDriven.Configurations
{
    public class SinglePropertyArgumentConfiguration : ArgumentConfiguration
    {
        public SinglePropertyArgumentConfiguration(string name)
            : base(ArgumentType.SingleProperty, name)
        {
        }

        public override object GetValue(string value)
        {
            throw new NotImplementedException();
        }
    }
}