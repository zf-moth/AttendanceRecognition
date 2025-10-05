// Správa paměti, automatická (na zásobníku), statický blok, dynamická alokace (na haldě).

namespace _12_MemoryManagement;

internal static class Program
{
    // Static variable - stored in static memory
    private const int StaticVariable = 100;

    private static void Main(string[] args)
    {
        Console.WriteLine("=== Memory Management ===\n");

        // 1. Stack Memory (Automatic)
        Console.WriteLine("1. Stack Memory (Automatic Allocation):");
        int stackVariable = 42;  // Allocated on stack
        Console.WriteLine($"Stack variable: {stackVariable}");
        Console.WriteLine("- Fast allocation and deallocation");
        Console.WriteLine("- Automatically cleaned when method ends");
        Console.WriteLine("- Limited size (typically 1MB)\n");

        // 2. Static Memory
        Console.WriteLine("2. Static Memory:");
        Console.WriteLine($"Static variable: {StaticVariable}");
        Console.WriteLine("- Allocated when program starts");
        Console.WriteLine("- Exists for entire program lifetime");
        Console.WriteLine("- Shared across all instances\n");

        // 3. Heap Memory (Dynamic Allocation)
        Console.WriteLine("3. Heap Memory (Dynamic Allocation):");
        Person person = new Person("Alice", 25); // Allocated on heap
        Console.WriteLine($"Heap object: {person.Name}, Age: {person.Age}");
        Console.WriteLine("- Allocated using 'new' keyword");
        Console.WriteLine("- Managed by Garbage Collector");
        Console.WriteLine("- Larger size, slower than stack\n");

        // 4. Value Types vs Reference Types
        Console.WriteLine("4. Value Types (Stack) vs Reference Types (Heap):");
        
        // Value type on stack
        int value1 = 10;
        int value2 = value1;  // Copy
        value2 = 20;
        Console.WriteLine($"Value types: value1={value1}, value2={value2}");
        
        // Reference type on heap
        Person p1 = new Person("Bob", 30);
        Person p2 = p1;  // Reference copy
        p2.Age = 35;
        Console.WriteLine($"Reference types: p1.Age={p1.Age}, p2.Age={p2.Age}");
        Console.WriteLine("Both point to same object on heap\n");

        // 5. Memory allocation examples
        Console.WriteLine("5. Memory Allocation Demonstration:");
        DemonstrateMemoryAllocation();
        Console.WriteLine();

        // 6. Garbage Collection
        Console.WriteLine("6. Garbage Collection:");
        Console.WriteLine("- Automatic memory management");
        Console.WriteLine("- Frees memory of unreferenced objects");
        Console.WriteLine("- Runs periodically");
        
        for (int i = 0; i < 5; i++)
        {
            Person temp = new Person($"Temp{i}", 20 + i);
        }
        
        Console.WriteLine($"Memory before GC: {GC.GetTotalMemory(false)} bytes");
        GC.Collect();
        GC.WaitForPendingFinalizers();
        Console.WriteLine($"Memory after GC: {GC.GetTotalMemory(true)} bytes\n");

        // 7. Struct vs Class memory
        Console.WriteLine("7. Struct (Stack) vs Class (Heap):");
        PointStruct ps = new PointStruct(10, 20);
        PointClass pc = new PointClass(10, 20);
        Console.WriteLine($"Struct on stack: ({ps.X}, {ps.Y})");
        Console.WriteLine($"Class on heap: ({pc.X}, {pc.Y})\n");

        // 8. Memory layout visualization
        Console.WriteLine("8. Memory Layout:");
        Console.WriteLine("+-------------------+");
        Console.WriteLine("|   STATIC MEMORY   |  <- Static variables");
        Console.WriteLine("+-------------------+");
        Console.WriteLine("|                   |");
        Console.WriteLine("|      HEAP         |  <- Reference types (objects, arrays)");
        Console.WriteLine("|        ↓          |     Grows downward");
        Console.WriteLine("|                   |     Managed by GC");
        Console.WriteLine("|                   |");
        Console.WriteLine("|        ↑          |");
        Console.WriteLine("|      STACK        |  <- Value types, local variables");
        Console.WriteLine("|                   |     Grows upward");
        Console.WriteLine("+-------------------+     Auto-cleaned (LIFO)");
    }

    static void DemonstrateMemoryAllocation()
    {
        // Stack allocation
        int localInt = 100;              // Stack
        double localDouble = 3.14;       // Stack
        bool localBool = true;           // Stack

        Console.WriteLine("Stack allocations:");
        Console.WriteLine($"  int: {localInt}");
        Console.WriteLine($"  double: {localDouble}");
        Console.WriteLine($"  bool: {localBool}");

        // Heap allocation
        Person person = new Person("Charlie", 28);  // Heap
        int[] array = new int[5];                   // Heap
        string text = "Hello";                      // Heap

        Console.WriteLine("Heap allocations:");
        Console.WriteLine($"  Person object: {person.Name}");
        Console.WriteLine($"  Array: {array.Length} elements");
        Console.WriteLine($"  String: {text}");

        // When method ends, stack variables are automatically cleaned
        // Heap objects remain until garbage collected
    }
}

// Reference type - allocated on heap
class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
}

// Value type - allocated on stack
struct PointStruct
{
    public int X;
    public int Y;

    public PointStruct(int x, int y)
    {
        X = x;
        Y = y;
    }
}

// Reference type - allocated on heap
class PointClass
{
    public int X { get; set; }
    public int Y { get; set; }

    public PointClass(int x, int y)
    {
        X = x;
        Y = y;
    }
}