using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class BSTNode<T>
    {
        public int NodeKey;
        public T NodeValue;
        public BSTNode<T> Parent;
        public BSTNode<T> LeftChild;
        public BSTNode<T> RightChild;

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
                Root = new BSTNode<T>(key, val, Root);
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
                        currentNode.RightChild = new BSTNode<T>(key, val, currentNode);
                        return true;
                    }

                    currentNode = currentNode.RightChild;
                }

                if (key < currentNode.NodeKey)
                {
                    if (currentNode.LeftChild == null)
                    {
                        currentNode.LeftChild = new BSTNode<T>(key, val, currentNode);
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
    }
}