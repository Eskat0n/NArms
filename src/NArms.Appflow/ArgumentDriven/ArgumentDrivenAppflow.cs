using NArms.Appflow.ArgumentDriven.ArgumentsParsers;

namespace NArms.Appflow.ArgumentDriven
{
    public abstract class ArgumentDrivenAppflow : AppflowBase
    {
        protected ArgumentDrivenAppflow(IArgumentParser argumentParser, string[] arguments)
            : base(arguments)
        {
        }
    }
}