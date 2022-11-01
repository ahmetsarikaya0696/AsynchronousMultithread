using System.Drawing;

namespace ForEachParallelApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ParallelForEach1();
            ParallelForEach2();
        }

        private static void ParallelForEach2()
        {
            long filesByte = 0;

            Console.Write("Path : ");
            string picturesPath = Console.ReadLine();
            var files = Directory.GetFiles(picturesPath);

            Parallel.ForEach(files, (file) =>
            {
                Console.WriteLine($"Thread Id : {Thread.CurrentThread.ManagedThreadId}");
                FileInfo fileInfo = new FileInfo(file);

                Interlocked.Add(ref filesByte, fileInfo.Length); // Race Condition durumunu önler
            });

            Console.WriteLine("İşlem bitti");
        }

        private static void ParallelForEach1()
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