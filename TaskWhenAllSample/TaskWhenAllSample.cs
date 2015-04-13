using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
// ReSharper disable ConvertClosureToMethodGroup

namespace TaskWhenAllSample
{
    public class Car
    {
    }

    public class TaskWhenAllSample
    {
        private static readonly string[] PayloadSources = {
            "http://localhost:2700/api/cars/cheap",
            "http://localhost:2700/api/cars/expensive"
        };

        public Task WriteCarsAsync()
        {
            Task<string>[] tasks = PayloadSources.Select(uri => GetCarsAsync(uri)).ToArray();
            return Task.WhenAll(tasks);
        }

        private async Task<string> GetCarsAsync(string uri)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetStringAsync(uri);
                return response;
            }
        }
    }
}
