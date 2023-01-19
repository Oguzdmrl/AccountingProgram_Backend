using AccountingSolutions.Presentation.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace AccountingSolutions.Presentation.Controller
{
    public sealed class TestController : ApiController
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("test başarılı");
        }
    }
}