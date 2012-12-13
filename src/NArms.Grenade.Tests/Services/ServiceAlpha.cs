namespace NArms.Grenade.Tests.Services
{
    using Depedencies;

    public class ServiceAlpha : IServiceAlpha
    {
        public ServiceAlpha(IDependency1 dependency1)
        {
            SetFromCtor = dependency1;
        }

        public IDependency1 SetFromCtor { get; private set; }
        public IDependency2 WillBeSetViaPublicAccess { get; set; }
        public IDependency2 WillNotBeSet { get; private set; }
    }
}