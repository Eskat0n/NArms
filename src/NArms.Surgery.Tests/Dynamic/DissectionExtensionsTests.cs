namespace NArms.Surgery.Tests.Dynamic
{
    using NUnit.Framework;
    using Surgery.Dynamic;

    [TestFixture]
    public class DissectionExtensionsTests
    {
        private class SurgeryTarget
        {
        }

        [Test]
        public void CallToDissectionReturnsProxyWithCorrectTarget()
        {
            var stub = new SurgeryTarget();
            object proxy = stub.Dissect();

            Assert.IsInstanceOf<DynamicProxy<SurgeryTarget>>(proxy);
        }
    }
}