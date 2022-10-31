namespace TaskFlow
{
    internal class Program
    {
        // 1 4 2 5 3
        static async Task Main(string[] args)
        {
            Console.WriteLine("1. Adım");
            var myTask = GetContent();

            Console.WriteLine("2. Adım");
            var content = await myTask;

            Console.WriteLine("3. Adım");

        }

        public static async Task<string> GetContent()
        {
            Console.WriteLine("4. Adım");
            var content = await new HttpClient().GetStringAsync("https://www.google.com");

            Console.WriteLine("5. Adım");
            return content;
        }
    }
}