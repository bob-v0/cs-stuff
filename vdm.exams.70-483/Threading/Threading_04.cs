using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace vdm.exams.cs.Threading
{
    class Threading_04
    {
        public static void RunMe()
        {
            ThreadPool.QueueUserWorkItem((s) =>
            {
                Console.WriteLine("working on a thread from threadpool");
            });
        }
    }
}
