namespace NArms.Grenade.Tests.Services
{
    using Depedencies;

    public class ServiceBravo : IServiceBravo
    {
        public ServiceBravo(IDependency3 dependency3)
        {
            Dependency3 = dependency3;
        }

        public IDependency3 Dependency3 { get; private set; }
    }
}