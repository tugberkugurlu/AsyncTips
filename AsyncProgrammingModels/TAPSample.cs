using System;
using System.Net;
using System.Threading.Tasks;

// ReSharper disable ConvertClosureToMethodGroup

namespace AsyncProgrammingModels
{
    public class TapSample
    {
        static void Main(string[] args)
        {
            WebClient client = new WebClient();
            client.DownloadStringTaskAsync(new Uri("http://example.com")).ContinueWith(data =>
            {
                Console.WriteLine(data);

            }, TaskContinuationOptions.OnlyOnRanToCompletion);
        }
    }
}