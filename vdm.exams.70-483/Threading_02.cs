using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace vdm.exams.cs
{
    class Threading_02
    {
        [ThreadStatic]
        private static int  _field;     // Every thread has its own local copy of this variable
        private static bool _stopped;   // this field is shared between all threads


        public static void RunMe()
        {
            var t = new Thread(() =>
            {
                while(!_stopped)
                {
                    Console.WriteLine("Lamdba invocation still running ... field = " + _field);
                    _field++;
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

            _stopped = true;

            // Wait until thread finishes
            t.Join();
        }

        private static void ThreadMethod()
        {
            for(var i=0; i < 10; i++)
            {
                Console.WriteLine("ThreadProc: {0}. field = {1}", i, _field);
                _field++;
                Thread.Sleep(3);
            }
        }
    }
}
