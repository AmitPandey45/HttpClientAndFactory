using Api.Client;
using Consumer.Client;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Consumer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public Task<string> Bad()
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7293")
            };

            return client.GetStringAsync($"api/homes/{Guid.NewGuid()}");
        }

        [HttpGet]
        [Route("simple")]
        public Task<string> Simple([FromServices] IHttpClientFactory factory, [FromServices] IConfiguration configuration)
        {
            //var client = factory.CreateClient();
            //var client = factory.CreateClient("NamedHttpClient");
            var client = factory.CreateClient("NameHttpClientWithConfiguration");

            //client.BaseAddress = new Uri("https://localhost:7293");

            return client.GetStringAsync($"api/homes/{Guid.NewGuid()}");
        }

        [HttpGet]
        [Route("Typed")]
        public async Task<string> Typed([FromServices] CustomHttpClient client)
        {
            return await client.GetHome();
        }

        [HttpGet]
        [Route("Shared")]
        public Task<Home> Shared([FromServices] ApiClient client)
        {
            return client.GetHome();
        }
    }
}
