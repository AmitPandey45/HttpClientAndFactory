using Microsoft.AspNetCore.Mvc;

namespace Api.Versioning.Controllers.V2
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("2.0", Deprecated = true)]
    public class MusicController : ControllerBase
    {
        [HttpGet]
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
                        Author = "Author1",
                    },
                    new
                    {
                        Id = 1,
                        Name = "Music1",
                        Author = "Author1",
                    }
                },
                Total = 2
            };

            return Ok(data);
        }
    }
}
