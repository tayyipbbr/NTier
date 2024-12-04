using FluentValidation;

// <>   {}

namespace NTier.Business.Features.Authentication.Register
{
    public sealed class RegisterValidation : AbstractValidator<RegisterCommand>
    {
        public RegisterValidation()
        {
            RuleFor(p => p.UserName).NotEmpty().WithMessage("Kullanıcı adı boş bırakılamaz.");
            RuleFor(p => p.UserName).NotNull().WithMessage("Kullanıcı adı boş bırakılamaz.");
            RuleFor(p => p.UserName).MinimumLength(5).WithMessage("Kullanıcı adı en az 5 karakterden oluşur.");
            RuleFor(p => p.UserName).MaximumLength(15).WithMessage("Kullanıcı adı en fazla 15 karakterden oluşur.");
            RuleFor(p => p.Name).NotEmpty().WithMessage("İsim alanı adı boş bırakılamaz.");
            RuleFor(p => p.Name).NotNull().WithMessage("İsim alanı adı boş bırakılamaz.");
            RuleFor(p => p.Name).MinimumLength(3).WithMessage("İsim en az 3 karakterden oluşur.");
            RuleFor(p => p.Lastname).NotEmpty().WithMessage("Soyisim alanı  boş bırakılamaz.");
            RuleFor(p => p.Lastname).NotNull().WithMessage("Soyisim alanı  boş bırakılamaz.");
            RuleFor(p => p.Lastname).MinimumLength(3).WithMessage("Soyisim en az 3 karakterden oluşur.");
            RuleFor(p => p.Email).NotEmpty().WithMessage("Email alanı  boş bırakılamaz.");
            RuleFor(p => p.Email).NotNull().WithMessage("Email alanı  boş bırakılamaz.");
            RuleFor(p => p.Email).MinimumLength(10).WithMessage("Email en az 10 karakterden oluşur.");
            RuleFor(p => p.Email).EmailAddress().WithMessage("Geçerli bir Email adresi giriniz.");      // standart Email uyumluluk kontrolü
            RuleFor(p => p.Password).NotEmpty().WithMessage("Şifre boş olamaz.");
            RuleFor(p => p.Password).NotNull().WithMessage("Şifre boş olamaz.");
            RuleFor(p => p.Password).MinimumLength(8).WithMessage("Şifre en az 8 karakter olmalıdır.");
            RuleFor(p => p.Password).Matches("[A-Z]").WithMessage("Şife en az 1 büyük harf içermelidir.");
            RuleFor(p => p.Password).Matches("[a-z]").WithMessage("Şife en az 1 küçük harf içermelidir.");
            RuleFor(p => p.Password).Matches("[0-9]").WithMessage("Şife en az 1 rakam içermelidir.");
            RuleFor(p => p.Password).Matches("[^a-zA-Z0-9]").WithMessage("Şife en az 1 özel karakter (*.,! vb.) içermelidir.");
        }

    }

}
