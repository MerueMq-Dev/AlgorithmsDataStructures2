using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class BSTNode
    {
        public int NodeKey;
        public BSTNode Parent;
        public BSTNode LeftChild;
        public BSTNode RightChild;
        public int Level;

        public BSTNode(int key, BSTNode parent)
        {
            NodeKey = key;
            Parent = parent;
            LeftChild = null;
            RightChild = null;
        }

        public BSTNode(int key, BSTNode parent, int level)
        {
            NodeKey = key;
            Parent = parent;
            Level = level;
        }
    }


    public class BalancedBST
    {
        public BSTNode Root;

        public BalancedBST()
        {
            Root = null;
        }

        public void GenerateTree(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
                return;

            Array.Sort(numbers);
            int rootIndex = numbers.Length % 2 == 0 ? numbers.Length / 2 - 1 : numbers.Length / 2;
            if (Root == null)
            {
                Root = new BSTNode(numbers[rootIndex], null, 0);
            }

            Root.LeftChild = GenerateTree(numbers, Root, 0, rootIndex - 1);
            Root.RightChild = GenerateTree(numbers, Root, rootIndex + 1, numbers.Length - 1);
        }

        private BSTNode GenerateTree(int[] numbers, BSTNode parent, int start, int end)
        {
            if (start > end)
                return null;

            int rootIndex = (start + end) / 2;
            BSTNode node = new BSTNode(numbers[rootIndex], parent, parent.Level + 1);
            node.LeftChild = GenerateTree(numbers, node, start, rootIndex - 1);
            node.RightChild = GenerateTree(numbers, node, rootIndex + 1, end);

            return node;
        }


        public bool IsBalanced(BSTNode rootNode)
        {
            if (rootNode == null)
            {
                return true;
            }

            int leftHeight = CalculateHeight(rootNode.LeftChild);
            int rightHeight = CalculateHeight(rootNode.RightChild);

            if (Math.Abs(leftHeight - rightHeight) <= 1 && IsBalanced(rootNode.LeftChild)
                                                        && IsBalanced(rootNode.RightChild))
                return true;

            return false;
        }

        private int CalculateHeight(BSTNode rootNode)
        {
            if (rootNode == null)
                return 0;

            int leftHeight = CalculateHeight(rootNode.LeftChild);
            int rightHeight = CalculateHeight(rootNode.RightChild);

            return 1 + Math.Max(leftHeight, rightHeight);
        }

        public bool IsValidBST()
        {
            return IsValidBST(Root, null, null);
        }

        private bool IsValidBST(BSTNode node, int? minValue, int? maxValue)
        {
            if (node == null)
                return true;

            if ((minValue.HasValue && node.NodeKey <= minValue.Value) ||
                (maxValue.HasValue && node.NodeKey >= maxValue.Value))
            {
                return false;
            }

            return IsValidBST(node.LeftChild, minValue, node.NodeKey) &&
                   IsValidBST(node.RightChild, node.NodeKey, maxValue);
        }

        public List<BSTNode> WideAllNodes()
        {
            if (Root == null)
                return new List<BSTNode>();

            Queue<BSTNode> queue = new Queue<BSTNode>();
            List<BSTNode> allNodes = new List<BSTNode>();

            queue.Enqueue(Root);

            while (queue.Count > 0)
            {
                BSTNode currentNode = queue.Dequeue();
                allNodes.Add(currentNode);

                if (currentNode.LeftChild != null)
                    queue.Enqueue(currentNode.LeftChild);

                if (currentNode.RightChild != null)
                    queue.Enqueue(currentNode.RightChild);
            }

            return allNodes;
        }

        public bool AddKey(int key)
        {
            if (Root == null)
            {
                Root = new BSTNode(key, null, 0);
                return true;
            }

            BSTNode currentNode = Root;
            while (currentNode != null)
            {
                if (key == currentNode.NodeKey)
                    break;

                if (key > currentNode.NodeKey)
                {
                    if (currentNode.RightChild == null)
                    {
                        currentNode.RightChild = new BSTNode(key, currentNode,
                            currentNode.Level + 1);
                        return true;
                    }

                    currentNode = currentNode.RightChild;
                    continue;
                }

                if (key < currentNode.NodeKey)
                {
                    if (currentNode.LeftChild == null)
                    {
                        currentNode.LeftChild = new BSTNode(key,
                            currentNode, currentNode.Level + 1);
                        return true;
                    }

                    currentNode = currentNode.LeftChild;
                }
            }

            return false;
        }
    }
}