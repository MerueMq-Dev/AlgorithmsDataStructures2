using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace AlgorithmsDataStructures2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BSTNode<int> rootNode = new BSTNode<int>(3, 3, null);
            List<int> values = new List<int> { 1, 2, 4, 5 };
            BST<int> tree = new BST<int>(rootNode);

            foreach (var value in values)
            {
                tree.AddKeyValue(value, value);
            }

            List<List<BSTNode<int>>> maxSumPaths = tree.GetMaxSumPaths();
            for (int i = 0; i < maxSumPaths.Count; i++)
            {
                Console.WriteLine($"Путь номер {i + 1}");
                int count = 0;
                for (int j = 0; j < maxSumPaths[i].Count; j++)
                {
                    count += maxSumPaths[i][j].NodeKey;
                    Console.WriteLine(maxSumPaths[i][j].NodeKey);
                }

                Console.WriteLine($"MAX {count}");
            }
            // Console.WriteLine($"Найденный ключ в дереве: {resultNode.NodeKey}");
        }
    }
}