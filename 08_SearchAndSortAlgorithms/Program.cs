// Algoritmy hledání v poli (lineární vyhledávání se zarážkou, binární vyhledávání).
// Řadící algoritmy Bubble Sort, Select Sort, Insert Sort.

namespace _08_SearchAndSortAlgorithms;

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("=== Search and Sort Algorithms ===\n");

        // 1. Linear Search
        Console.WriteLine("1. Linear Search:");
        int[] arr1 = { 64, 34, 25, 12, 22, 11, 90 };
        Console.WriteLine($"Array: {string.Join(", ", arr1)}");
        int target = 25;
        int index = LinearSearch(arr1, target);
        Console.WriteLine($"Linear search for {target}: Found at index {index}\n");

        // 2. Linear Search with Sentinel
        Console.WriteLine("2. Linear Search with Sentinel:");
        int[] arr2 = { 64, 34, 25, 12, 22, 11, 90 };
        int indexSentinel = LinearSearchWithSentinel(arr2, 22);
        Console.WriteLine($"Search with sentinel for 22: Found at index {indexSentinel}\n");

        // 3. Binary Search (requires a sorted array)
        Console.WriteLine("3. Binary Search:");
        int[] arr3 = { 11, 12, 22, 25, 34, 64, 90 }; // Sorted array
        Console.WriteLine($"Sorted array: {string.Join(", ", arr3)}");
        int binaryIndex = BinarySearch(arr3, 25);
        Console.WriteLine($"Binary search for 25: Found at index {binaryIndex}\n");

        // 4. Bubble Sort
        Console.WriteLine("4. Bubble Sort:");
        int[] arr4 = { 64, 34, 25, 12, 22, 11, 90 };
        Console.WriteLine($"Before: {string.Join(", ", arr4)}");
        BubbleSort(arr4);
        Console.WriteLine($"After:  {string.Join(", ", arr4)}\n");

        // 5. Selection Sort
        Console.WriteLine("5. Selection Sort:");
        int[] arr5 = { 64, 25, 12, 22, 11 };
        Console.WriteLine($"Before: {string.Join(", ", arr5)}");
        SelectionSort(arr5);
        Console.WriteLine($"After:  {string.Join(", ", arr5)}\n");

        // 6. Insertion Sort
        Console.WriteLine("6. Insertion Sort:");
        int[] arr6 = { 12, 11, 13, 5, 6 };
        Console.WriteLine($"Before: {string.Join(", ", arr6)}");
        InsertionSort(arr6);
        Console.WriteLine($"After:  {string.Join(", ", arr6)}\n");

        // Performance Comparison
        Console.WriteLine("7. Algorithm Complexity:");
        Console.WriteLine("Linear Search: O(n)");
        Console.WriteLine("Binary Search: O(log n) - requires sorted array");
        Console.WriteLine("Bubble Sort: O(n²)");
        Console.WriteLine("Selection Sort: O(n²)");
        Console.WriteLine("Insertion Sort: O(n²)");
    }

    // Linear Search - O(n)
    // Linear search goes through each element until it finds the target.
    private static int LinearSearch(int[] arr, int target)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == target)
                return i;
        }
        return -1; // Not found
    }

    // Linear Search with Sentinel
    // Sentinel is a special element at the end of the array it is used to detect the end of the array.
    // It's faster than checking if the index is out of bounds.
    private static int LinearSearchWithSentinel(int[] arr, int target)
    {
        int n = arr.Length;
        int[] tempArr = new int[n + 1];
        Array.Copy(arr, tempArr, n);
        tempArr[n] = target; // Sentinel

        int i = 0;
        while (tempArr[i] != target)
        {
            i++;
        }

        if (i < n)
            return i;
        return -1;
    }

    // Binary Search - O(log n)
    // Binary search is a more efficient search algorithm than linear search.
    // It works by dividing the array in half until it finds the target.
    private static int BinarySearch(int[] arr, int target)
    {
        int left = 0;
        int right = arr.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (arr[mid] == target)
                return mid;

            if (arr[mid] < target)
                left = mid + 1;
            else
                right = mid - 1;
        }

        return -1; // Not found
    }

    // Bubble Sort - O(n²)
    // Bubble sort is a simple sorting algorithm that repeatedly steps through the list to be sorted,
    // compares each pair of adjacent items and swaps them if they are in the wrong order.
    // The pass through the list is repeated until no swaps are needed, which indicates that the list is sorted.
    private static void BubbleSort(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    // Swap
                    (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                }
            }
        }
    }

    // Selection Sort - O(n²)
    // Selection sort is a simple sorting algorithm that repeatedly steps through the list to be sorted,
    // finds the minimum element from the unsorted part and puts it at the beginning.
    private static void SelectionSort(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < n; j++)
            {
                if (arr[j] < arr[minIndex])
                {
                    minIndex = j;
                }
            }

            // Swap
            (arr[minIndex], arr[i]) = (arr[i], arr[minIndex]);
        }
    }

    // Insertion Sort - O(n²)
    // Insertion sort is a simple sorting algorithm that builds the final sorted array (or list) one item at a time.
    // It works by taking the next element in the array and inserting it into the sorted subarray that has already been sorted.
    private static void InsertionSort(int[] arr)
    {
        int n = arr.Length;
        for (int i = 1; i < n; i++)
        {
            int key = arr[i];
            int j = i - 1;

            while (j >= 0 && arr[j] > key)
            {
                arr[j + 1] = arr[j];
                j--;
            }
            arr[j + 1] = key;
        }
    }
}