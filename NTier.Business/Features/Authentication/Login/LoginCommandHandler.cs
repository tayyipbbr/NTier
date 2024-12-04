using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NTier.Business.Features.Authentication.Login;
using NTier.Entities.Models;

internal sealed class LoginCommandHandler : IRequestHandler<LoginCommand, Unit>
{
    private readonly UserManager<AppUser> _userManager;

    public LoginCommandHandler(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Unit> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var appUser = await _userManager.Users.Where(p => p.UserName == request.UserNameOrEmail || p.Email == request.UserNameOrEmail).FirstOrDefaultAsync(cancellationToken);
            if (appUser is null) 
            {
                throw new ArgumentNullException($"Kullanıcı adı veya Email hatalı. UserNameOrEmail: {request.UserNameOrEmail}");
            }

            

        bool checkPassword = await _userManager.CheckPasswordAsync(appUser, request.Password);
            if (!checkPassword) 
            {
            throw new ArgumentException($"Şifre yanlış. UserNameOrEmail: {request.UserNameOrEmail}");
            }

        return Unit.Value;
    }
}