using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLabs.Lab06.Tasks
{
    public delegate void TemperatureHandler(string message, double temp);

    public class Task07
    {
        // Run method to demonstrate usage
        public static void Run()
        {
            Console.WriteLine("=== Temperature Monitor Events ===");

            // Create sensor and monitor
            TemperatureSensor sensor = new TemperatureSensor();
            TemperatureMonitor monitor = new TemperatureMonitor();

            // Subscribe monitor to sensor event
            sensor.TemperatureHigh += monitor.OnHighTemperature;

            // Simulate temperature changes
            sensor.SetTemperature(25);
            sensor.SetTemperature(32);
            sensor.SetTemperature(28);
            sensor.SetTemperature(35);
        }
    }

    // Sender
    public class TemperatureSensor
    {
        // Event based on delegate
        public event TemperatureHandler TemperatureHigh;

        public void SetTemperature(double temp)
        {
            Console.WriteLine($"Temperature set to {temp}°C");

            if (temp > 30)
            {
                // Fire event if subscribers exist
                TemperatureHigh?.Invoke("Warning! High temperature detected.", temp);
            }
        }
    }

    // Listener
    public class TemperatureMonitor
    {
        public void OnHighTemperature(string msg, double temp)
        {
            Console.WriteLine($"Alert: {temp}°C - {msg}");
        }
    }
}
