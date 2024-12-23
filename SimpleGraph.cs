using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class Vertex<T>
    {
        public bool Hit;
        public T Value;

        public Vertex(T val)
        {
            Value = val;
            Hit = false;
        }
    }

    public class SimpleGraph<T>
    {
        public Vertex<T>[] vertex;
        public int[,] m_adjacency;
        public int max_vertex;

        public SimpleGraph(int size)
        {
            max_vertex = size;
            m_adjacency = new int [size, size];
            vertex = new Vertex<T> [size];
        }

        public void AddVertex(T value)
        {
            if (vertex == null)
                return;

            int freePosition = Array.IndexOf(vertex, null);
            if (freePosition == -1)
                return;

            Vertex<T> newVertex = new Vertex<T>(value);
            vertex[freePosition] = newVertex;
        }

        public void RemoveVertex(int v)
        {
            if (vertex == null)
                return;
            if (v >= max_vertex || vertex[v] == null)
                return;

            for (int i = 0; i < max_vertex; i++)
            {
                RemoveEdge(v, i);
            }

            for (int i = 0; i < max_vertex; i++)
            {
                RemoveEdge(i, v);
            }

            vertex[v] = null;
        }

        public bool IsEdge(int v1, int v2)
        {
            if (vertex == null)
                return false;

            if (v1 >= max_vertex || v2 >= max_vertex)
                return false;

            if (vertex[v1] == null || vertex[v2] == null)
                return false;

            return m_adjacency[v1, v2] == 1 && m_adjacency[v2, v1] == 1;
        }

        public void AddEdge(int v1, int v2)
        {
            if (vertex == null)
                return;

            if (v1 >= max_vertex || v2 >= max_vertex)
                return;

            if (vertex[v1] == null || vertex[v2] == null)
                return;

            m_adjacency[v1, v2] = 1;
            m_adjacency[v2, v1] = 1;
        }

        public void AddDirectedEdge(int v1, int v2)
        {
            if (vertex == null)
                return;

            if (v1 >= max_vertex || v2 >= max_vertex)
                return;

            if (vertex[v1] == null || vertex[v2] == null)
                return;

            m_adjacency[v1, v2] = 1;
        }

        public void RemoveEdge(int v1, int v2)
        {
            if (vertex == null)
                return;

            if (v1 >= max_vertex || v2 >= max_vertex)
                return;

            if (vertex[v1] == null || vertex[v2] == null)
                return;

            m_adjacency[v1, v2] = 0;
            m_adjacency[v2, v1] = 0;
        }

        public bool HasCycle()
        {
            bool[] visited = new bool[max_vertex];

            for (int i = 0; i < max_vertex; i++)
            {
                if (!visited[i])
                {
                    if (IsCyclic(i, visited))
                        return true;
                }
            }

            return false;
        }

        private bool IsCyclic(int vertex, bool[] visited)
        {
            if (visited[vertex]) return true;

            visited[vertex] = true;
            for (int i = 0; i < max_vertex; i++)
            {
                if (m_adjacency[vertex, i] == 1)
                {
                    if (IsCyclic(i, visited))
                        return true;
                }
            }

            visited[vertex] = false;
            return false;
        }

        public List<Vertex<T>> DepthFirstSearch(int VFrom, int VTo)
        {
            List<Vertex<T>> path = new List<Vertex<T>>();
            if (vertex == null)
                return path;

            if (VFrom >= max_vertex || VTo >= max_vertex)
                return path;

            if (vertex[VFrom] == null || vertex[VFrom] == null)
                return path;
            
            if (HasCycle())
                return path;
            
            Stack<int> stack = new Stack<int>();
            foreach (Vertex<T> vertex in vertex)
            {
                vertex.Hit = false;
            }
            
            stack.Push(VFrom);
            vertex[VFrom].Hit = true;
            
            while (stack.Count > 0)
            {
                int currentIdx = stack.Peek();
                Vertex<T> currentVertex = vertex[currentIdx];
                
                path.Add(currentVertex);
                
                if (currentIdx == VTo)
                {
                    return path;
                }
                
                bool foundNeighbor = false;
                
                for (int i = 0; i < max_vertex; i++)
                {
                    if (m_adjacency[currentIdx, i] == 1 && !vertex[i].Hit)
                    {
                        vertex[i].Hit = true;
                        stack.Push(i);
                        foundNeighbor = true;
                        break;
                    }
                }
                
                if (!foundNeighbor)
                {
                    stack.Pop();
                }
            }
            
            return new List<Vertex<T>>();
        }
    }
}