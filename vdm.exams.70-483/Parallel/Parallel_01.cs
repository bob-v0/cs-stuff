using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace vdm.exams.cs.Parallel
{
    class Parallel_02
    {
        public static void RunMe()
        {
            System.Threading.Tasks.Parallel.For(0, 10, i => { Console.WriteLine(i); });

            // Notice how only an X number of tasks are executed at a time. Not the whole range at once.
            var numbers = Enumerable.Range(0, 50);
            System.Threading.Tasks.Parallel.ForEach(numbers, i =>
            {
                Thread.Sleep(1000);
                Console.Write("*");
            });
        }
    }
}
