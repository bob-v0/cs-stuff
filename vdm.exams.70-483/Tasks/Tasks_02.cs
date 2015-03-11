using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vdm.exams.cs.Tasks
{
    class Tasks_02
    {
        public static void RunMe()
        {
            var t = Task.Run(() =>
            {
                return 42;
            });

            t.ContinueWith(i =>
            {
                Console.WriteLine("Cancelled");
            }, TaskContinuationOptions.OnlyOnCanceled);

            t.ContinueWith(i=> {
                Console.WriteLine("Faulted");
            }, TaskContinuationOptions.OnlyOnFaulted);

            t.ContinueWith(i =>
            {
                Console.WriteLine("Completed: " + i.Result);
            }, TaskContinuationOptions.OnlyOnRanToCompletion);

            t.Wait();

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
