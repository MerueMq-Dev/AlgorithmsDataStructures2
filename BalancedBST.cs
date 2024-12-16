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
        
        // public static int[] BuildBBST(int[] numbers)
        // {
        //     if (numbers == null || numbers.Length == 0)
        //         return Array.Empty<int>();
        //
        //     if (numbers.Length == 1 || numbers.Length == 2)
        //         return numbers;
        //
        //     Array.Sort(numbers);
        //
        //     int rootIndex = numbers.Length % 2 == 0 ? numbers.Length / 2 - 1 : numbers.Length / 2;
        //     int[] result = new int[numbers.Length];
        //     result[0] = numbers[rootIndex];
        //     
        //     int[] left = numbers.Take(rootIndex).ToArray();
        //     int[] right = numbers.Skip(rootIndex + 1).ToArray();
        //     BuildBBST(left, result, 1);
        //     return BuildBBST(right, result, rootIndex + 1);
        // }
        //
        // private static int[] BuildBBST(int[] numbers, int[] acc, int index)
        // {
        //     switch (numbers.Length)
        //     {
        //         case 0:
        //             return acc;
        //         case 1:
        //             acc[index] = numbers[0];
        //             return acc;
        //     }
        //
        //     int rootIndex = numbers.Length % 2 == 0 ? numbers.Length / 2 - 1 : numbers.Length / 2;
        //     acc[index] = numbers[rootIndex]; 
        //     int[] left = numbers.Take(rootIndex).ToArray();
        //     int[] right = numbers.Skip(rootIndex + 1).ToArray();
        //
        //     BuildBBST(left, acc, index + 1);
        //     return BuildBBST(right, acc, index + 2);
        // }
    }
}