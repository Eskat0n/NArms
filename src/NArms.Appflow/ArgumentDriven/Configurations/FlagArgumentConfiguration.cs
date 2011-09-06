using System;

namespace NArms.Appflow.ArgumentDriven.Configurations
{
    public class FlagArgumentConfiguration : ArgumentConfiguration
    {
        public FlagArgumentConfiguration(string name) 
            : base(ArgumentType.Flag, name)
        {
        }

        public override object GetValue(string value)
        {
            if (value == null)
                return false;
            if (value == string.Empty)
                return true;

            throw new FormatException();
        }
    }
}