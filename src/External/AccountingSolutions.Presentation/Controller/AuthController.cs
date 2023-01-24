using AccountingSolutions.Application.Features.AppFeatures.AppUserFeatures.Login;
using AccountingSolutions.Presentation.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AccountingSolutions.Presentation.Controller
{
    public class AuthController : ApiController
    {
        public AuthController(IMediator mediator) : base(mediator)
        {
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            LoginResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}