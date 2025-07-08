using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Web.HTTPClient
{
    public class APIHttpClient
    {
        private readonly string baseAPI;

        public APIHttpClient(string baseAPI)
        {
            this.baseAPI = baseAPI;
        }

        private HttpClient CriarHttpClient(string token = null)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(baseAPI)
            };

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            if (!string.IsNullOrEmpty(token))
            {
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);
            }

            return client;
        }

        public Guid Post<T>(string action, T data, string token = null)
        {
            using (var client = CriarHttpClient(token))
            {
                var response = client.PostAsJsonAsync(action, data).Result;
                if (response.IsSuccessStatusCode)
                {
                    var sucesso = response.Content.ReadAsAsync<Guid>().Result;
                    return sucesso;
                }
                else
                {
                    throw new Exception(response.Content.ReadAsStringAsync().Result);
                }
            }
        }

        public Guid Put<T>(string action, Guid id, T data, string token = null)
        {
            using (var client = CriarHttpClient(token))
            {
                var response = client.PutAsJsonAsync(action + id, data).Result;
                if (response.IsSuccessStatusCode)
                {
                    var sucesso = response.Content.ReadAsAsync<Guid>().Result;
                    return sucesso;
                }
                else
                {
                    throw new Exception(response.Content.ReadAsStringAsync().Result);
                }
            }
        }

        public T Get<T>(string actionUri, string token = null)
        {
            using (var client = CriarHttpClient(token))
            {
                var response = client.GetAsync(actionUri).Result;
                if (response.IsSuccessStatusCode)
                {
                    var sucesso = response.Content.ReadAsAsync<T>().Result;
                    return sucesso;
                }
                else
                {
                    throw new Exception(response.Content.ReadAsStringAsync().Result);
                }
            }
        }

        public T Delete<T>(string action, Guid id, string token = null)
        {
            using (var client = CriarHttpClient(token))
            {
                var response = client.DeleteAsync(action + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    var sucesso = response.Content.ReadAsAsync<T>().Result;
                    return sucesso;
                }
                else
                {
                    throw new Exception(response.Content.ReadAsStringAsync().Result);
                }
            }
        }
    }
}
