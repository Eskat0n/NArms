using NArms.Collections;
using Xunit;

namespace NArms.Core.Collections
{
    public class CompositeKeyTests
    {
        #region CompositeKey with two generic parameters

        [Fact]
        public void ComparisonOfTwoCompositeKeysForTwoValuesEqualValuesCorrect()
        {
            var firstCompositeKey = CompositeKey.Create("Test1", "Test2");
            var secondCompositeKey = CompositeKey.Create("Test1", "Test2");

            Assert.Equal(firstCompositeKey, secondCompositeKey);            
        }       
        
        [Fact]
        public void ComparisonOfTwoCompositeKeysForTwoValuesOneNonEqualValueCorrect()
        {
            var firstCompositeKey = CompositeKey.Create("Test1", "Test2");
            var secondCompositeKey = CompositeKey.Create("Test1", "Test3");

            Assert.NotEqual(firstCompositeKey, secondCompositeKey);            
        }
        
        [Fact]
        public void ComparisonOfTwoCompositeKeysForTwoValuesNonEqualValuesCorrect()
        {
            var firstCompositeKey = CompositeKey.Create("Test1", "Test2");
            var secondCompositeKey = CompositeKey.Create("Test3", "Test4");

            Assert.NotEqual(firstCompositeKey, secondCompositeKey);            
        }

        #endregion
        
        #region CompositeKey with three generic parameters

        [Fact]
        public void ComparisonOfTwoCompositeKeysForThreeValuesEqualValuesCorrect()
        {
            var firstCompositeKey = CompositeKey.Create("Test1", "Test2", "Test3");
            var secondCompositeKey = CompositeKey.Create("Test1", "Test2", "Test3");

            Assert.Equal(firstCompositeKey, secondCompositeKey);            
        }       
        
        [Fact]
        public void ComparisonOfTwoCompositeKeysForThreeValuesOneNonEqualValueCorrect()
        {
            var firstCompositeKey = CompositeKey.Create("Test1", "Test2", "Test3");
            var secondCompositeKey = CompositeKey.Create("Test1", "Test2", "Test4");

            Assert.NotEqual(firstCompositeKey, secondCompositeKey);            
        }
        
        [Fact]
        public void ComparisonOfTwoCompositeKeysForThreeValuesNonEqualValuesCorrect()
        {
            var firstCompositeKey = CompositeKey.Create("Test1", "Test2", "Test3");
            var secondCompositeKey = CompositeKey.Create("Test4", "Test5", "Test6");

            Assert.NotEqual(firstCompositeKey, secondCompositeKey);            
        }

        #endregion
    }
}