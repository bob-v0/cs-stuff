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
                return 42;
            });

            // We can no do other stuff here while the task runs!

            // Wait for the task to complete. Like t.Join() on a Thread.
            t.Wait();

            // Reading the result will force the thread to wait until the thread has completed
            // In this case, the wait statement above is not needed.
            Console.WriteLine(t.Result);


            var t2 = Task.Run(() =>
            {
                return 33;
            }).ContinueWith(s =>{
                Console.WriteLine("I have read: " + s.Result);
            });

            Console.WriteLine("meeep");

        }
    }
}
