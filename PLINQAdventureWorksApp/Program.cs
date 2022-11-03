using PLINQAdventureWorksApp.Models;

namespace PLINQAdventureWorksApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AdventureWorks2019Context context = new();

            // İlk önce tüm productlar çekilir daha sonra multithread işlem yapılır.
            var product = (from p in context.Products.AsParallel()
                           where p.ListPrice > 10M
                           select p).Take(10);

            // Aynı kodun farklı yazım şekli
            var product2 = context.Products
                .AsParallel()
                .WithDegreeOfParallelism(2)
                .WithExecutionMode(ParallelExecutionMode.ForceParallelism)
                .AsOrdered()
                .Where(p => p.ListPrice > 10M).Take(10);


            product.ForAll(p =>
            {
                Console.WriteLine(p.Name);
            });
        }
    }
}