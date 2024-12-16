using System;
using System.Collections.Generic;


namespace AlgorithmsDataStructures2
{
    public static class BalancedBST
    {
        
        public static int[] GenerateBBSTArray(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
                return Array.Empty<int>();
            
            if (numbers.Length == 1)
                return numbers;
            if (numbers.Length == 2)
                return new[] { numbers[0], numbers[1] };
            
            Array.Sort(numbers);
            
            int[] result = new int[numbers.Length];
            
            GenerateBBSTArray(numbers, result, 0, numbers.Length - 1, 0);

            return result; 
        }
        
        private static void GenerateBBSTArray(int[] numbers, int[] result, int leftPointer, int rightPointer, int index)
        {
            if (leftPointer > rightPointer)
                return;
            
            int rootIndex = (rightPointer + leftPointer) / 2;
            result[index] = numbers[rootIndex];
            
            GenerateBBSTArray(numbers, result, leftPointer, rootIndex - 1, 2 * index + 1);
            GenerateBBSTArray(numbers, result, rootIndex + 1, rightPointer, 2 * index + 2); 
        }
    }
}