using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLabs.Lab06.Tasks
{
    public class Task05
    {
        // Declare delegate type
        public delegate bool NumberFilter(int n);

        // Run method to demonstrate usage
        public static void Run()
        {
            Console.WriteLine("=== Task05: Lambda Expression Filter ===");

            // Example array
            int[] numbersArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // Lambda expression (shorter syntax)
            NumberFilter lambdaFilter = n => n % 2 == 0;
            Console.WriteLine("Lambda evens: " +
                string.Join(", ", FilterArray(numbersArray, lambdaFilter)));

            // Using List<T> methods with lambdas
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            int firstGreaterThan5 = numbers.Find(n => n > 5);
            Console.WriteLine($"First number > 5: {firstGreaterThan5}");

            List<int> evens = numbers.FindAll(n => n % 2 == 0);
            Console.WriteLine("Evens via FindAll: " + string.Join(", ", evens));

            bool hasNegative = numbers.Exists(n => n < 0);
            Console.WriteLine($"Has negative? {hasNegative}");
        }

        public static int[] FilterArray(int[] array, NumberFilter filter)
        {
            List<int> result = new List<int>();
            foreach (int item in array)
            {
                if (filter(item))
                {
                    result.Add(item);
                }
            }
            return result.ToArray();
        }
    }
}
