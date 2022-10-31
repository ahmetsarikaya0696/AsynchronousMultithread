namespace TaskResult
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetData());
        }

        public static string GetData()
        {
            var task = new HttpClient().GetStringAsync("https://www.google.com");
            return task.Result; // Sonuç gelene kadar thread bloklanır. Yani asenkron metodu senkron yapmış olduk.
        }
    }
}