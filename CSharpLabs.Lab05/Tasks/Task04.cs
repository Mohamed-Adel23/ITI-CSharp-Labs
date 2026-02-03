namespace CSharpLabs.Lab05.Tasks
{
    public class Task04
    {
        public static void Run()
        {
            Console.WriteLine("=== Task 04: String Collection Indexer ===");

            StringCollection collection = new StringCollection();

            // Integer indexer (list-like)
            collection[0] = "First";
            collection[1] = "Second";
            collection[2] = "Third";

            Console.WriteLine("Integer Indexer:");
            for (int i = 0; i < collection.Count; i++)
            {
                Console.WriteLine($"Index {i}: {collection[i]}");
            }

            // String indexer (dictionary-like)
            collection["server"] = "localhost";
            collection["port"] = "8080";

            Console.WriteLine("\nString Indexer:");
            Console.WriteLine($"Server: {collection["server"]}");
            Console.WriteLine($"Port: {collection["port"]}");
        }
    }

    // Collection class with TWO indexers
    public class StringCollection
    {
        private List<string> _list = new List<string>();
        private Dictionary<string, string> _dict = new Dictionary<string, string>();

        // Integer indexer
        public string this[int index]
        {
            get
            {
                // Expand list if index is out of range
                while (_list.Count <= index)
                {
                    _list.Add(null);
                }
                return _list[index];
            }
            set
            {
                while (_list.Count <= index)
                {
                    _list.Add(null);
                }
                _list[index] = value;
            }
        }

        // String indexer
        public string this[string key]
        {
            get => _dict.ContainsKey(key) ? _dict[key] : null;
            set => _dict[key] = value;
        }

        // Property to expose count of list items
        public int Count => _list.Count;
    }
}
