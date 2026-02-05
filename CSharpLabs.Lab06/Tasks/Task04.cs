using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLabs.Lab06.Tasks
{
    public class Task04
    {
        // Declare delegate type
        public delegate bool NumberFilter(int n);

        public static void Run()
        {
            Console.WriteLine("=== Anonymous Method ===");

            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // Anonymous method approach
            NumberFilter anonFilter = delegate (int n)
            {
                return n % 2 == 0;
            };
            int[] evensAnon = FilterArray(numbers, anonFilter);
            Console.WriteLine("Anonymous method evens: " + string.Join(", ", evensAnon));

            // Direct inline anonymous method as argument
            int[] greaterThan5 = FilterArray(numbers, delegate (int n)
            {
                return n > 5;
            });
            Console.WriteLine("Anonymous method > 5: " + string.Join(", ", greaterThan5));
        }

        // Generic filter method
        public static int[] FilterArray(int[] array, NumberFilter filter)
        {
            List<int> result = new List<int>();

            foreach (int item in array)
            {
                if (filter(item)) // delegate decides whether to keep
                {
                    result.Add(item);
                }
            }

            return result.ToArray();
        }
    }
}
