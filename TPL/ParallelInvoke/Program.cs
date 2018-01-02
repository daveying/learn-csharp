using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelInvoke
{
    class Program
    {
        static void Main(string[] args)
        {
            Parallel.Invoke(() => Console.WriteLine("Job 1"), () => Console.WriteLine("Job 2"), () => Console.WriteLine("Job 3"));
            Console.Read();
        }
    }
}
