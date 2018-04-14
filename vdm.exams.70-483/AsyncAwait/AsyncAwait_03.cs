using System.Net.Http;

namespace vdm.exams.cs.AsyncWait
{
    class AsyncAwait_03
    {
        internal async static System.Threading.Tasks.Task RunMe()
        {
            var client = new HttpClient();

            var data = await client.GetStringAsync("http://filipekberg.se/rss/").ContinueWith(t=> {
                Log.Write("completed, still on background: " + t.Result);
                return "";
            }).ConfigureAwait(false);

            Log.Write(data);
        }
    }

    class Log
    {
        internal static void Write(object data)
        {
            System.Diagnostics.Debug.WriteLine(data);
        }
    }
}
