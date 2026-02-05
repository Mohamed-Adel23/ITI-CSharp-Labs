using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLabs.Lab06.Tasks
{
    public class Task01
    {
        // 1. Declare delegate type
        public delegate double MathOperation(double a, double b);

        public static void Run()
        {
            Console.WriteLine("=== Calculator Delegate ===");

            // Create delegate instance pointing to Add
            MathOperation operation = Add;
            Console.WriteLine($"10 + 5 = {operation(10, 5)}");

            // Reassign to Subtract
            operation = Subtract;
            Console.WriteLine($"10 - 5 = {operation(10, 5)}");

            // Reassign to Multiply
            operation = Multiply;
            Console.WriteLine($"10 * 5 = {operation(10, 5)}");

            // Reassign to Divide
            operation = Divide;
            Console.WriteLine($"10 / 5 = {operation(10, 0)}");
        }

        // C# 3.0
        public static double Add(double a, double b) => a + b;
        public static double Subtract(double a, double b) => a - b;
        public static double Multiply(double a, double b) => a * b;
        public static double Divide(double a, double b) => b != 0 ? a / b : double.NaN;

    }
}
