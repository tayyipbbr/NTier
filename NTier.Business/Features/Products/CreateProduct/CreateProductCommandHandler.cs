using MediatR;
using NTier.Business.Features.Categories.CreateCategory;
using NTier.Business.Features.Products.CreateProduct;


// <>   {}
internal sealed class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Unit>
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;
    public CreateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

}
