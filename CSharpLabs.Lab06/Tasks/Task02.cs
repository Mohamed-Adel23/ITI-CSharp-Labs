using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLabs.Lab06.Tasks
{
    public class Task02
    {
        // 1. Declare delegate type
        public delegate void NotifyHandler(string message);

        // 3. Run method to demonstrate usage
        public static void Run()
        {
            Console.WriteLine("=== Multicast Delegate ===");

            // Create delegate instance pointing to SendEmail
            NotifyHandler notify = SendEmail;

            // Add more methods to the invocation list
            notify += SendSMS;
            notify += LogToFile;

            // Call all methods in order
            Console.WriteLine("\n--- First Notification ---");
            notify("Order confirmed!");

            // Remove one method
            notify -= SendSMS;

            // Call remaining methods
            Console.WriteLine("\n--- Second Notification ---");
            notify("Shipped!");
        }

        public static void SendEmail(string message)
        {
            Console.WriteLine($"Email sent: {message}");
        }

        public static void SendSMS(string message)
        {
            Console.WriteLine($"SMS sent: {message}");
        }

        public static void LogToFile(string message)
        {
            Console.WriteLine($"Logged: {message}");
        }
    }
}
