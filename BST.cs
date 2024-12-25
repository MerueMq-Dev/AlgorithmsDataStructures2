using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsDataStructures2
{
    public class BSTNode<T>
    {
        public int level;
        public int NodeKey;
        public T NodeValue;
        public BSTNode<T> Parent;
        public BSTNode<T> LeftChild;
        public BSTNode<T> RightChild;

        public BSTNode(int key, T val, BSTNode<T> parent, int nodeLevel)
        {
            level = nodeLevel;
            NodeKey = key;
            NodeValue = val;
            Parent = parent;
            LeftChild = null;
            RightChild = null;
        }
        
        public BSTNode(int key, T val, BSTNode<T> parent)
        {
            NodeKey = key;
            NodeValue = val;
            Parent = parent;
            LeftChild = null;
            RightChild = null;
        }
    }

    
    public class BSTFind<T>
    {
        public BSTNode<T> Node;

        public bool NodeHasKey;

        public bool ToLeft;

        public BSTFind()
        {
            Node = null;
        }

        public BSTFind(BSTNode<T> node, bool nodeHasKey, bool toLeft = false)
        {
            Node = node;
            NodeHasKey = nodeHasKey;
            ToLeft = toLeft;
        }
    }

    public class BST<T>
    {
        BSTNode<T> Root;

        public BST(BSTNode<T> node)
        {
            Root = node;
        }

        public BSTFind<T> FindNodeByKey(int key)
        {
            if (Root == null)
            {
                return new BSTFind<T>(null, false, false);
            }

            BSTNode<T> currentNode = Root;
            BSTNode<T> prevNode = Root;
            while (currentNode != null)
            {
                if (key == currentNode.NodeKey)
                    return new BSTFind<T>(currentNode, true);

                prevNode = currentNode;

                if (key > currentNode.NodeKey)
                {
                    currentNode = currentNode.RightChild;
                    continue;
                }

                if (key < currentNode.NodeKey)
                {
                    currentNode = currentNode.LeftChild;
                }
            }

            bool toLeft = prevNode.NodeKey > key;
            return new BSTFind<T>(prevNode, false, toLeft);
        }

        public bool AddKeyValue(int key, T val)
        {
            if (Root == null)
            {
                Root = new BSTNode<T>(key, val, null, 0);
                return true;
            }

            BSTNode<T> currentNode = Root;
            while (currentNode != null)
            {
                if (key == currentNode.NodeKey)
                    break;

                if (key > currentNode.NodeKey)
                {
                    if (currentNode.RightChild == null)
                    {
                        currentNode.RightChild = new BSTNode<T>(key, val, currentNode,
                            currentNode.level + 1);
                        return true;
                    }

                    currentNode = currentNode.RightChild;
                    continue;
                }

                if (key < currentNode.NodeKey)
                {
                    if (currentNode.LeftChild == null)
                    {
                        currentNode.LeftChild = new BSTNode<T>(key, val,
                            currentNode, currentNode.level + 1);
                        return true;
                    }

                    currentNode = currentNode.LeftChild;
                }
            }

            return false;
        }

        public BSTNode<T> FinMinMax(BSTNode<T> FromNode, bool FindMax)
        {
            if (FromNode == null)
            {
                return null;
            }

            if (FindMax)
            {
                for (BSTNode<T> currentNode = FromNode;; currentNode = currentNode.RightChild)
                {
                    if (currentNode.RightChild == null)
                    {
                        return currentNode;
                    }
                }
            }

            for (BSTNode<T> currentNode = FromNode;; currentNode = currentNode.LeftChild)
            {
                if (currentNode.LeftChild == null)
                {
                    return currentNode;
                }
            }
        }


        public bool DeleteNodeByKey(int key)
        {
            BSTFind<T> findRes = FindNodeByKey(key);
            if (!findRes.NodeHasKey || findRes.Node == null)
                return false;

            BSTNode<T> nodeToDelete = findRes.Node;

            if (nodeToDelete.LeftChild == null || nodeToDelete.RightChild == null)
            {
                ReplaceNode(nodeToDelete, nodeToDelete.LeftChild ?? nodeToDelete.RightChild);
            }
            else
            {
                BSTNode<T> successor = FinMinMax(nodeToDelete.RightChild, false);
                nodeToDelete.NodeKey = successor.NodeKey;
                nodeToDelete.NodeValue = successor.NodeValue;
                ReplaceNode(successor, successor.RightChild);
            }

            return true;
        }

        public bool IsIdentical(BST<T> compareTo)
        {
            if (compareTo.Count() != Count())
                return false;

            return IsIdentical(Root, compareTo.Root);
        }

        private bool IsIdentical(BSTNode<T> node, BSTNode<T> compareTo)
        {
            if (node == null && compareTo == null)
                return true;

            if (node?.NodeKey != compareTo?.NodeKey)
                return false;

            return IsIdentical(node.LeftChild, compareTo.LeftChild) &&
                   IsIdentical(node.RightChild, compareTo.RightChild);
        }

        private void ReplaceNode(BSTNode<T> node, BSTNode<T> newNode)
        {
            if (node.Parent == null)
            {
                Root = newNode;
            }
            else if (node.Parent.LeftChild == node)
            {
                node.Parent.LeftChild = newNode;
            }
            else
            {
                node.Parent.RightChild = newNode;
            }

            if (newNode != null)
            {
                newNode.Parent = node.Parent;
            }
        }


        public int Count()
        {
            return Count(Root);
        }

        private int Count(BSTNode<T> node)
        {
            if (node == null)
                return 0;

            return 1 + Count(node.LeftChild) + Count(node.RightChild);
        }

        public List<List<BSTNode<T>>> GetPathsWithLength(int pathLength)
        {
            List<List<BSTNode<T>>> allPaths = new List<List<BSTNode<T>>>();
            if (Root == null)
                return allPaths;

            GetPathsWithLength(pathLength, Root, new List<BSTNode<T>>(), allPaths);
            return allPaths;
        }

        private void GetPathsWithLength(int pathLength, BSTNode<T> node,
            List<BSTNode<T>> currentPath, List<List<BSTNode<T>>> allPaths)
        {
            if (node == null)
                return;

            currentPath.Add(node);

            if (node.LeftChild == null && node.RightChild == null && currentPath.Count == pathLength)
            {
                allPaths.Add(new List<BSTNode<T>>(currentPath));
            }
            else
            {
                GetPathsWithLength(pathLength, node.LeftChild, currentPath, allPaths);
                GetPathsWithLength(pathLength, node.RightChild, currentPath, allPaths);
            }

            currentPath.RemoveAt(currentPath.Count - 1);
        }

        public List<List<BSTNode<T>>> GetMaxSumPaths()
        {
            List<List<BSTNode<T>>> allPaths = GetAllPaths();
            List<List<BSTNode<T>>> maxPaths = new List<List<BSTNode<T>>>();
            int maxPathValue = 0;
            for (int i = 0; i < allPaths.Count; i++)
            {
                int count = 0;
                for (int j = 0; j < allPaths[i].Count; j++)
                {
                    count += allPaths[i][j].NodeKey;
                }

                if (count > maxPathValue)
                {
                    maxPathValue = count;
                    maxPaths = new List<List<BSTNode<T>>>() { allPaths[i] };
                    continue;
                }

                if (count == maxPathValue)
                {
                    maxPathValue = count;
                    maxPaths.Add(allPaths[i]);
                }
            }

            return maxPaths;
        }

        public List<List<BSTNode<T>>> GetAllPaths()
        {
            if (Root == null)
                return new List<List<BSTNode<T>>>();
            List<List<BSTNode<T>>> result = new List<List<BSTNode<T>>>();
            GetAllPaths(Root, new List<BSTNode<T>>(), result);
            return result;
        }

        private void GetAllPaths(BSTNode<T> node,
            List<BSTNode<T>> currentPath, List<List<BSTNode<T>>> allPaths)
        {
            if (node == null)
                return;

            currentPath.Add(node);

            if (node.LeftChild == null && node.RightChild == null)
            {
                allPaths.Add(new List<BSTNode<T>>(currentPath));
            }
            else
            {
                GetAllPaths(node.LeftChild, currentPath, allPaths);
                GetAllPaths(node.RightChild, currentPath, allPaths);
            }

            currentPath.RemoveAt(currentPath.Count - 1);
        }


        public List<BSTNode> WideAllNodes()
        {
            if (Root == null)
                return new List<BSTNode>();

            Queue<BSTNode<T>> queue = new Queue<BSTNode<T>>();
            List<BSTNode> allNodes = new List<BSTNode>();

            queue.Enqueue(Root);

            while (queue.Count > 0)
            {
                BSTNode<T> currentNode = queue.Dequeue();
                allNodes.Add(new BSTNode(currentNode.NodeKey, null));

                if (currentNode.LeftChild != null)
                    queue.Enqueue(currentNode.LeftChild);

                if (currentNode.RightChild != null)
                    queue.Enqueue(currentNode.RightChild);
            }

            return allNodes;
        }
        
        public List<BSTNode> DeepAllNodes(int processingOrder)
        {
            if (Root == null)
                return new List<BSTNode>();

            return DeepAllNodes(processingOrder, Root);
        }

        private List<BSTNode> DeepAllNodes(int processingOrder, BSTNode<T> node)
        {
            if (node == null)
                return new List<BSTNode>();

            List<BSTNode> allNodes = new List<BSTNode>();
            if (processingOrder == 0)
            {
                List<BSTNode> leftNodes = DeepAllNodes(processingOrder, node.LeftChild);
                allNodes.AddRange(leftNodes);

                allNodes.Add(new BSTNode(node.NodeKey, null));

                List<BSTNode> rightNodes = DeepAllNodes(processingOrder, node.RightChild);
                allNodes.AddRange(rightNodes);
                return allNodes;
            }

            if (processingOrder == 1)
            {
                List<BSTNode> leftNodes = DeepAllNodes(processingOrder, node.LeftChild);
                allNodes.AddRange(leftNodes);

                List<BSTNode> rightNodes = DeepAllNodes(processingOrder, node.RightChild);
                allNodes.AddRange(rightNodes);
                
                allNodes.Add(new BSTNode(node.NodeKey, null));

                return allNodes;
            }
            if (processingOrder == 2)
            {
                allNodes.Add(new BSTNode(node.NodeKey, null));
                
                List<BSTNode> leftNodes = DeepAllNodes(processingOrder, node.LeftChild);
                allNodes.AddRange(leftNodes);

                List<BSTNode> rightNodes = DeepAllNodes(processingOrder, node.RightChild);
                allNodes.AddRange(rightNodes);
                
                return allNodes;
            }
            
            return allNodes;
        }
        
        public void InvertTree()
        {

            InvertTree(Root);
        }

        private void InvertTree(BSTNode<T> currentNode)
        {
            if (currentNode == null)
                return;

            (currentNode.LeftChild, currentNode.RightChild) = (currentNode.RightChild, currentNode.LeftChild);
            InvertTree(currentNode.LeftChild);
            InvertTree(currentNode.RightChild);
        }

        public int FindLevelWithMaxSum()
        {
            Queue<BSTNode<T>> queue = new Queue<BSTNode<T>>();
            queue.Enqueue(Root);
            int maxLevelIndex = FindMaxLevel() + 1;
            int[] levelsSum = new int[maxLevelIndex];
            
            while (queue.Count > 0)
            {
                BSTNode<T> currentNode = queue.Dequeue();
                levelsSum[currentNode.level] += currentNode.NodeKey;
                
                if (currentNode.RightChild != null)
                    queue.Enqueue(currentNode.RightChild);
                
                if (currentNode.LeftChild != null)
                    queue.Enqueue(currentNode.LeftChild);
            }

            int levelWithMaxSum = -1;
            int maxSum = 0;
            for (int i = 0; i < levelsSum.Length; i++)
            {
                if (maxSum < levelsSum[i])
                {
                    maxSum = levelsSum[i];
                    levelWithMaxSum = i;
                }
            }

            return levelWithMaxSum;
        }

        public int FindMaxLevel()
        {
            if (Root == null)
                return -1;

            return FindMaxLevel(Root);
        }
        
        private int FindMaxLevel(BSTNode<T> node)
        {
            if (node == null)
                return 0;
            
            if (node.LeftChild == null && node.RightChild == null)
                return node.level;

            int maxLevelLeft = FindMaxLevel(node.LeftChild);
            int maxLevelRight = FindMaxLevel(node.LeftChild);
            
            return maxLevelLeft > maxLevelRight ? maxLevelLeft : maxLevelRight;
        }
        
        public void RestoreTree(int[] prefixTraversal,int[] infixTraversal)
        {
            Root = RestoreTree(prefixTraversal, infixTraversal, 0, 0);
        }

        private BSTNode<T> RestoreTree(int[] prefixTraversal, int[] infixTraversal, int index,int level)
        {
            if (infixTraversal.Length == 0)
                return null;
            
            int currentValue = prefixTraversal[index];
            index += 1;
            level += 1;
            
            int rootIndexInInfix = Array.IndexOf(infixTraversal, currentValue);
            
            int[] leftInfix = infixTraversal.Take(rootIndexInInfix).ToArray();
            int[] rightInfix = infixTraversal.Skip(rootIndexInInfix + 1).ToArray();
            
            BSTNode<T> node = new BSTNode<T>(currentValue, default, null, level)
            {
                LeftChild = RestoreTree(prefixTraversal, leftInfix, index, level),
                RightChild = RestoreTree(prefixTraversal, rightInfix, index + leftInfix.Length, level)
            };

            return node;
            
        }
        
        public List<BSTNode<T>> GetAllNodes()
        {
            if (Root == null)
                return new List<BSTNode<T>>();

            Queue<BSTNode<T>> queue = new Queue<BSTNode<T>>();
            List<BSTNode<T>> allNodes = new List<BSTNode<T>>();

            queue.Enqueue(Root);

            while (queue.Count > 0)
            {
                BSTNode<T> currentNode = queue.Dequeue();
                allNodes.Add(currentNode);

                if (currentNode.LeftChild != null)
                    queue.Enqueue(currentNode.LeftChild);

                if (currentNode.RightChild != null)
                    queue.Enqueue(currentNode.RightChild);
            }
            
            return allNodes;
        }
        public void BalanceTree()
        {
            List<BSTNode<T>> allNodes = GetAllNodes();
            BSTNode<T>[] sortedNodes = allNodes.OrderBy(x => x.NodeKey).ToArray();
            int[] keys = new int[allNodes.Count];
            T[] values = new T[allNodes.Count];
            for (int i = 0; i < sortedNodes.Length; i++)
            {   
                keys[i] = sortedNodes[i].NodeKey;
                values[i] = sortedNodes[i].NodeValue;
            }

            GenerateTree(keys, values);
        }
        
        public void GenerateTree(int[] keys, T[] values)
        {
            if (keys == null || keys.Length == 0)
                return;
            
            int rootIndex = keys.Length % 2 == 0 ? keys.Length / 2 - 1 : keys.Length / 2;
            if (Root == null)
            {
                Root = new BSTNode<T>(keys[rootIndex],values[rootIndex], null, 0);
            }

            Root.LeftChild = GenerateTree(keys ,values, Root, 0, rootIndex - 1);
            Root.RightChild = GenerateTree(keys ,values, Root, rootIndex + 1, keys.Length - 1);
        }

        private BSTNode<T> GenerateTree(int[] keys, T[] values, BSTNode<T> parent, int start, int end)
        {
            if (start > end)
                return null;
        
            int rootIndex = (start + end) / 2;
            BSTNode<T> node = new BSTNode<T>(keys[rootIndex], values[rootIndex], parent,
                parent.level + 1);
            node.LeftChild = GenerateTree(keys,values, node, start, rootIndex - 1);
            node.RightChild = GenerateTree(keys,values, node, rootIndex + 1, end);
        
            return node;
        }
    }
}