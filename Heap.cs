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
            for (int i = 0; i < HeapArray.Length; i++)
                HeapArray[i] = -1;
            
            foreach (var key in keys)
            {
                bool isAdded = Add(key);
                if (!isAdded)
                    break;
            }
        }

        public int GetMax()
        {
            if (HeapArray == null || HeapArray.Length == 0 || HeapArray[0] == -1)
                return -1;

            int max = HeapArray[0];
            HeapArray[0] = -1;
            
            for(int currentIndex = 0;true;)
            {
                int leftChildIndex = currentIndex * 2 + 1;
                int rightChildIndex = currentIndex * 2 + 2;
                int largestIndex = currentIndex;
                
                if (leftChildIndex < HeapArray.Length && HeapArray[leftChildIndex] > HeapArray[largestIndex])
                {
                    largestIndex = leftChildIndex;
                }
                
                if (rightChildIndex < HeapArray.Length && HeapArray[rightChildIndex] > HeapArray[largestIndex])
                {
                    largestIndex = rightChildIndex;
                }
                
                if (largestIndex <= currentIndex)
                    break;
                
                (HeapArray[currentIndex], HeapArray[largestIndex]) =
                    (HeapArray[largestIndex], HeapArray[currentIndex]);
                
                currentIndex = largestIndex;
            }

            return max;
        }

        public bool IsHeap()
        {
            return IsHeap(0);
        }

        private bool IsHeap(int currentIndex)
        {
            if (currentIndex >= HeapArray.Length)
                return true;

            int leftChild = currentIndex * 2 + 1;
            int rightChild = currentIndex * 2 + 2;

            if (leftChild < HeapArray.Length && HeapArray[leftChild] > HeapArray[currentIndex])
                return false;

            if (rightChild < HeapArray.Length && HeapArray[rightChild] > HeapArray[currentIndex])
                return false;

            return IsHeap(leftChild) && IsHeap(rightChild);
        }

        public bool Add(int key)
        {
            if (HeapArray == null || HeapArray.Length == 0)
                return false;

            if (key < 0)
                return false;

            if (HeapArray[HeapArray.Length - 1] != -1)
                return false;

            int smallestElementIndex = -1;
            for (int i = 0; i < HeapArray.Length; i++)
            {
                if (HeapArray[i] == -1)
                {
                    smallestElementIndex = i;
                    break;
                }
            }

            if (smallestElementIndex == -1)
                return false;

            HeapArray[smallestElementIndex] = key;


            // int parentIndex = (smallestElementIndex - 1) / 2;
            for (int currentIndex = smallestElementIndex; currentIndex > 0;)
            {
                int parentIndex = (currentIndex - 1) / 2;
                
                if (HeapArray[parentIndex] < HeapArray[currentIndex])
                {
                    (HeapArray[currentIndex], HeapArray[parentIndex]) =
                        (HeapArray[parentIndex], HeapArray[currentIndex]);
                    currentIndex = parentIndex;
                    continue;
                }

                break;
            }

            return true;
        }
    }
}