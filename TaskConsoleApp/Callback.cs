using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskConsoleApp
{
    public static class Callback
    {
        public static void Work(Task<string> data)
        {
            // 100 satırlık kod
            Console.WriteLine(data.Result.Length);
        }
    }
}
