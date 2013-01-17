namespace NArms.Surgery.Tests.Dynamic
{
    using NUnit.Framework;
    using Surgery.Dynamic;

    [TestFixture]
    public class DynamicProxyTests
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

        [Test]
        public void CanReadPrivateFieldViaDynamicProxy()
        {
            var proxy = new SurgeryTarget().Dissect();
            string value = proxy._value;

            Assert.AreEqual("TestField", value);
        }

        [Test]
        public void CanWritePrivateFieldViaDynamicProxy()
        {
            var stub = new SurgeryTarget();
            var proxy = stub.Dissect();

            proxy._value = "NewTestField";

            Assert.AreEqual("NewTestField", stub.GetValue());
        }

        [Test]
        public void CanReadPrivateAutoPropertyViaDynamicProxy()
        {
            var proxy = new SurgeryTarget().Dissect();
            string value = proxy.AutoProperty;

            Assert.AreEqual("TestProperty", value);
        }

        [Test]
        public void CanWritePrivateAutoPropertyViaDynamicProxy()
        {
            var stub = new SurgeryTarget();
            var proxy = stub.Dissect();

            proxy.AutoProperty = "NewTestProperty";

            Assert.AreEqual("NewTestProperty", stub.GetAutoProperty());
        }
    }
}