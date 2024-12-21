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

        public int CurrentSize => HeapArray.Length;

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
            if (HeapArray == null || HeapArray.Length == 0)
                return -1;

            int max = HeapArray[0];
            if (max == 0)
                return -1;

            HeapArray[0] = HeapArray[HeapArray.Length - 1];

            HeapArray[HeapArray.Length - 1] = 0;

            int heapSize = HeapArray.Length - 1;
            for (int currentIndex = 0;;)
            {
                int leftChildIndex = currentIndex * 2 + 1;
                int rightChildIndex = currentIndex * 2 + 2;
                int largestIndex = currentIndex;

                if (leftChildIndex < heapSize && HeapArray[leftChildIndex] > HeapArray[largestIndex])
                {
                    largestIndex = leftChildIndex;
                }

                if (rightChildIndex < heapSize && HeapArray[rightChildIndex] > HeapArray[largestIndex])
                {
                    largestIndex = rightChildIndex;
                }

                if (largestIndex == currentIndex)
                    break;

                (HeapArray[currentIndex], HeapArray[largestIndex]) =
                    (HeapArray[largestIndex], HeapArray[currentIndex]);
                currentIndex = largestIndex;
            }

            return max;
        }

        public int FindMaxInRange(int low, int high)
        {
            int max = -1;
            foreach (var value in HeapArray)
            {
                if (value >= low && value <= high && max < value)
                {
                    max = value;
                }
            }

            return max;
        }

        public int Find(Predicate<int> predicate)
        {
            int currentIndex = 0;
            if (HeapArray == null)
                return -1;

            return Find(predicate, currentIndex);
        }

        private int Find(Predicate<int> predicate, int currentIndex)
        {
            if (currentIndex >= HeapArray.Length)
                return -1;

            if (predicate(HeapArray[currentIndex]))
            {
                return HeapArray[currentIndex];
            }

            int leftResult = -1;
            int leftIndex = currentIndex * 2 + 1;
            if (leftIndex < HeapArray.Length && HeapArray[leftIndex] <= HeapArray[currentIndex])
            {
                leftResult = Find(predicate, leftIndex);
            }

            if (leftResult != -1)
                return leftResult;

            int rightIndex = currentIndex * 2 + 2;
            int rightResult = -1;
            if (rightIndex < HeapArray.Length && HeapArray[rightIndex] <= HeapArray[currentIndex])
            {
                rightResult = Find(predicate, rightIndex);
            }

            return rightResult;
        }

        public bool MergeHeaps(Heap heapToMerge)
        {
            if (HeapArray == null)
                return false;

            if (heapToMerge == null || heapToMerge.CurrentSize == 0)
                return true;

            int[] mergedArray = new int[CurrentSize + heapToMerge.CurrentSize];
            int maxValue = heapToMerge.GetMax();
            int currentIndex = 0;
            while (maxValue != -1)
            {
                mergedArray[currentIndex] = maxValue;
                currentIndex++;
                maxValue = heapToMerge.GetMax();
            }

            maxValue = GetMax();
            while (maxValue != -1)
            {
                mergedArray[currentIndex] = maxValue;
                currentIndex++;
                maxValue = GetMax();
            }

            int newHeapDepth = CalculateDepth(mergedArray.Length);
            MakeHeap(mergedArray, newHeapDepth);
            return true;
        }


        public int CalculateDepth(int heapSize)
        {
            if (heapSize <= 0)
                return 0; // Невозможно вычислить глубину для некорректного размера кучи

            int depth = (int)(Math.Sqrt(heapSize + 1) - 1);
            return depth;
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


            int smallestElementIndex = -1;
            for (int i = 0; i < HeapArray.Length; i++)
            {
                if (HeapArray[i] == 0)
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