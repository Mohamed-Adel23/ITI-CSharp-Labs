namespace CSharpLabs.Lab05.Tasks
{
    public class Task07
    {
        public static void Run()
        {
            Console.WriteLine("=== Task 07: Calculator with Exceptions ===");

            Calculator calc = new Calculator();

            try
            {
                // Example: Divide by zero
                double result1 = calc.Divide(10, 0);
                Console.WriteLine($"Result1: {result1}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Cannot divide by zero!");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Invalid number format!");
            }
            catch (Exception ex) // General catch - MUST be last
            {
                Console.WriteLine($"Unknown error: {ex.Message}");
            }

            try
            {
                // Example: Parse invalid string to number
                double result2 = calc.ParseAndAdd("abc", "5");
                Console.WriteLine($"Result2: {result2}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Cannot divide by zero!");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Invalid number format!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unknown error: {ex.Message}");
            }
        }
    }

    // Calculator class
    public class Calculator
    {
        public double Divide(double a, double b)
        {
            if (b == 0)
                throw new DivideByZeroException();

            return a / b;
        }

        public double ParseAndAdd(string x, string y)
        {
            try
            {
                double num1 = double.Parse(x);
                double num2 = double.Parse(y);
                return num1 + num2;
            }
            catch (FormatException)
            {
                throw; // rethrow FormatException
            }
        }
    }
}
