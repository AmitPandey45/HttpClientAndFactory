using Microsoft.AspNetCore.Mvc;

namespace Api.Versioning.Controllers.V1_1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.1", Deprecated = true)]
    public class MusicController : ControllerBase
    {
        [HttpGet]
        [MapToApiVersion("1.1")]
        public IActionResult Get()
        {
            var data = new
            {
                data = new List<dynamic>
                {
                    new
                    {
                        Id = 1,
                        Name = "Music1",
                    },
                    new
                    {
                        Id = 1,
                        Name = "Music1",
                    }
                },
                Total = 2
            };

            return Ok(data);
        }
    }
}
