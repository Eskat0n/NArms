using NArms.Surgery.Dynamic;
using Xunit;

namespace NArms.Surgery.Tests.Dynamic
{
    public class DynamicProxyTests
    {
        private class Stub
        {
            private readonly string _value = "TestField";
            private string AutoProperty { get; set; }

            public Stub()
            {
                AutoProperty = "TestProperty";
            }

            public string GetValue()
            {
                return _value;
            }

            public string GetAutoProperty()
            {
                return AutoProperty;
            }
        }

        [Fact]
        public void CanReadPrivateFieldViaProxy()
        {
            var proxy = new Stub().Dissect();
            string value = proxy._value;

            Assert.Equal("TestField", value);
        }

        [Fact]
        public void CanWritePrivateFieldViaProxy()
        {
            var stub = new Stub();
            var proxy = stub.Dissect();

            proxy._value = "NewTestField";

            Assert.Equal("NewTestField", stub.GetValue());
        }

        [Fact]
        public void CanReadPrivateAutoPropertyViaProxy()
        {
            var proxy = new Stub().Dissect();
            string value = proxy.AutoProperty;

            Assert.Equal("TestProperty", value);
        }

        [Fact]
        public void CanWritePrivateAutoPropertyViaProxy()
        {
            var stub = new Stub();
            var proxy = stub.Dissect();

            proxy.AutoProperty = "NewTestProperty";

            Assert.Equal("NewTestProperty", stub.GetAutoProperty());
        }
    }
}