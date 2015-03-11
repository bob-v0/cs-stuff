using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vdm.exams.cs.Tasks
{
    class Tasks_03
    {
        public static void RunMe()
        {
            Task<int[]> parent = Task.Run(() =>
            {
                var result = new int[3];
                new Task(() => result[0] = 0, TaskCreationOptions.AttachedToParent).Start();
                new Task(() => result[1] = 1, TaskCreationOptions.AttachedToParent).Start();
                new Task(() => result[2] = 2, TaskCreationOptions.AttachedToParent).Start();
                return result;
            });

            parent.ContinueWith(i =>
            {
                Console.WriteLine("Faulted");
            }, TaskContinuationOptions.OnlyOnFaulted);

            parent.ContinueWith(i =>
            {
                Console.WriteLine("Cancelled");
            }, TaskContinuationOptions.OnlyOnCanceled);

            parent.Wait();

            parent.ContinueWith(i =>
            {
                i.Result.ToList().ForEach(t => Console.WriteLine("item: " + t));
            }, TaskContinuationOptions.OnlyOnRanToCompletion);


            // Sometimes this results in 3x "item: 0" being printed.
            // When changed to a collection List<int> as return type, a collection has modified exception is caught.
            // Not sure why this happens
        }
    }
}
