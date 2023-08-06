using Entities;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace Api.Client
{
    public class ApiClient
    {
        private readonly HttpClient client;
        private string guidy;

        public ApiClient(HttpClient client)
        {
            this.client = client;
            client.DefaultRequestHeaders.Add("StartupHeader", Guid.NewGuid().ToString());

            this.guidy = Guid.NewGuid().ToString();
        }

        public async Task<string> GetStringAsync(string url)
        {
            using (var httpResponse = await client.GetAsync(url))
            {
                return await ReadStringResponse(httpResponse);
            }
        }

        public async Task<T> GetAsync<T>(string url)
        {
            using (var httpResponse = await client.GetAsync(url))
            {
                return await ReadResponse<T>(httpResponse);
            }
        }

        public async Task<T> GetFromJsonAsync<T>(string url)
        {
            return await client.GetFromJsonAsync<T>(url);
        }

        public Task<Home> GetHome()
        {
            return client.GetFromJsonAsync<Home>($"api/homes/{guidy}");
        }

        private async Task<string> ReadStringResponse(HttpResponseMessage httpResponse)
        {
            using (httpResponse)
            {
                string content = await httpResponse.Content.ReadAsStringAsync();
                return content;
            }
        }

        private async Task<T> ReadResponse<T>(HttpResponseMessage httpResponse)
        {
            using (httpResponse)
            {
                string content = await httpResponse.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(content);
            }
        }
    }
}
