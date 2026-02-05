using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLabs.Lab06.Tasks
{
    public class Task03
    {
        // Declare delegate type
        public delegate bool IntFilter(int value);

        // Run method to demonstrate usage
        public static void Run()
        {
            Console.WriteLine("=== Array Filter Delegate ===");

            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            int[] evens = FilterArray(numbers, IsEven);
            Console.WriteLine("Evens: " + string.Join(", ", evens));

            int[] odds = FilterArray(numbers, IsOdd);
            Console.WriteLine("Odds: " + string.Join(", ", odds));

            int[] big = FilterArray(numbers, IsGreaterThan5);
            Console.WriteLine("Greater than 5: " + string.Join(", ", big));
        }

        public static int[] FilterArray(int[] array, IntFilter filter)
        {
            ArrayList result = new ArrayList();

            foreach (int item in array)
            {
                if (filter(item))
                {
                    result.Add(item);
                }
            }

            return (int[])result.ToArray(typeof(int));
        }

        public static bool IsEven(int value) => value % 2 == 0;
        public static bool IsOdd(int value) => value % 2 != 0;
        public static bool IsGreaterThan5(int value) => value > 5;
    }
}
