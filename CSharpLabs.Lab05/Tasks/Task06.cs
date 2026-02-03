namespace CSharpLabs.Lab05.Tasks
{
    public class Task06
    {
        public static void Run()
        {
            Console.WriteLine("=== Task 06: Generic Student List ===");

            // Collection initializer syntax
            var students = new List<Student>
            {
                new Student { Id = 1, Name = "Ahmed", GPA = 3.5 },
                new Student { Id = 2, Name = "Sara", GPA = 3.8 },
                new Student { Id = 3, Name = "Omar", GPA = 3.2 },
                new Student { Id = 4, Name = "Laila", GPA = 3.9 }
            };

            Console.WriteLine("All Students:");
            foreach (var s in students)
            {
                Console.WriteLine($"{s.Id}: {s.Name}, GPA {s.GPA}");
            }

            // Find: first student with GPA > 3.5
            Student found = students.Find(s => s.GPA > 3.5);
            Console.WriteLine($"\nFound student with GPA > 3.5: {found.Name}, GPA {found.GPA}");

            // FindAll: all honors students (GPA >= 3.5)
            List<Student> honors = students.FindAll(s => s.GPA >= 3.5);
            Console.WriteLine("\nHonors Students (GPA >= 3.5):");
            foreach (var s in honors)
            {
                Console.WriteLine($"{s.Name}, GPA {s.GPA}");
            }

            // Sort by GPA descending
            students.Sort((a, b) => b.GPA.CompareTo(a.GPA));
            Console.WriteLine("\nStudents sorted by GPA (descending):");
            foreach (var s in students)
            {
                Console.WriteLine($"{s.Name}, GPA {s.GPA}");
            }
        }
    }

    // Student class
    public class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public double GPA { get; set; }
    }
}
