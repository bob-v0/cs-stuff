using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace vdm.exams.cs
{
    class Threading_03
    {
        // Every thread has its own local copy of this variable with his own initialization
        private static ThreadLocal<int> _field = new ThreadLocal<int>(() => {
            return Thread.CurrentThread.ManagedThreadId;
        });        
        
        public static void RunMe()
        {
            var t = new Thread(() =>
            {
                for(var i=0; i < _field.Value; i++)
                {
                    Console.WriteLine("Thread: {0} to {1} ", i, _field.Value);
                    Thread.Sleep(1000);
                }
            });

            var t2 = new Thread(ThreadMethod);

            t.Start();
            t2.Start();

            for(var i=0; i < 5; i++)
            {
                Console.WriteLine("MainProc: {0}", i);
                Thread.Sleep(3);
            }


            Console.WriteLine("Press a key to exit");
            Console.ReadKey();

            // Wait until thread finishes
            t.Join();
            t2.Join();
        }

        private static void ThreadMethod()
        {
            for(var i=0; i < _field.Value; i++)
            {
                Console.WriteLine("ThreadProc: {0} to {1} ", i, _field.Value);
                Thread.Sleep(3);
            }
        }
    }
}
