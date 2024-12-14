using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class aBST
    {
        public int?[] Tree; // массив ключей

        public aBST(int depth)
        {
            int treeSize = depth <= 0 ? 1 : (int)Math.Pow(depth + 1, 2) - 1;
            Tree = new int?[treeSize];
            for (int i = 0; i < treeSize; i++)
                Tree[i] = null;
        }

        public int? FindKeyIndex(int key)
        {
            if (Tree[0] == null)
            {
                return 0;
            }   
            int? current = Tree[0];
            for(int i = 0 ;i < Tree.Length;) 
            {
                if (current == key)
                {
                    return i;
                }
                if (current == null)
                {
                    return ~i + 1;
                }
                if (current > key)
                {
                    i = i * 2 + 1;
                    current = Tree[i];
                    continue;
                }
                if (current < key)
                {
                    i = i * 2 + 2;
                    current = Tree[i];
                }
            }
            return null;
        }

        public int AddKey(int key)
        {
            // добавляем ключ в массив
            int? indexToAdd = FindKeyIndex(key);
            if (indexToAdd == null)
            {
                return -1;
            }

            if (0 == indexToAdd && Tree[indexToAdd.Value] == null)
            {
                Tree[indexToAdd.Value] = key;
                return indexToAdd.Value;
            }
            if (0 == indexToAdd && Tree[indexToAdd.Value] != null)
            {
                return indexToAdd.Value;
            }
            
            if (indexToAdd < 0)
            {
                int index = Math.Abs(indexToAdd.Value);
                Tree[index] = key;
                return index;
            }

            if (Tree[indexToAdd.Value] != null)
            {
                return indexToAdd.Value;
            }

            if (Tree[indexToAdd.Value] == null)
            {
                Tree[indexToAdd.Value] = key;
                return indexToAdd.Value;
            }

            return -1;
        }
    }
}