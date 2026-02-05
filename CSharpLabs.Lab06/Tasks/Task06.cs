using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLabs.Lab06.Tasks
{
    public class Task06
    {
        public static void Run()
        {
            Console.WriteLine("=== Lambda Sort ===");

            // Sample data
            List<Person> people = new List<Person>
            {
                new Person { Name = "Alice", Age = 30, Department = "HR" },
                new Person { Name = "Bob", Age = 25, Department = "IT" },
                new Person { Name = "Charlie", Age = 35, Department = "Finance" },
                new Person { Name = "Diana", Age = 28, Department = "IT" },
                new Person { Name = "Eve", Age = 40, Department = "HR" }
            };

            // Sort by Age (ascending)
            people.Sort((a, b) => a.Age.CompareTo(b.Age));
            Console.WriteLine("\nSorted by Age (ascending):");
            people.ForEach(p => Console.WriteLine(p));

            // Sort by Age (descending)
            people.Sort((a, b) => b.Age.CompareTo(a.Age));
            Console.WriteLine("\nSorted by Age (descending):");
            people.ForEach(p => Console.WriteLine(p));

            // Sort by Name
            people.Sort((a, b) => a.Name.CompareTo(b.Name));
            Console.WriteLine("\nSorted by Name:");
            people.ForEach(p => Console.WriteLine(p));

            // Sort by Department, then Name
            people.Sort((a, b) =>
            {
                int result = a.Department.CompareTo(b.Department);
                if (result != 0) return result;
                return a.Name.CompareTo(b.Name);
            });
            Console.WriteLine("\nSorted by Department, then Name:");
            people.ForEach(p => Console.WriteLine(p));
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public string Department { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"{Name} (Age: {Age}, Dept: {Department})";
        }
    }
}
