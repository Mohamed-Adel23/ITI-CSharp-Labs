namespace CSharpLabs.Lab05.Tasks
{
    public class Task01
    {
        public static void Run()
        {
            Console.WriteLine("=== Task 01: Person Object Initializer ===");

            // Traditional way (verbose)
            Person p1 = new Person();
            p1.FirstName = "Ahmed";
            p1.LastName = "Hassan";
            p1.Age = 25;

            Console.WriteLine($"Traditional: {p1.FirstName} {p1.LastName}, Age {p1.Age}");

            // Object initializer (concise)
            var p2 = new Person
            {
                FirstName = "Ahmed",
                LastName = "Hassan",
                Age = 25
            };

            Console.WriteLine($"Initializer: {p2.FirstName} {p2.LastName}, Age {p2.Age}");
        }
    }

    public class Person
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Age { get; set; }
    }
}
