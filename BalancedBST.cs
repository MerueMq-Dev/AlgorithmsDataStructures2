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
            int heightDifference = CalculateHeight(rootNode.LeftChild) - CalculateHeight(rootNode.RightChild);
            int balanceDifference = Math.Abs(heightDifference);
            return balanceDifference <= 1;
        }

        private int CalculateHeight(BSTNode rootNode)
        {
            if (rootNode == null)
                return 0;
            
            int leftHeight = CalculateHeight(rootNode.LeftChild);
            int rightHeight = CalculateHeight(rootNode.RightChild);
            
            return 1 + Math.Max(leftHeight, rightHeight);
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
    }
}