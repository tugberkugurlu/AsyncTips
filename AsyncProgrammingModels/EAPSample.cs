using System;
using System.Net;

namespace AsyncProgrammingModels
{
    public class EapSample
    {
        static void Main(string[] args)
        {
            WebClient client = new WebClient();

            client.DownloadStringCompleted += (sender, eventArgs) =>
            {
                Console.WriteLine(eventArgs.Result);
            };

            client.DownloadStringAsync(new Uri("http://example.com"));
        }
    }
}
