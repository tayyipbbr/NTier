using MediatR;
using Microsoft.AspNetCore.Mvc;
using NTier.Business.Features.Authentication.Login;
using NTier.Business.Features.Authentication.Register;
using NTier.WebApi.Abstracts;

// []  <>   {}

namespace NTier.WebApi.Controllers
{
    public class AuthenticationController : ApiController
    {
        public AuthenticationController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterCommand request, CancellationToken cancellationToken) 
        {
            await _mediator.Send(request, cancellationToken);

            return NoContent();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginCommand request, CancellationToken cancellationToken)
        {
          var response = await _mediator.Send(request, cancellationToken);

            return Ok(response);
        }
    }
}
