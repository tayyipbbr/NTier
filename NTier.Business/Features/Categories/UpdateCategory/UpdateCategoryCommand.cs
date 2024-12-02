using MediatR;

// <>   {}

namespace NTier.Business.Features.Categories.UpdateCategory
{
    public sealed record UpdateCategoryCommand(
    Guid Id, 
    string Name) : IRequest
}
