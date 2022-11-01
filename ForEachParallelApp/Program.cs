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
            //ParallelFor1();
            //MultithreadTotalForEach();
            MultithreadTotalFor();
        }

        private static void MultithreadTotalFor()
        {
            long filesByte = 0;

            Parallel.For(0, 100, () => 0, (x, loop, subTotal) =>
            {
                subTotal += x;
                return subTotal;
            }, (y) => Interlocked.Add(ref filesByte, y));

            Console.WriteLine($"Total File Byte : {filesByte}");
        }

        private static void MultithreadTotalForEach()
        {
            /* 
             * Thread 4 e bölünür
             * Her biri kendi içinde subtotal ' ı bulur
             * Bulunan subtotal filesByte ' a eklenir.
             */
            long filesByte = 0;

            Parallel.ForEach(Enumerable.Range(1, 100).ToList(), () => 0, (x, loop, subTotal) =>
            {
                subTotal += x;
                return subTotal;
            }, (y) => Interlocked.Add(ref filesByte, y));

            Console.WriteLine($"Total File Byte : {filesByte}");
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