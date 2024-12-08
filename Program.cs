using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SimpleTreeNode<int> rootNode = new SimpleTreeNode<int>(0, null);
            
            SimpleTreeNode<int> nodeOne = new SimpleTreeNode<int>(1, null);
            SimpleTreeNode<int> secondNodeOne = new SimpleTreeNode<int>(1, null);
            
            SimpleTreeNode<int> nodeTwo = new SimpleTreeNode<int>(2, null);
            SimpleTreeNode<int> secondNodeTwo = new SimpleTreeNode<int>(2, null);

            SimpleTreeNode<int> nodeThree = new SimpleTreeNode<int>(3, null);
            SimpleTreeNode<int> secondNodeThree = new SimpleTreeNode<int>(3, null);
            
            // SimpleTreeNode<int> nodeFour = new SimpleTreeNode<int>(4, null);
            // SimpleTreeNode<int> secondNodeFour = new SimpleTreeNode<int>(4, null);

            
            SimpleTree<int> tree = new SimpleTree<int>(rootNode);
            tree.AddChild(rootNode, nodeOne);
            tree.AddChild(nodeOne, nodeThree);
            tree.AddChild(nodeOne, nodeTwo);
            
            tree.AddChild(rootNode, secondNodeOne);
            tree.AddChild(secondNodeOne, secondNodeTwo);
            tree.AddChild(secondNodeOne, secondNodeThree);
            
            List<SimpleTreeNode<int>> allNodes = tree.GetAllNodes();
            Console.WriteLine("BEFORE:");
            foreach (var currentNode in allNodes)
            {
                Console.WriteLine("--------------------------------------");
                Console.WriteLine($"node value: {currentNode.NodeValue}");
                Console.WriteLine($"node level: {currentNode.level}");
            }

            Console.WriteLine($"is symmetrical {tree.IsSymmetrical()}");
            
            // Console.WriteLine("AFTER:");
            // List<SimpleTreeNode<int>> nodes = tree.GetAllNodes();
            // tree.AssignNodeLevels();
            // foreach (var currentNode in nodes)
            // {
            //     Console.WriteLine($"node value: {currentNode.NodeValue}");
            //     Console.WriteLine($"node level: {currentNode.level}");
            // }

            Console.WriteLine($"Узлов в дереве: {tree.Count()}");
            Console.WriteLine($"Листьев в дереве: {tree.LeafCount()}");
        }
    }
}