using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskExample
{
    class Program
    {
        static void Main2(string[] args)
        {
            Thread.CurrentThread.Name = "Main";
            Task taskA = new Task(() => Console.WriteLine("Hello from taskA"));
            taskA.Start();
            Console.WriteLine("Hello from thread '{0}'.", Thread.CurrentThread.Name);
            taskA.Wait();
        }

        static void Main3(string[] args)
        {
            Thread.CurrentThread.Name = "Main";
            Task taskA = Task.Run(() => Console.WriteLine("Hello from taskA"));
            Console.WriteLine("Hello from thread '{0}'.", Thread.CurrentThread.Name);
            taskA.Wait();
        }

        static void Main4(string[] args)
        {
            Thread.CurrentThread.Name = "Main";
            Task taskA = Task.Factory.StartNew(() => Console.WriteLine("Hello from taskA"));
            Console.WriteLine("Hello from thread '{0}'.", Thread.CurrentThread.Name);

            taskA.Wait();
        }

        static void Main(string[] args)
        {
            Task<Double>[] taskArray = {Task<Double>.Factory.StartNew(() => DoComputation(1.0)),
                                        Task<Double>.Factory.StartNew(() => DoComputation(100.0)),
                                        Task<Double>.Factory.StartNew(() => DoComputation(1000.0))};
            var result = new Double[taskArray.Length];
            Double sum = 0;

            for (int i = 0; i < taskArray.Length; ++i)
            {
                result[i] = taskArray[i].Result;
                Console.Write("{0:N1} {1}", result[i], i == taskArray.Length - 1 ? "= " : "+ ");
                sum += result[i];
            }
            Console.WriteLine("{0:N1}", sum);

        }

        private static Double DoComputation(Double start)
        {
            Double sum = 0;
            for (var value = start; value <= start + 10; value += .1)
                sum += value;
            return sum;
        }
    }
}
