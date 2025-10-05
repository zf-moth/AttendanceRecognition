// Základní prvky programu. Způsob zadávání hodnot, výrazů a příkazů v programu.
// Reprezentace hodnot v paměti. Základní typy objektů a operací, které s nimi můžeme provádět.
// Rozsah platnosti objektu.

namespace _04_BasicProgramElements;

internal static class Program
{
    // Global/Class-level variable
    private const int GlobalVariable = 100;

    private static void Main(string[] args)
    {
        Console.WriteLine("=== Basic Program Elements ===\n");

        // 1. Variables - storing values
        Console.WriteLine("1. Variables:");
        const int age = 25;                    // Integer (whole number)
        const double price = 19.99;            // Floating point (decimal number)
        const char grade = 'A';                // Character (single character)
        const bool isStudent = true;           // Boolean (true/false)
        const string name = "John";            // String (text)

        Console.WriteLine($"age={age}, price={price}, grade={grade}, isStudent={isStudent}, name={name}\n");

        // 2. Constants
        const double pi = 3.14159;
        Console.WriteLine($"2. Constant: PI = {pi}\n");

        // 3. Expressions and Operators
        Console.WriteLine("3. Expressions and Operators:");
        const int a = 10, b = 3;
        Console.WriteLine($"a = {a}, b = {b}");
        Console.WriteLine($"a + b = {a + b}");
        Console.WriteLine($"a - b = {a - b}");
        Console.WriteLine($"a * b = {a * b}");
        Console.WriteLine($"a / b = {a / b}");
        Console.WriteLine($"a % b = {a % b}");
        Console.WriteLine($"a > b = {a > b}\n");

        // 4. Type Conversion
        Console.WriteLine("4. Type Conversion:");
        const int intValue = 42;
        double doubleValue = intValue;  // Implicit conversion
        Console.WriteLine($"Implicit: int {intValue} to double {doubleValue}");
        
        const double d = 3.14;
        int i = (int)d;                 // Explicit conversion (casting)
        Console.WriteLine($"Explicit: double {d} to int {i}\n");

        // 5. Memory Representation
        Console.WriteLine("5. Memory Representation:");
        Console.WriteLine($"int size: {sizeof(int)} bytes");
        Console.WriteLine($"double size: {sizeof(double)} bytes");
        Console.WriteLine($"char size: {sizeof(char)} bytes");
        Console.WriteLine($"bool size: {sizeof(bool)} byte\n");

        // 6. Scope of variables
        Console.WriteLine("6. Variable Scope:");
        Console.WriteLine($"Global variable: {GlobalVariable}");
        
        {
            int localVariable = 50;
            Console.WriteLine($"Local variable in block: {localVariable}");
        }
        // localVariable is not accessible here
        
        Console.WriteLine("Local variable is only accessible within its block scope");

        // 7. Value Types vs Reference Types
        Console.WriteLine("\n7. Value Types vs Reference Types:");
        int val1 = 10;
        int val2 = val1;
        val2 = 20;
        Console.WriteLine($"Value types: val1={val1}, val2={val2} (independent)");

        int[] arr1 = { 1, 2, 3 };
        int[] arr2 = arr1;
        arr2[0] = 99;
        Console.WriteLine($"Reference types: arr1[0]={arr1[0]}, arr2[0]={arr2[0]} (shared reference)");
    }
}