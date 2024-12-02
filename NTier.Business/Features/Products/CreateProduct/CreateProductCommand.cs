using MediatR;

// <>   {}

namespace NTier.Business.Features.Products.CreateProduct
{
    public sealed record CreateProductCommand(string Name) : IRequest;
    {
    }
}
