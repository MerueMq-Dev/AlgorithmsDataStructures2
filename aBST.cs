using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class aBST
    {
        public int?[] Tree;

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
            for (int i = 0; i < Tree.Length;)
            {
                if (current == key)
                {
                    return i;
                }

                if (current == null)
                {
                    return ~i + 1;
                }

                int leftIndex = i * 2 + 1;
                int rightIndex = i * 2 + 2;
                if (leftIndex >= Tree.Length || rightIndex >= Tree.Length)
                {
                    return null;
                }

                if (current > key && leftIndex < Tree.Length)
                {
                    i = i * 2 + 1;
                    current = Tree[i];
                    continue;
                }

                if (current < key && rightIndex < Tree.Length)
                {
                    i = i * 2 + 2;
                    current = Tree[i];
                }
            }

            return null;
        }

        public int AddKey(int key)
        {
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

        public int GetLowestCommonAncestor(int firstElementIndex, int secondElementIndex)
        {
            if (firstElementIndex < 0 || firstElementIndex > Tree.Length - 1)
                return -1;

            if (secondElementIndex < 0 || secondElementIndex > Tree.Length - 1)
                return -1;

            if (Tree[firstElementIndex] == null || Tree[secondElementIndex] == null)
                return -1;

            //(I - 1) / 2
            int currentIndex = firstElementIndex;
            List<int> firstList = new List<int>();
            while (currentIndex > 0)
            {
                firstList.Add(currentIndex);
                currentIndex = (currentIndex - 1) / 2;
            }

            currentIndex = secondElementIndex;
            List<int> secondList = new List<int>();
            while (currentIndex > 0)
            {
                secondList.Add(currentIndex);
                currentIndex = (currentIndex - 1) / 2;
            }

            int curValue = int.MinValue;
            for (int i = 0; i < firstList.Count; i++)
            {
                for (int j = 0; j < secondList.Count; j++)
                {
                    if (firstList[i] == secondList[j])
                    {
                        return secondList[j];
                    }
                }
            }

            return 0;
        }

        public List<int> WideAllNodes()
        {
            int currentIndex = 0;
            if (Tree.Length == 0 || Tree[currentIndex] == null)
                return new List<int>();

            Queue<int> queue = new Queue<int>();
            List<int> allNodes = new List<int>();

            queue.Enqueue(currentIndex);
            while (queue.Count > 0)
            {
                int currentNodeIndex = queue.Dequeue();
                allNodes.Add(Tree[currentNodeIndex].Value);

                int leftIndex = currentNodeIndex * 2 + 1;
                if (leftIndex < Tree.Length && Tree[leftIndex] != null)
                    queue.Enqueue(leftIndex);

                int rightIndex = currentNodeIndex * 2 + 2;
                if (rightIndex < Tree.Length && Tree[rightIndex] != null)
                    queue.Enqueue(rightIndex);
            }

            return allNodes;
        }
    }
}