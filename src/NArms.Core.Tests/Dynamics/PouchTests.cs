using System.Collections.Generic;
using NArms.Dynamics;
using Xunit;

namespace NArms.Core.Dynamics
{
    public class PouchTests
    {
        [Fact]
        public void CanSetAndGetValueOfAnyPropertyByItsName()
        {
            dynamic pouch = new Pouch();

            pouch.Property = 15;
            
            Assert.Equal(15, pouch.Property);
        }

        [Fact]
        public void GettingUnsettedPropertyValueReturnsNull()
        {
            dynamic pouch = new Pouch();

            Assert.Null(pouch.Property);
        }

        [Fact]
        public void CanBeConvertedToDictionary()
        {
            dynamic pouch = new Pouch();

            pouch.Property = "test";
            IDictionary<string, object> dictionary = pouch.ToDictionary();

            Assert.True(dictionary.ContainsKey("Property"));
            Assert.Equal("test", dictionary["Property"]);
        }

        [Fact]
        public void MakingChangesToDictionaryDoNotChangePouchInstance()
        {
            dynamic pouch = new Pouch();

            pouch.Property = "test";
            IDictionary<string, object> dictionary = pouch.ToDictionary();
            dictionary["Property"] = "newTest";

            Assert.True(dictionary.ContainsKey("Property"));
            Assert.Equal("newTest", dictionary["Property"]);
            Assert.Equal("test", pouch.Property);
        }
    }
}