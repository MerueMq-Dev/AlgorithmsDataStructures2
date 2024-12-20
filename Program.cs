﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace AlgorithmsDataStructures2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] s = new string[] { "1" };
            int test = Array.IndexOf(s, null);
            Console.WriteLine($"test {test}");

            int[] keys = new[] { 8, 3, 1, 4, 5, 2 };
            Heap heap = new Heap();
            heap.MakeHeap(keys, 3);
            
            Console.WriteLine(string.Join(", ", heap.HeapArray));   
            
            int[] keys2 = new[] { 8, 3, 1 };
            Heap heap2 = new Heap();
            heap2.MakeHeap(keys2, 2);

            heap.MergeHeaps(heap2);
            
            Console.WriteLine($"IsHeap: {heap.IsHeap()}");
            Console.WriteLine(string.Join(", ", heap.HeapArray));
            Console.WriteLine();
            // heap.HeapArray[1] = 1;

            // SimpleGraph simpleGraph = new SimpleGraph(4);
            // simpleGraph.AddVertex(1);
            // simpleGraph.AddVertex(2);
            // simpleGraph.AddVertex(3);
            // simpleGraph.AddVertex(4);
            //
            // simpleGraph.AddEdge(1, 2);
            // simpleGraph.AddEdge(0, 3);
            // simpleGraph.AddEdge(3, 1);
            // simpleGraph.AddEdge(2, 0);
            //
            // Console.WriteLine("BEFORE");
            //
            // int rows = simpleGraph.m_adjacency.GetUpperBound(0) + 1; // количество строк
            // int columns = simpleGraph.m_adjacency.Length / rows;
            //
            // for (int i = 0; i < rows; i++)
            // {
            //     for (int j = 0; j < columns; j++)
            //     {
            //         Console.Write($"{simpleGraph.m_adjacency[i, j]} ");
            //     }
            //
            //     Console.WriteLine();
            // }
            //
            // Console.WriteLine();
            //
            // simpleGraph.RemoveVertex(2);
            // Console.WriteLine("AFTER"); 
            //
            // for (int i = 0; i < rows; i++)
            // {
            //     for (int j = 0; j < columns; j++)
            //     {
            //         Console.Write($"{simpleGraph.m_adjacency[i, j]} ");
            //     }
            //
            //     Console.WriteLine();
            // }
            //
            // bool isEdge = simpleGraph.IsEdge(1, 2);
            // Console.WriteLine($"IsEdge: {isEdge}");


            Console.WriteLine();

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