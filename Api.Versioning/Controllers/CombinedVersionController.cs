using Microsoft.AspNetCore.Mvc;

namespace Api.Versioning.Controllers
{
    [Route("api/[controller]")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0", Deprecated = true)]
    [ApiVersion("1.1", Deprecated = true)]
    [ApiVersion("2.0")]
    public class CombinedVersionController : ControllerBase
    {
        /// <summary>
        /// By default when we are not mapping any Http Method to a specific version then all the versions
        /// defined at the controller level applicable to the those Http Methods
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("version1")]
        public IActionResult GetResponseFromV1()
        {
            return Ok("Getting the response from API with version1.0");
        }

        [HttpGet]
        [Route("version1_1")]
        public IActionResult GetResponseFromV1_1()
        {
            return Ok("Getting the response from API with version1.1");
        }

        [HttpGet]
        [Route("version2")]
        public IActionResult GetResponseFromV2()
        {
            return Ok("Getting the response from API with version2");
        }

        [HttpGet]
        [Route("specificversion1")]
        [MapToApiVersion("1.0")]
        public IActionResult GetResponseFromSpecificV1()
        {
            return Ok("Getting the response from API with Specific version1.0");
        }

        [HttpGet]
        [Route("specificversion1_1")]
        [MapToApiVersion("1.1")]
        public IActionResult GetResponseFromSpecificV1_1()
        {
            return Ok("Getting the response from API with Specific version1.1");
        }

        [HttpGet]
        [Route("specificversion2")]
        [MapToApiVersion("2.0")]
        public IActionResult GetResponseFromSpecificV2()
        {
            return Ok("Getting the response from API with Specific version2");
        }
    }
}
