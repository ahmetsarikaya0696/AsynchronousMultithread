using System.Drawing;

namespace ForEachParallelApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ParallelForEach1();
            //ParallelForEach2();
            //RaceConditionExample();

            ParallelFor1();

        }

        private static void ParallelFor1()
        {
            long filesByte = 0;

            Console.Write("Path : ");
            string picturesPath = Console.ReadLine();
            var files = Directory.GetFiles(picturesPath);

            Parallel.For(0, files.Length, (index) =>
            {
                Console.WriteLine($"Thread Id : {Thread.CurrentThread.ManagedThreadId}");
                FileInfo fileInfo = new FileInfo(files[index]);
                Interlocked.Add(ref filesByte, fileInfo.Length); // Race Condition durumunu önler
            });

            Console.WriteLine($"Total File Byte : {filesByte}");
        }

        private static void RaceConditionExample()
        {
            int value = 0;

            Parallel.ForEach(Enumerable.Range(1, 10000000).ToList(), (x) =>
            {
                value = x;
            });

            Console.WriteLine(value);
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

            Console.WriteLine($"Total File Byte : {filesByte}");
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