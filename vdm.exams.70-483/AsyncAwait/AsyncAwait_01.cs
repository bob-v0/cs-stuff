using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace vdm.exams.cs.AsyncWait
{
    class AsyncAwait_01
    {
        static void RunMe()
        {
            string result = DownloadContent().Result;
            Console.WriteLine(result);
        }

        static async Task<string> DownloadContent()
        {
            using(HttpClient client = new HttpClient())
            {
                string result = await client.GetStringAsync("http://www.microsoft.com"); // return task of string to caller when finished
                return result;
            }
        }
    }
}
