using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace AlgorithmsDataStructures2.Tests
{
    public class SimpleTreeTests
    {
        [Fact]
        public void AddChild_ShouldAddChildNodeToParentNodeOfTree()
        {
            SimpleTreeNode<int> parentNode = new SimpleTreeNode<int>(0, null);
            SimpleTreeNode<int> childNode = new SimpleTreeNode<int>(2, null);
            SimpleTree<int> tree = new SimpleTree<int>(parentNode);

            tree.AddChild(parentNode, childNode);

            parentNode.Children.Count.Should().Be(1);
            parentNode.Children[0].Should().Be(childNode);
            childNode.Parent.Should().Be(parentNode);
        }

        [Fact]
        public void DeleteNode_ShouldDeleteTheNodeAlongWithItsSubtree()
        {
            SimpleTreeNode<int> rootNode = new SimpleTreeNode<int>(0, null);
            SimpleTreeNode<int> firstChild = new SimpleTreeNode<int>(1, null);
            SimpleTreeNode<int> secondChild = new SimpleTreeNode<int>(2, null);
            SimpleTree<int> tree = new SimpleTree<int>(rootNode);
            tree.AddChild(rootNode, firstChild);
            tree.AddChild(rootNode, secondChild);
            
            tree.DeleteNode(secondChild);
            
            rootNode.Children.Count.Should().Be(1);
            rootNode.Children.Should().NotContain(secondChild);
        }


        [Fact]
        public void GetAllNodes_ShouldReturnListOfAllNodesInTheTree()
        {
            SimpleTreeNode<int> rootNode = new SimpleTreeNode<int>(0, null);
            SimpleTreeNode<int> nodeOne = new SimpleTreeNode<int>(1, null);
            SimpleTreeNode<int> nodeTwo = new SimpleTreeNode<int>(2, null);
            SimpleTree<int> tree = new SimpleTree<int>(rootNode);
            tree.AddChild(rootNode, nodeOne);
            tree.AddChild(nodeOne, nodeTwo);
            List<SimpleTreeNode<int>> expectedNodes = new List<SimpleTreeNode<int>> { rootNode, nodeOne, nodeTwo };

            List<SimpleTreeNode<int>> actualNodes = tree.GetAllNodes();

            actualNodes.Should().BeEquivalentTo(expectedNodes);
        }

        [Fact]
        public void FindNodesByValue_ShouldReturnAllNodesInTheTree()
        {
            SimpleTreeNode<int> rootNode = new SimpleTreeNode<int>(0, null);
            SimpleTreeNode<int> nodeOne = new SimpleTreeNode<int>(1, null);
            SimpleTreeNode<int> nodeTwo = new SimpleTreeNode<int>(2, null);
            SimpleTreeNode<int> secondNodeOne = new SimpleTreeNode<int>(1, null);
            SimpleTree<int> tree = new SimpleTree<int>(rootNode);
            tree.AddChild(rootNode, nodeOne);
            tree.AddChild(nodeOne, nodeTwo);
            tree.AddChild(nodeOne, secondNodeOne);
            List<SimpleTreeNode<int>> expectedNodes = new List<SimpleTreeNode<int>> { nodeOne, secondNodeOne };
            
            List<SimpleTreeNode<int>> actualNodes = tree.FindNodesByValue(1);

            actualNodes.Should().BeEquivalentTo(expectedNodes);
        }

        [Fact]
        public void MoveNode_ShouldMoveSubtreeToNewParent()
        {
            SimpleTreeNode<int> rootNode = new SimpleTreeNode<int>(0, null);
            SimpleTreeNode<int> nodeOne = new SimpleTreeNode<int>(1, null);
            SimpleTreeNode<int> nodeTwo = new SimpleTreeNode<int>(2, null);
            SimpleTreeNode<int> nodeThree = new SimpleTreeNode<int>(3, null);
            SimpleTree<int> tree = new SimpleTree<int>(rootNode);
            tree.AddChild(rootNode, nodeOne);
            tree.AddChild(nodeOne, nodeTwo);
            tree.AddChild(nodeOne, nodeThree);
            
            tree.MoveNode(nodeTwo, nodeThree);

            nodeOne.Children.Should().NotContain(nodeTwo);
            nodeThree.Children.Should().Contain(nodeTwo);
        } 
        
        [Fact]
        public void LeafCount_ShouldReturnTwo()
        {
            SimpleTreeNode<int> rootNode = new SimpleTreeNode<int>(0, null);
            SimpleTreeNode<int> nodeOne = new SimpleTreeNode<int>(1, null);
            SimpleTreeNode<int> nodeTwo = new SimpleTreeNode<int>(2, null);
            SimpleTreeNode<int> secondNodeOne = new SimpleTreeNode<int>(1, null);
            SimpleTree<int> tree = new SimpleTree<int>(rootNode);
            tree.AddChild(rootNode, nodeOne);
            tree.AddChild(nodeOne, nodeTwo);
            tree.AddChild(nodeOne, secondNodeOne);
            
            
            tree.LeafCount().Should().Be(2);
        }
        
        
        [Fact]
        public void Count_ShouldReturnFour()
        {
            SimpleTreeNode<int> rootNode = new SimpleTreeNode<int>(0, null);
            SimpleTreeNode<int> nodeOne = new SimpleTreeNode<int>(1, null);
            SimpleTreeNode<int> nodeTwo = new SimpleTreeNode<int>(2, null);
            SimpleTreeNode<int> secondNodeOne = new SimpleTreeNode<int>(1, null);
            SimpleTree<int> tree = new SimpleTree<int>(rootNode);
            tree.AddChild(rootNode, nodeOne);
            tree.AddChild(nodeOne, nodeTwo);
            tree.AddChild(nodeOne, secondNodeOne);

            tree.Count().Should().Be(4);
        }
    }
}