using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace vdm.exams.cs.Parallel
{
    class Parallel_01
    {
        public static void RunMe()
        {
            var options = new ParallelOptions();
            //options.MaxDegreeOfParallelism = 100;
            ParallelLoopResult result = System.Threading.Tasks.Parallel.For(0, 1000, options  , (int i, ParallelLoopState loopState) =>
            {
                if (i == 500)
                {
                    Console.WriteLine("breaking loop");
                    //loopState.Break();      // Break ensures that all iterations currently running will be finished. LowestBreakIteration is 500
                    loopState.Stop();    // Stop terminates everything. LowestBreakIteration will be null.
                }
            });

            Console.WriteLine("Completed {0} : LBI {1}", result.IsCompleted, result.LowestBreakIteration);
        }
    }
}
