namespace NArms.Appflow
{
    public abstract class AppflowBase
    {
        protected readonly string[] Arguments;

        protected AppflowBase(string[] arguments)
        {
            Arguments = arguments;
        }

        public abstract void Run();
    }
}