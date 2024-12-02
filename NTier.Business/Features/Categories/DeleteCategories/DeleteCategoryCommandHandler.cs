using MediatR;
using NTier.Business.Features.Categories.DeleteCategories;
using NTier.Entities.Models;

internal sealed class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;
    public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
    {
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        Category category = await _categoryRepository.GetByIdAsync(p => p.Id == request.Id);

        if (category == null)
        {
            throw new ArgumentException($"Kategori mevcut değil: {request.Id}");
        }
        else 
        {
            _categoryRepository.Remove(category);                   // neden await yok ?
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            throw new ArgumentException($"Kategori silme başarılı. (ID: {request.Id})");
        }

    }
}


