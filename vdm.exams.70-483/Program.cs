using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vdm.exams.cs.Threading;
using vdm.exams.cs.Tasks;
using vdm.exams.cs.Parallel;

namespace vdm.exams.cs
{
    class Program
    {
        static void Main(string[] args)
        {
            // Tests here
            //Parallel_01.RunMe();

            Task.Run(async () => await AsyncWait.AsyncAwait_03.RunMe());

            // Blocks thread
            Task.Run(async () => await AsyncWait.AsyncAwait_03.RunMe()).GetAwaiter().GetResult();

            AsyncWait.AsyncAwait_03.RunMe().Wait();

            Console.WriteLine(Environment.NewLine + "End. Press ENTER to exit.");
            Console.ReadLine();
        }
    }
}
