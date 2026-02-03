namespace CSharpLabs.Lab05.Tasks
{
    public class Task03
    {
        public static void Run()
        {
            Console.WriteLine("=== Task 03: Student Gradebook Indexer ===");

            // Create a gradebook with capacity for 5 grades
            Gradebook grades = new Gradebook(5);

            // Using indexer to SET values
            grades[0] = 95;
            grades[1] = 88;
            grades[2] = 72;
            grades[3] = 100;
            grades[4] = 85;

            // Using indexer to GET values
            double mathGrade = grades[0];
            double scienceGrade = grades[1];

            Console.WriteLine($"Math Grade: {mathGrade}");
            Console.WriteLine($"Science Grade: {scienceGrade}");

            // Loop through all grades
            Console.WriteLine("All Grades:");
            for (int i = 0; i < grades.Length; i++)
            {
                Console.WriteLine($"Grade {i + 1}: {grades[i]}");
            }
        }
    }

    // Gradebook class with indexer
    public class Gradebook
    {
        private double[] _grades;

        // Constructor to set capacity
        public Gradebook(int size)
        {
            _grades = new double[size];
        }

        // Indexer using 'this' keyword
        public double this[int index]
        {
            get
            {
                return _grades[index];
            }
            set
            {
                _grades[index] = value;
            }
        }

        // Property to expose length
        public int Length => _grades.Length;
    }
}
