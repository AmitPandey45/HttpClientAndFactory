namespace Consumer.Client
{
    public class CustomHttpClient
    {
        private readonly HttpClient client;
        private string guidy;

        public CustomHttpClient(HttpClient client)
        {
            this.client = client;
            client.DefaultRequestHeaders.Add("StartupHeader", Guid.NewGuid().ToString());

            this.guidy = Guid.NewGuid().ToString();
        }

        public Task<string> GetHome()
        {
            return client.GetStringAsync($"api/homes/{guidy}");
        }
    }
}
