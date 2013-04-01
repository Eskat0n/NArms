namespace NArms.Grenade.Tests
{
    using NUnit.Framework;
    using Services;
    using Services.Depedencies;

    [TestFixture]
    public class BasicResolvingTests
    {
        private readonly Container _container;

        public BasicResolvingTests()
        {
            _container = new Container();
        }

        [Test]
        public void ResolvableServiceRegistrationTest()
        {
            _container.Register(Link.Between<IServiceAlpha>().And<ServiceAlpha>());            
            _container.Register(Link.Between<IDependency1>().And<Dependency1>());
            _container.Register(Link.Between<IDependency2>().And<Dependency2>());

            var service = _container.Resolve<IServiceAlpha>() as ServiceAlpha;

            Assert.NotNull(service);
            Assert.IsInstanceOf<Dependency1>(service.SetFromCtor);
            Assert.IsInstanceOf<Dependency2>(service.WillBeSetViaPublicAccess);
            Assert.Null(service.WillNotBeSet);
        }

        [Test]
        public void UnresolvableServiceRegistrationTest()
        {
            
        }
    }
}
