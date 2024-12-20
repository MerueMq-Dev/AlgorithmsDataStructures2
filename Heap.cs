using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class Heap
    {
        public int[] HeapArray;

        public Heap()
        {
            HeapArray = null;
        }

        public void MakeHeap(int[] keys, int depth)
        {
            int heapSize = depth <= 0 ? 1 : (int)Math.Pow(depth + 1, 2) - 1;
            HeapArray = new int[heapSize];

            foreach (var key in keys)
            {
                bool isAdded = Add(key);
                if (!isAdded)
                    break;
            }
        }

        public int GetMax()
        {
            if (HeapArray == null || HeapArray.Length == 0 || HeapArray[0] == 0)
                return -1;

            int max = HeapArray[0];
            HeapArray[0] = 0;

            for (int currentIndex = 0; currentIndex < HeapArray.Length;)
            {
                int key = HeapArray[currentIndex];
                int leftChildIndex = currentIndex * 2 + 1;
                int rightChildIndex = currentIndex * 2 + 2;

                if (rightChildIndex < HeapArray.Length && HeapArray[rightChildIndex] > key &&
                    HeapArray[rightChildIndex] > HeapArray[leftChildIndex])
                {
                    (HeapArray[rightChildIndex], HeapArray[currentIndex]) =
                        (HeapArray[currentIndex], HeapArray[rightChildIndex]);
                    currentIndex = rightChildIndex;
                    continue;
                }

                if (leftChildIndex < HeapArray.Length && HeapArray[leftChildIndex] > key)
                {
                    (HeapArray[leftChildIndex], HeapArray[currentIndex]) =
                        (HeapArray[currentIndex], HeapArray[leftChildIndex]);
                    currentIndex = leftChildIndex;
                    continue;
                }

                currentIndex = currentIndex * 2 + 1;
            }

            return max;
        }

        public bool IsHeap()
        {
            return IsHeap(0);
        }

        private bool IsHeap(int currentIndex)
        {
            if (HeapArray == null || HeapArray.Length == 0 || currentIndex > HeapArray.Length - 1 ||
                HeapArray[currentIndex] == -1)
                return true;

            int rightChild = currentIndex * 2 + 2;
            int leftChild = currentIndex * 2 + 1;


            if ((rightChild < HeapArray.Length - 1 && HeapArray[rightChild] > HeapArray[currentIndex])
                || leftChild < HeapArray.Length - 1 && (HeapArray[leftChild] > HeapArray[currentIndex]))
                return false;

            return IsHeap(leftChild) && IsHeap(rightChild);
        }

        public bool Add(int key)
        {
            if (HeapArray == null || HeapArray.Length == 0)
                return false;

            if (key < 0)
                return false;

            if (HeapArray[HeapArray.Length - 1] != 0)
                return false;

            int smallestElementIndex = HeapArray.Length - 1;
            for (int i = 0; i < HeapArray.Length; i++)
            {
                if (HeapArray[i] == 0)
                {
                    smallestElementIndex = i;
                    HeapArray[i] = key;
                    break;
                }
            }

            int parentIndex = (smallestElementIndex - 1) / 2;

            for (int currentIndex = smallestElementIndex; currentIndex > 0 && parentIndex > 0;)
            {
                parentIndex = (currentIndex - 1) / 2;
                int leftChildIndex = currentIndex * 2 + 1;
                int rightChildIndex = currentIndex * 2 + 2;
                if (rightChildIndex < HeapArray.Length
                    && leftChildIndex < HeapArray.Length
                    && key < HeapArray[parentIndex]
                    && key > HeapArray[leftChildIndex]
                    && key > HeapArray[rightChildIndex])
                    return true;

                if (HeapArray[parentIndex] < HeapArray[currentIndex])
                {
                    (HeapArray[currentIndex], HeapArray[parentIndex]) =
                        (HeapArray[parentIndex], HeapArray[currentIndex]);
                }

                currentIndex = (currentIndex - 1) / 2;
            }

            return true;
        }
    }
}