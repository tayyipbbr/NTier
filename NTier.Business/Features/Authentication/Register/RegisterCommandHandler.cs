using MediatR;
using Microsoft.AspNetCore.Identity;
using NTier.Business.Features.Authentication.Register;
using NTier.Entities.Models;

internal sealed class RegisterCommandHandler : IRequestHandler<RegisterCommand, Unit>
{
    private readonly UserManager<AppUser> _userManager; // varlık olarak eklemedim çünkü hazırı var.

    public RegisterCommandHandler(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Unit> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var checkUserNameExists = await _userManager.FindByNameAsync(request.UserName); // veya .User
        if(checkUserNameExists is not null)
        {
            throw new ArgumentException("Bu kullanıcı adı sistemde kayıtlı");
        }

        var checkEmailExists = await _userManager.FindByEmailAsync(request.Email);
        if(checkEmailExists is not null) 
        {
            throw new ArgumentException("Email sistemde kayıtlı");
        }

        // mail ve username daha önce kullanılmamış ise artık User oluşturabiliriz.

        AppUser appUser = new AppUser()
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Lastname = request.Lastname,
            Email = request.Email,
            UserName = request.UserName
        };

        var result = await _userManager.CreateAsync(appUser, request.Password); //manager hzır metotu createAsync
/*
        if (!result.Succeeded)
        {
            var errors = string.Join(", ", result.Errors.Select(e => e.Description));
            throw new Exception($"Kullanıcı oluşturma başarısız: {errors}");
        }
*/
        return Unit.Value;
    }
}
