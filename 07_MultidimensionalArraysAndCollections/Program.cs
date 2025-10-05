// Dvojrozměrné a vícerozměrné pole, zásobník, fronta, dynamické pole a asociativní pole z hlediska uživatele.

namespace _07_MultidimensionalArraysAndCollections;

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("=== Multidimensional Arrays and Collections ===\n");

        // 1. Two-Dimensional Array
        Console.WriteLine("1. Two-Dimensional Array (Matrix):");
        int[,] matrix = {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
        };

        Console.WriteLine("Matrix:");
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write($"{matrix[i, j]}\t");
            }
            Console.WriteLine();
        }
        Console.WriteLine();

        // 2. Three-Dimensional Array
        Console.WriteLine("2. Three-Dimensional Array:");
        int[,,] cube = new int[2, 2, 2]
        {
            { { 1, 2 }, { 3, 4 } },
            { { 5, 6 }, { 7, 8 } }
        };
        Console.WriteLine($"Element [1,1,1]: {cube[1, 1, 1]}\n");

        // 3. Jagged Array (Array of Arrays)
        Console.WriteLine("3. Jagged Array:");
        int[][] jagged = new int[3][];
        jagged[0] = new int[] { 1, 2 };
        jagged[1] = new int[] { 3, 4, 5 };
        jagged[2] = new int[] { 6, 7, 8, 9 };

        for (int i = 0; i < jagged.Length; i++)
        {
            Console.Write($"Row {i}: ");
            for (int j = 0; j < jagged[i].Length; j++)
            {
                Console.Write($"{jagged[i][j]} ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();

        // 4. Stack (LIFO - Last In First Out)
        Console.WriteLine("4. Stack (LIFO):");
        Stack<int> stack = new Stack<int>();
        stack.Push(10);
        stack.Push(20);
        stack.Push(30);
        Console.WriteLine($"Stack elements: {string.Join(", ", stack)}");
        Console.WriteLine($"Pop: {stack.Pop()}");
        Console.WriteLine($"Peek: {stack.Peek()}");
        Console.WriteLine($"After operations: {string.Join(", ", stack)}\n");

        // 5. Queue (FIFO - First In First Out)
        Console.WriteLine("5. Queue (FIFO):");
        Queue<string> queue = new Queue<string>();
        queue.Enqueue("First");
        queue.Enqueue("Second");
        queue.Enqueue("Third");
        Console.WriteLine($"Queue elements: {string.Join(", ", queue)}");
        Console.WriteLine($"Dequeue: {queue.Dequeue()}");
        Console.WriteLine($"Peek: {queue.Peek()}");
        Console.WriteLine($"After operations: {string.Join(", ", queue)}\n");

        // 6. Dynamic Array (List)
        Console.WriteLine("6. Dynamic Array (List<T>):");
        List<int> dynamicList = new List<int>();
        dynamicList.Add(10);
        dynamicList.Add(20);
        dynamicList.Add(30);
        Console.WriteLine($"List: {string.Join(", ", dynamicList)}");
        dynamicList.Insert(1, 15);
        Console.WriteLine($"After Insert(1, 15): {string.Join(", ", dynamicList)}");
        dynamicList.Remove(20);
        Console.WriteLine($"After Remove(20): {string.Join(", ", dynamicList)}");
        Console.WriteLine($"Count: {dynamicList.Count}\n");

        // 7. Associative Array (Dictionary)
        Console.WriteLine("7. Associative Array (Dictionary):");
        Dictionary<string, int> ages = new Dictionary<string, int>();
        ages["Alice"] = 25;
        ages["Bob"] = 30;
        ages["Charlie"] = 35;

        Console.WriteLine("Dictionary contents:");
        foreach (var pair in ages)
        {
            Console.WriteLine($"{pair.Key}: {pair.Value}");
        }

        Console.WriteLine($"\nBob's age: {ages["Bob"]}");
        Console.WriteLine($"Contains 'Alice': {ages.ContainsKey("Alice")}");

        // 8. LinkedList
        Console.WriteLine("\n8. LinkedList:");
        LinkedList<string> linkedList = new LinkedList<string>();
        linkedList.AddLast("A");
        linkedList.AddLast("C");
        linkedList.AddFirst("B");
        Console.WriteLine($"LinkedList: {string.Join(" -> ", linkedList)}");

        // 9. HashSet (Unique elements)
        Console.WriteLine("\n9. HashSet (Unique Elements):");
        HashSet<int> hashSet = new HashSet<int> { 1, 2, 3, 2, 1 };
        Console.WriteLine($"HashSet: {string.Join(", ", hashSet)}");
    }
}