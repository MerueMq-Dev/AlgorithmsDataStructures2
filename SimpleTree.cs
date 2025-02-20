using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class SimpleTreeNode<T>
    {
        public int level;
        public T NodeValue;
        public SimpleTreeNode<T> Parent;
        public List<SimpleTreeNode<T>> Children;

        public SimpleTreeNode(T val, SimpleTreeNode<T> parent)
        {
            NodeValue = val;
            Parent = parent;
            Children = null;
        }
    }


    public class SimpleTree<T>
    {
        public SimpleTreeNode<T> Root;

        public SimpleTree(SimpleTreeNode<T> root)
        {
            Root = root;
        }

        public void AddChild(SimpleTreeNode<T> parentNode, SimpleTreeNode<T> newChild)
        {
            if (parentNode == null || newChild == null)
                return;
            if (parentNode.Children == null)
                parentNode.Children = new List<SimpleTreeNode<T>>();

            parentNode.Children.Add(newChild);
            newChild.Parent = parentNode;
            newChild.level = parentNode.level + 1;
        }

        public void DeleteNode(SimpleTreeNode<T> nodeToDelete)
        {
            if (nodeToDelete == null || nodeToDelete.Parent == null)
                return;

            nodeToDelete.Parent.Children.Remove(nodeToDelete);
            nodeToDelete.Parent = null;
            ClearNodeLevels(nodeToDelete);
        }

        public List<SimpleTreeNode<T>> GetAllNodes()
        {
            if (Root == null)
                return new List<SimpleTreeNode<T>>();

            return GetAllNodes(Root);
        }

        private List<SimpleTreeNode<T>> GetAllNodes(SimpleTreeNode<T> treeNode)
        {
            List<SimpleTreeNode<T>> treeNodes = new List<SimpleTreeNode<T>> { treeNode };

            if (treeNode?.Children == null || treeNode.Children.Count == 0)
                return treeNodes;

            foreach (SimpleTreeNode<T> treeNodeChildren in treeNode.Children)
            {
                treeNodes.AddRange(GetAllNodes(treeNodeChildren));
            }

            return treeNodes;
        }

        public void MoveNode(SimpleTreeNode<T> originalNode, SimpleTreeNode<T> newParent)
        {
            if (originalNode == Root || originalNode == null || newParent == null)
                return;

            DeleteNode(originalNode);
            AddChild(newParent, originalNode);
            AssignNodeLevels(originalNode, newParent.level + 1);
        }

        public List<SimpleTreeNode<T>> FindNodesByValue(T val)
        {
            if (Root == null)
                return new List<SimpleTreeNode<T>>();

            return FindNodesByValue(val, Root);
        }

        private List<SimpleTreeNode<T>> FindNodesByValue(T val, SimpleTreeNode<T> treeNode)
        {
            List<SimpleTreeNode<T>> treeNodes = new List<SimpleTreeNode<T>>();
            if (IsEqualTo(treeNode.NodeValue, val))
                treeNodes.Add(treeNode);

            if (treeNode?.Children == null || treeNode.Children.Count == 0)
                return treeNodes;

            foreach (SimpleTreeNode<T> treeNodeChildren in treeNode.Children)
            {
                treeNodes.AddRange(FindNodesByValue(val, treeNodeChildren));
            }

            return treeNodes;
        }

        public int Count()
        {
            if (Root == null)
                return 0;

            return Count(Root);
        }

        private int Count(SimpleTreeNode<T> treeNode)
        {
            int nodeCount = 1;

            if (treeNode?.Children == null || treeNode.Children.Count == 0)
                return nodeCount;

            foreach (SimpleTreeNode<T> treeNodeChildren in treeNode.Children)
            {
                nodeCount += Count(treeNodeChildren);
            }

            return nodeCount;
        }

        public int LeafCount()
        {
            if (Root == null)
                return 0;

            return LeafCount(Root);
        }

        private int LeafCount(SimpleTreeNode<T> treeNode)
        {
            int leafCount = 0;

            if (treeNode?.Children == null || treeNode.Children.Count == 0)
                return leafCount + 1;

            foreach (SimpleTreeNode<T> treeNodeChildren in treeNode.Children)
            {
                leafCount += LeafCount(treeNodeChildren);
            }

            return leafCount;
        }

        private bool IsEqualTo(T value, T compareTo)
        {
            if (typeof(T) != typeof(string))
                return Comparer<T>.Default.Compare(value, compareTo) == 0;

            return string.Compare(value.ToString(), compareTo.ToString(), StringComparison.Ordinal) == 0;
        }

        public void AssignNodeLevels()
        {
            AssignNodeLevels(Root, 0);
        }

        private void AssignNodeLevels(SimpleTreeNode<T> treeNode, int nodeLevel)
        {
            treeNode.level = nodeLevel;

            if (treeNode?.Children == null || treeNode.Children.Count == 0)
                return;

            foreach (SimpleTreeNode<T> treeNodeChildren in treeNode.Children)
            {
                AssignNodeLevels(treeNodeChildren, nodeLevel + 1);
            }
        }

        private void ClearNodeLevels(SimpleTreeNode<T> treeNode)
        {
            treeNode.level = -1;

            if (treeNode?.Children == null || treeNode.Children.Count == 0)
                return;

            foreach (SimpleTreeNode<T> treeNodeChildren in treeNode.Children)
            {
                ClearNodeLevels(treeNodeChildren);
            }
        }

        public bool IsSymmetrical()
        {
            if (Root == null || Root.Children == null || Root.Children.Count == 0)
                return true;

            int count = Root.Children.Count;
            for (int i = 0; i < count / 2; i++)
            {
                if (!IsSymmetrical(Root.Children[i], Root.Children[count - 1 - i]))
                    return false;
            }

            return true;
        }

        private bool IsSymmetrical(SimpleTreeNode<T> leftTreeNode, SimpleTreeNode<T> rightTreeNode)
        {
            if (leftTreeNode == null && rightTreeNode == null)
                return true;

            if (leftTreeNode == null || rightTreeNode == null)
                return false;

            if (!IsEqualTo(leftTreeNode.NodeValue, rightTreeNode.NodeValue))
                return false;

            List<SimpleTreeNode<T>> leftChildren = leftTreeNode.Children;
            List<SimpleTreeNode<T>> rightChildren = rightTreeNode.Children;
            if (leftChildren == null && rightChildren == null)
                return true;

            if (leftChildren == null || rightChildren == null)
                return false;

            if (leftChildren.Count != rightChildren.Count)
                return false;

            int count = leftChildren.Count;
            for (int i = 0; i < count; i++)
            {
                if (!IsSymmetrical(leftChildren[i], rightChildren[count - 1 - i]))
                    return false;
            }

            return true;
        }

        public List<T> EvenTrees()
        {
            List<T> brokenConnections = new List<T>();
            List<SimpleTreeNode<T>> nodesToRemove = new List<SimpleTreeNode<T>>();

            foreach (var child in Root.Children)
            {
                int nodesCount = Count(child);
                if (nodesCount % 2 == 0)
                {
                    brokenConnections.Add(Root.NodeValue);
                    brokenConnections.Add(child.NodeValue);
                    nodesToRemove.Add(child);
                }
            }

            foreach (var node in nodesToRemove)
            {
                DeleteNode(node);
            }

            return brokenConnections;
        }

        public int CountEvenSubTree(SimpleTreeNode<T> node)
        {
            if (node == null)
                return 0;

            int countNode = Count(node);
            int countEvenSubTree = Count(node) % 2 == 0 && countNode != 0 ? 1 : 0;

            if (node.Children == null || node.Children.Count == 0)
                return 0;

            foreach (var child in node.Children)
            {
                countEvenSubTree += CountEvenSubTree(child);
            }

            return countEvenSubTree;
        }
        
        public int FindMaxDistance()
        {
            if (Root == null)
                return 0;

            (SimpleTreeNode<T> farthestNode1, _) = BFS(Root);

            (_, int maxDistance) = BFS(farthestNode1);

            return maxDistance;
        }
        
        private (SimpleTreeNode<T> farthestNode, int maxDistance) BFS(SimpleTreeNode<T> startNode)
        {
            Queue<SimpleTreeNode<T>> queue = new Queue<SimpleTreeNode<T>>();
            Dictionary<SimpleTreeNode<T>, int> distances = new Dictionary<SimpleTreeNode<T>, int>();
            HashSet<SimpleTreeNode<T>> visited = new HashSet<SimpleTreeNode<T>>();
            
            queue.Enqueue(startNode);
            distances[startNode] = 0;
            visited.Add(startNode);

            SimpleTreeNode<T> farthestNode = startNode;
            int maxDistance = 0;

            while (queue.Count > 0)
            {
                SimpleTreeNode<T> currentNode = queue.Dequeue();
                int currentDistance = distances[currentNode];
                
                (SimpleTreeNode<T> childFarthestNode,int childMaxDistance) =
                    ProcessChildren(currentNode, currentDistance, queue, distances, visited);
                
                if (childMaxDistance > maxDistance)
                {
                    maxDistance = childMaxDistance;
                    farthestNode = childFarthestNode;
                }
                
                (SimpleTreeNode<T> parentFarthestNode,int parentMaxDistance) =
                    ProcessParent(currentNode, currentDistance, queue, distances, visited);
                
                if (parentMaxDistance > maxDistance)
                {
                    maxDistance = parentMaxDistance;
                    farthestNode = parentFarthestNode;
                }
            }

            return (farthestNode, maxDistance);
        }
        
        private (SimpleTreeNode<T> farthestNode, int maxDistance) ProcessChildren(SimpleTreeNode<T> currentNode,
            int currentDistance,
            Queue<SimpleTreeNode<T>> queue, Dictionary<SimpleTreeNode<T>, int> distances,
            HashSet<SimpleTreeNode<T>> visited)
        {
            SimpleTreeNode<T> farthestNode = currentNode;
            int maxDistance = currentDistance;

            if (currentNode.Children == null)
                return (farthestNode, maxDistance);
            
            foreach (var child in currentNode.Children)
            {
                if (!visited.Add(child))
                    continue;
                
                distances[child] = currentDistance + 1;
                queue.Enqueue(child);

                if (distances[child] <= maxDistance)
                    continue;
                
                maxDistance = distances[child];
                farthestNode = child;
            }
            
            return (farthestNode, maxDistance);
        }

        private (SimpleTreeNode<T> farthestNode, int maxDistance) ProcessParent(SimpleTreeNode<T> currentNode,
            int currentDistance,
            Queue<SimpleTreeNode<T>> queue, Dictionary<SimpleTreeNode<T>, int> distances,
            HashSet<SimpleTreeNode<T>> visited)
        {
            SimpleTreeNode<T> farthestNode = currentNode;
            int maxDistance = currentDistance;

            if (currentNode.Parent == null || !visited.Add(currentNode.Parent)) 
                return (farthestNode, maxDistance);
            
            distances[currentNode.Parent] = currentDistance + 1;
            queue.Enqueue(currentNode.Parent);

            if (distances[currentNode.Parent] <= maxDistance) 
                return (farthestNode, maxDistance);
            
            maxDistance = distances[currentNode.Parent];
            farthestNode = currentNode.Parent;

            return (farthestNode, maxDistance);
        }
    }
}