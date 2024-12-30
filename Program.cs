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
            SimpleGraph<int> simpleGraph = new SimpleGraph<int>(7);
            simpleGraph.AddVertex(0);
            simpleGraph.AddVertex(1);
            simpleGraph.AddVertex(2);
            simpleGraph.AddVertex(3);
            
            simpleGraph.AddEdge(0, 1);
            simpleGraph.AddEdge(1, 2); 
            simpleGraph.AddEdge(2, 0);
            simpleGraph.AddEdge(2, 3);

            List<Vertex<int>> verticesNotInTriangles = simpleGraph.WeakVertices();

            int countTriangles = simpleGraph.CountTriangles();
            Console.WriteLine($"Number of Triangles is {countTriangles}");
            
            foreach (var vertex in verticesNotInTriangles)
            {
                Console.WriteLine(vertex.Value);
            }


            // SimpleTreeNode<int> root = new SimpleTreeNode<int>(1, null);
            // SimpleTreeNode<int> two = new SimpleTreeNode<int>(2, null);
            // SimpleTreeNode<int> three = new SimpleTreeNode<int>(3, null);
            // SimpleTreeNode<int> four = new SimpleTreeNode<int>(4, null);
            // SimpleTreeNode<int> five = new SimpleTreeNode<int>(5, null);
            // SimpleTreeNode<int> six = new SimpleTreeNode<int>(6, null);
            // SimpleTreeNode<int> seven = new SimpleTreeNode<int>(7, null);
            // SimpleTreeNode<int> eight = new SimpleTreeNode<int>(8, null);
            // SimpleTree<int> tree = new SimpleTree<int>(root);
            // tree.AddChild(root, two);
            // tree.AddChild(root, three);
            // // tree.AddChild(two, four);
            // // tree.AddChild(two, five);
            // tree.AddChild(three, six);
            // // tree.AddChild(three, seven);
            // // tree.AddChild(four,eight);
            // var diameter = tree.FindMaxDistance();

            // Console.WriteLine("Diameter of the tree is: " + diameter); // Ожидаемый результат
            // var nodes = tree.GetAllNodes();
            //
            // foreach (var node in nodes)
            // {
            // }
            //
            // Console.WriteLine(node.NodeValue);

            
        }

        public static void TestCycles()
        {
            var graph1 = new SimpleGraph<int>(5);
            graph1.AddVertex(0);
            graph1.AddVertex(1);
            graph1.AddVertex(2);
            graph1.AddVertex(3);
            graph1.AddVertex(4);
            graph1.AddEdge(0, 1);
            graph1.AddEdge(1, 2);
            graph1.AddEdge(2, 0);
            graph1.AddEdge(2, 3);
            graph1.AddEdge(3, 4);
            graph1.AddEdge(4, 2);
            
            var cycles1 = graph1.FindCycles();
            Console.WriteLine($"Cycles in Graph 1: {cycles1.Count}");
            Console.WriteLine(cycles1.Count == 0
                ? "No cycles"
                : string.Join(", ", cycles1.Select(c => string.Join(" -> ", c))));
            
            var graph2 = new SimpleGraph<int>(   4);
            graph2.AddVertex(0);
            graph2.AddVertex(1);
            graph2.AddVertex(2);
            graph2.AddVertex(3);
            graph2.AddEdge(0, 1);
            graph2.AddEdge(1, 2);
            graph2.AddEdge(2, 3);
            var cycles2 = graph2.FindCycles();
            Console.WriteLine("Cycles in Graph 2:");
            Console.WriteLine(cycles2.Count == 0
                ? "No cycles"
                : string.Join(", ", cycles2.Select(c => string.Join(" -> ", c))));
            
            
            var graph3 = new SimpleGraph<int>(4);
            graph3.AddVertex(0);
            graph3.AddVertex(1);
            graph3.AddVertex(2);
            graph3.AddVertex(3);
            graph3.AddEdge(0, 1);
            graph3.AddEdge(1, 2);
            graph3.AddEdge(2, 3);
            graph3.AddEdge(3, 0); // Цикл 0-1-2-3-0
            var cycles3 = graph3.FindCycles();
            Console.WriteLine("Cycles in Graph 3:");
            Console.WriteLine(cycles3.Count == 0
                ? "No cycles"
                : string.Join(", ", cycles3.Select(c => string.Join(" -> ", c))));
            
            
            var graph4 = new SimpleGraph<int>(5);
            graph4.AddVertex(0);
            graph4.AddVertex(1);
            graph4.AddVertex(2);
            graph4.AddVertex(3);
            graph4.AddVertex(4);
            graph4.AddEdge(0, 1);
            graph4.AddEdge(1, 2);
            graph4.AddEdge(2, 3);
            graph4.AddEdge(3, 4);
            var cycles4 = graph4.FindCycles();
            Console.WriteLine("Cycles in Graph 4:");
            Console.WriteLine(cycles4.Count == 0
                ? "No cycles"
                : string.Join(", ", cycles4.Select(c => string.Join(" -> ", c))));
            
            
            var graph5 = new SimpleGraph<int>(6);
            graph5.AddVertex(0);
            graph5.AddVertex(1);
            graph5.AddVertex(2);
            graph5.AddVertex(3);
            graph5.AddVertex(4);
            graph5.AddVertex(5);
            graph5.AddEdge(0, 1);
            graph5.AddEdge(1, 2);
            graph5.AddEdge(2, 3);
            graph5.AddEdge(3, 4);
            graph5.AddEdge(4, 5);
            var cycles5 = graph5.FindCycles();
            Console.WriteLine("Cycles in Graph 5:");
            Console.WriteLine(cycles5.Count == 0
                ? "No cycles"
                : string.Join(", ", cycles5.Select(c => string.Join(" -> ", c))));
        }
    }
}