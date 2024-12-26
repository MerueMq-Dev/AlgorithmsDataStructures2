using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class DirectedGraph<T>
    {
        public Vertex<T>[] vertex;
        public int[,] m_adjacency;
        public int max_vertex;

        public DirectedGraph(int size)
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

            return m_adjacency[v1, v2] == 1;
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
            // m_adjacency[v2, v1] = 1;
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
        
        public int FindLengthLongestSimplePath()
        {
            int maxLength = 0;

            for (int start = 0; start < max_vertex; start++)
            {
                Stack<(int vertex, int currentLength)> stack = new Stack<(int, int)>();
                stack.Push((start, 0));

                while (stack.Count > 0)
                {
                    var (currentIdx, currentLength) = stack.Pop();
                    maxLength = Math.Max(maxLength, currentLength);
                    vertex[currentIdx].Hit = true;

                    for (int i = 0; i < max_vertex; i++)
                    {
                        if (m_adjacency[currentIdx, i] == 1 && !vertex[i].Hit) 
                        {
                            stack.Push((i, currentLength + 1));
                        }
                    }

                    vertex[currentIdx].Hit = false;
                }
            }

            return maxLength;
        }
    }
}