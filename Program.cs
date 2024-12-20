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
            int[] keys = new[] { 8, 3, 32, 6, 5, 2, 112, 1231 };
            Heap heap = new Heap();
            heap.MakeHeap(keys, 2);

            Console.WriteLine(string.Join(", ", heap.HeapArray).Replace("-1", "_"));

            int max = heap.GetMax();

            Console.WriteLine(max);
            Console.WriteLine(string.Join(", ", heap.HeapArray).Replace("-1", "_"));
            heap.HeapArray[1] = 1;
            
            Console.WriteLine($"IsHeap: {heap.IsHeap()}");

            // 0 - 1
            // 1 - 3
            // 2 - 7
            // 3 - 15

            // aBST tree = new aBST(4);
            // int fiveKeyIndex = tree.AddKey(5);
            // int fourKeyIndex = tree.AddKey(4);
            // int treeKeyIndex = tree.AddKey(3);
            // int twoKeyIndex = tree.AddKey(2);
            // int oneKeyIndex = tree.AddKey(1);
            // // int sixKeyIndex = tree.AddKey(6);   
            // int eightKeyIndex = tree.AddKey(8);
            //
            // int sevenKeyIndex = tree.AddKey(7);

            // Console.WriteLine("BEFORE"); `
            // Console.WriteLine(string.Join(", ", tree.Tree).Replace(" ", "_"));
            // Console.Write("All Nodes: ");
            // List<int> allNodes = tree.WideAllNodes();
            // foreach (var node in allNodes)
            // {
            //     Console.Write($"{tree.Tree[node]} ");
            // }
            //
            // Console.WriteLine();
            // int valueToRemove = 4;
            // Console.WriteLine($"value to remove {valueToRemove}");
            // tree.RemoveNodeByKey(valueToRemove);
            // Console.WriteLine("AFTER");
            // Console.WriteLine(string.Join(", ", tree.Tree).Replace(" ", "_"));
            // allNodes = tree.WideAllNodes();
            // foreach (var node in allNodes)
            // {
            //     Console.Write($"{tree.Tree[node]} ");
            // }

            Console.WriteLine();


            // int[] numbers = new[] { 7, 2, 4, 5, 3, 1, 6 };
            // int[] numbers = new[] { 13, 11, 15 };
            // BalancedBST tree = new BalancedBST();
            // foreach (var number in numbers)
            // {
            //     tree.AddKey(number);
            // }
            //
            // Console.WriteLine($"TEST {tree.IsBalanced(tree.Root)}");
            // // tree.GenerateTree(numbers);
            //
            // List<BSTNode> allNodes = tree.WideAllNodes();
            // int currentLevel = 0;
            // foreach (BSTNode node in allNodes)
            // {
            //     if (currentLevel < node.Level)
            //     {
            //         Console.WriteLine();
            //         currentLevel += 1;
            //     }
            //
            //     Console.Write($" {node.NodeKey} ");
            // }
            //
            // int[] balancedNumbers = new[] { 6, 1, 9, 11 };
            // BalancedBST balancedTree = new BalancedBST();
            // foreach (var number in balancedNumbers)
            // {
            //     balancedTree.AddKey(number);
            // }
            //
            // Console.WriteLine("Balanced Tree: " +
            //                   (balancedTree.IsBalanced(balancedTree.Root) ? "Balanced" : "Not Balanced"));
            //
            // int[] unbalancedLeftNumbers = new[] { 1, 2, 3, 4, 5, 6, 7 };
            // BalancedBST unbalancedLeftTree = new BalancedBST();
            // foreach (var number in unbalancedLeftNumbers)
            // {
            //     unbalancedLeftTree.AddKey(number);
            // }
            //
            // Console.WriteLine(
            //     "Unbalanced Left Tree: " +
            //     (unbalancedLeftTree.IsBalanced(unbalancedLeftTree.Root) ? "Balanced" : "Not Balanced"));
            //
            // // Несбалансированное дерево (слишком глубокое правое поддерево)
            // int[] unbalancedRightNumbers = new[] { 7, 6, 5, 4, 3, 2, 1 };
            // BalancedBST unbalancedRightTree = new BalancedBST();
            // foreach (var number in unbalancedRightNumbers)
            // {
            //     unbalancedRightTree.AddKey(number);
            // }
            //
            // Console.WriteLine("Unbalanced Right Tree: " +
            //                   (unbalancedRightTree.IsBalanced(unbalancedRightTree.Root) ? "Balanced" : "Not Balanced"));
            //
            // // Сбалансированное дерево с несколькими уровнями
            // int[] balancedMultiLevelNumbers = new[] { 10, 5, 15, 2, 7, 12, 20 };
            // BalancedBST balancedMultiLevelTree = new BalancedBST();
            // foreach (var number in balancedMultiLevelNumbers)
            // {
            //     balancedMultiLevelTree.AddKey(number);
            // }
            //
            // Console.WriteLine("Balanced Multi-level Tree: " +
            //                   (balancedMultiLevelTree.IsBalanced(balancedMultiLevelTree.Root)
            //                       ? "Balanced"
            //                       : "Not Balanced"));
            //
            // // Пустое дерево
            // BalancedBST emptyTree = new BalancedBST();
            // emptyTree.GenerateTree(new int[] { });
            //
            // Console.WriteLine("Empty Tree: " +
            //                   (emptyTree.IsBalanced(balancedMultiLevelTree.Root) ? "Balanced" : "Not Balanced"));

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