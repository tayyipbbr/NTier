using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

// <>   {}

namespace NTier.Business.Features.Categories.CreateCategory
{
    internal sealed class CreateCategoryValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Kategori adı boş bırakılamaz.");
            RuleFor(p => p.Name).NotNull().WithMessage("Kategori adı boş bırakılamaz.");
            RuleFor(p => p.Name).MinimumLength(2).WithMessage("Kategori adı en az 2 karakter içermeli.");
            RuleFor(p => p.Name).MaximumLength(20).WithMessage("Kategori adı 20 karakterden fazla olamaz.");
        }
    }
}
