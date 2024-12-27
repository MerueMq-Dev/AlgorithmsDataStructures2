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

            List<Vertex<int>> verticesNotInTriangles = simpleGraph.WeakVertices();

            foreach (var vertex in verticesNotInTriangles)
            {
                Console.WriteLine(vertex.Value);
            }
        }
    }
}