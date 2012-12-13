namespace NArms.Grenade.Tests
{
    using Xunit;

    public class CommonTests
    {
        [Fact]
        public void TestOne()
        {
            var container = new Container();

            container.Register(Link.Between<ITest>().And<Test>());
            container.Register(Link.Between<ITest1>().And<Test1>());
            container.Register(Link.Between<IDep1>().And<Dep1>());
            container.Register(Link.Between<IDep2>().And<Dep2>());

            var resolve = container.Resolve<ITest>();
        }
    }

    public interface ITest1
    {
        IDep3 Dep3 { get; }
    }

    public interface IDep3
    {
    }

    public class Test1 : ITest1
    {
        public Test1(IDep3 dep3)
        {
            Dep3 = dep3;
        }

        public IDep3 Dep3 { get; private set; }
    }

    public interface IDep2
    {
    }

    public class Dep2 : IDep2
    {
    }

    public class Dep1 : IDep1
    {
    }

    public interface IDep1
    {
    }

    public class Test : ITest
    {
        public Test(IDep1 dep1)
        {
            SetFromCtor = dep1;
        }

        public IDep1 SetFromCtor { get; private set; }
        public IDep2 WillBeSetViaPublicAccess { get; set; }
        public IDep2 WillNotBeSet { get; private set; }
    }

    public interface ITest
    {
    }
}
