using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace AsyncProgrammingModels
{
    public class AsyncAwaitSample
    {
        public async Task GetStuffAsync()
        {            
            using (var httpClient = new HttpClient())
            using (var fileStream = new FileStream(@"c:\index.html", FileMode.Create))
            using (Stream stream = await httpClient.GetStreamAsync("http://www.tugberkugurlu.com"))
            {
                await stream.CopyToAsync(fileStream);
                Console.WriteLine("Done!");
            }
        }
    }
}
