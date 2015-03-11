using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace vdm.exams.cs.Threading
{
    // Should use Thread.Sleep(0) to tell Windows to not finish current time slice for thread.
    // My machine is too fast to generate obvious async output, so i set it to 3 ms.
    class Threading_01
    {
        public static void RunMe()
        {
            var t = new Thread(new ThreadStart(ThreadMethod));
            t.Start();

            var t2 = new Thread(new ParameterizedThreadStart(ThreadMethod2));
            t2.Start(5);

            // This constructor overload works since .NET version... ?
            // new Thread(ThreadMethod);
            
            var stopped = false;

            var t3 = new Thread(() =>
            {
                while(!stopped)
                {
                    Console.WriteLine("Lamdba invocation still running ...");
                    Thread.Sleep(3000);
                }
            });
            t3.Start();

            for(var i=0; i < 5; i++)
            {
                Console.WriteLine("MainProc: {0}", i);
                Thread.Sleep(3);
            }


            Console.WriteLine("Press a key to exit");
            Console.ReadKey();

            stopped = true;

            // Wait until thread finishes
            t.Join();
            t2.Join();
            t3.Join();
        }

        private static void ThreadMethod()
        {
            for(var i=0; i < 10; i++)
            {
                Console.WriteLine("ThreadProc: {0}", i);
                Thread.Sleep(3);
            }
        }

        private static void ThreadMethod2(object o)
        {
            for (var i = 0; i < 10; i++)
            {
                Console.WriteLine("ThreadProc2: {0} - {1}", i, o);
                Thread.Sleep(3);
            }
        }
    }
}
