using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BSTNode<int> rootNode = new BSTNode<int>(0, 0, null);
            List<int> values = new List<int> { 1, 2, 3, 4, 5 };
            BST<int> tree = new BST<int>(rootNode);

            foreach (var value in values)
            {
                tree.AddKeyValue(value, value);
            }

            BSTNode<int> maxNode = tree.FinMinMax(rootNode, true);
            Console.WriteLine($"Максимальное значение в дереве {maxNode.NodeKey}");
            BSTNode<int> minNode = tree.FinMinMax(rootNode, false);
            Console.WriteLine($"Минимальное значение в дереве {minNode.NodeKey}");


            int nodeCount = tree.Count();
            Console.WriteLine($"node count {nodeCount}");
            tree.DeleteNodeByKey(4);
            var res = tree.FindNodeByKey(4);
            if (!res.NodeHasKey)
            {
                Console.WriteLine("Нода 4 удалена");
            }
            // Console.WriteLine($"Найденный ключ в дереве: {resultNode.NodeKey}");
        }
    }
}