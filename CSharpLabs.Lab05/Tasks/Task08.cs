namespace CSharpLabs.Lab05.Tasks
{
    public class Task08
    {
        public static void Run()
        {
            Console.WriteLine("=== Task 08: File Processor with Finally ===");

            Resource file = new Resource("data.txt");

            try
            {
                file.Open();
                string data = file.Read();
                Console.WriteLine($"Data read: {data}");
                // Process data...
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                // ALWAYS executes - cleanup
                file.Close();
                Console.WriteLine("File closed (cleanup done).");
            }
        }
    }

    // Resource class simulating file operations
    public class Resource
    {
        private string _filename;
        private bool _isOpen;

        public Resource(string filename)
        {
            _filename = filename;
        }

        public void Open()
        {
            Console.WriteLine($"Opening {_filename}...");
            _isOpen = true;
        }

        public string Read()
        {
            if (!_isOpen)
                throw new InvalidOperationException("File not open!");

            // Simulate reading data
            return "Sample file content";
        }

        public void Close()
        {
            if (_isOpen)
            {
                Console.WriteLine($"Closing {_filename}...");
                _isOpen = false;
            }
        }
    }
}
