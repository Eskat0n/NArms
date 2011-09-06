using System.Collections;
using System.Collections.Generic;
using NArms.Appflow.ArgumentDriven.Configurations;

namespace NArms.Appflow.ArgumentDriven
{
    public class ArgumentsConfigurationCollection : IEnumerable<ArgumentConfiguration>
    {
        public IEnumerable<ArgumentConfiguration> Configurations { get; private set; }

        public ArgumentsConfigurationCollection(IEnumerable<ArgumentConfiguration> configurations)
        {
            Configurations = configurations;
        }

        public IEnumerator<ArgumentConfiguration> GetEnumerator()
        {
            return Configurations.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}