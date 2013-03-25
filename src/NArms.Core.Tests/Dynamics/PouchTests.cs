using System.Collections.Generic;
using NArms.Dynamics;

namespace NArms.Core.Dynamics
{
    using NUnit.Framework;

    public class PouchTests
    {
        [Test]
        public void CanSetAndGetValueOfAnyPropertyByItsName()
        {
            dynamic pouch = new Pouch();

            pouch.Property = 15;
            
            Assert.AreEqual(15, pouch.Property);
        }

        [Test]
        public void GettingUnsettedPropertyValueReturnsNull()
        {
            dynamic pouch = new Pouch();

            Assert.Null(pouch.Property);
        }

        [Test]
        public void CanBeConvertedToDictionary()
        {
            dynamic pouch = new Pouch();

            pouch.Property = "test";
            IDictionary<string, object> dictionary = pouch.ToDictionary();

            Assert.True(dictionary.ContainsKey("Property"));
            Assert.AreEqual("test", dictionary["Property"]);
        }

        [Test]
        public void MakingChangesToDictionaryDoNotChangePouchInstance()
        {
            dynamic pouch = new Pouch();

            pouch.Property = "test";
            IDictionary<string, object> dictionary = pouch.ToDictionary();
            dictionary["Property"] = "newTest";

            Assert.True(dictionary.ContainsKey("Property"));
            Assert.AreEqual("newTest", dictionary["Property"]);
            Assert.AreEqual("test", pouch.Property);
        }
    }
}