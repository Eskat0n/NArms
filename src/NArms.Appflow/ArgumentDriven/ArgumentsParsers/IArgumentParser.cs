using System.Collections.Generic;

namespace NArms.Appflow.ArgumentDriven.ArgumentsParsers
{
    public interface IArgumentParser
    {
        IDictionary<string, string> Parse(string[] arguments, ArgumentsConfigurationCollection configuration);
    }
}