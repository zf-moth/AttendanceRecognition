// Popis algoritmu pomocí vývojového diagramu.
// TODO: Add Flowchart using Latex and TikZ

namespace _02_AlgorithmFlowcharts;

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("=== Algorithm Description with Flowcharts ===\n");
        Console.WriteLine("See the LaTeX files for visual flowchart representations:\n");
        Console.WriteLine("1. EvenOddFlowchart.tex - Even/Odd number checker");
        Console.WriteLine("2. FactorialFlowchart.tex - Factorial calculator\n");

        // Algorithm 1: Check if the number is even or odd
        Console.WriteLine("Algorithm 1: Check Even/Odd Number");
        Console.Write("Enter a number: ");
        if (int.TryParse(Console.ReadLine(), out int number))
        {
            if (number % 2 == 0)
                Console.WriteLine($"{number} is Even");
            else
                Console.WriteLine($"{number} is Odd");
        }

        Console.WriteLine("\n--- Algorithm 2: Calculate Factorial ---");
        Console.Write("Enter number for factorial: ");
        if (int.TryParse(Console.ReadLine(), out int n))
        {
            double factorial = CalculateFactorial(n);
            Console.WriteLine($"Factorial of {n} = {factorial}");
        }
    }

    private static double CalculateFactorial(int n)
    {
        double result = 1;
        for (int i = 1; i <= n; i++)
        {
            result *= i;
        }
        return result;
    }
}

