using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class Vertex
    {
        public int Value;

        public Vertex(int val)
        {
            Value = val;
        }
    }

    public class SimpleGraph
    {
        public Vertex[] vertex;
        public int[,] m_adjacency;
        public int max_vertex;

        public SimpleGraph(int size)
        {
            max_vertex = size;
            m_adjacency = new int [size, size];
            vertex = new Vertex [size];
        }

        public void AddVertex(int value)
        {
            if (vertex == null)
                return;

            int freePosition = Array.IndexOf(vertex, null);
            if (freePosition == -1)
                return;

            Vertex newVertex = new Vertex(value);
            vertex[freePosition] = newVertex;
        }

        // здесь и далее, параметры v -- индекс вершины
        // в списке vertex
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
            // ваш код удаления вершины со всеми её рёбрами
        }

        public bool IsEdge(int v1, int v2)
        {
            if (vertex == null)
                return false;

            if (v1 >= max_vertex || v2 >= max_vertex)
                return false;

            if (vertex[v1] == null || vertex[v2] == null)
                return false;

            // true если есть ребро между вершинами v1 и v2
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
    }
}