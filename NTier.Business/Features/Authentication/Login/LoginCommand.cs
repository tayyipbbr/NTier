using MediatR;

// <>   {}

namespace NTier.Business.Features.Authentication.Login
{
    public sealed record LoginCommand(
    string UserNameOrEmail,
    string Password) : IRequest<Unit>;
}
