// Struktury a třídy. Základy objektově orientovaného programování.

namespace _10_OOPBasics;

internal static class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("=== Structures and Classes - OOP Basics ===\n");

        // 1. Structure Example
        Console.WriteLine("1. Structure (Value Type):");
        Point p1 = new Point(10, 20);
        Point p2 = p1; // Copy by value
        p2.X = 100;
        Console.WriteLine($"p1: ({p1.X}, {p1.Y})");
        Console.WriteLine($"p2: ({p2.X}, {p2.Y})");
        Console.WriteLine("Structures are value types - independent copies\n");

        // 2. Class Example
        Console.WriteLine("2. Class (Reference Type):");
        Person person1 = new Person("Alice", 25);
        Person person2 = person1; // Copy by reference
        person2.Age = 30;
        Console.WriteLine($"person1: {person1.Name}, Age: {person1.Age}");
        Console.WriteLine($"person2: {person2.Name}, Age: {person2.Age}");
        Console.WriteLine("Classes are reference types - shared reference\n");

        // 3. Encapsulation
        Console.WriteLine("3. Encapsulation:");
        BankAccount account = new BankAccount("123456", 1000);
        Console.WriteLine($"Initial balance: ${account.GetBalance()}");
        account.Deposit(500);
        Console.WriteLine($"After deposit: ${account.GetBalance()}");
        account.Withdraw(200);
        Console.WriteLine($"After withdrawal: ${account.GetBalance()}\n");

        // 4. Properties
        Console.WriteLine("4. Properties:");
        Car car = new Car();
        car.Brand = "Toyota";
        car.Model = "Camry";
        car.Year = 2023;
        Console.WriteLine($"Car: {car.Brand} {car.Model} ({car.Year})");
        Console.WriteLine($"Age: {car.Age} years\n");

        // 5. Constructor Overloading
        Console.WriteLine("5. Constructor Overloading:");
        Rectangle rect1 = new Rectangle();
        Rectangle rect2 = new Rectangle(5, 10);
        Console.WriteLine($"rect1 area: {rect1.CalculateArea()}");
        Console.WriteLine($"rect2 area: {rect2.CalculateArea()}\n");

        // 6. Static Members
        Console.WriteLine("6. Static Members:");
        Console.WriteLine($"Total persons created: {Person.Count}");
        Person p3 = new Person("Bob", 30);
        Person p4 = new Person("Charlie", 35);
        Console.WriteLine($"Total persons now: {Person.Count}\n");

        // 7. Object Methods
        Console.WriteLine("7. Object Methods:");
        Calculator calc = new Calculator();
        Console.WriteLine($"5 + 3 = {calc.Add(5, 3)}");
        Console.WriteLine($"10 - 4 = {calc.Subtract(10, 4)}");
        Console.WriteLine($"6 * 7 = {calc.Multiply(6, 7)}");
        Console.WriteLine($"15 / 3 = {calc.Divide(15, 3)}\n");

        // 8. Object Initialization
        Console.WriteLine("8. Object Initialization:");
        Student student = new Student
        {
            Name = "David",
            Age = 20,
            Grade = "A"
        };
        student.DisplayInfo();
    }
}

// Structure - Value Type
struct Point
{
    public int X;
    public int Y;

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }
}

// Class - Reference Type
class Person
{
    // Fields
    private string name;
    private int age;

    // Static member
    public static int Count = 0;

    // Properties
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int Age
    {
        get { return age; }
        set 
        { 
            if (value >= 0)
                age = value; 
        }
    }

    // Constructor
    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
        Count++;
    }
}

// Encapsulation Example
class BankAccount
{
    private string accountNumber;
    private double balance;

    public BankAccount(string accountNumber, double initialBalance)
    {
        this.accountNumber = accountNumber;
        this.balance = initialBalance;
    }

    public void Deposit(double amount)
    {
        if (amount > 0)
            balance += amount;
    }

    public bool Withdraw(double amount)
    {
        if (amount > 0 && amount <= balance)
        {
            balance -= amount;
            return true;
        }
        return false;
    }

    public double GetBalance()
    {
        return balance;
    }
}

// Properties Example
class Car
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }

    // Computed property
    public int Age
    {
        get { return DateTime.Now.Year - Year; }
    }
}

// Constructor Overloading
class Rectangle
{
    private double width;
    private double height;

    public Rectangle()
    {
        width = 1;
        height = 1;
    }

    public Rectangle(double width, double height)
    {
        this.width = width;
        this.height = height;
    }

    public double CalculateArea()
    {
        return width * height;
    }
}

// Methods Example
class Calculator
{
    public int Add(int a, int b) => a + b;
    public int Subtract(int a, int b) => a - b;
    public int Multiply(int a, int b) => a * b;
    public double Divide(int a, int b) => b != 0 ? (double)a / b : 0;
}

// Object Initialization
class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Grade { get; set; }

    public void DisplayInfo()
    {
        Console.WriteLine($"Student: {Name}, Age: {Age}, Grade: {Grade}");
    }
}