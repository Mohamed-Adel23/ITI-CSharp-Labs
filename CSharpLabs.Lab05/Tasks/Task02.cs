namespace CSharpLabs.Lab05.Tasks
{
    public class Task02
    {
        public static void Run()
        {
            Console.WriteLine("=== Task 02: Rectangle with Auto Properties ===");

            // Using object initializer with defaults
            Rectangle rect1 = new Rectangle
            {
                Width = 10,
                Height = 5
            };

            Console.WriteLine($"Rect1: {rect1.Width}{rect1.Unit} x {rect1.Height}{rect1.Unit}, " +
                              $"Color: {rect1.Color}, Area: {rect1.Area}");

            // Overriding defaults
            Rectangle rect2 = new Rectangle
            {
                Width = 7.5,
                Height = 3.2,
                Color = "Blue",
                Unit = "m"
            };

            Console.WriteLine($"Rect2: {rect2.Width}{rect2.Unit} x {rect2.Height}{rect2.Unit}, " +
                              $"Color: {rect2.Color}, Area: {rect2.Area}");
        }
    }

    // Rectangle class with auto properties, defaults, and computed property
    public class Rectangle
    {
        // [1] Auto-implemented properties
        public double Width { get; set; }
        public double Height { get; set; }

        // [2] With default values (C# 6.0 feature)
        public string Color { get; set; } = "White";
        public string Unit { get; set; } = "cm";

        // [3] Read-only property (set only in constructor)
        public int Id { get; }

        // [4] Constructor to set Id
        public Rectangle()
        {
            Id = new Random().Next(1000, 9999);
        }

        // [5] Computed property
        public double Area => Width * Height;
    }
}
