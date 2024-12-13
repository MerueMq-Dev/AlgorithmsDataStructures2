﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace AlgorithmsDataStructures2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // BSTNode<int> rootNode = new BSTNode<int>(4, 4, null);
            // List<int> values = new List<int> { 2, 1, 3, 6, 5, 7 };
            BST<int> tree = new BST<int>(null);

            // foreach (var value in values)
            // {
            //     tree.AddKeyValue(value, value);
            // }
            
            int[] prefixTraversal = { 1,2,4,5,3,6,7 };
            int[] infixTraversal = { 4,2,5,1,6,3,7 };
            
            tree.RestoreTree(prefixTraversal,infixTraversal);
            
            List<BSTNode<int>> allNodes = tree.WideAllNodes2();
            int currentLevel = 0;
            foreach (BSTNode<int> node in allNodes)
            {
                if (currentLevel < node.level)
                {
                    Console.WriteLine();
                    currentLevel += 1;
                }
                Console.Write($" {node.NodeKey} ");
            }

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