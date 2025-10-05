// Vztahy mezi objekty, skládání objektů. Asociace, agregace a kompozice.

namespace _11_ObjectRelations;

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("=== Object Relations: Association, Aggregation, Composition ===\n");

        // 1. Association (weak relationship)
        Console.WriteLine("1. Association:");
        Teacher teacher = new Teacher("Dr. Smith");
        Student student = new Student("Alice");
        teacher.Teach(student);
        Console.WriteLine();

        // 2. Aggregation (HAS-A relationship, can exist independently)
        Console.WriteLine("2. Aggregation:");
        Employee emp1 = new Employee("Bob");
        Employee emp2 = new Employee("Charlie");
        Department dept = new Department("IT");
        dept.AddEmployee(emp1);
        dept.AddEmployee(emp2);
        dept.ShowEmployees();
        Console.WriteLine("Employees can exist without the department\n");

        // 3. Composition (strong ownership, cannot exist independently)
        Console.WriteLine("3. Composition:");
        House house = new House("Dlouhá 52");
        house.ShowRooms();
        Console.WriteLine("Rooms cannot exist without the house");
        Console.WriteLine("When house is destroyed, rooms are destroyed too\n");

        // 4. One-to-One Relationship
        Console.WriteLine("4. One-to-One Relationship:");
        Person person = new Person("David");
        Passport passport = new Passport("P123456", person);
        Console.WriteLine($"{person.Name} has passport {passport.Number} with owner {passport.Owner.Name}\n");

        // 5. One-to-Many Relationship
        Console.WriteLine("5. One-to-Many Relationship:");
        Author author = new Author("J.K. Rowling");
        author.AddBook(new Book("Harry Potter 1"));
        author.AddBook(new Book("Harry Potter 2"));
        author.AddBook(new Book("Harry Potter 3"));
        author.ShowBooks();
        Console.WriteLine();

        // 6. Many-to-Many Relationship
        Console.WriteLine("6. Many-to-Many Relationship:");
        Course course1 = new Course("Mathematics");
        Course course2 = new Course("Physics");

        Student s1 = new Student("Emma");
        Student s2 = new Student("Frank");

        s1.EnrollInCourse(course1);
        s1.EnrollInCourse(course2);
        s2.EnrollInCourse(course1);

        Console.WriteLine($"{s1.Name} is enrolled in:");
        foreach (var c in s1.Courses)
            Console.WriteLine($"  - {c.Name}");

        Console.WriteLine($"\n{course1.Name} has students:");
        foreach (var s in course1.Students)
            Console.WriteLine($"  - {s.Name}");
    }
}

// === ASSOCIATION ===
class Teacher
{
    public string Name { get; set; }

    public Teacher(string name)
    {
        Name = name;
    }

    public void Teach(Student student)
    {
        Console.WriteLine($"{Name} teaches {student.Name}");
    }
}

class Student
{
    public string Name { get; set; }
    public List<Course> Courses { get; set; } = new List<Course>();

    public Student(string name)
    {
        Name = name;
    }

    public void EnrollInCourse(Course course)
    {
        Courses.Add(course);
        course.Students.Add(this);
    }
}

// === AGGREGATION ===
class Employee
{
    public string Name { get; set; }

    public Employee(string name)
    {
        Name = name;
    }
}

class Department
{
    public string Name { get; set; }
    private List<Employee> employees = new List<Employee>();

    public Department(string name)
    {
        Name = name;
    }

    public void AddEmployee(Employee employee)
    {
        employees.Add(employee);
    }

    public void ShowEmployees()
    {
        Console.WriteLine($"Department: {Name}");
        foreach (var emp in employees)
        {
            Console.WriteLine($"  - {emp.Name}");
        }
    }
}

// === COMPOSITION ===
class House
{
    public string Address { get; set; }
    private List<Room> rooms = new List<Room>();

    public House(string address)
    {
        Address = address;
        // Rooms are created with the house
        rooms.Add(new Room("Living Room", 20));
        rooms.Add(new Room("Bedroom", 15));
        rooms.Add(new Room("Kitchen", 12));
    }

    public void ShowRooms()
    {
        Console.WriteLine($"House at {Address} has rooms:");
        foreach (var room in rooms)
        {
            Console.WriteLine($"  - {room.Name} ({room.Size} sq meters)");
        }
    }

    // Inner class - tight composition
    private class Room
    {
        public string Name { get; set; }
        public int Size { get; set; }

        public Room(string name, int size)
        {
            Name = name;
            Size = size;
        }
    }
}

// === ONE-TO-ONE ===
class Person
{
    public string Name { get; set; }

    public Person(string name)
    {
        Name = name;
    }
}

class Passport
{
    public string Number { get; set; }
    public Person Owner { get; set; }

    public Passport(string number, Person owner)
    {
        Number = number;
        Owner = owner;
    }
}

// === ONE-TO-MANY ===
class Author
{
    public string Name { get; set; }
    private List<Book> books = new List<Book>();

    public Author(string name)
    {
        Name = name;
    }

    public void AddBook(Book book)
    {
        books.Add(book);
    }

    public void ShowBooks()
    {
        Console.WriteLine($"Author: {Name}");
        Console.WriteLine("Books:");
        foreach (var book in books)
        {
            Console.WriteLine($"  - {book.Title}");
        }
    }
}

class Book
{
    public string Title { get; set; }

    public Book(string title)
    {
        Title = title;
    }
}

// === MANY-TO-MANY ===
class Course
{
    public string Name { get; set; }
    public List<Student> Students { get; set; } = new List<Student>();

    public Course(string name)
    {
        Name = name;
    }
}