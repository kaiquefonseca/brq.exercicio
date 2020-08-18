using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace BRQ.Orientacao.Console.REST
{
    public static class Requisicao
    {
        public static T Post<T>(Uri Url_, string Body_, Dictionary<string, string> DicHeader_)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.Timeout = TimeSpan.FromMinutes(1);
                HttpRequestMessage request = new HttpRequestMessage();
                request.Method = HttpMethod.Post;
                request.RequestUri = Url_;

                request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));

                request.Content = new StringContent(Body_);
                request.Content.Headers.ContentType = MediaTypeWithQualityHeaderValue.Parse("application/json");


                foreach (var item in DicHeader_)
                    request.Headers.Add(item.Key, item.Value);

                var taskResponse = httpClient.SendAsync(request);

                taskResponse.Wait();

                var responseResultado = taskResponse.Result.Content.ReadAsStringAsync();
                responseResultado.Wait();

                return JsonConvert.DeserializeObject<T>(responseResultado.Result);
            }
        }

        public static T Get<T>(string Url_, Dictionary<string, string> DicHeader_)
        {

            using (HttpClient cliente = new HttpClient())
            {
                cliente.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue
                {
                    NoCache = true
                };

                HttpRequestMessage request = new HttpRequestMessage();
                request.Method = HttpMethod.Get;
                request.RequestUri = new Uri(Url_);
                request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));
                cliente.Timeout = TimeSpan.FromMinutes(1);

                foreach (var item in DicHeader_)
                    request.Headers.Add(item.Key, item.Value);

                var taskResponse = cliente.SendAsync(request);

                taskResponse.Wait();

                var responseResultado = taskResponse.Result.Content.ReadAsStringAsync();
                responseResultado.Wait();

                return JsonConvert.DeserializeObject<T>(responseResultado.Result);
            }
        }
    }
}
