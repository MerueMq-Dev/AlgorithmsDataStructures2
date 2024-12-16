using System;
using System.Collections.Generic;
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
            int test = (int)Math.Pow(1,2) - 1;
            
            aBST tree = new aBST(3);
            int fiveKeyIndex = tree.AddKey(5);
            int threeKeyIndex = tree.AddKey(3);
            int fourKeyIndex = tree.AddKey(4);
            int twoKeyIndex = tree.AddKey(2);
            
            
            // oneKeyIndex, secondKeyIndex
            
            
            List<int> nodes = tree.WideAllNodes();

            foreach (var node in nodes)
            {
                Console.Write($"{node} ");
            }

            Console.WriteLine();
            
             int index = tree.GetLowestCommonAncestor(fourKeyIndex, threeKeyIndex);
             Console.WriteLine($"index: {index}");
             Console.WriteLine($"value {tree.Tree[index]}");

             int[] testArr = new[] { 1, 12, 8, 5, 2, 54, 4, 6 };

             Array.Sort(testArr);
             
             foreach (var val in testArr)
             {
                 Console.Write($"{val} ");
             }
             
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