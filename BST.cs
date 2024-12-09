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
                return new BSTFind<T>();
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
    }
}