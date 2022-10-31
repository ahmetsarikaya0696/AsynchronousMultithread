using System.Drawing;

namespace ForEachParallelApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Path : ");
            string picturesPath = Console.ReadLine();
            var files = Directory.GetFiles(picturesPath);
         
            Parallel.ForEach(files, (file) =>
            {
                Console.WriteLine($"Thread Id : {Thread.CurrentThread.ManagedThreadId}");
                Image img = new Bitmap(file);
                var thumbnail = img.GetThumbnailImage(50, 50, () => false, IntPtr.Zero);
                thumbnail.Save(Path.Combine(picturesPath, "thumbnails", Path.GetFileName(file)));
            });

            Console.WriteLine("İşlem bitti");
        }
    }
}