using MediatR;

// <>   {}

namespace NTier.Business.Features.Authentication.Register
{
    public sealed record RegisterCommand(
    string UserName,
    string Name,
    string Lastname,
    string Email,
    string Password) : IRequest<Unit>;
}
