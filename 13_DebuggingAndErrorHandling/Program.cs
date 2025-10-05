// Nalezení chyb, ladění programu, sledování průběhu programu.

using System.Diagnostics;
using System.Text;

namespace _13_DebuggingAndErrorHandling;

internal static class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("=== Debugging and Error Detection ===\n");
        
        // Trace.Listeners.Add(new ConsoleTraceListener()); // Uncomment to see trace messages in console

        // 1. Console Debugging
        Console.WriteLine("1. Console Debugging with WriteLine:");
        int x = 10;
        int y = 20;
        Console.WriteLine($"DEBUG: x = {x}, y = {y}");
        int result = x + y;
        Console.WriteLine($"DEBUG: result = {result}\n");

        // 2. Debug Class
        Console.WriteLine("2. Using Debug Class:");
        Debug.WriteLine("This appears in Debug output window");
        Debug.Assert(result == 30, "Result should be 30");
        Console.WriteLine("Debug assertions help catch logical errors\n");

        // 3. Trace
        Console.WriteLine("3. Trace Messages:");
        Trace.WriteLine($"Trace: Program started at {DateTime.Now}");
        Trace.WriteLine("Trace works in both Debug and Release modes\n");

        // 4. Breakpoint simulation
        Console.WriteLine("4. Breakpoint Simulation:");
        Console.WriteLine("To set breakpoint in IDE:");
        Console.WriteLine("- Click on left margin of code line");
        Console.WriteLine("- Or press F9 on the line");
        Console.WriteLine("- Run with Shift+F9 (Debug mode)");
        Console.WriteLine("- Execution pauses at breakpoint\n");

        // 5. Watch variables
        Console.WriteLine("5. Watching Variables:");
        for (int i = 0; i < 5; i++)
        {
            int square = i * i;
            Console.WriteLine($"i={i}, square={square}");
            // In debugger, add 'i' and 'square' to Watches
        }
        Console.WriteLine();

        // 6. Step Through Code
        Console.WriteLine("6. Stepping Through Code:");
        Console.WriteLine("- F8: Step Over (execute line)");
        Console.WriteLine("- F7: Step Into (enter method)");
        Console.WriteLine("- Shift+F8: Step Out (exit method)");
        Console.WriteLine("- F9: Continue to next breakpoint\n");

        // 7. Call Stack
        Console.WriteLine("7. Call Stack Tracing:");
        Method1();
        Console.WriteLine();

        // 8. Conditional Debugging
        Console.WriteLine("8. Conditional Debugging:");
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine($"i = {i}"); // Set conditional breakpoint here (e.g., i == 5)
        }
        Console.WriteLine();

        // 9. Performance Measurement
        Console.WriteLine("9. Performance Measurement:");

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        // Method 1: String concatenation with + operator
        string result1 = "";
        for (int i = 0; i < 10000; i++)
        {
            result1 += "test";
        }

        stopwatch.Stop();
        Console.WriteLine($"DEBUG: Method1() took {stopwatch.ElapsedMilliseconds} ms");
        Console.WriteLine();

        stopwatch.Restart();

        // Method 2: StringBuilder approach
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < 10000; i++)
        {
            sb.Append("test");
        }
        string result2 = sb.ToString();

        stopwatch.Stop();
        Console.WriteLine($"DEBUG: Method2() took {stopwatch.ElapsedMilliseconds} ms\n");

        // 10. Debugging Complex Objects
        Console.WriteLine("10. Debugging Complex Objects:");
        Person person = new Person { Name = "Alice", Age = 25 };
        Console.WriteLine($"DEBUG: Person = {person}");
        Console.WriteLine("Use debugger to inspect object properties\n");

        // 11. Common Debugging Scenarios
        Console.WriteLine("11. Common Debugging Scenarios:");
        DebugCommonErrors();
    }

    static void Method1()
    {
        Console.WriteLine("Entered Method1");
        Method2();
        Console.WriteLine("Exited Method1");
    }

    static void Method2()
    {
        Console.WriteLine("Entered Method2");
        Method3();
        Console.WriteLine("Exited Method2");
    }

    static void Method3()
    {
        Console.WriteLine("Entered Method3");
        Console.WriteLine("View Call Stack window to see: Main -> Method1 -> Method2 -> Method3");
        Console.WriteLine("Exited Method3");
    }

    static void DebugCommonErrors()
    {
        // Off-by-one error
        Console.WriteLine("Common Error 1: Off-by-one");
        int[] arr = { 1, 2, 3, 4, 5 };
        for (int i = 0; i <= arr.Length; i++) // Off-by-one error
        {
            if (i < arr.Length) // Prevent out-of-bounds
                Console.Write($"{arr[i]} ");
            else
                Console.WriteLine("\nAvoided IndexOutOfRangeException");
        }
        Console.WriteLine("\n");

        // Null reference
        Console.WriteLine("Common Error 2: Null Reference");
        string text = null;
        if (text != null) // Check before use
        {
            Console.WriteLine(text.Length);
        }
        else
        {
            Console.WriteLine("Text is null - avoided NullReferenceException");
        }
        Console.WriteLine();

        // Integer division
        Console.WriteLine("Common Error 3: Integer Division");
        int a = 5, b = 2;
        Console.WriteLine($"Integer division: {a / b}");
        Console.WriteLine($"Correct division: {(double)a / b}");
    }
}

class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public override string ToString()
    {
        return $"Person(Name={Name}, Age={Age})";
    }
}