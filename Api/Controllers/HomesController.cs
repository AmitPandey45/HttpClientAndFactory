using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomesController : ControllerBase
    {
        [HttpGet("{id}")]
        public Home Index(string id)
        {
            //return new 
            //{
            //    Name = $"Home {id}",
            //    StartupHeader = Request.Headers["StartupHeader"],
            //    CtorHeader = Request.Headers["Middleware-Ctor"],
            //    MethodHeader = Request.Headers["Middleware-Method"]
            //};

            return new Home
            {
                Name = "Our Home!"
            };
        }
    }
}
