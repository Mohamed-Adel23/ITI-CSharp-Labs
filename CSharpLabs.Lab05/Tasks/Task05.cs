using System.Collections;
namespace CSharpLabs.Lab05.Tasks
{
    public class Task05
    {
        public static void Run()
        {
            Console.WriteLine("=== Task 05: Shopping Cart with ArrayList ===");

            ArrayList cart = new ArrayList();

            // Add different types (not type-safe!)
            cart.Add(42);
            cart.Add("Hello");
            cart.Add(3.14);
            cart.Add(DateTime.Now);

            Console.WriteLine("Cart contents:");
            foreach (var item in cart)
            {
                Console.WriteLine(item);
            }

            // Sorting (works only if items are comparable)
            Console.WriteLine("\nSorting cart...");
            try
            {
                cart.Sort();
                foreach (var item in cart)
                {
                    Console.WriteLine(item);
                }
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Cannot sort mixed types in ArrayList!");
            }

            // Reverse order
            Console.WriteLine("\nReversing cart...");
            cart.Reverse();
            foreach (var item in cart)
            {
                Console.WriteLine(item);
            }

            // Remove item
            Console.WriteLine("\nRemoving item 42...");
            cart.Remove(42);
            foreach (var item in cart)
            {
                Console.WriteLine(item);
            }
        }
    }
}
