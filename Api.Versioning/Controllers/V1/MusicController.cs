using Microsoft.AspNetCore.Mvc;

namespace Api.Versioning.Controllers.V1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0", Deprecated = true)]
    public class MusicController : ControllerBase
    {
        [HttpGet]
        [MapToApiVersion("1.0")]
        public IActionResult Get()
        {
            return Ok(new string[] { "music1", "music2" });
        }
    }
}
