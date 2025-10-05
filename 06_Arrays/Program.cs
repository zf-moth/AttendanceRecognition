// Pole. Způsob práce s polem hodnot stejných typů, testování rovnosti a přesouvání hodnot pole.

namespace _06_Arrays;

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("=== Working with Arrays ===\n");

        // 1. Array Declaration and Initialization
        Console.WriteLine("1. Array Declaration:");
        int[] numbers1 = new int[5];              // Declare with size
        int[] numbers2 = { 1, 2, 3, 4, 5 };      // Initialize with values
        int[] numbers3 = new int[] { 10, 20, 30 }; // Explicit initialization

        Console.WriteLine($"Array length: {numbers2.Length}");
        Console.WriteLine($"Elements: {string.Join(", ", numbers2)}\n");

        // 2. Accessing Array Elements
        Console.WriteLine("2. Accessing Elements:");
        Console.WriteLine($"First element: {numbers2[0]}");
        Console.WriteLine($"Last element: {numbers2[^1]}\n");

        // 3. Modifying Array Elements
        Console.WriteLine("3. Modifying Elements:");
        numbers2[0] = 99;
        Console.WriteLine($"After modification: {string.Join(", ", numbers2)}\n");

        // 4. Iterating Through Array
        Console.WriteLine("4. Iterating with for loop:");
        for (int i = 0; i < numbers2.Length; i++)
        {
            Console.Write($"{numbers2[i]} ");
        }
        Console.WriteLine("\n");

        // 5. Testing Array Equality
        Console.WriteLine("5. Testing Array Equality:");
        int[] arr1 = { 1, 2, 3 };
        int[] arr2 = { 1, 2, 3 };
        int[] arr3 = arr1;

        Console.WriteLine($"arr1 == arr2 (reference): {arr1 == arr2}");
        Console.WriteLine($"arr1 == arr3 (reference): {arr1 == arr3}");
        Console.WriteLine($"Arrays content equal: {AreArraysEqual(arr1, arr2)}\n");

        // 6. Copying Arrays
        Console.WriteLine("6. Copying Arrays:");
        int[] original = { 1, 2, 3, 4, 5 };
        int[] copy = new int[original.Length];
        Array.Copy(original, copy, original.Length);
        Console.WriteLine($"Original: {string.Join(", ", original)}");
        Console.WriteLine($"Copy: {string.Join(", ", copy)}\n");

        // 7. Shifting Array Values (Left Shift)
        Console.WriteLine("7. Shifting Array Values:");
        int[] toShift = { 10, 20, 30, 40, 50 };
        Console.WriteLine($"Before shift: {string.Join(", ", toShift)}");
        ShiftLeft(toShift);
        Console.WriteLine($"After left shift: {string.Join(", ", toShift)}\n");

        // 8. Shifting Right
        int[] toShiftRight = { 10, 20, 30, 40, 50 };
        Console.WriteLine($"Before shift: {string.Join(", ", toShiftRight)}");
        ShiftRight(toShiftRight);
        Console.WriteLine($"After right shift: {string.Join(", ", toShiftRight)}\n");

        // 9. Reversing Array
        Console.WriteLine("9. Reversing Array:");
        int[] toReverse = { 1, 2, 3, 4, 5 };
        Console.WriteLine($"Before: {string.Join(", ", toReverse)}");
        Array.Reverse(toReverse);
        Console.WriteLine($"After: {string.Join(", ", toReverse)}\n");

        // 10. Finding Min/Max
        Console.WriteLine("10. Finding Min and Max:");
        int[] values = { 45, 12, 78, 23, 67 };
        Console.WriteLine($"Array: {string.Join(", ", values)}");
        Console.WriteLine($"Min: {FindMin(values)}");
        Console.WriteLine($"Max: {FindMax(values)}");
    }

    private static bool AreArraysEqual(int[] arr1, int[] arr2)
    {
        if (arr1.Length != arr2.Length) return false;
        for (int i = 0; i < arr1.Length; i++)
        {
            if (arr1[i] != arr2[i]) return false;
        }
        return true;
    }

    private static void ShiftLeft(int[] arr)
    {
        if (arr.Length == 0) return;
        int first = arr[0];
        for (int i = 0; i < arr.Length - 1; i++)
        {
            arr[i] = arr[i + 1];
        }
        arr[arr.Length - 1] = first;
    }

    private static void ShiftRight(int[] arr)
    {
        if (arr.Length == 0) return;
        int last = arr[arr.Length - 1];
        for (int i = arr.Length - 1; i > 0; i--)
        {
            arr[i] = arr[i - 1];
        }
        arr[0] = last;
    }

    private static int FindMin(int[] arr)
    {
        int min = arr[0];
        foreach (int num in arr)
        {
            if (num < min) min = num;
        }
        return min;
    }

    private static int FindMax(int[] arr)
    {
        int max = arr[0];
        foreach (int num in arr)
        {
            if (num > max) max = num;
        }
        return max;
    }
}