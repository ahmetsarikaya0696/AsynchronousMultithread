using PLINQAdventureWorksApp.Models;

namespace PLINQAdventureWorksApp
{
    internal class Program
    {
        private static bool IsControl(Product p)
        {
            try
            {
                return p.Name[2] == 'a';
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType().Name);
                return false;
            }
        }

        static void Main(string[] args)
        {
            AdventureWorks2019Context context = new();

            // İlk önce tüm productlar çekilir daha sonra multithread işlem yapılır.
            var products = (from p in context.Products.AsParallel()
                           where p.ListPrice > 10M
                           select p)
                           .Take(100)
                           .ToArray();

            products[3].Name = "##";

            //var query = products.AsParallel().Where(p => p.Name[2] == 'a');
            var query = products.AsParallel().Where(IsControl); // lambda yerine bu şekilde kod yazıldığında programda hata fırlatılsa dahi program çalışmaya devam eder.
            try
            {
                query.ForAll(x =>
                {
                    Console.WriteLine($"{x.Name}");
                });
            }
            catch (AggregateException exceptions)
            {
                exceptions.InnerExceptions.ToList().ForEach(x =>
                {
                    Console.WriteLine($"Error Messages : {x.GetType().Name}");
                });
            }

            // Aynı kodun farklı yazım şekli
            //var product2 = context.Products
            //    .AsParallel()
            //    .WithDegreeOfParallelism(2)
            //    .WithExecutionMode(ParallelExecutionMode.ForceParallelism)
            //    .AsOrdered()
            //    .Where(p => p.ListPrice > 10M).Take(10);


            //product2.ForAll(p =>
            //{
            //    Console.WriteLine(p.Name);
            //});
        }
    }
}