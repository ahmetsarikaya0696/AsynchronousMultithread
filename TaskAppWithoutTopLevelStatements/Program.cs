namespace TaskAppWithoutTopLevelStatements
{
    internal class Program
    {
        public static string CacheData { get; set; }
        static async Task Main(string[] args)
        {
            CacheData = await GetDataAsync();
            Console.WriteLine(CacheData);
        }

        public static Task<string> GetDataAsync()
        {
            if (string.IsNullOrEmpty(CacheData)) return File.ReadAllTextAsync("file.txt");
            
            // FromResult Genelde Cachelenmiş datayı dönmek için kullanılır.
            return Task.FromResult(CacheData);
        }
    }
}