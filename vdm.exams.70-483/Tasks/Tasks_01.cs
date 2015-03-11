using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vdm.exams.cs.Tasks
{
    class Tasks_01
    {
        public static void RunMe()
        {
            var t = Task.Run(() =>
            {
                Console.Write("*");
            });

            // We can no do other stuff here while the task runs!

            // Wait for the task to complete.
            t.Wait();
        }
    }
}
