using MediatR;
using NTier.Entities.Models;


// <>   {}
namespace NTier.Business.Features.Categories.CreateCategory
{
    internal sealed class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Unit>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }


        public async Task<Unit> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var isCategoryNameExists = await _categoryRepository.AnyAsync(p => p.Name == request.Name, cancellationToken);

            if (isCategoryNameExists) 
            {
                throw new ArgumentException("Kategori zaten mevcut.");
            }

            Category category = new Category()
            {
                Name = request.Name
            };

            await _categoryRepository.AddAsync(category, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;                                                  // boş döner, dönme şartını yerine getirmiş oluruz.
        }
    }
}
