using Microsoft.AspNetCore.Mvc;

namespace Api.Versioning.Controllers.V3
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("3.0")]
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
                        LyricsBy = "LyricsBy"
                    },
                    new
                    {
                        Id = 1,
                        Name = "Music1",
                        Author = "Author1",
                        LyricsBy = "LyricsBy"
                    }
                },
                Total = 2
            };

            return Ok(data);
        }
    }
}
