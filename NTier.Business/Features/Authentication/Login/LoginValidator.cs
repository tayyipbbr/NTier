using FluentValidation;

namespace NTier.Business.Features.Authentication.Login
{
    internal class LoginValidator : AbstractValidator<LoginCommand>
    {
        public LoginValidator()
        {
            RuleFor(p => p.UserNameOrEmail).NotEmpty().WithMessage("Kullanıcı adı boş bırakılamaz.");
            RuleFor(p => p.UserNameOrEmail).NotNull().WithMessage("Kullanıcı adı boş bırakılamaz.");
            RuleFor(p => p.Password).NotEmpty().WithMessage("Şifre boş olamaz.");
            RuleFor(p => p.Password).NotNull().WithMessage("Şifre boş olamaz.");
        }
    }
}