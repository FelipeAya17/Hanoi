using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Hanoi
{
    public class WSClient
    {
        public async Task<T> Get<T>(string url)
        {
            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) =>
            {
                return true;
            };
            HttpClient client = new HttpClient(httpClientHandler);
            var response = await client.GetAsync(url).ConfigureAwait(false);
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(json);
        }
        public async Task<T> Get<T>(string url, String json)
        {
            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) =>
            {
                return true;
            };
            HttpClient client = new HttpClient(httpClientHandler);
            client.BaseAddress = new Uri(url);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            try
            {
                var response = await client.PostAsync("", content);
                var datas = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(datas);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return default(T);

        }
    }
}
