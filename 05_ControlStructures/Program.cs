// Větvení programu a cykly.

namespace _05_ControlStructures;

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("=== Branching and Loops ===\n");

        // 1. IF-ELSE Statement
        Console.WriteLine("1. IF-ELSE Statement:");
        Console.Write("Enter number: ");
        int number = int.TryParse(Console.ReadLine(), out var n) ? n : 0;
        if (number > 10)
        {
            Console.WriteLine($"{number} is greater than 10");
        }
        else
        {
            Console.WriteLine($"{number} is 10 or less");
        }

        // 2. IF-ELSE IF-ELSE (Switch is better for this)
        Console.WriteLine("\n2. IF-ELSE IF-ELSE:");
        Console.Write("Enter score(0-100): ");
        int score = int.TryParse(Console.ReadLine(), out var s) ? s : 0;
        if (score >= 90)
            Console.WriteLine("Grade: A");
        else if (score >= 80)
            Console.WriteLine("Grade: B");
        else if (score >= 70)
            Console.WriteLine("Grade: C");
        else
            Console.WriteLine("Grade: F");

        // 3. SWITCH Statement
        Console.WriteLine("\n3. SWITCH Statement:");
        Console.Write("Enter day of the week (1-7): ");
        int day = int.TryParse(Console.ReadLine(), out var d) ? d : 0;
        switch (day)
        {
            case 1:
                Console.WriteLine("Monday");
                break;
            case 2:
                Console.WriteLine("Tuesday");
                break;
            case 3:
                Console.WriteLine("Wednesday");
                break;
            case 4:
                Console.WriteLine("Thursday");
                break;
            case 5:
                Console.WriteLine("Friday");
                break;
            case 6:
                Console.WriteLine("Saturday");
                break;
            case 7:
                Console.WriteLine("Sunday");
                break;
            default:
                Console.WriteLine("Invalid day");
                break;
        }

        // 4. FOR Loop
        Console.WriteLine("\n4. FOR Loop:");
        Console.Write("Counting 1 to 5: ");
        for (int i = 1; i <= 5; i++)
        {
            Console.Write($"{i} ");
        }
        Console.WriteLine();

        // 5. WHILE Loop
        Console.WriteLine("\n5. WHILE Loop:");
        int count = 1;
        Console.Write("While loop 1 to 5: ");
        while (count <= 5)
        {
            Console.Write($"{count} ");
            count++;
        }
        Console.WriteLine();

        // 6. DO-WHILE Loop
        Console.WriteLine("\n6. DO-WHILE Loop:");
        int num = 1;
        Console.Write("Do-while loop 1 to 5: ");
        do
        {
            Console.Write($"{num} ");
            num++;
        } while (num <= 5);
        Console.WriteLine();

        // 7. FOREACH Loop
        Console.WriteLine("\n7. FOREACH Loop:");
        string[] fruits = { "Apple", "Banana", "Cherry" };
        Console.WriteLine("Fruits:");
        foreach (string fruit in fruits)
        {
            Console.WriteLine($"- {fruit}");
        }

        // 8. BREAK and CONTINUE
        Console.WriteLine("\n8. BREAK and CONTINUE:");
        Console.Write("Break example (stop at 5): ");
        for (int i = 1; i <= 10; i++)
        {
            if (i == 6) break;
            Console.Write($"{i} ");
        }
        Console.WriteLine();

        Console.Write("Continue example (skip 3): ");
        for (int i = 1; i <= 5; i++)
        {
            if (i == 3) continue;
            Console.Write($"{i} ");
        }
        Console.WriteLine();

        // 9. Nested Loops
        Console.WriteLine("\n9. Nested Loops (Multiplication Table):");
        for (int i = 1; i <= 5; i++)
        {
            for (int j = 1; j <= 5; j++)
            {
                Console.Write($"{i * j}\t");
            }
            Console.WriteLine();
        }

        // 10. Ternary Operator
        Console.WriteLine("\n10. Ternary Operator:");
        Console.Write("Enter age: ");
        int age = int.TryParse(Console.ReadLine(), out var a) ? a : 0;
        string status = (age >= 18) ? "Adult" : "Minor";
        Console.WriteLine($"Age {age}: {status}");
    }
}