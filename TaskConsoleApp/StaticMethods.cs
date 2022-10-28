using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskConsoleApp
{
    public static class StaticMethods
    {
        public static async Task<Content> GetContentAsync(string url)
        {
            Content c = new();
            var data = await new HttpClient().GetStringAsync(url);
            
            c.Site = url;
            c.Len = data.Length;
            Console.WriteLine($"GetContentAsync thread : {Thread.CurrentThread.ManagedThreadId}");
            return c;
        }

        public static void Callback(Task<string> data)
        {
            // 100 satırlık kod
            Console.WriteLine(data.Result.Length);
        }
    }
}
