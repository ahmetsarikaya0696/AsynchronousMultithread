namespace PLINQApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var array = Enumerable.Range(1, 100).ToList();
            var evens = array
                .AsParallel()
                .Where(GetEvens);

            evens.ForAll(x =>
            {
                Console.WriteLine(x);
            }); // ParallelIQuery dönüş metodunda kullanılır

            Console.WriteLine("***************");
            evens.ToList().ForEach(even =>
            {
                Console.WriteLine(even);
            });
        }

        private static bool GetEvens(int x)
        {
            return x % 2 == 0;
        }
    }
}