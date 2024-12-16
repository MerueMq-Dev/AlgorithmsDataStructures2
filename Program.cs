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

            // aBST tree = new aBST(3);
            // int fiveKeyIndex = tree.AddKey(5);
            // int threeKeyIndex = tree.AddKey(3);
            // int fourKeyIndex = tree.AddKey(4);
            // int twoKeyIndex = tree.AddKey(2);

            int[] numbers = new[] { 7, 2, 4, 5, 3, 1, 6 };
            int[] testNumbers = new[] { 1,2,3,4,5,6,7 };
            
            int rootIndex = numbers.Length % 2 == 0 ? numbers.Length / 2 - 1 : numbers.Length / 2;

            int[] result = BalancedBST.GenerateBBSTArray(numbers);

            Console.WriteLine(string.Join(", ", result));
            
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

            // List<List<BSTNode<int>>> maxSumPaths = tree.GetMaxSumPaths();
            // for (int i = 0; i < maxSumPaths.Count; i++)
            // {
            //     Console.WriteLine($"Путь номер {i + 1}");
            //     int count = 0;
            //     for (int j = 0; j < maxSumPaths[i].Count; j++)
            //     {
            //         count += maxSumPaths[i][j].NodeKey;
            //         Console.WriteLine(maxSumPaths[i][j].NodeKey);
            //     }
            //
            //     Console.WriteLine($"MAX {count}");
            // }
            // Console.WriteLine($"Найденный ключ в дереве: {resultNode.NodeKey}");
        }
    }
}