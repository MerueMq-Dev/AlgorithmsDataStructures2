using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace AlgorithmsDataStructures2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BSTNode<int> rootNode = new BSTNode<int>(5, 5, null);
            List<int> values = new List<int> { 3,7,1,4,6,8 };
            BST<int> tree = new BST<int>(rootNode);

            foreach (var value in values)
            {
                tree.AddKeyValue(value, value);
            }

            List<BSTNode> allNodes = tree.DeepAllNodes(0);
            foreach (BSTNode node in allNodes)
            {
                Console.WriteLine("--------------------------------------------------------------------");
                Console.WriteLine($"current key {node.NodeKey}");
            }
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