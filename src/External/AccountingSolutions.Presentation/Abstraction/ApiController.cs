using Microsoft.AspNetCore.Mvc;

namespace AccountingSolutions.Presentation.Abstraction
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class ApiController: ControllerBase
    {
    }
}