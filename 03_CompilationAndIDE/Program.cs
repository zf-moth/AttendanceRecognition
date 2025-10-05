// Překlad, sestavení a spuštění programu a základy práce s IDE.
// Základní knihovny jazyka. Nástroje pro vstupní a výstupní operace.

namespace _03_CompilationAndIDE;

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("=== Compilation, Build, Run & IDE Basics ===\n");

        // Compilation process explanation
        Console.WriteLine("Compilation Process:");
        Console.WriteLine("1. Source Code (.cs) -> C# Compiler (csc.exe)");
        Console.WriteLine("2. Intermediate Language (IL/MSIL) -> .dll or .exe");
        Console.WriteLine("3. JIT Compiler -> Native Machine Code");
        Console.WriteLine("4. Execution by CLR (Common Language Runtime)\n");

        // IDE Basics
        Console.WriteLine("IDE Features:");
        Console.WriteLine("- Code Editor with syntax highlighting");
        Console.WriteLine("- IntelliSense (auto-completion)");
        Console.WriteLine("- Debugger (breakpoints, step through)");

        // Basic Libraries
        Console.WriteLine("Common C# Libraries:");
        Console.WriteLine("- System: Basic types and utilities");
        Console.WriteLine("- System.Collections.Generic: Lists, Dictionaries");
        Console.WriteLine("- System.IO: File and stream operations");
        Console.WriteLine("- System.Linq: Language Integrated Query\n");

        // Input/Output Operations
        Console.WriteLine("=== Input/Output Operations ===\n");

        // Console Input
        string name = AskUser("Enter your name: ");
        Console.WriteLine($"Hello, {name}!");

        // Console Output
        Console.WriteLine("\nFormatted output:");
        int age = 25;
        Console.WriteLine($"Name: {name}, Age: {age}");

        // File I/O Example
        Console.WriteLine("\n--- File I/O Example ---");
        string filePath = "example.txt";
        
        // Check if a file exists if it does clear its content
        if (File.Exists(filePath))
        {
            File.WriteAllText(filePath,  string.Empty);
            Console.WriteLine($"File {filePath} cleared");
        }
        
        // Write to a file
        File.WriteAllText(filePath, $"User: {name}\nAge: {age}");
        Console.WriteLine($"Data written to {filePath}");

        // Read from a file
        string content = File.ReadAllText(filePath);
        Console.WriteLine($"Data read from file:\n{content}");
    }
    
    private static string AskUser(string prompt)
    {
        string? input;
        do
        {
            Console.Write(prompt);
            input = Console.ReadLine();
        } while (string.IsNullOrWhiteSpace(input));
        return input;
    }
}