using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace AlgorithmsDataStructures2.Tests
{
    public class BSTTests
    {
        [Fact]
        public void FindNodeByKey_ShouldIndicateToLeftAndReturnFalse_WhenKeyIsLessThanParent()
        {
            BSTNode<int> rootNode = new BSTNode<int>(0, 0, null);
            List<int> values = new List<int> { 3, 4, 5 };
            BST<int> tree = new BST<int>(rootNode);
            foreach (var value in values)
            {
                tree.AddKeyValue(value, value);
            }

            const int expectedParentValue = 3;

            BSTFind<int> findRes = tree.FindNodeByKey(2);

            findRes.NodeHasKey.Should().BeFalse();
            findRes.ToLeft.Should().BeTrue();
            findRes.Node.NodeKey.Should().Be(expectedParentValue);
        }

        [Fact]
        public void FindNodeByKey_ShouldIndicateToRightAndReturnFalse_WhenKeyIsGreaterThanParent()
        {
            BSTNode<int> rootNode = new BSTNode<int>(2, 2, null);
            List<int> values = new List<int> { 3, 4, 5 };
            BST<int> tree = new BST<int>(rootNode);
            foreach (var value in values)
            {
                tree.AddKeyValue(value, value);
            }

            const int expectedParentValue = 5;

            BSTFind<int> findRes = tree.FindNodeByKey(6);

            findRes.NodeHasKey.Should().BeFalse();
            findRes.ToLeft.Should().BeFalse();
            findRes.Node.NodeKey.Should().Be(expectedParentValue);
        }

        [Fact]
        public void FindNodeByKey_ShouldReturnNodeAndTrue_WhenKeyExists()
        {
            BSTNode<int> rootNode = new BSTNode<int>(2, 2, null);
            List<int> values = new List<int> { 3, 4, 5 };
            BST<int> tree = new BST<int>(rootNode);
            foreach (var value in values)
            {
                tree.AddKeyValue(value, value);
            }

            const int expectedValue = 4;

            BSTFind<int> findRes = tree.FindNodeByKey(4);

            findRes.NodeHasKey.Should().BeTrue();
            findRes.Node.NodeKey.Should().Be(expectedValue);
        }

        [Fact]
        public void AddKeyValue_ShouldAddNodeToLeft_WhenKeyIsLessThanParent()
        {
            BSTNode<int> rootNode = new BSTNode<int>(4, 4, null);
            BST<int> tree = new BST<int>(rootNode);
            const int expectedValue = 2;

            bool isAdded = tree.AddKeyValue(2, 2);

            isAdded.Should().BeTrue();
            rootNode.LeftChild.NodeKey.Should().Be(expectedValue);
        }

        [Fact]
        public void AddKeyValue_ShouldAddNodeToRight_WhenKeyIsGreaterThanParent()
        {
            BSTNode<int> rootNode = new BSTNode<int>(4, 4, null);
            BST<int> tree = new BST<int>(rootNode);
            const int expectedValue = 6;

            bool isAdded = tree.AddKeyValue(6, 6);

            isAdded.Should().BeTrue();
            rootNode.RightChild.NodeKey.Should().Be(expectedValue);
        }

        [Fact]
        public void AddKeyValue_ShouldNotModifyTree_WhenKeyAlreadyExists()
        {
            BSTNode<int> rootNode = new BSTNode<int>(6, 6, null);
            BST<int> tree = new BST<int>(rootNode);

            bool isAdded = tree.AddKeyValue(6, 6);

            isAdded.Should().BeFalse();
            rootNode.RightChild.Should().BeNull();
            rootNode.LeftChild.Should().BeNull();
        }

        [Fact]
        public void FinMinMax_ShouldReturnMinimumKey()
        {
            BSTNode<int> rootNode = new BSTNode<int>(2, 2, null);
            List<int> values = new List<int> { 1, 3, 4, 5 };
            BST<int> tree = new BST<int>(rootNode);
            foreach (var value in values)
            {
                tree.AddKeyValue(value, value);
            }

            const int expectedValue = 1;

            BSTNode<int> minKeyNode = tree.FinMinMax(rootNode, false);

            minKeyNode.NodeKey.Should().Be(expectedValue);
        }

        [Fact]
        public void FinMinMax_ShouldReturnMaximumKey()
        {
            BSTNode<int> rootNode = new BSTNode<int>(2, 2, null);
            List<int> values = new List<int> { 3, 4, 5 };
            BST<int> tree = new BST<int>(rootNode);
            foreach (var value in values)
            {
                tree.AddKeyValue(value, value);
            }

            const int expectedValue = 5;

            BSTNode<int> maxKeyNode = tree.FinMinMax(rootNode, true);

            maxKeyNode.NodeKey.Should().Be(expectedValue);
        }

        [Fact]
        public void FinMinMax_ShouldReturnMinimumKey_FromSubtree()
        {
            BSTNode<int> rootNode = new BSTNode<int>(4, 4, null);
            List<int> values = new List<int> { 1, 2, 3, 5, 6, 7 };
            BST<int> tree = new BST<int>(rootNode);
            foreach (var value in values)
            {
                tree.AddKeyValue(value, value);
            }

            const int expectedValue = 3;
            BSTFind<int> findRes = tree.FindNodeByKey(2);

            BSTNode<int> maxKeyNode = tree.FinMinMax(findRes.Node, true);

            maxKeyNode.NodeKey.Should().Be(expectedValue);
        }   

        [Fact]
        public void FinMinMax_ShouldReturnMaximumKey_FromSubtree()
        {
            BSTNode<int> rootNode = new BSTNode<int>(4, 4, null);
            List<int> values = new List<int> { 1, 2, 3, 5, 6, 7 };
            BST<int> tree = new BST<int>(rootNode);
            foreach (var value in values)
            {
                tree.AddKeyValue(value, value);
            }

            const int expectedValue = 6;
            BSTFind<int> findRes = tree.FindNodeByKey(6);

            BSTNode<int> maxKeyNode = tree.FinMinMax(findRes.Node, false);

            maxKeyNode.NodeKey.Should().Be(expectedValue);
        }

        [Fact]
        public void DeleteNodeByKey_ShouldRemoveNodeAndReturnTrue_WhenNodeExists()
        {
            BSTNode<int> rootNode = new BSTNode<int>(4, 4, null);
            List<int> values = new List<int> { 1, 2, 3, 5 };
            BST<int> tree = new BST<int>(rootNode);
            foreach (var value in values)
            {
                tree.AddKeyValue(value, value);
            }

            const int keyToRemove = 1;
            rootNode.LeftChild.NodeKey.Should().Be(keyToRemove);

            bool isDeleted = tree.DeleteNodeByKey(keyToRemove);

            isDeleted.Should().BeTrue();
            rootNode.LeftChild.NodeKey.Should().NotBe(keyToRemove);
        }
    }
}