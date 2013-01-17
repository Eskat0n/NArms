namespace NArms.Surgery.Tests.Dynamic
{
    using NUnit.Framework;
    using Surgery.Static;

    [TestFixture]
    public class StaticProxyTests
    {
        private class SurgeryTarget
        {
            private readonly string _value;

            public SurgeryTarget()
            {
                _value = "TestField";
                AutoProperty = "TestProperty";
            }

            private string AutoProperty { get; set; }

            public string GetValue()
            {
                return _value;
            }

            public string GetAutoProperty()
            {
                return AutoProperty;
            }
        }

        private class Proxy
        {
            public virtual string _value { get; set; }

            public virtual string AutoProperty { get; set; }
        }

        [Test]
        public void CanReadPrivateFieldViaStaticProxy()
        {
            var proxy = new SurgeryTarget().Dissect<Proxy>();
            var value = proxy._value;

            Assert.AreEqual("TestField", value);
        }
    }
}