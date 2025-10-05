// Funkce, definice a použití. Rekurzivní funkce. Řadící algoritmus QuickSort.

namespace _09_FunctionsAndRecursion;

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("=== Functions and Recursion ===\n");

        // 1. Simple Function
        Console.WriteLine("1. Simple Function:");
        int sum = Add(10, 20);
        Console.WriteLine($"Add(10, 20) = {sum}\n");

        // 2. Function with Return Value
        Console.WriteLine("2. Function with Return Value:");
        double area = CalculateCircleArea(5);
        Console.WriteLine($"Circle area (radius=5): {area:F2}\n");

        // 3. Function with Multiple Parameters
        Console.WriteLine("3. Function with Multiple Parameters:");
        DisplayInfo("Alice", 25, "Engineer");
        Console.WriteLine();

        // 4. Function with Default Parameters
        Console.WriteLine("4. Default Parameters:");
        Greet("Bob");
        Greet("Charlie", "Good evening");
        Console.WriteLine();

        // 5. Ref and Out Parameters
        Console.WriteLine("5. Ref and Out Parameters:");
        int number = 10;
        Console.WriteLine($"Before Square (ref): {number}");
        Square(ref number);
        Console.WriteLine($"After Square (ref): {number}");

        Divide(20, 3, out int quotient, out int remainder);
        Console.WriteLine($"20 / 3 = {quotient} remainder {remainder}\n");

        // 6. Recursive Functions
        Console.WriteLine("6. Recursive Functions:");
        
        // Factorial
        Console.WriteLine("Factorial Examples:");
        for (int i = 0; i <= 5; i++)
        {
            Console.WriteLine($"{i}! = {Factorial(i)}");
        }
        Console.WriteLine();

        // Fibonacci
        Console.WriteLine("Fibonacci Sequence (first 10):");
        for (int i = 0; i < 10; i++)
        {
            Console.Write($"{Fibonacci(i)} ");
        }
        Console.WriteLine("\n");

        // Sum of digits
        Console.WriteLine("Sum of Digits:");
        const int num = 12345;
        Console.WriteLine($"Sum of digits of {num}: {SumOfDigits(num)}\n");

        // 7. QuickSort Algorithm (Recursive)
        Console.WriteLine("7. QuickSort (Recursive):");
        int[] arr = { 64, 34, 25, 12, 22, 11, 90 };
        Console.WriteLine($"Before: {string.Join(", ", arr)}");
        QuickSort(arr, 0, arr.Length - 1);
        Console.WriteLine($"After:  {string.Join(", ", arr)}\n");

        // 8. Tower of Hanoi
        Console.WriteLine("8. Tower of Hanoi (3 disks):");
        TowerOfHanoi(3, 'A', 'C', 'B');
    }

    // Simple function
    private static int Add(int a, int b)
    {
        return a + b;
    }

    // Function with calculation
    private static double CalculateCircleArea(double radius)
    {
        return Math.PI * radius * radius;
    }

    // Function with multiple parameters
    private static void DisplayInfo(string name, int age, string occupation)
    {
        Console.WriteLine($"Name: {name}, Age: {age}, Occupation: {occupation}");
    }

    // Function with default parameters
    private static void Greet(string name, string greeting = "Hello")
    {
        Console.WriteLine($"{greeting}, {name}!");
    }

    // Ref parameter
    private static void Square(ref int num)
    {
        num = num * num;
    }

    // Out parameters
    private static void Divide(int dividend, int divisor, out int quotient, out int remainder)
    {
        quotient = dividend / divisor;
        remainder = dividend % divisor;
    }

    // Recursive: Factorial
    private static int Factorial(int n)
    {
        if (n <= 1)
            return 1;
        return n * Factorial(n - 1);
    }

    // Recursive: Fibonacci
    private static int Fibonacci(int n)
    {
        if (n <= 1)
            return n;
        return Fibonacci(n - 1) + Fibonacci(n - 2);
    }

    // Recursive: Sum of digits
    private static int SumOfDigits(int n)
    {
        if (n == 0)
            return 0;
        return (n % 10) + SumOfDigits(n / 10);
    }

    // QuickSort - Recursive sorting algorithm
    // Quicksort works by choosing a pivot, partitioning the surrounding array,
    // then recursively sorting the left and right halves.
    // It’s efficient (O(n log n) average), simple to implement, and widely used.
    private static void QuickSort(int[] arr, int low, int high)
    {
        if (low < high)
        {
            int pivotIndex = Partition(arr, low, high);
            QuickSort(arr, low, pivotIndex - 1);
            QuickSort(arr, pivotIndex + 1, high);
        }
    }

    private static int Partition(int[] arr, int low, int high)
    {
        int pivot = arr[high];
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (arr[j] < pivot)
            {
                i++;
                Swap(ref arr[i], ref arr[j]);
            }
        }

        Swap(ref arr[i + 1], ref arr[high]);
        return i + 1;
    }

    private static void Swap(ref int a, ref int b)
    {
        (a, b) = (b, a);
    }

    // Tower of Hanoi - Recursive algorithm
    private static void TowerOfHanoi(int n, char from, char to, char aux)
    {
        if (n == 1)
        {
            Console.WriteLine($"Move disk 1 from {from} to {to}");
            return;
        }

        TowerOfHanoi(n - 1, from, aux, to);
        Console.WriteLine($"Move disk {n} from {from} to {to}");
        TowerOfHanoi(n - 1, aux, to, from);
    }
    
    /*TowerOfHanoi(3, A, C, B)
    ├── TowerOfHanoi(2, A, B, C)
    │   ├── TowerOfHanoi(1, A, C, B)
    │   │    └── Move disk 1 from A → C
    │   ├── Move disk 2 from A → B
    │   └── TowerOfHanoi(1, C, B, A)
    │        └── Move disk 1 from C → B
    │
    ├── Move disk 3 from A → C
    │
    └── TowerOfHanoi(2, B, C, A)
    ├── TowerOfHanoi(1, B, A, C)
    │    └── Move disk 1 from B → A
    ├── Move disk 2 from B → C
    └── TowerOfHanoi(1, A, C, B)
    └── Move disk 1 from A → C*/
}