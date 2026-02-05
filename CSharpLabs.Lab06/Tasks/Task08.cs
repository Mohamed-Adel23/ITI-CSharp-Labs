using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CSharpLabs.Lab06.Tasks.Task08;

namespace CSharpLabs.Lab06.Tasks
{
    public delegate void ClickHandler(object sender, string buttonName);

    public class Task08
    {
        // Run method to demonstrate usage
        public static void Run()
        {
            Console.WriteLine("=== Button Click Events ===");

            // Create button
            Button button = new Button("Submit");

            // Create listeners
            Handler handler = new Handler();
            Logger logger = new Logger();

            // Subscribe handlers
            button.Click += handler.OnClick;
            button.Click += logger.LogClick;                 
            button.Click += (sender, name) =>                
                Console.WriteLine($"Lambda: '{name}' button clicked!");

            // Trigger click
            button.PerformClick();
        }
    }

    // Sender
    public class Button
    {
        public string Name { get; set; }

        // Event based on delegate
        public event ClickHandler Click;

        public Button(string name)
        {
            Name = name;
        }

        // Method to simulate a click
        public void PerformClick()
        {
            Console.WriteLine($"Button '{Name}' clicked!");
            Click?.Invoke(this, Name);
        }
    }

    // Listener
    public class Handler
    {
        public void OnClick(object sender, string name)
        {
            Console.WriteLine($"Handler: Button '{name}' was clicked.");
        }
    }

    // Listener
    public class Logger
    {
        public void LogClick(object sender, string name)
        {
            Console.WriteLine($"Logger: Click logged for '{name}'.");
        }
    }
}
