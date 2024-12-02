using MediatR;
using NTier.Business.Features.Categories.UpdateCategory;
using NTier.Entities.Models;

internal sealed class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;
    public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
    {
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
    }


    public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        Category category = await _categoryRepository.GetByIdAsync(p => p.Id == request.Id, cancellationToken)
            if (category is null) 
            {
                // throw new ArgumentNException(nameof(category)); VEYA
                throw new ArgumentException("Güncellemek istediğiniz kategori mevcut değil.");
            }
            if (category.Name != request.Name)
            {
                var isCategoryNameExists = await _categoRepository.AnyAsync(p => p.Name == request.Name);

                if (isCategoryNameExists)
                {
                    throw new ArgumentException("Kategori ismi uyumsuz."); // "" değiştirilebilir.
                }

                category.Name = request.Name;

                await _unitOfWork.SaveChangesAsync(cancellationToken); // Tracking olduğu için buradan direkt kayıt yapabiliriz.
                                                                       // Neden update metodu yazdık? tracking iptal edersek diye.
        }
    }
}