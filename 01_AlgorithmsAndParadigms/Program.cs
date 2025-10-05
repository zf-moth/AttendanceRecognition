// Co je to algoritmus, program, programovací jazyk a vývojové prostředí.
// Základní paradigmata programování:
// deklarativní programování, imperativní programování, objektově orientované programování.

namespace _01_AlgorithmsAndParadigms;

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("=== Algorithms and Programming Paradigms ===\n");

        // Algorithm: Step-by-step procedure to solve a problem
        Console.WriteLine("1. Algorithm Example: Find maximum of three numbers");
        int max = FindMax(15, 42, 28);
        Console.WriteLine($"Maximum: {max}\n");

        // Imperative Programming - step-by-step instructions
        Console.WriteLine("2. Imperative Programming:");
        int sum = 0;
        for (int i = 1; i <= 5; i++)
        {
            sum += i;
        }
        Console.WriteLine($"Sum 1-5: {sum}\n");

        // Declarative Programming (using LINQ)
        Console.WriteLine("3. Declarative Programming (LINQ):");
        int[] numbers = { 1, 2, 3, 4, 5 };
        int sumLinq = numbers.Sum();
        Console.WriteLine($"Sum using LINQ: {sumLinq}\n");

        // Object-Oriented Programming
        Console.WriteLine("4. Object-Oriented Programming:");
        Calculator calc = new Calculator();
        Console.WriteLine($"5 + 3 = {calc.Add(5, 3)}");
        Console.WriteLine($"10 - 4 = {calc.Subtract(10, 4)}\n");

        Console.WriteLine("Program: Set of instructions written in programming language");
        Console.WriteLine("Programming Language: C# - high-level, object-oriented language");
        Console.WriteLine("IDE: Visual Studio, VS Code, Rider - development environments");
    }

    // Simple algorithm implementation
    private static int FindMax(int a, int b, int c)
    {
        int max = a;
        if (b > max) max = b;
        if (c > max) max = c;
        return max;
    }
}

// OOP Example - Encapsulation
internal class Calculator
{
    public int Add(int a, int b) => a + b;
    public int Subtract(int a, int b) => a - b;
}
