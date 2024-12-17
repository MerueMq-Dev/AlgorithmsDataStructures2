using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace AlgorithmsDataStructures2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // 0 - 1
            // 1 - 3
            // 2 - 7
            // 3 - 15

            aBST tree = new aBST(3);
            // int fiveKeyIndex = tree.AddKey(5);
            // int threeKeyIndex = tree.AddKey(3);
            // int fourKeyIndex = tree.AddKey(4);
            // int twoKeyIndex = tree.AddKey(2);
            // int oneKeyIndex = tree.AddKey(1);
            // int sixKeyIndex = tree.AddKey(6);
            // int sevenKeyIndex = tree.AddKey(7);
            
            
            
            Console.WriteLine("tree:");
            Console.Write(string.Join(", ", tree.Tree));
            Console.WriteLine();
            

            Console.WriteLine("BEFORE");
            Console.Write("All Nodes: ");
            List<int> allNodes = tree.WideAllNodes();
            foreach (var node in allNodes)
            {
                Console.Write($"{tree.Tree[node]} ");
            }

            Console.WriteLine();
            tree.RemoveNodeByKey(2);

            Console.WriteLine("AFTER");
            allNodes = tree.WideAllNodes();
            foreach (var node in allNodes)
            {
                Console.Write($"{tree.Tree[node]} ");
            }

            Console.WriteLine();


            int[] numbers = new[] { 7, 2, 4, 5, 3, 1, 6 };

            // BSTNode<int> rootNode = new BSTNode<int>(4, 4, null);
            // List<int> values = new List<int> { 2, 1, 3, 6, 5, 7 };
            // BST<int> tree = new BST<int>(null);

            // foreach (var value in values)
            // {
            //     tree.AddKeyValue(value, value);
            // }

            // int[] prefixTraversal = { 1, 2, 4, 5, 3, 6, 7 };
            // int[] infixTraversal = { 4, 2, 5, 1, 6, 3, 7 };
            //
            // tree.RestoreTree(prefixTraversal, infixTraversal);
            //
            // List<BSTNode<int>> allNodes = tree.WideAllNodes2();
            // int currentLevel = 0;
            // foreach (BSTNode<int> node in allNodes)
            // {
            //     if (currentLevel < node.level)
            //     {
            //         Console.WriteLine();
            //         currentLevel += 1;
            //     }
            //
            //     Console.Write($" {node.NodeKey} ");
            // }

            // tree.InvertTree();
            // Console.WriteLine();
            // Console.WriteLine("AFTER");
            // currentLevel = 0;
            // allNodes = tree.WideAllNodes2();
            // foreach (BSTNode<int> node in allNodes)
            // {
            //     if (currentLevel < node.level)
            //     {
            //         Console.WriteLine();
            //         currentLevel += 1;
            //     }
            //     Console.Write($" {node.NodeKey} ");
            // }
            //
            // Console.WriteLine();


            // int maxLevel = tree.FindLevelWithMaxSum();
            // Console.WriteLine();
            // Console.WriteLine($"lvl with max sum {maxLevel}");
        }
    }
}