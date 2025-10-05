// Druhy výjimek v programu a jejich zpracování.

namespace _14_ExceptionHandling;

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("=== Exception Types and Handling ===\n");

        // 1. Basic Try-Catch
        Console.WriteLine("1. Basic Try-Catch:");
        try
        {
            Console.WriteLine("Enter a zero: ");
            int result = 10 / int.Parse(Console.ReadLine());  // DivideByZeroException
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        Console.WriteLine();

        // 2. Multiple Catch Blocks
        Console.WriteLine("2. Multiple Catch Blocks:");
        HandleMultipleExceptions("123");
        HandleMultipleExceptions("abc");
        HandleMultipleExceptions(null);
        Console.WriteLine();

        // 3. Finally Block
        Console.WriteLine("3. Finally Block:");
        TryWithFinally();
        Console.WriteLine();

        // 4. Common Exception Types
        Console.WriteLine("4. Common Exception Types:");
        DemonstrateExceptionTypes();
        Console.WriteLine();

        // 5. Throwing Exceptions
        Console.WriteLine("5. Throwing Exceptions:");
        try
        {
            ValidateAge(-5);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Caught: {ex.Message}");
        }
        Console.WriteLine();

        // 6. Custom Exceptions
        Console.WriteLine("6. Custom Exceptions:");
        try
        {
            BankAccount account = new BankAccount(100);
            account.Withdraw(150);
        }
        catch (InsufficientFundsException ex)
        {
            Console.WriteLine($"Custom Exception: {ex.Message}");
            Console.WriteLine($"Balance: ${ex.CurrentBalance}, Attempted: ${ex.AttemptedAmount}");
        }
        Console.WriteLine();

        // 7. Exception Properties
        Console.WriteLine("7. Exception Properties:");
        try
        {
            throw new InvalidOperationException("Test exception");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Message: {ex.Message}");
            Console.WriteLine($"Type: {ex.GetType().Name}");
            Console.WriteLine($"Stack Trace:\n{ex.StackTrace}");
        }
        Console.WriteLine();

        // 8. Nested Try-Catch
        Console.WriteLine("8. Nested Try-Catch:");
        NestedTryCatch();
        Console.WriteLine();

        // 9. Re-throwing Exceptions
        Console.WriteLine("9. Re-throwing Exceptions:");
        try
        {
            ProcessData();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Caught re-thrown exception: {ex.Message}");
        }
        Console.WriteLine();

        // 10. Using Statement (Automatic Resource Cleanup)
        Console.WriteLine("10. Using Statement:");
        UsingStatementDemo();
    }

    static void HandleMultipleExceptions(string input)
    {
        try
        {
            int number = int.Parse(input);
            int result = 100 / number;
            Console.WriteLine($"Result: {result}");
        }
        catch (FormatException)
        {
            Console.WriteLine($"FormatException: '{input}' is not a valid number");
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("DivideByZeroException: Cannot divide by zero");
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("ArgumentNullException: Input is null");
        }
    }

    static void TryWithFinally()
    {
        try
        {
            Console.WriteLine("Try block executed");
            int result = 10 / 2;
            Console.WriteLine($"Result: {result}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Catch: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("Finally block always executes (cleanup code here)");
        }
    }

    static void DemonstrateExceptionTypes()
    {
        // NullReferenceException
        try
        {
            string text = null;
            int length = text.Length;
        }
        catch (NullReferenceException)
        {
            Console.WriteLine("- NullReferenceException: Accessing null object");
        }

        // IndexOutOfRangeException
        try
        {
            int[] arr = { 1, 2, 3 };
            int value = arr[5];
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("- IndexOutOfRangeException: Array index out of bounds");
        }

        // InvalidCastException
        try
        {
            object obj = "Hello";
            int number = (int)obj;
        }
        catch (InvalidCastException)
        {
            Console.WriteLine("- InvalidCastException: Invalid type casting");
        }

        // FileNotFoundException
        try
        {
            string content = File.ReadAllText("nonexistent.txt");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("- FileNotFoundException: File not found");
        }

        // OverflowException
        try
        {
            checked
            {
                int max = int.MaxValue;
                max = max + 1;
            }
        }
        catch (OverflowException)
        {
            Console.WriteLine("- OverflowException: Arithmetic overflow");
        }
    }

    static void ValidateAge(int age)
    {
        if (age < 0)
        {
            throw new ArgumentException("Age cannot be negative");
        }
        Console.WriteLine($"Age is valid: {age}");
    }

    static void NestedTryCatch()
    {
        try
        {
            Console.WriteLine("Outer try");
            try
            {
                Console.WriteLine("Inner try");
                Console.WriteLine("Enter a zero: ");
                int result = 10 / int.Parse(Console.ReadLine());
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Inner catch: Division by zero");
                throw; // Re-throw to outer catch
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Outer catch: {ex.Message}");
        }
    }

    static void ProcessData()
    {
        try
        {
            throw new InvalidOperationException("Data processing failed");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Caught in ProcessData: {ex.Message}");
            throw; // Re-throw to caller
        }
    }

    static void UsingStatementDemo()
    {
        // Using statement ensures Dispose() is called
        string fileName = "test.txt";
        
        try
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.WriteLine("Line 1");
                writer.WriteLine("Line 2");
                Console.WriteLine($"Data written to {fileName}");
            }
            // writer.Dispose() automatically called here

            using (StreamReader reader = new StreamReader(fileName))
            {
                string content = reader.ReadToEnd();
                Console.WriteLine($"Data read: {content.Length} characters");
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine($"IO Exception: {ex.Message}");
        }
    }
}

// Custom Exception Class
class InsufficientFundsException : Exception
{
    public double CurrentBalance { get; set; }
    public double AttemptedAmount { get; set; }

    public InsufficientFundsException(double balance, double amount)
        : base($"Insufficient funds. Balance: ${balance}, Attempted: ${amount}")
    {
        CurrentBalance = balance;
        AttemptedAmount = amount;
    }
}

class BankAccount
{
    private double balance;

    public BankAccount(double initialBalance)
    {
        balance = initialBalance;
    }

    public void Withdraw(double amount)
    {
        if (amount > balance)
        {
            throw new InsufficientFundsException(balance, amount);
        }
        balance -= amount;
    }
}