using NArms.Collections;

namespace NArms.Core.Collections
{
    using NUnit.Framework;

    public class CompositeKeyTests
    {
        #region CompositeKey with two generic parameters

        [Test]
        public void ComparisonOfTwoCompositeKeysForTwoValuesEqualValuesCorrect()
        {
            var firstCompositeKey = CompositeKey.Create("Test1", "Test2");
            var secondCompositeKey = CompositeKey.Create("Test1", "Test2");

            Assert.AreEqual(firstCompositeKey, secondCompositeKey);            
        }

        [Test]
        public void ComparisonOfTwoCompositeKeysForTwoValuesOneNonEqualValueCorrect()
        {
            var firstCompositeKey = CompositeKey.Create("Test1", "Test2");
            var secondCompositeKey = CompositeKey.Create("Test1", "Test3");

            Assert.AreNotEqual(firstCompositeKey, secondCompositeKey);            
        }

        [Test]
        public void ComparisonOfTwoCompositeKeysForTwoValuesNonEqualValuesCorrect()
        {
            var firstCompositeKey = CompositeKey.Create("Test1", "Test2");
            var secondCompositeKey = CompositeKey.Create("Test3", "Test4");

            Assert.AreNotEqual(firstCompositeKey, secondCompositeKey);            
        }

        #endregion
        
        #region CompositeKey with three generic parameters

        [Test]
        public void ComparisonOfTwoCompositeKeysForThreeValuesEqualValuesCorrect()
        {
            var firstCompositeKey = CompositeKey.Create("Test1", "Test2", "Test3");
            var secondCompositeKey = CompositeKey.Create("Test1", "Test2", "Test3");

            Assert.AreEqual(firstCompositeKey, secondCompositeKey);            
        }

        [Test]
        public void ComparisonOfTwoCompositeKeysForThreeValuesOneNonEqualValueCorrect()
        {
            var firstCompositeKey = CompositeKey.Create("Test1", "Test2", "Test3");
            var secondCompositeKey = CompositeKey.Create("Test1", "Test2", "Test4");

            Assert.AreNotEqual(firstCompositeKey, secondCompositeKey);            
        }

        [Test]
        public void ComparisonOfTwoCompositeKeysForThreeValuesNonEqualValuesCorrect()
        {
            var firstCompositeKey = CompositeKey.Create("Test1", "Test2", "Test3");
            var secondCompositeKey = CompositeKey.Create("Test4", "Test5", "Test6");

            Assert.AreNotEqual(firstCompositeKey, secondCompositeKey);            
        }

        #endregion
    }
}