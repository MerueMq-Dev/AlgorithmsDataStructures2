using FluentAssertions;
using Xunit;

namespace AlgorithmsDataStructures2.Tests
{
    public class aBSTTests
    {
        [Fact]
        public void AddKey_ShouldAddKeyToTheTreeAndTreeShouldNotContainNulls()
        {
            aBST tree = new aBST(1);
            int firstKeyIndex = tree.AddKey(2);
            int secondKeyIndex = tree.AddKey(3);
            int thirdKeyIndex = tree.AddKey(1);

            firstKeyIndex.Should().Be(0);
            secondKeyIndex.Should().Be(2);
            thirdKeyIndex.Should().Be(1);
            tree.Tree.Should().NotContainNulls();
        }
        
        [Fact]
        public void FindKeyIndex_ShouldReturnKeyIndexInTheTree()
        {
            aBST tree = new aBST(2);
            tree.AddKey(2);
            int keyIndex = tree.AddKey(3);
            tree.AddKey(4);
            
            int? foundKeyIndex = tree.FindKeyIndex(3);
            
            foundKeyIndex.Should().Be(keyIndex);
        }
    }
}