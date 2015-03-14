using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Threading;

namespace vdm.exams.cs.AsyncWait
{
    class AsyncAwait_02
    {
        static void RunMe()
        {
            // this example shows responsiveness vs performance. SleepAsyncA method uses a thread from the threadpool while sleeping. The second method however does not occupy
            // a thread while waiting for the timer to run. The second method gives you scalability.
        }

        static Task SleepAsyncA(int msTimeout)
        {
            return Task.Run(() => Thread.Sleep(msTimeout));
        }

        static Task SleepAsyncB(int msTimeout)
        {
            TaskCompletionSource<bool> tcs = null;
            var t = new Timer(delegate { tcs.TrySetResult(true); }, null, -1, -1);
            tcs = new TaskCompletionSource<bool>(t);
            t.Change(msTimeout, -1);
            return tcs.Task;
        }
    }
}
